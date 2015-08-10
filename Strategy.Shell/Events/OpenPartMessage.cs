// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenPartMessage.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the OpenPartEvent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Events
{
    using System;
    using System.Collections.Generic;

    /// <summary>The open part event.</summary>
    public class OpenPartMessage : EventArgs
    {
        /// <summary>Gets or sets the file.</summary>
        public List<string> FilePath { get; set; }
    }
}