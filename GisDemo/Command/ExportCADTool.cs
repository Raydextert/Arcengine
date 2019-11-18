using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using System.IO;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.ConversionTools;
using ESRI.ArcGIS.Geoprocessing;
/*============================================================
 * 主要思路：1、图层要素转为SHP文件
 *           2、SHP文件转为CAD文件
 *           3、删除SHP文件
 * 
 *功能概述：图层转CAD
 * 
 * 作者：ZRC  日期：2019/11/17
 *============================================================ 
 */

namespace GisDemo.Command
{
    public class ExportCADTool
    {
       
        private IMapControlDefault mapcontrol = null;
        public  IMapControlDefault Mapcontrol { get { return mapcontrol; } set { mapcontrol = value; } }
       
        public void FclssToShp(IFeatureClass fteClss,string lsshp)
        {
            if (fteClss == null||string .IsNullOrEmpty (lsshp )) return;
            string filename = System.IO.Path.GetFileName(lsshp);
            string filepath = System.IO.Path.GetDirectoryName(lsshp);
            if (!System.IO.Directory.Exists(filepath))
            {
                System.IO.Directory.CreateDirectory(filepath);
            }
            //释放空间
            using (ComReleaser comreleaser = new ComReleaser())
            {
                IDataset indataset = fteClss as IDataset;
                IWorkspaceFactory pWorkfactory = new ShapefileWorkspaceFactoryClass();
                IFeatureWorkspace fteWsp = pWorkfactory.OpenFromFile(filepath, 0) as IFeatureWorkspace;
                IWorkspace inwsp = indataset.Workspace;

                IFeatureClassName inFCName = indataset.FullName as IFeatureClassName;
                //
                IWorkspace outWsp = fteWsp as IWorkspace;
                IDataset outdataset = outWsp as IDataset;
                IWorkspaceName outWspName = outdataset.FullName as IWorkspaceName;

                IFeatureClassName outFCName = new FeatureClassNameClass();
                IDatasetName outDstName = outFCName as IDatasetName;
                outDstName.WorkspaceName = outWspName;
                outDstName.Name = fteClss.AliasName.ToString();

                //检查字段的合法性
                IFieldChecker checker = new FieldCheckerClass();
                checker.InputWorkspace = inwsp;
                checker.ValidateWorkspace = outWsp;

                IFields fileds = fteClss.Fields;
                IFields outfields = null;
                IEnumFieldError error = null;
                checker.Validate(fileds, out error, out outfields);

                //转换为SHP
                IFeatureDataConverter convert = new FeatureDataConverterClass();
                convert.ConvertFeatureClass(inFCName, null, null, outFCName, null, outfields, "", 100, 0);
            }
        
        }

        public void ShpToCAD(IFeatureClass fteclss, string lsshp, string cadpath,string FormatType)
        {
          
            //先转为shp文件
            try
            {
                FclssToShp(fteclss, lsshp);
                //shp转为要素
                Geoprocessor gp = new Geoprocessor();
                gp.OverwriteOutput = true;
                ExportCAD export = new ExportCAD();
                export.in_features = lsshp;
                export.Output_Type = FormatType;
                export.Output_File = cadpath;
                export.Ignore_FileNames = "1";
                export.Append_To_Existing = "1";

                IGeoProcessorResult result = gp.Execute(export, null) as IGeoProcessorResult;
                //转换成功是否将CAD文件添加进图层
                if (result.Status == esriJobStatus.esriJobSucceeded)
                {
                    if (MessageBox.Show("转换成功，是否添加至图层", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        string filepath = System.IO.Path.GetDirectoryName(cadpath);
                        string filename = System.IO.Path.GetFileName(cadpath);

                        CadWorkspaceFactory cadwspFcy = new CadWorkspaceFactoryClass();
                        IFeatureWorkspace fteWsp = cadwspFcy.OpenFromFile(filepath, 0) as IFeatureWorkspace;
                        //转换为CAD工作空间
                        ICadDrawingWorkspace CadWsp = fteWsp as ICadDrawingWorkspace;
                        ICadDrawingDataset CadDataset = CadWsp.OpenCadDrawingDataset(filename);
                        ICadLayer cadLyr = new CadLayerClass();
                        cadLyr.CadDrawingDataset = CadDataset;
                        cadLyr.Name = filename;
                        this.Mapcontrol.AddLayer(cadLyr, 0);
                        this.Mapcontrol.Refresh();
                    }

                }
                shpDel(lsshp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("转换失败" + ex.Message);
            }
           
        
        }

        public void shpDel(string shppath)
        {
            if (string.IsNullOrEmpty(shppath)) return;
            if (!System.IO.File.Exists(shppath))
                return;
            using (ComReleaser comreleaser = new ComReleaser())
            {
                IWorkspaceFactory WspFac = new ShapefileWorkspaceFactoryClass ();
                IFeatureWorkspace fteWsp = WspFac.OpenFromFile(System.IO.Path.GetDirectoryName(shppath), 0) as IFeatureWorkspace;
                IFeatureClass fClss = fteWsp.OpenFeatureClass(System.IO.Path.GetFileName(shppath));
                IFeatureLayer fteLyr = new FeatureLayerClass();
                IDataset dataset = null;
                if (fClss == null) return;
                fteLyr.FeatureClass = fClss;
                fteLyr.Name = fteLyr.FeatureClass.AliasName;
                //定义数据集，保证处于编辑状态
                dataset = fteLyr.FeatureClass as IDataset;
                dataset.Delete();
            }
        
        }

    }
}
