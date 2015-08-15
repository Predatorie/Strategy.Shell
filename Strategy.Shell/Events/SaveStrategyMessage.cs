// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveStrategyMessage.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the SaveStrategyMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Events
{
    using System;

    /// <summary>The save strategy message.</summary>
    public class SaveStrategyMessage : EventArgs
    {
        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; }
    }
}