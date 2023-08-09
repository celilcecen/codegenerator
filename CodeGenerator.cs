using System;
using System.Text;
using System.Collections.Generic;

namespace UniqueCodeGenerator
{
    class CodeGenerator
    {
        static HashSet<string> existingCodes = new HashSet<string>();
        static int maxAttempts = 1000;
        static int codeLength = 8;
        static string characters = "ACDEFGHKLMNPRTXYZ234579";

        static void Main(string[] args)
        {
            GenerateUniqueCode();
        }

        static void GenerateUniqueCode()
        {
            Random random = new Random();
            StringBuilder codeBuilder = new StringBuilder();

            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                codeBuilder.Clear();
                for (int i = 0; i < codeLength; i++)
                {
                    int randomIndex = random.Next(0, characters.Length);
                    char randomChar = characters[randomIndex];
                    codeBuilder.Append(randomChar);
                }

                string uniqueCode = codeBuilder.ToString();

                if (!existingCodes.Contains(uniqueCode))
                {
                    existingCodes.Add(uniqueCode);
                    Console.WriteLine("Generated Unique Code: " + uniqueCode);
                    break;
                }

                if (attempt == maxAttempts - 1)
                {
                    Console.WriteLine("Maximum attempts reached. Could not generate a unique code.");
                }
            }
        }
    }
}
