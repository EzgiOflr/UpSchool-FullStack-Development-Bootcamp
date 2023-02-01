using Homework._1;
using Homework._1.Enums;
using System;
using System.Text.RegularExpressions;

PasswordCreator instance = new PasswordCreator();

var questionList = new List<Questions>() {
    Questions.includeLowercase,
    Questions.includeUppercase,
    Questions.includeCharacters,
    Questions.includeNumber,
    Questions.characterLength
};

foreach (var question in questionList)
    instance.AskQuestion(question);

var password = instance.CreatePassword();

Console.WriteLine("Created Password = " + password);
Console.ReadLine();