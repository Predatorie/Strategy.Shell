// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ilevels.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the Ilevels type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Models
{
    using System.Collections.Generic;

    /// <summary>The levels interface.</summary>
    public interface ILevels
    {
        /// <summary>Gets or sets the levels.</summary>
        List<string> List { get; set; }

        /// <summary>Gets or sets the name.</summary>
        string Name { get; set; }
    }
}