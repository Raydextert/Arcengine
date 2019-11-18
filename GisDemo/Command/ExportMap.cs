using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Output;
 /*============================================================
  * 
  *  本类功能概述：要素转图片
  * 
  * 
  * 
  * 
  *============================================================
  */
namespace GisDemo.Command
{
    public class ExportMap
    {

        //使用静态方法提高代码的复用性
        public static void ExportView(IActiveView ActiveView,int _resolution,IGeometry pGeo,int Width,int Height,string pathtxt,bool bRegion)
        {
            IExport pExort = null;
            tagRECT pRect = new tagRECT ();
            IEnvelope pEnvelope=pGeo .Envelope ;
            string outputType = System.IO.Path.GetExtension(pathtxt).ToLower ();
            switch (outputType)
            { 
                case ".jpg":
                    pExort = new ExportJPEGClass();
                    break;
                case ".bmp":
                    pExort = new ExportBMPClass();
                    break;
                case ".gif":
                    pExort = new ExportGIFClass();
                    break;
                case ".tif":
                    pExort = new ExportTIFFClass();
                    break;
                case ".png":
                    pExort = new ExportPNGClass();
                    break;
                case ".pdf":
                    pExort = new ExportPDFClass();
                    break;
                default :
                    MessageBox.Show("未设置输出格式,默认为jpg格式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pExort = new ExportJPEGClass();
                    break;
            }
            pExort.ExportFileName = pathtxt;
            pRect.left = 0; pRect.top = 0;
            pRect.right = Width; pRect.bottom = Height;
            //
            if (bRegion)
            {
                ActiveView.GraphicsContainer.DeleteAllElements();
                ActiveView.Refresh();
            
            }
            //获取输出影像范围的矩形大小
            IEnvelope envelope = new EnvelopeClass();
            envelope.PutCoords((double)pRect.left, (double)pRect.top, (double)pRect.right, (double)pRect.bottom);
            pExort.PixelBounds = envelope;
            ActiveView.Output(pExort.StartExporting(), _resolution, ref pRect, pEnvelope, null);
            pExort.FinishExporting();
            pExort.Cleanup();
        }

        public static IElement CreateElement(IGeometry pGeometry, IRgbColor linecolor, IRgbColor fillcolor)
        {
            if (pGeometry == null || linecolor == null || fillcolor == null)
            {
                return null;
            }
            IElement pEle = null;
            if (pGeometry == null) return null;
            //限制只能创建面要素
            pEle = new PolygonElementClass();
            pEle.Geometry = pGeometry;
            IFillShapeElement pFillEle = pEle as IFillShapeElement;
            ISimpleFillSymbol symbol = new SimpleFillSymbolClass();
            symbol.Color = fillcolor;
            symbol.Outline.Color = linecolor;
            symbol.Style = esriSimpleFillStyle.esriSFSBackwardDiagonal;
            if (symbol == null)
            {
                return null;
            }
            pFillEle.Symbol = symbol;
            return pEle;
        }

        public static IRgbColor Getcolor(int red, int blue, int green)
        {
            IRgbColor color =new RgbColorClass ();
            if (red > 255) red = 255;
            if (red < 0) red = 0;
            if (blue > 255) red = 255;
            if (blue < 0) red = 0;
            if (green > 255) red = 255;
            if (green < 0) red = 0;
            color.Red = red;
            color.Blue = blue;
            color.Green = green;
            return color;
        }

        public static void AddElement(IGeometry pGeo,IActiveView m_ActiveView)
        {
            if (pGeo == null || m_ActiveView == null) return;
            //非静态方法要求对象引用
            IRgbColor fillColor = Getcolor(255, 0, 0);
            IRgbColor lineColor = Getcolor(255, 255, 255);
            IElement pElement = CreateElement(pGeo, lineColor, fillColor);
            m_ActiveView.GraphicsContainer.AddElement(pElement, 0);
            m_ActiveView.Refresh(); 
        }
    }
}
