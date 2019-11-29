using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.NetworkAnalysis;
using System.Collections.Generic;
using ESRI.ArcGIS.Geodatabase;
/*================================================
 * 
 *   
 * 
 * 本类实现功能概述；提供程序所需静态方法，提高代码的复用性
 * 
 * 
 * 作者：ZRC   时间：2019/11/28
 *================================================
 */
namespace GisDemo
{
    public class Method
    {
     
        public static IRgbColor Getcolor(int red, int blue, int green)
        {
            IRgbColor color = new RgbColorClass();
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
    }
}
