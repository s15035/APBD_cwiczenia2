using apbd_cw2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace apbd_cw2
{
    class Program
    {
        public static void Main(string[] args)
        {
            string csvPath;
            string xmlPath;
            //string jsonPath;
            string format;
            int argsLen = args.Length;

            if (argsLen != 3)
            {
                csvPath = @"data.csv";
                xmlPath = @"result.xml";
                //jsonPath = @"result.json";
                format = "xml";
            }
            else
            {
                csvPath = args[0];
                xmlPath = args[1];
                //jsonPath = args[1];
                format = args[2];
            }

            if (File.Exists(xmlPath))
            {
                File.Delete(xmlPath);
            }

            try
            {
                FileStream writer = new FileStream(xmlPath, FileMode.Create);

                using var stream = new StreamReader(File.OpenRead(csvPath));
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] student = line.Split(',');
                    if(student.Length != 9)
                    {
                        return;
                    }

                    var st = new Student
                    {
                        FirstName = student[0],
                        LastName = student[1],
                        StudiesName = student[2],
                        StudiesMode = student[3],
                        IndexNumber = student[4],
                        Birthdate = student[5],
                        Email = student[6],
                        MothersName = student[7],
                        FathersName = student[8]
                    };

                    switch (format)
                    {
                        case "":
                        case "xml":
                            {
                                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("uczelnia"));
                                var xmlList = new List<Student>();
                                xmlList.Add(new Student
                                {
                                    FirstName = student[0],
                                    LastName = student[1],
                                    study = new Study
                                    {
                                        StudiesName = student[2],
                                        StudiesMode = student[3]
                                    },
                                    IndexNumber = student[4],
                                    Birthdate = student[5],
                                    Email = student[6],
                                    MothersName = student[7],
                                    FathersName = student[8]
                                }
                                );

                                serializer.Serialize(writer, xmlList);
                                break;
                            }
                        case "json":
                            {
                                var jsonList = new List<Student>()
                                {
                                    new Student
                                    {
                                        FirstName = student[0],
                                        LastName = student[1],
                                        study = new Study
                                        {
                                            StudiesName = student[2],
                                            StudiesMode = student[3]
                                        },
                                        IndexNumber = student[4],
                                        Birthdate = student[5],
                                        Email = student[6],
                                        MothersName = student[7],
                                        FathersName = student[8]
                                    }
                                };

                                var jsonString = JsonSerializer.Serialize(jsonList);
                                File.WriteAllText("result.json", jsonString);
                                break;
                            }
                        default:
                            throw new ArgumentException("Wprowadzono bledny format danych");
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Nie znaleziono pliku.");
                Console.WriteLine(e.Message);
            }
        }
    }
}
