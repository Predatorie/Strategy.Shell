// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileBrowserService.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Services
{
    using System.Windows.Forms;

    using Localization;

    using Mastercam.IO;

    /// <summary>The file browser service.</summary>
    public class FileBrowserService : IFileBrowserService
    {
        /// <summary>The browse for file.</summary>
        /// <param name="fileFilter">The file filter.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string BrowseForFile(string fileFilter)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.InitialDirectory = SettingsManager.SharedDirectory;
                dlg.Multiselect = false;
                dlg.Title = LocalizationStrings.Title;

                dlg.Filter = fileFilter;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    return dlg.FileName;
                }                   
            }

            return string.Empty;
        }
    }
}