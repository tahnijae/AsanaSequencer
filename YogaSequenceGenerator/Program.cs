using System;
using System.Collections.Generic;
using System.Speech.Synthesis;

namespace YogaSequenceGenerator
{
    internal class Program
    {
        List<Asana> listOfAsanas = Asana.ReadFiles();




        static void Main(string[] args)
        {
            var synthesis = new SpeechSynthesizer();
            synthesis.SpeakAsync("Hello and welcome to the yoga sequence generator");
            Console.WriteLine("Hello and welcome to the yoga sequence generator!\n");
            Program run = new Program();
            run.GetUserInput();



            //List<Asana> listOfAsanas = Asana.ReadFiles();




        }




        //USER INPUT METHODS
        public void GetUserInput()
        {
            int userInput = 0;
            do
            {
                Console.WriteLine("\nPlease select from the following:\n" +
                    "1. Quick Reference List\n" +
                    "2. Generate\n");
                userInput = int.Parse(Console.ReadLine());
            } while (userInput < 1 || userInput > 3);
            if (userInput == 1)
            {
                QuickReference();
            }
            else if (userInput == 2)
            { }
        }

        //QUICK REFERENCE METHODS
        public void QuickReference()
        {
            int userInput = 0;
            List<Asana> printList = new List<Asana>();

            do
            {
                Console.WriteLine("\nGreat! What would you like a list of?:\n" +
                    "1. All Poses\n" +
                    "2. Standing Poses\n" +
                    "3. Floor Poses\n" +
                    "4. List by Focus Area\n" +
                    "5. Sun Salutation\n");
                userInput = int.Parse(Console.ReadLine());
            } while (userInput < 1 || userInput > 5);

            switch(userInput)
            {
                case 1:
                    foreach (Asana asana in listOfAsanas)
                    {
                        printList.Add(asana);
                    }
                    break;
                case 2:
                    foreach (Asana asana in listOfAsanas)
                    {
                        if (asana.IsStanding == true)
                        { printList.Add(asana); }
                    }
                    break;
                case 3:
                    foreach (Asana asana in listOfAsanas)
                    {
                        if (asana.IsStanding == false)
                        { printList.Add(asana); }
                    }
                    break;
                case 4:
                    printList = FindFocusArea();
                    break;
                case 5:
                    printList = SunSalutation();
                    break;
            }
            

            foreach (Asana asana in printList)
            {
                Console.WriteLine(asana.Name);
            }
        }

        public List<Asana> FindFocusArea()
        {
            int userInput = 0;
            List<Asana> returnList = new List<Asana>();
            do
            {
                Console.Write("\nGreat! What would you like a list of?:\n" +
                        "1. Backbend" + Environment.NewLine +
                        "2. Balance" + Environment.NewLine +
                        "3. Chest" + Environment.NewLine +
                        "4. Core" + Environment.NewLine +
                        "5. Forward Fold" + Environment.NewLine +
                        "6. Hips" + Environment.NewLine +
                        "7. Restorative" + Environment.NewLine +
                        "8. Strengthening" + Environment.NewLine +
                        "9. Twist" + Environment.NewLine); 
                userInput = int.Parse(Console.ReadLine());
            } while (userInput < 1 || userInput > 9);

            string[] focusAreaArray = { "backbend", "balance", "chest", "core", "forward fold", "hip", "restorative", "strengthening", "twist" };
            string focusWord = focusAreaArray[userInput - 1];
            foreach (Asana asana in listOfAsanas)
            {
                if (asana.FocusAreas.Contains(focusWord))
                {returnList.Add(asana);}
            }
            
            return returnList;
        }

        public List<Asana> SunSalutation()
        {
            List<Asana> returnList = new List<Asana>();
            string[] sunSal = { "Mountain", "Standing Forward Fold", "Half Forward Fold", "Chaturanga", "Upwards Dog", "Downwards Dog", "Standing Forward Fold", "Half Forward Fold", "Mountain" };
            for(int i =0; i < sunSal.Length; i++)
            {
               foreach(Asana asana in listOfAsanas)
                {
                    if (asana.Name == sunSal[i])
                    {
                        returnList.Add(asana);
                    }
                }
               
            }
            return returnList;
        }



        //GENERATE SEQUENCE METHODS 
        }

    }



