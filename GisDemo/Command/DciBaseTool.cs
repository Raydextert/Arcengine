using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

using System.Windows.Forms;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using GISLibrarys.Utility;

namespace Plugin.UIContent.ExtensionsTool
{
    public class DciBaseTool:BaseTool
    {

        private ICommand _baseCommand = null;
        private string _customBitmapFile;
        private string _customCaption;
        private string _customCategory;
        private string _customCursorFile;
        private string _customMessage;
        private string _customTooltip;
        private IntPtr _gdiBitmap;
        private int _lastClickButton = 0;
        private string _referCommandString = null;
        private IArcEngineToolbarButton _toolButton = null;
        private bool _useCustomBitmap = false;
        private bool _useCustomCaption = false;
        private bool _useCustomCategory = false;
        private bool _useCustomCursor = false;
        private bool _useCustomMessage = false;
        private bool _useCustomTooltip = false;
        protected IHookHelper m_HookHelper = null;
        protected int m_shift = 0;


        private static void ArcGISCategoryRegistration(Type registerType)
        {
            ControlsCommands.Register(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            ControlsCommands.Unregister(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private static object COMCreateObject(string sProgID)
        {
            Type typeFromProgID = Type.GetTypeFromProgID(sProgID);
            if (typeFromProgID != null)
            {
                return Activator.CreateInstance(typeFromProgID);
            }
            return null;
        }
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        ~DciBaseTool()
        {
            this.m_HookHelper = null;
            if (base.m_bitmap != null)
            {
                DeleteObject(this._gdiBitmap);
                base.m_bitmap.Dispose();
                base.m_bitmap = null;
            }
            if (base.m_cursor != null)
            {
                base.m_cursor.Dispose();
                base.m_cursor = null;
            }
        }
        public override bool Deactivate()
        {
            if (this._baseCommand != null)
            {
                return (this._baseCommand as ITool).Deactivate();
            }
            return base.Deactivate();
        }

        public override void OnClick()
        {
            if (this._baseCommand != null)
            {
                this._baseCommand.OnClick();
            }
            else
            {
                base.OnClick();
            }
            IntPtr handle = new IntPtr(this.m_HookHelper.ActiveView.ScreenDisplay.hWnd);
            Control.FromHandle(handle).Focus();
        }

        public override bool OnContextMenu(int X, int Y)
        {
            if (this._baseCommand != null)
            {
                return (this._baseCommand as ITool).OnContextMenu(X, Y);
            }
            return base.OnContextMenu(X, Y);
        }

        public override void OnCreate(object hook) 
        {
            try
            {
                if (this._referCommandString != null)
                {
                    this._baseCommand = COMCreateObject(this._referCommandString) as ICommand;
                    this._baseCommand.OnCreate(hook);
                }
                this.m_HookHelper = new HookHelper();
                this.m_HookHelper.Hook=hook;
            }
            catch
            {
            }
        }

        public override void OnDblClick()
        {
            if (this._baseCommand != null)
            {
                (this._baseCommand as ITool).OnDblClick();
            }
            else
            {
                base.OnDblClick();
            }
        }
        public override void OnKeyDown(int keyCode, int Shift)
        {
            if (this._baseCommand != null)
            {
                (this._baseCommand as ITool).OnKeyDown(keyCode, Shift);
            }
            else
            {
                base.OnKeyDown(keyCode, Shift);
            }
            if (this.m_shift != Shift)
            {
                this.m_shift = Shift;
                int num = this.Cursor;
            }
        }

        public override void OnKeyUp(int keyCode, int Shift)
        {
            if (this._baseCommand != null)
            {
                (this._baseCommand as ITool).OnKeyUp(keyCode, Shift);
            }
            else
            {
                base.OnKeyUp(keyCode, Shift);
            }
            if (this.m_shift != 0)
            {
                this.m_shift = 0;
                int num = this.Cursor;
            }
        }


        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            this._lastClickButton = Button;
            if (this._baseCommand != null)
            {
                (this._baseCommand as ITool).OnMouseDown(Button, Shift, X, Y);
            }
            else
            {
                base.OnMouseDown(Button, Shift, X, Y);
            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            if (this._baseCommand != null)
            {
                (this._baseCommand as ITool).OnMouseMove(Button, Shift, X, Y);
            }
            else
            {
                base.OnMouseMove(Button, Shift, X, Y);
            }
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            if (this._baseCommand != null)
            {
                (this._baseCommand as ITool).OnMouseUp(Button, Shift, X, Y);
            }
            else
            {
                base.OnMouseUp(Button, Shift, X, Y);
            }
        }

        public override void Refresh(int hDC)
        {
            if (this._baseCommand != null)
            {
                (this._baseCommand as ITool).Refresh(hDC);
            }
            else
            {
                base.Refresh(hDC);
            }
        }



        private void RefreshButtonUI()
        {
            if (this._toolButton != null)
            {
                System.Drawing.Bitmap bitmap = Image.FromHbitmap(new IntPtr(this.Bitmap));
                bitmap.MakeTransparent();
                this._toolButton.Image = bitmap;
                this._toolButton.ToolTipText = this.Tooltip;
                this._toolButton.Text = this.Caption;
            }
        }
        private void RefreshCursor()
        {
            if (((this.m_HookHelper != null) && (this.m_HookHelper.ActiveView != null)) && (this.m_HookHelper.ActiveView.ScreenDisplay != null))
            {
                IntPtr handle = new IntPtr(this.m_HookHelper.ActiveView.ScreenDisplay.hWnd);
                Control.FromHandle(handle).Cursor = new System.Windows.Forms.Cursor(new IntPtr(this.Cursor));
            }
        }

        [ComVisible(false), ComRegisterFunction]
        private static void RegisterFunction(Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }
        //public IArcEngineToolbarButton BindingButton
        //{
        //    set
        //    {
        //        this._toolButton = value;
        //    }
        //}
        public override int Bitmap
        {
            get
            {
                if (this._useCustomBitmap)
                {
                    if (base.m_bitmap == null)
                    {
                        string pathFromFullFilePath = FileOrDirEnhancedTools.GetPathFromFullFilePath(Assembly.GetExecutingAssembly().Location);
                        base.m_bitmap = Image.FromFile(Path.Combine(pathFromFullFilePath, this._customBitmapFile)) as System.Drawing.Bitmap;
                        base.m_bitmap.MakeTransparent(Color.Magenta);
                        this._gdiBitmap = base.m_bitmap.GetHbitmap();
                    }return this._gdiBitmap.ToInt32();
                }
                return base.Bitmap;
            }
        }
        public override string Caption
        {get
            {
                if (this._useCustomCaption)
                {
                    return this._customCaption;
                }
                if (this._baseCommand != null)
                {
                    return this._baseCommand.Caption;
                }
                return base.Caption;
            }
        }

        public override string Category
        {
            get
            {
                if (this._useCustomCategory)
                {
                    return this._customCategory;
                }
                if (this._baseCommand != null)
                {
                    return this._baseCommand.Category;
                }
                return base.Category;
            }
        }
        public override bool Checked
        {
            get
            {
                if (this._baseCommand != null)
                {
                    return this._baseCommand.Checked;
                }
                return base.Checked;
            }
        }
        public override int Cursor
        {
            get
            {
                if (this._useCustomCursor)
                {
                    if (base.m_cursor == null)
                    {
                        string pathFromFullFilePath = FileOrDirEnhancedTools.GetPathFromFullFilePath(Assembly.GetExecutingAssembly().Location);
                        base.m_cursor = new System.Windows.Forms.Cursor(Path.Combine(pathFromFullFilePath, this._customCursorFile));
                    }
                    return base.m_cursor.Handle.ToInt32();
                }
                if (this._baseCommand != null)
                {
                    return (this._baseCommand as ITool).Cursor;
                }
                return base.Cursor;
            }
        }

        public string CustomBitmapFile
        {
            get
            {
                return this._customBitmapFile;
            }
            set
            {
                if (this._customBitmapFile != value)
                {
                    this._customBitmapFile = value;
                    this._useCustomBitmap = true;
                    if (base.m_bitmap != null)
                    {
                        base.m_bitmap.Dispose();
                        base.m_bitmap = null;
                    }
                    this.RefreshButtonUI();
                }
            }
        }

        public string CustomCaption
        {
            get
            {
                return this._customCaption;
            }
            set
            {
                if (this._customCaption != value)
                {
                    this._customCaption = value;
                    this._useCustomCaption = true;
                    this.RefreshButtonUI();
                }
            }
        }

        public string CustomCategory
        {
            get
            {
                return this._customCategory;
            }
            set
            {
                if (this._customCategory != value)
                {
                    this._customCategory = value;
                    this._useCustomCategory = true;
                }
            }
        }

        public string CustomCursorFile
        {
            get
            {
                return this._customCursorFile;
            }
            set
            {
                if (this._customCursorFile != value)
                {
                    this._customCursorFile = value;
                    this._useCustomCursor = true;
                    if (base.m_cursor != null)
                    {
                        base.m_cursor.Dispose();
                        base.m_cursor = null;
                    }
                    this.RefreshCursor();
                }
            }
        }
        public string CustomMessage
        {
            get
            {
                return this._customMessage;
            }
            set
            {
                if (this._customMessage != value)
                {
                    this._customMessage = value;
                    this._useCustomMessage = true;
                }
            }
        }
        public string CustomTooltip
        {
            get
            {
                return this._customTooltip;
            }
            set
            {
                if (this._customTooltip != value)
                {
                    this._customTooltip = value;
                    this._useCustomTooltip = true;
                    this.RefreshButtonUI();
                }
            }
        }
        public override bool Enabled
        {
            get
            {
                if (this._baseCommand != null)
                {
                    return this._baseCommand.Enabled;
                }
                return base.Enabled;
            }
        }


        public override int HelpContextID
        {
            get
            {
                if (this._baseCommand != null)
                {
                    return this._baseCommand.HelpContextID;
                }
                return base.HelpContextID;
            }
        }


        public override string HelpFile
        {
            get
            {
                if (this._baseCommand != null)
                {
                    return this._baseCommand.HelpFile;
                }
                return base.HelpFile;
            }
        }

        public virtual bool IgnoreMapContextMenu
        {
            get
            {
                return false;
            }
        }
        public int LastClickButton
        {
            get
            {
                return this._lastClickButton;
            }
        }
        public override string Message
        {
            get
            {
                if (this._useCustomMessage)
                {
                    return this._customMessage;
                }
                if (this._baseCommand != null)
                {
                    return this._baseCommand.Message;
                }
                return base.Message;
            }
        }

        public override string Name
        {
            get
            {
                if (this._baseCommand != null)
                {
                    return this._baseCommand.Name;
                }
                return base.Name;
            }
        }public string ReferCommandString
        {
            get
            {
                return this._referCommandString;
            }
            set
            {
                if (this._referCommandString != value)
                {
                    this._referCommandString = value;
                }
            }
        }

        public override string Tooltip
        {
            get
            {
                if (this._useCustomTooltip)
                {
                    return this._customTooltip;
                }
                if (this._baseCommand != null)
                {
                    return this._baseCommand.Tooltip;
                }
                return base.Tooltip;
            }
        }
    }
}
