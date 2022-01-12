using System;
using System.IO;

namespace MergeFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define the path of files (I've used the path of the project inside my projects folder)
            // please change the path if required.
            var filesPath = @"C:\Projects\CodeChallenge\MergeFiles\MergeFiles\";

            MergeFiles(filesPath + "CACities.txt", filesPath + "USCities.txt", filesPath + "output.txt");
        }

        /// <summary>
        /// Merge the two input files into one output file, making sure that all the cities are in alphabetical order.
        /// Each data file cannot have its contents loaded entirely into memory at any time (e.g., no List<string>, string[] objects, or collections of any type).
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <param name="outputFile"></param>
        public static void MergeFiles(string file1, string file2, string outputFile)
        {
            using (var file1Sr = new StreamReader(file1))
            {
                using (var file2Sr = new StreamReader(file2))
                {
                    using (var outputFileWr = new StreamWriter(outputFile))
                    {
                        // Start reading both files and compare
                        var file1currentLine = file1Sr.ReadLine();
                        var file2currentLine = file2Sr.ReadLine();

                        // Both files has lines to read
                        while (file1currentLine != null && file2currentLine != null)
                        {
                            // we compare both lines and determine via string.Compare
                            // the sort. If comparison is -1 then first element
                            // should be first. If 0, then both lines are equal
                            // If 1, then second element should be first.

                            if (string.Compare(file1currentLine, file2currentLine) < 0)
                            {
                                outputFileWr.WriteLine(file1currentLine);
                                file1currentLine = file1Sr.ReadLine();
                            }
                            else if(string.Compare(file1currentLine, file2currentLine) > 0)
                            {
                                outputFileWr.WriteLine(file2currentLine);
                                file2currentLine = file2Sr.ReadLine();
                            }
                            else
                            {
                                // If there is a repeated entry on both files, then
                                // we take first ocurrence and move to the next line
                                outputFileWr.WriteLine(file1currentLine);
                                file1currentLine = file1Sr.ReadLine();
                                file2currentLine = file2Sr.ReadLine();
                            }
                        }

                        // If file 1 still has lines (when file2 is over)
                        while (file1currentLine != null)
                        {
                            outputFileWr.WriteLine(file1currentLine);
                            file1currentLine = file1Sr.ReadLine();
                        }

                        // If file 2 still has lines (when file1 is over)
                        while (file2currentLine != null)
                        {
                            outputFileWr.WriteLine(file2currentLine);
                            file2currentLine = file2Sr.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
