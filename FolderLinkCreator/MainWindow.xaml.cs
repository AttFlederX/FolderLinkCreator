using FolderLinkCreator.UWPUI;
using FolderLinkCreator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.UI.Xaml.Controls.Primitives;

namespace FolderLinkCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel => DataContext as MainViewModel;

        public MainWindow()
        {
            DataContext = new MainViewModel();

            InitializeComponent();
        }

        private void MasterEntryControl_ChildChanged(object sender, EventArgs e)
        {
            if (MasterEntryControl.Child is MasterEntryControl msentryctrl)
            {
                //msentryctrl.TargetFolderTextbox.SetBinding(Windows.UI.Xaml.Controls.TextBox.TextProperty,
                //    new Windows.UI.Xaml.Data.Binding()
                //    {
                //        Source = ViewModel,
                //        Path = new Windows.UI.Xaml.PropertyPath("TargetFolderPath"),
                //        Mode = Windows.UI.Xaml.Data.BindingMode.TwoWay,
                //        UpdateSourceTrigger = Windows.UI.Xaml.Data.UpdateSourceTrigger.PropertyChanged
                //    }
                //);

                //msentryctrl.LinkLocationTextbox.SetBinding(Windows.UI.Xaml.Controls.TextBox.TextProperty,
                //    new Windows.UI.Xaml.Data.Binding()
                //    {
                //        Source = ViewModel,
                //        Path = new Windows.UI.Xaml.PropertyPath("LinkLocationPath"),
                //        Mode = Windows.UI.Xaml.Data.BindingMode.TwoWay,
                //        UpdateSourceTrigger = Windows.UI.Xaml.Data.UpdateSourceTrigger.PropertyChanged,
                //    }
                //);

                //msentryctrl.TargetFolderBrowseButton.SetBinding(ButtonBase.CommandProperty,
                //    new Windows.UI.Xaml.Data.Binding()
                //    {
                //        Source = ViewModel.BrowseTargetFolderCommand
                //    }
                //);

                //msentryctrl.LinkLocationBrowseButton.SetBinding(ButtonBase.CommandProperty,
                //    new Windows.UI.Xaml.Data.Binding()
                //    {
                //        Source = ViewModel.BrowseLinkLocationPathCommand
                //    }
                //);

                //msentryctrl.CreateLinkButton.SetBinding(ButtonBase.CommandProperty,
                //    new Windows.UI.Xaml.Data.Binding()
                //    {
                //        Source = ViewModel.CreateLinkCommand
                //    }
                //);
            }
        }
    }
}
