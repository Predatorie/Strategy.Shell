// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MappedLevel.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>The mapped levels.</summary>
    public class MappedLevel
    {
        /// <summary>Initializes a new instance of the <see cref="MappedLevel"/> class.</summary>
        public MappedLevel()
        {
            this.Operations = new List<string>();
        }

        /// <summary>Gets or sets the name.</summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>Gets or sets the operations.</summary>
        [XmlArrayItem("OPERATIONS")]
        public List<string> Operations { get; set; }
    }
}
