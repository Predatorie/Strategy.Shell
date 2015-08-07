// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemInformationService.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the SystemInformationService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Services
{
    using System.Windows.Forms;

    /// <summary>The system information service.</summary>
    public class SystemInformationService : ISystemInformationService
    {
        public bool IsHighContrastColourScheme => SystemInformation.HighContrast;
    }
}