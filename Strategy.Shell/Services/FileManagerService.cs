// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileManagerService.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Services
{
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>The file manager service.</summary>
    public class FileManagerService : IFileManagerService
    {
        /// <summary>The save strategy.</summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="o">The payload to serialize</param>
        public void WriteObject(string filepath, object o)
        {
            // Avoiding mutliple using's here, see-> CA2202: Do not dispose objects multiple times
            XmlWriter xmlWriter = null;
            try
            {
                using (xmlWriter = XmlWriter.Create(filepath, new XmlWriterSettings { Encoding = Encoding.UTF8, CloseOutput = false, Indent = true }))
                {
                    var serializer = new XmlSerializer(o.GetType());
                    serializer.Serialize(xmlWriter, o);
                }
            }
            finally
            {
                xmlWriter?.Dispose();
            }
        }

        /// <summary>The read object.</summary>
        /// <param name="filepath">The filepath.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        public T ReadObject<T>(string filepath)
        {
            XmlReader xmlReader = null;
            try
            {
                using (xmlReader = XmlReader.Create(filepath))
                {
                    var xs = new XmlSerializer(typeof(T));
                    return (T)xs.Deserialize(xmlReader);
                }
            }
            finally
            {
                xmlReader?.Dispose();
            }
        }
    }
}