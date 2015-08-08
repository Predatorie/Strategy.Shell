// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationsLibraryLoadEvent.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Events
{
    using System.Collections.Generic;

    /// <summary>The operations library load event.</summary>
    public class OperationsLibraryLoadEvent
    {
        /// <summary>Gets or sets the library.</summary>
        public List<string> Libraries { get; set; }
    }
}
