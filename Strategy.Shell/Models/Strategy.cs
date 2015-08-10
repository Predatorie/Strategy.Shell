// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Strategy.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>The strategy.</summary>
    [Serializable]
    public class Strategy : IStrategy
    {
        /// <summary>Gets or sets the version.</summary>
        [XmlElement]
        public string Version { get; set; }

        /// <summary>Gets or sets the name.</summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>Gets or sets the levels.</summary>
        [XmlArray("LEVELS")]
        [XmlArrayItem("LEVEL")]
        public List<string> Levels { get; set; }

        /// <summary>Gets or sets the operations.</summary>
        [XmlArray("OPERATIONS")]
        [XmlArrayItem("OPERATION")]
        public List<string> Operations { get; set; }
    }
}