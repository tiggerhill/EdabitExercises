using System;
using System.Text;

class Program
{
    static void Main()
    {
        //AverageWordLength("this is a test of the Average Word Length method");

        //Console.WriteLine(ConsecutiveNumbers(new int[] { 5, 1, 4, 3, 2 }));  // result == True
        //Console.WriteLine(ConsecutiveNumbers(new int[] { 5, 1, 4, 3, 2, 2 }));  // result == False

        //Console.WriteLine(CupSwapping(new string[] { "BC", "CB", "CA", "BA" })); // result == A

        //LongestCommonEnding("multiplication", "rotation");

        //NumType(6);  // Perfect
        //NumType(2924); // Amicable

        //AlphabetIndex("The river stole the gods.");

        //GetFrame(15, 20, '-');


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
    public static bool ConsecutiveNumbers(int[] arr)
    {
        //Create a function that determines whether elements in an array can be 
        //re-arranged to form a consecutive list of numbers where each number appears exactly once.

        Array.Sort(arr);
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int next = int.Parse(arr[i].ToString()) + 1;
            if (arr[i + 1] != next)
            {
                return false;
            }
        }

        return true;
    }
    public static string CupSwapping(string[] swaps)
    {
        // There are three cups on a table, at positions A, B, and C.
        // At the start, there is a ball hidden under the cup at position B.
        // However, I perform several swaps on the cups, which is notated as two letters.
        // For example, if I swap the cups at positions A and B, I could notate this as AB or BA.
        // Create a function that returns the letter position that the ball is at,
        // once I finish swapping the cups. The swaps will be given to you as an array.

        char ball = 'B';  // starting location
        for (int i = 0; i < swaps.Length; i++)
        {
            char[] ch = swaps[i].ToCharArray();
            if (ch[0] == ball)
            {
                ball = ch[1];
            }
            else if (ch[1] == ball)
            {
                ball = ch[0];
            }
        }

        return "The ball is under cup " + ball.ToString();

    }
    public static string LongestCommonEnding(string str1, string str2)
    {
        // Write a function that returns the longest common ending between two strings.
        // Return an empty string if there exists no common ending.
        string answer = "";
        int count = 1;

        while ((count <= str1.Length && count <= str2.Length) &&
        (str1[str1.Length - count]) == (str2[str2.Length - count]))
        {
            answer += str1[str1.Length - count];
            count++;
        }

        char[] ch = answer.ToCharArray();
        Array.Reverse(ch);
        answer = new string(ch);

        Console.WriteLine("Longest common ending of '{0}' and '{1}' is '{2}'.", str1, str2, answer);

        return answer;
    }
    public static string NumType(int num)
    {
        /* Given a positive number x, if all the positive divisors of x 
         * (excluding x) add up to x, then x is said to be a perfect number. 
         * For example, the set of positive divisors of 6 excluding 6 itself is (1, 2, 3). 
         * The sum of this set is 6.Therefore, 6 is a perfect number. 
         * . 
         * Given a positive number x, if all the positive divisors of x add up to a second number y, 
         * and all the positive divisors of y add up to x, then x and y are said to be a pair of amicable numbers. 
         * . 
         * Create a function that takes a number and returns "Perfect" if the number is perfect, 
         * "Amicable" if the number is part of an amicable pair, or "Neither". */


        // Check if Perfect
        int sum = CalcNum(num);
        if (sum == num)
        {
            Console.WriteLine(num + " is perfect");
            return "Perfect";
        }

        // Check if Amicable
        int sum2 = CalcNum(sum);
        if (sum2 == num)
        {
            Console.WriteLine(num + " amicable with " + sum);
            return "Amicable";
        }

        // Return if Neither
        Console.WriteLine("Neither");
        return "Neither";
    }
    private static int CalcNum(int num)
    {
        int sum = 0;
        for (int i = 1; i < num; i++)
        {
            if (num % i == 0)
            {
                sum += i;
            }
        }

        return sum;
    }
    public static string AlphabetIndex(string str)
    {
        /* Create a function that takes a string and replaces 
         * each letter with its appropriate position in the alphabet. 
         * "a" is 1, "b" is 2, "c" is 3, etc, etc. */


        // I'm certain there are shorter ways to do this
        char[] alphabet = {'a','b','c','d','e','f','g','h',
            'i','j','k','l','m','n','o','p','q','r','s','t','u','v',
            'w','x','y','z'};
        char[] strChars = str.ToLower().ToCharArray();
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < strChars.Length; i++)
        {
            for (int j = 0; j < alphabet.Length; j++)
            {
                if (alphabet[j] == strChars[i])
                {
                    sb.Append(j + 1 + " ");
                }
            }
        }

        Console.WriteLine(sb.ToString().Trim());
        return sb.ToString().Trim();
    }   
    public static string[] GetFrame(int w, int h, char ch)
    {
        /* Create a function that takes the width, height and character 
         * and returns a picture frame as an array of strings (string[]). 
         * Remember the gap. Return ["invalid"] if width or height is 
         * less than 3 (can't put anything inside). */

        string[] result = new string[h];
        string[,] frameRows = new string[h, w];
        if (h < 3 || w < 3)
        {
            result[0] = "invalid";
            Console.WriteLine("invalid");
            return result;
        }
        else
        {
            for (int height = 0; height < h; height++)
            {
                for (int width = 0; width < w; width++)
                {
                    if (width == 0 || width == w - 1)
                    {
                        frameRows[height, width] += ch;
                    }
                    else if (height == 0 || height == h - 1)
                    {
                        frameRows[height, width] += ch;
                    }
                    else
                    {
                        frameRows[height, width] += " ";
                    }
                }
            }
        }

        // convert [,] to []
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                result[i] += frameRows[i, j];
            }
        }

        string strFrame = "";
        foreach (var item in result)
        {
            strFrame += item + "\r\n";
        }
        Console.WriteLine(strFrame);

        return result;
    }



}
