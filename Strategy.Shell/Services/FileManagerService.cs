// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileManagerService.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the FileManagerService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Services
{
    using Models;

    /// <summary>The file manager service.</summary>
    public class FileManagerService : IFileManagerService
    {
        /// <summary>The save strategy.</summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="strategy">The strategy.</param>
        public void SaveStrategy(string filepath, IStrategy strategy)
        {
        }

        /// <summary>The load strategy.</summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="strategy">The strategy.</param>
        public void LoadStrategy(string filepath, IStrategy strategy)
        {
        }
    }
}