using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace apbd_cw2.Models
{
    [Serializable]
    public class Student
    {

        [XmlAttribute(attributeName: "indexNumber")]
        [JsonPropertyName("indexNumer")]
        public string IndexNumber { get; set; }

        [XmlElement(elementName: "fname")]
        [JsonPropertyName("fname")]
        public string FirstName { get; set; }

        [XmlElement(elementName: "lname")]
        [JsonPropertyName("lname")]
        public string LastName { get; set; }

        [XmlElement(elementName: "birthday")]
        [JsonPropertyName("birthday")]
        public string Birthdate { get; set; }

        [XmlElement(elementName: "email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        public Study study { get; set; }

        [XmlElement(elementName: "name")]
        [JsonPropertyName("name")]
        public string StudiesName { get; set; }

        [XmlElement(elementName: "mode")]
        [JsonPropertyName("mode")]
        public string StudiesMode { get; set; }

        [XmlElement(elementName: "mothersName")]
        [JsonPropertyName("mothersName")]
        public string MothersName { get; set; }

        [XmlElement(elementName: "fathersName")]
        [JsonPropertyName("fathersName")]
        public string FathersName { get; set; }

    }
}
