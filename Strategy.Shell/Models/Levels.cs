// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Levels.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the Levels type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>The levels.</summary>
    [Serializable]
    public class Levels : ILevels
    {
        /// <summary>Initializes a new instance of the <see cref="Levels"/> class.</summary>
        public Levels()
        {
            this.List = new List<string>();
        }

        /// <summary>Gets or sets the list.</summary>
        [XmlArray("LIST")]
        [XmlArrayItem("LEVEL-NAME")]
        public List<string> List { get; set; }

        /// <summary>Gets or sets the name.</summary>
        [XmlElement("FILENAME")]
        public string Name { get; set; }
    }
}