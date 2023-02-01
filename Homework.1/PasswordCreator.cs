using Homework._1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Homework._1
{
    public class PasswordCreator
    {
        List<string> UpperCaseCharacters = new List<string>();
        List<string> LowerCaseCharacters = new List<string>();
        List<string> Numbers = new List<string>();
        List<string> SpecialCharacters = new List<string> { "!", "@", "#", "$", "%", "^", "&", "*", "_", "-", "=", "+", ";" };

        Random rnd = new Random();

        bool includeLowercase = false;
        bool includeUppercase = false;
        bool includeNumber = false;
        bool includeCharacters = false;
        int length = 0;

        public PasswordCreator()
        {
            for (char i = 'A'; i <= 'Z'; i++)
            {
                UpperCaseCharacters.Add(i.ToString());
            }

            for (char i = 'a'; i <= 'z'; i++)
            {
                LowerCaseCharacters.Add(i.ToString());
            }

            for (int i = 0; i <= 9; i++)
            {
                Numbers.Add(i.ToString());
            }
        }

        public void AskQuestion(Questions _question)
        {
            var answer = "";

            switch (_question)
            {
                case Questions.includeLowercase:
                    while (answer == "")
                    {
                        Console.Write("Include lowercase? (y / n) : ");
                        var readed = Console.ReadLine();

                        answer = readed.ToLower() == "y" ? "y" : readed.ToLower() == "n" ? "n" : "";
                    }

                    includeLowercase = answer.ToLower() == "y" ? true : false;

                    break;
                case Questions.includeUppercase:
                    while (answer == "")
                    {
                        Console.Write("Include uppercase? (y / n) : ");
                        var readed = Console.ReadLine();
                        answer = readed.ToLower() == "y" ? "y" : readed.ToLower() == "n" ? "n" : "";
                    }

                    includeUppercase = answer.ToLower() == "y" ? true : false;

                    break;
                case Questions.includeNumber:
                    while (answer == "")
                    {
                        Console.Write("Include number? (y / n) : ");
                        var readed = Console.ReadLine();

                        answer = readed.ToLower() == "y" ? "y" : readed.ToLower() == "n" ? "n" : "";
                    }

                    includeNumber = answer.ToLower() == "y" ? true : false;

                    break;
                case Questions.includeCharacters:
                    while (answer == "")
                    {
                        Console.Write("Include special charecters? (y / n) : ");
                        var readed = Console.ReadLine();

                        answer = readed.ToLower() == "y" ? "y" : readed.ToLower() == "n" ? "n" : "";
                    }

                    includeCharacters = answer.ToLower() == "y" ? true : false;
                    break;
                case Questions.characterLength:
                    Console.Write("How many characters? : ");
                    length = Convert.ToInt32(Console.ReadLine());

                    break;
            }
        }

        public string CreatePassword()
        {
            var charsToBeUsed = new List<string>();

            if (includeCharacters)
                charsToBeUsed.AddRange(SpecialCharacters);

            if (includeLowercase)
                charsToBeUsed.AddRange(LowerCaseCharacters);

            if (includeUppercase)
                charsToBeUsed.AddRange(UpperCaseCharacters);

            if (includeNumber)
                charsToBeUsed.AddRange(Numbers);

            var password = "";

            for (var i = 0; i < length; i++)
            {
                int randomIndex = rnd.Next(charsToBeUsed.Count);
                var randomChar = charsToBeUsed[randomIndex];

                password += randomChar;
            }

            return password;
        }
    }
}
