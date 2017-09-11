using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LoggerUtility
    {
        public static String filename = "log.txt";
        public static String file = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\" + filename;
        //public FileStream fstream;

        public LoggerUtility()
        {
            //Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            //Console.WriteLine(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            Console.WriteLine(file);
            try
            {
                if (!File.Exists(file))
                {
                    File.Create(file);
                    //fstream = new FileStream(file, FileMode.Create);
                    //TextWriter tw = new StreamWriter(filePath);
                    Console.WriteLine("Empty Log File is created");

                }
                else
                {
                    File.WriteAllText(file, string.Empty);
                    //fstream = new FileStream(file, FileMode.Open);
                    Console.WriteLine("Log File already exist, contents are cleared.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public String returnFilePath()
        {
            return file;
        }




}

