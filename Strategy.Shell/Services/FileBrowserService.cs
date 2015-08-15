// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileBrowserService.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using Localization;

    /// <summary>The file browser service.</summary>
    public class FileBrowserService : IFileBrowserService
    {
        /// <summary>The BrowseForFile method</summary>
        /// <param name="parent">The parent form.</param>
        /// <param name="title">The title.</param>
        /// <param name="fileFilter">The file filter type</param>
        /// <param name="location">The Initial Directory</param>
        /// <param name="multi">The multi.</param>
        /// <returns>The selected file pth</returns>
        public List<string> BrowseForFile(IWin32Window parent, string title, string fileFilter, string location, bool multi)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Multiselect = multi;
                dlg.Title = title;
                dlg.Filter = fileFilter;
                dlg.InitialDirectory = location;

                if (dlg.ShowDialog(parent) == DialogResult.OK)
                {
                    return dlg.FileNames.ToList();
                }
            }

            return new List<string>();
        }

        /// <summary>The browse for folder.</summary>
        /// <param name="title">The title.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string BrowseForFolder(string title)
        {
            using (var browse = new FolderBrowserDialog())
            {
                browse.Description = LocalizationStrings.SelectFolder;
                browse.ShowNewFolderButton = true;
                if (browse.ShowDialog() != DialogResult.OK)
                {
                    return string.Empty;
                }

                if (Directory.Exists(browse.SelectedPath))
                {
                    return browse.SelectedPath;
                }
            }

            return string.Empty;
        }

        /// <summary>The save file.</summary>
        /// <param name="parent">The parent.</param>
        /// <param name="title">The title.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="initialDirectory">The initial directory.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string SaveFile(IWin32Window parent, string title, string filter, string initialDirectory)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Title = title;
                dlg.Filter = filter;
                dlg.InitialDirectory = initialDirectory;

                if (dlg.ShowDialog(parent) == DialogResult.OK)
                {
                    return dlg.FileName;
                }
            }

            return string.Empty;
        }
    }
}