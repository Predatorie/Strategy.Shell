// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationsLibraryLoadMessage.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Events
{
    using System;
    using System.Collections.Generic;

    /// <summary>The operations library load event.</summary>
    public class OperationsLibraryLoadMessage : EventArgs
    {
        /// <summary>Gets or sets the library.</summary>
        public List<string> Libraries { get; set; }
    }
}
