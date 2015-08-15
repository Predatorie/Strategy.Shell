// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenLevelsMessage.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the OpenLevelsMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Events
{
    using System;

    /// <summary>The open levels message.</summary>
    public class OpenLevelsMessage : EventArgs
    {
        /// <summary>Gets or sets the file path.</summary>
       public string FilePath { get; set; }
    }
}