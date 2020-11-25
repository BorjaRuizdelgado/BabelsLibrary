using System;
namespace BabelLibrary.ProgramLogic
{
    public class UserInterface
    {
        public UserInterface()
        {
           
        }

        public void StartInteraction()
        {
            Console.WriteLine("Hi, this is Babel's Library, a tool to generate all possible permutations given an alphabet.");
            Console.WriteLine("Please, specify the maximum page length in chars:");
            string userInput = Console.ReadLine();
            int lines = int.Parse(userInput);
            char[] alphabet = InputAlphabet();
            string path = InputPath();
            Console.WriteLine("Please, wait while the pages are being written, this could take a while depending on the size of your input");
            BabelLibrary library = new BabelLibrary(alphabet, lines, path);
            library.GeneratePagesSync();
            Console.WriteLine("We are done! Any text from now to the future is written there, maybe we wrote a best seller for you :).\n Good bye!");
        }

        private string InputPath()
        {
            Console.WriteLine("Please input the path where you want to store the books");
            return Console.ReadLine();
        }

        private char[] InputAlphabet()
        {
            Console.WriteLine("Please input in a string format the alphabet you want to use to generate the Babel's Library:");
            string userInput = Console.ReadLine();
            return userInput.ToCharArray();
        }
    }
}
