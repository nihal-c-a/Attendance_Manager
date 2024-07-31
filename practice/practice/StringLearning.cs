using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    using System;

    class StringLearning
    {
        public void Example1()
        {
            // Example string
            string myString = "Hello World";

            // 1. Get the length of the string
            int length = myString.Length;
            Console.WriteLine($"Length: {length}"); // Output: Length: 11

            // 2. Convert string to uppercase
            string upper = myString.ToUpper();
            Console.WriteLine($"Uppercase: {upper}"); // Output: Uppercase: HELLO WORLD

            // 3. Convert string to lowercase
            string lower = myString.ToLower();
            Console.WriteLine($"Lowercase: {lower}"); // Output: Lowercase: hello world

            // 4. Check if the string contains a specific substring
            bool contains = myString.Contains("World");
            Console.WriteLine($"Contains 'World': {contains}"); // Output: Contains 'World': True

            // 5. Replace occurrences of a substring
            string replaced = myString.Replace("World", "CSharp");
            Console.WriteLine($"Replaced: {replaced}"); // Output: Replaced: Hello CSharp

            // 6. Extract a substring
            string sub = myString.Substring(6, 5); // Start index 6, length 5
            Console.WriteLine($"Substring: {sub}"); // Output: Substring: World
        }
        public void Example2()
        {
            string s1 = "Learning C# ";
            string s2 = "is awesome";

            // Concatenate the strings using String.Concat
            string s3 = String.Concat(s1, s2);

            // Output the result
            Console.WriteLine(s3); // Output: Learning C# is awesome

            // Declare variables
            string employeeName = "Bethany";
            int age = 34;

            // Format the greeting text using String.Format
            string greetingText = string.Format("Hello {0}, you are {1} years old", employeeName, age);

            // Output the result
            Console.WriteLine(greetingText); // Output: Hello Bethany, you are 34 years old


            // Declare and initialize the variable
            string firstName = "Bethany";

            // Check if firstName matches "Bethany"
            bool b2 = (firstName == "Bethany");

            // Check if firstName matches "bethany" (case-sensitive)
            bool b3 = (firstName == "bethany");

            // Print results
            Console.WriteLine($"b2: {b2}"); // true
            Console.WriteLine($"b3: {b3}"); // false

            // Optional: Case-insensitive comparison for `firstName`
            bool caseInsensitiveMatch = string.Equals(firstName, "bethany", StringComparison.OrdinalIgnoreCase);
            Console.WriteLine($"Case-insensitive match: {caseInsensitiveMatch}"); // true
        }
        public void learningStringBuilder()
        {
            // Initialize the StringBuilder object
            StringBuilder stringBuilder = new StringBuilder();

            // Append text to the StringBuilder
            stringBuilder.Append("Employee list");
            stringBuilder.AppendLine(); // Adds a newline
            stringBuilder.AppendLine("Nihal");
            stringBuilder.AppendLine("Ashley");
            stringBuilder.AppendLine("Bhavith");

            // Convert the StringBuilder content to a string
            string list = stringBuilder.ToString();

            // Output the result
            Console.WriteLine(list);
        }
    }


}
