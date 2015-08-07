// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISystemInformationService.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   The SystemInformationService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Services
{
    /// <summary>The SystemInformationService interface.</summary>
    public interface ISystemInformationService
    {
        /// <summary>Gets a value indicating whether is high contrast colour scheme.</summary>
        bool IsHighContrastColourScheme { get; }
    }
}