// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStrategy.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the IStrategy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Models
{
    using System.Collections.Generic;

    /// <summary>The Strategy interface.</summary>
    public interface IStrategy
    {
        /// <summary>Gets or sets the version.</summary>
        string Version { get; set; }

        /// <summary>Gets or sets the name.</summary>
        string Name { get; set; }

        /// <summary>Gets or sets the levels.</summary>
        List<string> Levels { get; set; }

        /// <summary>Gets or sets the operations.</summary>
        List<string> Operations { get; set; }
    }
}