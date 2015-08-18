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
        public bool SerializeObject<T>(string filepath, T o)
        {
            // Avoiding mutliple using's here, see-> CA2202: Do not dispose objects multiple times
            XmlWriter xmlWriter = null;
            try
            {
                using (
                    xmlWriter =
                    XmlWriter.Create(
                        filepath,
                        new XmlWriterSettings { Encoding = Encoding.UTF8, CloseOutput = false, Indent = true }))
                {
                    var serializer = new XmlSerializer(o.GetType());
                    serializer.Serialize(xmlWriter, o);
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                xmlWriter?.Dispose();
            }

            return true;
        }

        /// <summary>De-serializes an object from file.</summary>
        /// <param name="filepath">The filepath to the file location.</param>
        /// <typeparam name="T">The object type</typeparam>
        /// <returns>The <see cref="T"/> object type to return.</returns>
        public T DeserializeObject<T>(string filepath)
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