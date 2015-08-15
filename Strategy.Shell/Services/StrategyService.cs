// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StrategyService.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Services
{
    using System.IO;
    using System.Xml.Serialization;

    using Models;

    /// <summary>The strategy service.</summary>
    public class StrategyService : IStrategyService
    {
        /// <summary>The serialize.</summary>
        /// <param name="strategy">The strategy.</param>
        public void Serialize(Strategy strategy)
        {
            // TODO: Tokenize paths

            // Create a new XmlSerializer instance with the type of the test class
            var serializer = new XmlSerializer(typeof(Strategy));

            // Create a new file stream to write the serialized object to a file
            using (TextWriter writer = new StreamWriter(strategy.Name))
            {
                serializer.Serialize(writer, typeof(Strategy));
            }
        }

        /// <summary>The deserialize.</summary>
        /// <param name="filepath">The filepath.</param>
        /// <returns>The <see cref="Strategy"/>.</returns>
        public Strategy Deserialize(string filepath)
        {
            //// TODO: Tokenize paths
            var serializer = new XmlSerializer(typeof(Strategy));
            using (var reader = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return (Strategy)serializer.Deserialize(reader);
            }
        }
    }
}