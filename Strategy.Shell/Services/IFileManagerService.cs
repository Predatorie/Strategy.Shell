// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileManagerService.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Services
{
    /// <summary>The FileManagerService interface.</summary>
    public interface IFileManagerService
    {
        /// <summary>The save.</summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="o">The o.</param>
        void WriteObject(string filepath, object o);

        /// <summary>Reads the file to de-serialize</summary>
        /// <typeparam name="T">The type to de-serialize</typeparam>
        /// <param name="filepath">The filepath.</param>
        /// <returns>The <see cref="T"/> The type to return</returns>
        T ReadObject<T>(string filepath);
    }
}