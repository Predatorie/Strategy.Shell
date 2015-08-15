// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Strategy.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>The strategy.</summary>
    [XmlRoot("STRATEGY")]
    public class Strategy 
    {
        /// <summary>Initializes a new instance of the <see cref="Strategy"/> class.</summary>
        public Strategy()
        {
            this.MappedLevels = new List<MappedLevel>();
        }

        /// <summary>Gets or sets the version.</summary>
        [XmlElement]
        public string Version => "2014";

        /// <summary>Gets or sets the name.</summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>Gets or sets the mapped levels.</summary>
        [XmlArrayItem("MAPS")]
        public List<MappedLevel> MappedLevels { get; set; }
    }
}