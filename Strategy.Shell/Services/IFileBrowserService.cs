// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileBrowserService.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the IFileBrowserService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Services
{
    /// <summary>The FileBrowserService interface.</summary>
    public interface IFileBrowserService
    {
        /// <summary>The browse for file.</summary>
        /// <param name="fileFilter">The file filter.</param>
        /// <returns>The <see cref="string"/>.</returns>
        string BrowseForFile(string fileFilter);
    }
}