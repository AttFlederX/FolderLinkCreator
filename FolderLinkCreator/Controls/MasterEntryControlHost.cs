using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Microsoft.Toolkit.Win32.UI.XamlHost;
using Microsoft.Toolkit.Wpf.UI.XamlHost;

using FolderLinkCreator.UWPUI;
using DependencyObject = System.Windows.DependencyObject;
using DependencyProperty = System.Windows.DependencyProperty;
using DependencyPropertyChangedEventArgs = System.Windows.DependencyPropertyChangedEventArgs;
using PropertyMetadata = System.Windows.PropertyMetadata;

namespace FolderLinkCreator.Controls
{
    public class MasterEntryControlHost : WindowsXamlHostBase
    { 
        public MasterEntryControl Control => this.ChildInternal as MasterEntryControl;

        public static readonly DependencyProperty TargetFolderPathProperty =
            DependencyProperty.Register(
                "TargetFolderPath", typeof(string),
                typeof(MasterEntryControlHost), new PropertyMetadata(string.Empty, TargetFolderPathPropertyChanged)
            );

        private static void TargetFolderPathPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MasterEntryControlHost host)
            {
                host.Control.TargetFolderTextBox.Text = e.NewValue.ToString();
            }
        }

        public static readonly DependencyProperty LinkLocationPathProperty =
            DependencyProperty.Register(
                "LinkLocationPath", typeof(string),
                typeof(MasterEntryControlHost), null
            );

        public string TargetFolderPath
        {
            get => (string)GetValue(TargetFolderPathProperty);
            set
            {
                SetValue(TargetFolderPathProperty, value);
            }
        }

        public string LinkLocationPath
        {
            get => (string)GetValue(LinkLocationPathProperty);
            set
            {
                SetValue(LinkLocationPathProperty, value);
            }
        }


        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.ChildInternal = UWPTypeFactory.CreateXamlContentByType("FolderLinkCreator.UWPUI.MasterEntryControl");

            Control.TextBoxTextChanged += ControlOnTextBoxTextChanged;

            SetContent();
        }

        private void ControlOnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            TargetFolderPath = Control.TargetFolderTextBox.Text;
            LinkLocationPath = Control.LinkLocationTextBox.Text;
        }
    }
}
