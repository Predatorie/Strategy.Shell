// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileBrowserService.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Services
{
    using System.Windows.Forms;

    /// <summary>The file browser service.</summary>
    public class FileBrowserService : IFileBrowserService
    {
        /// <summary>The BrowseForFile method</summary>
        /// <param name="parent">The parent form.</param>
        /// <param name="title">The title.</param>
        /// <param name="fileFilter">The file filter type</param>
        /// <param name="location">The Initial Directory</param>
        /// <returns>The selected file pth</returns>
        public string BrowseForFile(IWin32Window parent, string title, string fileFilter, string location)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Multiselect = false;
                dlg.Title = title;
                dlg.Filter = fileFilter;
                dlg.InitialDirectory = location;

                if (dlg.ShowDialog(parent) == DialogResult.OK)
                {
                    return dlg.FileName;
                }                   
            }

            return string.Empty;
        }
    }
}