// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Strategy.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>The strategy.</summary>
    [DataContract(Name = "Strategy", Namespace = "")]
    public class Strategy 
    {
        /// <summary>Gets or sets the name of this strategy.</summary>
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        /// <summary>Gets or sets the list of mapped levels + operations.</summary>
        [DataMember(Name = "Maps")]
        public List<Mapping> MappedLevels { get; set; }
    }
}