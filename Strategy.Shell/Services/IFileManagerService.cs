// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileManagerService.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the IFileManagerService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Services
{
    using Models;

    /// <summary>The FileManagerService interface.</summary>
    public interface IFileManagerService
    {
        /// <summary>The save.</summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="strategy">The strategy.</param>
        void SaveStrategy(string filepath, IStrategy strategy);

        /// <summary>The load.</summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="strategy">The strategy.</param>
        void LoadStrategy(string filepath, IStrategy strategy);
    }
}