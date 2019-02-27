using System;
using System.IO;

namespace DocumentMerger
{

    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            Console.WriteLine("<<** Document Merger **>>");
         

            while (running)
            {
                Console.WriteLine("\nPlease enter the name of the first document:");
                string File1 = Console.ReadLine();

                while (!File.Exists(File1))
                {
                    Console.WriteLine("\nThis file does not exist. Please enter the first file name again:");
                    File1 = Console.ReadLine();
                }

                Console.WriteLine("\nPlease enter the name of the second document:");
                string File2 = Console.ReadLine();

                while (!File.Exists(File2))
                {
                    Console.WriteLine("\nThis file does not exist. Please enter the second file name again:");
                    File2 = Console.ReadLine();
                }

                string file1Content = File.ReadAllText(File1);
                string file2Content = File.ReadAllText(File2);

                char[] Text = { '.', 't', 'x', 't'};
                File1 = File1.TrimEnd(Text);
                File2 = File2.TrimEnd(Text);

                string newFile = File1 + File2 + ".txt";
                string newFileContent = file1Content + "\n" + file2Content;
                File.AppendAllText(newFile, newFileContent);


                StreamWriter sw = null;

                try
                {
                    sw = new StreamWriter(newFile);
                    sw.WriteLine(newFileContent);
                    Console.WriteLine("\n" + newFile + " was successfully saved. This document contains " + newFileContent.Length + " characters.");
                }

                catch (Exception e1)
                {
                    Console.WriteLine(e1);
                }

                finally
                {
                    if (sw != null)
                    {
                        sw.Close();
                    }
                }

                Console.WriteLine("\nDo you want to merge two more files? (Y/N)");
                string yesOrNo = Console.ReadLine();

                if (yesOrNo == "n" || yesOrNo == "N")
                {
                    running = false;
                }



            }
        }
    }
}
