using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;

namespace YogaSequenceGenerator
{
    public class Asana
    {
        //PARAMETERS
        public string Name { get; }
        public bool IsStanding { get; }
        public List<String> FocusAreas { get; }





        //CONSTRUCTORS
        public Asana() { }
        public Asana(string row)
        {
            string[] rowArray = row.Split("|");
            Name = rowArray[0];
            IsStanding = (int.Parse(rowArray[1]) == 1) ? true : false;
            FocusAreas = rowArray[2].Split(", ").ToList();
        }



        //METHODS to read and return the list of every pose 
        public static List<Asana> ReadFiles()

        {
            string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string fileName = "\\AsanaList.txt";
            string filePath = fileLocation + fileName;
            Console.WriteLine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent);
            List<Asana> listOfAsanas = new List<Asana>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        Asana asana = new Asana(sr.ReadLine());
                        listOfAsanas.Add(asana);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error Reading Asanas");
            }
            return listOfAsanas;
        }
    }
}
