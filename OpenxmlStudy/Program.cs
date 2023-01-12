// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using Documentxml;


//Documentxml.createDocument("/Users/fabianvalverde/Documents/StudyOpenXml/SampleFile.docx", "Style01", "Best Style");
//Documentxml.createCheckBox("C:/Users/Fabia/OneDrive/Documents/tests/SampleFile.docx","check",1,"Todosaliobien?");
//Documentxml.createDocument("C:/Users/Fabia/OneDrive/Documents/tests/createDocument.docx", "Heading1", "Normal Style");
//Documentxml.createTable("C:/Users/Fabia/OneDrive/Documents/tests/createTable.docx");
//DocManipulation.createCheckBox2("C:/Users/Fabia/OneDrive/Documents/tests/checkBox.docx");
//DocManipulation.changeBackgroundTable("C:/Users/Fabia/OneDrive/Documents/tests/BackgroundTable.docx");
//DocManipulation.highlightText("C:/Users/Fabia/OneDrive/Documents/tests/highLight.docx");
//DocManipulation.blockQuote(@"C:\\Users\\jaftb\\Documents\\StudyOpenXml\\tests\\BlockQuote.docx");

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        string document2 = @"C:\Users\jaftb\OneDrive\Escritorio\test\Word10.docx";

        string fileName = @"https://cdn.discordapp.com/attachments/458291463663386646/592779619212460054/Screenshot_20190624-201411.jpg?query&with.dots";
        DocManipulation.InsertAPicture(document2, fileName);
        //Stream result = await DocManipulation.DownloadImageAsync(new Uri(fileName));

    }
}