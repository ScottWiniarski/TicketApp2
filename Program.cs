using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection.PortableExecutable;

namespace TicketApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.txt";
            string resp;
            do {
                Console.WriteLine("(1) Will you read a file?");
                Console.WriteLine("(2) Create a file from inputted data?");
                Console.WriteLine("Enter any other key to exit.");

                resp = Console.ReadLine();

                if (resp == "1")
                {
                    if (File.Exists(file))
                    {
                        //int count = 0;

                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            sr.ReadLine();
                            string line = sr.ReadLine();
                            string[] sections = line.Split(",");
                            //Console.WriteLine(sections[6]);
                            sections[6] = sections[6].Replace("|", ",");
                            //sections[6].Replace("|", ",");
                            
                            //string[] thoseWatching = sections[6].Split("|");
                            //sections[6] = thoseWatching;

                            //for (int i = 0; i <sections.Length; i++)
                            //{
                            //     sections[i].Split("|");
                            //    foreach (string section in sections)
                            //    {
                            //        Console.WriteLine(sections[i]);
                            //    }
                                
                            //}
                            foreach (string section in sections)
                            {
                                //section.Split("|");
                                Console.WriteLine(section + " ");   
                            }
                            //count++;    
                        }
                        sr.Close();
                        

                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }

                else if (resp == "2")
                {
                    StreamWriter sw = new StreamWriter(file);
                    String[] heading = {"TicketID","Summary","Status","Priority","Submitter","Assigned","Watching"};
                    string input = "";
                    string watchers = "";
                    string cont = "";

                    do
                    {
                        Console.WriteLine("Please enter " + heading[0] + ":");
                        string id = Console.ReadLine();

                        Console.WriteLine("Please enter " + heading[1] + ":");
                        string summary = Console.ReadLine();

                        Console.WriteLine("Please enter " + heading[2] + ":");
                        string status = Console.ReadLine();

                        Console.WriteLine("Please enter " + heading[3] + ":");
                        string priority = Console.ReadLine();

                        Console.WriteLine("Please enter " + heading[4] + ":");
                        string submitter = Console.ReadLine();

                        Console.WriteLine("Please enter " + heading[5] + ":");
                        string assigned = Console.ReadLine();

                        do
                        {
                            Console.WriteLine($"Individuals {heading[6]}? ");
                            watchers += Console.ReadLine();
                            
                            Console.WriteLine("Add more watchers? (Y/N)");
                            cont = Console.ReadLine();
                            if (cont.ToUpper() == "Y")
                            {
                                watchers += "|";
                            }

                        } while (cont.ToUpper() != "N");

                        for (int i = 0; i < 6; i++)
                        {
                            sw.Write($"{heading[i]},");
                            //Console.Write($"{heading[i]},");
                            
                        }
                        sw.Write($"{heading[6]}\n");
                        //Console.Write($"{heading[6]}\n");
                        //Console.WriteLine($"{id},{summary},{status},{priority},{submitter},{assigned},{watchers}");

                        //sw.WriteLine();
                        sw.Write($"{id},{summary},{status},{priority},{submitter},{assigned},{watchers}");


                        Console.WriteLine("Another entry? (Y/N)");
                        input = Console.ReadLine().ToUpper();
                    } while (input == "Y");

                    sw.Close(); 
                }

            } while ( resp == "1" || resp == "2");  
               

        }
    }
}
