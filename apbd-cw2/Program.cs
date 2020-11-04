using apbd_cw2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace apbd_cw2
{
    class Program
    {
        public static void Main(string[] args)
        {
            string csvPath; 
            string xmlPath;
            //string format;
            int argsLen = args.Length;
            
            if (argsLen < 3)
            {
                csvPath = @"data.csv";
                xmlPath = @"result.xml";
                //format = "xml";
            }
            else
            {
                csvPath = args[0];
                xmlPath = args[1];
                //format = args[2];
            } 

            if (File.Exists(xmlPath))
            {
                File.Delete(xmlPath);
            }

            try
            {
                FileStream writer = new FileStream(xmlPath, FileMode.Create);

                using (var stream = new StreamReader(File.OpenRead(csvPath)))
                {
                    string line = null;
                    while ((line = stream.ReadLine()) != null)
                    {
                        string[] student = line.Split(',');
                        var st = new Student
                        {
                            fName = student[0],
                            lName = student[1],
                            name = student[2],
                            mode = student[3],
                            indexNumber = student[4],
                            birthdate = student[5],
                            email = student[6],
                            mothersName = student[7],
                            fathersName = student[8]
                        };

                        XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
                        var list = new List<Student>();
                        list.Add(new Student
                        {
                            fName = student[0],
                            lName = student[1],
                            name = student[2],
                            mode = student[3],
                            indexNumber = student[4],
                            birthdate = student[5],
                            email = student[6],
                            mothersName = student[7],
                            fathersName = student[8]
                        }
                        );

                        serializer.Serialize(writer, list);
                     
                        /*  Fragment kodu tylko do testow
                         * 
                         * Console.WriteLine(st.fName + ", " + st.lName + ", " + st.name + ", " + st.mode + ", " + st.indexNumber + ", " + st.birthdate + ", " + st.email + ", " + st.mothersName + ", " + st.fathersName);*/
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
