using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Toolkit.Win32.UI.XamlHost;
using Microsoft.Toolkit.Wpf.UI.XamlHost;

using FolderLinkCreator.UWPUI;

namespace FolderLinkCreator.Controls
{
    public class CalendarViewWrapper : WindowsXamlHostBase
    {
        public MasterEntryControl Control; 

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.ChildInternal = UWPTypeFactory.CreateXamlContentByType("FolderLinkCreator.UWPUI.MasterEntryControl");

            SetContent();
        }
    }
}
