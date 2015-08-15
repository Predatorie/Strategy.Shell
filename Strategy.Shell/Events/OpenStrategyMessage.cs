// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenStrategyMessage.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the OpenStrategyMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Events
{
    using System;

    /// <summary>The open strategy message.</summary>
    public class OpenStrategyMessage : EventArgs
    {
        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; }
    }
}