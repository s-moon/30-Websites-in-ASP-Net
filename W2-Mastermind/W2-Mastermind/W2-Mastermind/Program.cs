//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MastermindTest
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            MastermindSequence.ColourItem[] royg;
//            MastermindSequence.ColourItem[] gyor;


//            royg = new MastermindSequence.ColourItem[] { 
//                MastermindSequence.ColourItem.Red,
//                MastermindSequence.ColourItem.Orange,
//                MastermindSequence.ColourItem.Yellow,
//                MastermindSequence.ColourItem.Green };
//            gyor = new MastermindSequence.ColourItem[] { 
//                MastermindSequence.ColourItem.Green,
//                MastermindSequence.ColourItem.Yellow,
//                MastermindSequence.ColourItem.Orange,
//                MastermindSequence.ColourItem.Red };


//            MastermindSequence ms = new MastermindSequence(royg);
//            ms.ScoreGuess(gyor);

//            Console.WriteLine(ms);
//            Console.ReadLine();
//        }
//    }
//}
