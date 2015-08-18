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
        /// <summary>The write object.</summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="o">The payload.</param>
        /// <typeparam name="T">The type</typeparam>
        /// <returns>The <see cref="bool"/>.</returns>
        bool SerializeObject<T>(string filepath, T o);

        /// <summary>Reads the file to de-serialize</summary>
        /// <typeparam name="T">The type to de-serialize</typeparam>
        /// <param name="filepath">The filepath.</param>
        /// <returns>The <see cref="T"/> The type to return</returns>
        T DeserializeObject<T>(string filepath);
    }
}