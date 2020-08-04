using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ContactAPI.DAL.Utilities
{
    public static class Serializer
    {
        public static string Serialize<T>(this T value)
        {
            // removes version
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;

            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
            StringWriter sw = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(sw, settings))
            {
                // removes namespace
                var xmlns = new XmlSerializerNamespaces();
                xmlns.Add(string.Empty, string.Empty);

                xsSubmit.Serialize(writer, value, xmlns);
                return sw.ToString(); // Your XML
            }
        }
    }
}
