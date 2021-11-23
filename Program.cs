using System;

class Program
{
    static void Main()
    {
        AverageWordLength("this is a test of the Average Word Length method");
     
    }
    public static double AverageWordLength(string str)
    {
        // Calculate average word length in a string
         
        string[] words = str.Split(new char[] { ' ' });
        int[] wordLength = new int[words.Length];
        int sum = 0;
        for (int i = 0; i < words.Length; i++)
        {
            foreach (char c in words[i])
            {
                if (Char.IsPunctuation(c))
                {
                    wordLength[i] += 0; // just to put something here
                }
                else
                {
                    wordLength[i] += 1;
                }
            }
        }

        for (int i = 0; i < words.Length; i++)
        {
            sum += wordLength[i];
        }

        var writeArray = string.Join(", ", wordLength);
        Console.WriteLine("Average Word Length of \n" + str);
        Console.WriteLine("Word lengths are: " + writeArray);

        double average = Math.Round((double)sum / words.Length, 2);
        Console.WriteLine("Average is " + average);

        return average;

        /*  A shorter solution would be to use Regex, which I haven't
         *  yet studied.  The following is an example of how that solution
         *  would look (not my coding):
         *  
         *  string newstr = Regex.Replace(str, "[^A-Za-z ]", "");  // appears to replace anything that's not a letter with ""
         *  double average = newstr.Split(' ').Select(x => x.Length).Average();
         *  return Math.Round(average, 2);
         */
    }
}
