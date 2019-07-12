using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

using FolderLinkCreator.MVVM;
using FolderLinkCreator.ViewModels.Common;
using MessageBox = System.Windows.MessageBox;

namespace FolderLinkCreator.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Private fields

        private bool _hasError;

        private string _targetFolderPath;
        private string _linkLocationPath;

        #endregion

        #region Bindable properties

        public string TargetFolderPath
        {
            get => _targetFolderPath;
            set => SetProperty(ref _targetFolderPath, value);
        }

        public string LinkLocationPath
        {
            get => _linkLocationPath;
            set => SetProperty(ref _linkLocationPath, value);
        }

        #endregion

        #region Commands

        public ICommand BrowseTargetFolderCommand => new RelayCommand(param =>
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    TargetFolderPath = dialog.SelectedPath;
                }
            }
        });

        public ICommand BrowseLinkLocationPathCommand => new RelayCommand(param =>
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    LinkLocationPath = dialog.SelectedPath;
                }
            }
        });

        public ICommand CreateLinkCommand => new RelayCommand(param =>
        {
            var linkLocationFullPath = Path.Combine(LinkLocationPath, Path.GetDirectoryName(TargetFolderPath));
            _hasError = false;

            try
            {
                var cmdproc = new Process(); // create new process

                // set to launch the cmd prompt & run the mklink command that creates the needed folder link
                var startInfo = new ProcessStartInfo 
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = $"/C mklink /j \"{linkLocationFullPath}\" \"{TargetFolderPath}\"",
                    RedirectStandardOutput = true,
                    // make the app aware of process execution errors
                    RedirectStandardError = true 
                };

                cmdproc.StartInfo = startInfo;
                cmdproc.ErrorDataReceived += LinkCreationFailed;

                cmdproc.Start();

                cmdproc.WaitForExit();

                if (!_hasError)
                {
                    MessageBox.Show("Link created successfully", "Success",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create a directory link\n\n{ex.ToString()}\n{ex.Message}", "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        });

        private void LinkCreationFailed(object sender, DataReceivedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data))
            {
                _hasError = true;

                MessageBox.Show($"Failed to create a directory link\n{e.Data}", "Error", 
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        #endregion

        public MainViewModel()
        {
            TargetFolderPath = string.Empty;
            LinkLocationPath = string.Empty;
        }

    }
}
