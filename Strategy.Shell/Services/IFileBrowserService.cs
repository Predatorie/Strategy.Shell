// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileBrowserService.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Services
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Interfaces;

    /// <summary>The FileBrowserService interface.</summary>
    public interface IFileBrowserService
    {
        /// <summary>The browse for file.</summary>
        /// <param name="parent">The calling form</param>
        /// <param name="title">The title.</param>
        /// <param name="fileFilter">The file filter.</param>
        /// <param name="location">The initial location</param>
        /// <returns>The <see cref="string"/> file path.</returns>
        List<string> BrowseForFile(IWin32Window parent, string title, string fileFilter, string location);
    }
}