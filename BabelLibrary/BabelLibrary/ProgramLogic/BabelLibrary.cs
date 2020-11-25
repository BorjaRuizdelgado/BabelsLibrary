using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BabelLibrary.ProgramLogic
{
    public class BabelLibrary
    {
        const int MaxPages = 410;
        const int MaxVolumes = 32;
        const int MaxShelves = 5;
        const int MaxWalls = 4;

        private int maxSize;
        private char[] alphabet;
        private long hexagon;
        private int pageNumber;
        private int wall; 
        private int bookShelf;
        private int volumeNumber;
        private string path;
        private List<string> currentVolume;
        
        public BabelLibrary(char[] alphabet, int maxSize = 100, string path = "./")
        {
            this.alphabet = alphabet;
            this.maxSize = maxSize;
            this.path = path;
            pageNumber = 0;
            hexagon = 0;
            bookShelf = 0;
            volumeNumber = 0;
            wall = 0;
            volumeNumber = 0;
            currentVolume = Enumerable.Repeat("hola", 410).ToList();
            this.alphabet = alphabet;
        }

        public void GeneratePagesSync()
        {
            Stack<char> buffer = new Stack<char>();
            GeneratePagesRec(0, buffer);
        }

        private void GeneratePagesRec(int bufferPosition, Stack<char> buffer)
        {
            if (bufferPosition >= maxSize)
            {
                PrintPage(buffer);
            }

            else
            {
                foreach(char letter in alphabet)
                {
                    buffer.Push(letter);
                    GeneratePagesRec(bufferPosition + 1, buffer);
                    buffer.Pop();
                }
            }
        }

        private void PrintPage(Stack<char> buffer)
        {
            
            currentVolume[pageNumber] = "P" + pageNumber + ": " + string.Join("", buffer.ToArray()) + "\n";
            pageNumber++;

            if(pageNumber >= MaxPages)
            {
                Directory.CreateDirectory(path + "/hex" + hexagon + "/wall" + wall + "/shelf" + bookShelf);
                File.WriteAllLines(path + "/hex" + hexagon + "/wall" + wall + "/shelf" + bookShelf + "/volume" + volumeNumber + ".txt", currentVolume);
                pageNumber = 0;
                volumeNumber++;
            }
            if(volumeNumber >= MaxVolumes)
            {
                volumeNumber = 0;
                bookShelf++;
            }
            if(bookShelf >= MaxShelves)
            {
                bookShelf = 0;
                wall++;
            }
            if (wall >= MaxWalls)
            {
                wall = 0;
                hexagon++;
            }
        }
    }
}
