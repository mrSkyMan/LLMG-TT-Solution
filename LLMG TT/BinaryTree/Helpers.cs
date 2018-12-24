using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LLMG_TT
{
    public static class Helpers
    {
        public static void SerializeJSON(BinaryTree<Guid> binaryTree, string path)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer
                {
                    Formatting = Newtonsoft.Json.Formatting.Indented
                };
                serializer.Serialize(file, binaryTree);
            }
        }

        public static BinaryTree<Guid> DeserializeJSON(string path)
        {
            return JsonConvert.DeserializeObject<BinaryTree<Guid>>(File.ReadAllText(path));
        }

        public static void SerializeXML(BinaryTree<Guid> binaryTree, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BinaryTree<Guid>));

            using (var sww = new StreamWriter(path))
            {
                using (XmlWriter writer = XmlWriter.Create(sww, new XmlWriterSettings() { Indent = true }))
                {
                    serializer.Serialize(writer, binaryTree);
                }
            }
        }

        public static BinaryTree<Guid> DeserializeXML(string path)
        {
        return new XmlSerializer(typeof(BinaryTree<Guid>)).Deserialize(new StreamReader(path)) as BinaryTree<Guid>;
        }
    }
}
