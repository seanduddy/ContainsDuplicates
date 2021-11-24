using System;
using System.Collections.Generic;
using System.Linq;

//Pretty simple coding exercise that returns a list of duplicates and their indices within an array.
//Or returns a message indicating there are none.
//Array can be of any type.

namespace ContainsDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            //A few tested examples here:

            //dynamic[] inputArray = { 1, 2, 3,5,6,7,3,2,4,6,3,2,5,6,8,5,5,4,3,2,2,4,6,7,7,5};
            //dynamic[] inputArray = { "1", "2", "3", "1", };
            dynamic[] inputArray = { true, false, true };

            //Print output from function.
            Console.WriteLine(Functions.ContainsDuplicates(inputArray));
            //Read key so that we can view output.
            Console.ReadKey();
        }
    }

    class Functions
    {
        public static string ContainsDuplicates(dynamic[] inputArray)
        {
            //Instanciate a new dictionary. Int for the key and dynamic for the value
            //We can thus determine if ANY type of array has duplicates.
            var dictionary = new Dictionary<int, dynamic>();

            //Counter so that we have a value for the key and an index of the array.
            var counter = new int();

            //Loop through each element within the array.
            foreach (var element in inputArray)
            {
                //Store the index of the array as the key and the element as the value.
                dictionary.Add(counter++, element);

            }

            //Group by values, and then select where the count of any groups is greater than 1
            //Thus... a duplicate!
            var onlyDupes = dictionary.GroupBy(x => x.Value).Where(x => x.Count() > 1);

            //New string (update this to use new string).
            var outputString = "";

            //Loop through each outer key.
            foreach (var onlyDupeskeys in onlyDupes)
            {
                //Loop through each inner key.
                foreach (var key in onlyDupeskeys)
                {
                    //Build the string output.
                    outputString += $"Duplicate value of {key.Value} detected at index {key.Key}" + Environment.NewLine;
                }
            }

            //If we didnt build an output string ie we found no duplicates then...
            if (outputString == "")
            {
                //Let the user know.
                return "No duplicates detected";
            }
            //Otherwise return the built up string.
            return outputString.TrimEnd();
        }
    }
}
