// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mapping.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Models
{
    using System.Runtime.Serialization;

    /// <summary>The mapped levels.</summary>
    [DataContract(Name = "Mapping", Namespace = "")]
    public class Mapping
    {
        /// <summary>Gets or sets the map. Level Name, Operation Library</summary>
        [DataMember(Name = "Level")]
        public string Level { get; set; }

        /// <summary>Gets or sets the comment.</summary>
        [DataMember(Name = "Comment")]
        public string Comment { get; set; }

        /// <summary>Gets or sets the library.</summary>
        [DataMember(Name = "Library")]
        public string Library { get; set; }
    }
}
