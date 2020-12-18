using System;
using System.Xml;
using System.IO;
using System.Text.Json;
using System.IO.Compression;

namespace _1
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void XML_r()
        {
            Console.Clear();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\test\users.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr != null)
                        Console.WriteLine(attr.Value);
                }
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "company")
                    {
                        Console.WriteLine($"Company: {childnode.InnerText}");
                    }
                    if (childnode.Name == "age")
                    {
                        Console.WriteLine($"Age: {childnode.InnerText}");
                    }
                }
                Console.WriteLine();
            }
            Console.Read();
        }
        static void Drive_System()
        {
            DriveInfo[] drivers = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drivers)
            {
                Console.WriteLine($"Drive Format - {drive.DriveFormat}");
                Console.WriteLine($"Drive Name - {drive.Name}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Drive Size - {drive.TotalSize}");
                    Console.WriteLine($"Drive Free Space - {drive.TotalFreeSpace}");
                    Console.WriteLine($"{drive.VolumeLabel}");
                }
                Console.WriteLine();
            }
        }
        static void Create_File()
        {
            string path = @"D:\test";
            Console.Write("Input name of file - ");
            string file = Console.ReadLine();
            FileInfo filePath = new FileInfo(string.Format(@"{0}\{1}.txt", path, file));
            if (filePath.Exists) Console.WriteLine("This file exist");
            else filePath.Create();
            Console.Clear();
        }
        static void WFile()
        {
            string path = @"D:\test";
            Console.Write("Input name of file - ");
            string file = Console.ReadLine();
            path = string.Format(@"{0}\{1}.txt", path, file);
            FileStream filePath = new FileStream(path, FileMode.OpenOrCreate);
            Console.Write("Input string of text - ");
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(Console.ReadLine());
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("The text is written to a file");
            }

            filePath.Close();
            Console.ReadKey();
            Console.Clear();
        }
        static void RFile()
        {
            string path = @"D:\test";
            Console.Write("Input name of file - ");
            string file = Console.ReadLine();
            path = string.Format(@"{0}\{1}.txt", path, file);
            FileStream filePath = new FileStream(path, FileMode.OpenOrCreate);
            byte[] array = new byte[filePath.Length];
            filePath.Read(array, 0, array.Length);
            string textFromFile = System.Text.Encoding.UTF8.GetString(array);
            Console.WriteLine($"Text : {textFromFile}");
            filePath.Close();
            Console.ReadKey();
            Console.Clear();
        }
        static void DFile()
        {
            string path = @"D:\test";
            Console.Write("Input name of file - ");
            string file = Console.ReadLine();
            FileInfo filePath = new FileInfo(string.Format(@"{0}\{1}.txt", path, file));
            if (filePath.Exists)
            {
                filePath.Delete();
                Console.WriteLine("File deleted");
            }
            else Console.WriteLine("File did not exist");
            Console.ReadKey();
            Console.Clear();
        }
        static void select_an_operation_for_file()
        {
            bool check = true;
            int num;
            while (check)
            {
                Console.WriteLine("1.Create file\n2.Write in file\n3.Read file\n4.Delete file\n5.Exit");
                if (Int32.TryParse(Console.ReadLine(), out num))
                {
                    switch (num)
                    {
                        case 1:
                            Console.Clear();
                            Create_File();
                            break;

                        case 2:
                            Console.Clear();
                            WFile();
                            break;

                        case 3:
                            Console.Clear();
                            RFile();
                            break;

                        case 4:
                            Console.Clear();
                            DFile();
                            break;

                        case 5:
                            check = false;
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong Input");
                }
            }
        }
        static void JSON_r()
        {
            Person tom = new Person { Name = "Tom", Age = 35 };
            string json = JsonSerializer.Serialize<Person>(tom);
            Console.WriteLine(json);
            Person restoredPerson = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine(restoredPerson.Name);
            Console.ReadKey();
        }
        static void Com_File()
        {
            string sourceFolder = @"D:\test\test1";
            string zipFile = @"D:\test\test1.zip";
            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
            Console.WriteLine("successful");
            Console.ReadLine();
        }
        static void Decom_File()
        {
            string zipFile = @"D:\test\test1.zip";
            string decompressFolder = @"D:\test\test1";
            ZipFile.ExtractToDirectory(zipFile, decompressFolder);
            Console.WriteLine("successful");
            Console.ReadLine();
        }
        static void ZIP_r()
        {
            bool check = true;
            int num;
            while (check)
            {
                Console.WriteLine("1.Compress File\n2.Decompress\n3.Exit");
                if (Int32.TryParse(Console.ReadLine(), out num))
                {
                    switch (num)
                    {
                        case 1:
                            Console.Clear();
                            Com_File();
                            break;

                        case 2:
                            Console.Clear();
                            Decom_File();
                            break;

                        case 3:
                            check = false;
                            break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            bool check = true;
            int num;
            while (check)
            {
                Console.WriteLine("1.DriveInfo \n2.FileStream \n3.Json \n4.XML \n5.ZIP\n6.Exit");
                if (Int32.TryParse(Console.ReadLine(), out num))
                {
                    switch (num)
                    {
                        case 1:
                            Console.Clear();
                            Drive_System();
                            break;

                        case 2:
                            Console.Clear();
                            select_an_operation_for_file();
                            break;

                        case 3:
                            Console.Clear();
                            JSON_r();
                            break;

                        case 4:
                            XML_r();
                            break;

                        case 5:
                            Console.Clear();
                            ZIP_r();
                            break;

                        case 6:
                            check = false;
                            break;
                    }
                }
            }
        }
    }
}
