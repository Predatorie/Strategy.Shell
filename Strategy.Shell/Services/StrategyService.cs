// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StrategyService.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Services
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;

    using Models;

    /// <summary>The strategy service.</summary>
    public class StrategyService : IStrategyService
    {
        /// <summary>The serialize.</summary>
        /// <param name="strategy">The strategy.</param>
        public void Serialize(Strategy strategy)
        {
            // TODO: Tokenize paths

            // Avoiding mutliple using's here, see-> CA2202: Do not dispose objects multiple times
            XmlWriter xmlWriter = null;
            try
            {
                xmlWriter = XmlWriter.Create(strategy.Name, new XmlWriterSettings { Encoding = Encoding.UTF8, CloseOutput = false, Indent = true });
                using (var dictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(xmlWriter))
                {
                    var serializer = new DataContractSerializer(typeof(Strategy));
                    serializer.WriteObject(dictionaryWriter, strategy);
                }
            }
            finally
            {
                xmlWriter?.Dispose();
            }
        }

        /// <summary>The deserialize.</summary>
        /// <param name="filepath">The filepath.</param>
        /// <returns>The <see cref="Strategy"/>.</returns>
        public Strategy Deserialize(string filepath)
        {
            Stream stream = null;
            try
            {
                stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
                using (var xmlReader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas()))
                {
                    var serializer = new DataContractSerializer(typeof(Strategy));
                    return serializer.ReadObject(xmlReader) as Strategy;
                }
            }
            finally
            {
                stream?.Dispose();
            }
        }
    }
}