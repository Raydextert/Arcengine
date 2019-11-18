using System;
using System.Drawing;

namespace Plugin.UIContent.ExtensionsTool
{
    public enum ArcEngineToolbarButtonCommandStyle
    {
        Text,
        Image,
        TextAndImage
    }

    public enum ArcEngineToolbarButtonCommandType
    {
        StandardButton,
        ComboBoxCommand,
        Separator
    }

    public  interface IArcEngineToolbarButton
   {
      
       void AddStringToComboBox(string itemString);

       bool Checked { get; set; }

       string CommandClassString { get; set; }

       ArcEngineToolbarButtonCommandStyle CommandStyle { get; set; }

       ArcEngineToolbarButtonCommandType CommandType { get; set; }

       bool Enabled { get; set; }

       System.Drawing.Image Image { get; set; }

       string Name { get; set; }

       string Shortcut { get; set; }

       string Text { get; set; }

       string ToolTipText { get; set; }

 
   }
}
