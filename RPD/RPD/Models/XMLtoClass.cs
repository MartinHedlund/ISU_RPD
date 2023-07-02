using System.Xml.Serialization;
using System.Collections.Generic;
using RPD.Models;

namespace RPD.Models
{

    // класс записи в XML файле
    [XmlRoot(ElementName = "record")]
    public class Record
    {
        [XmlAttribute(AttributeName = "format")]
        public string Format { get; set; }

        [XmlElement(ElementName = "leader")]
        public string Leader { get; set; }

        [XmlElement(ElementName = "field")]
        public List<Field> Fields { get; set; }
        public static List<Record> XmlToList(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Collection));
            Collection collection = null;

            using (StringReader reader = new StringReader(xml))
            {
                collection = (Collection)serializer.Deserialize(reader);
            }

            return collection.Records;
        }
    }

    // класс поля записи в XML файле
    [XmlRoot(ElementName = "field")]
    public class Field
    {
        [XmlAttribute(AttributeName = "tag")]
        public string Tag { get; set; }

        [XmlElement(ElementName = "subfield")]
        public List<SubField> SubFields { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    // класс подполя поля записи в XML файле
    [XmlRoot(ElementName = "subfield")]
    public class SubField
    {
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    // класс коллекции записей в XML файле
    [XmlRoot(ElementName = "collection")]
    public class Collection
    {
        [XmlElement(ElementName = "record")]
        public List<Record> Records { get; set; }
    }

    // функция преобразования XML файла в список
   
}

