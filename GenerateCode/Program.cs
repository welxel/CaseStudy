using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Business.Business;
using Business.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            ICodeManager codeManager = new CodeManager();
            while (true)
            {
                Console.Write("Lütfen bir metin girin: ");
                string text = Console.ReadLine();

                int codeGIndex = text.IndexOf("code-g");
                int codeVIndex = text.IndexOf("code-v-");
                if (codeGIndex != -1)
                {
                    Console.WriteLine(codeManager.CodeGenerater());
                }
                else if (codeVIndex != -1)
                {
                    string code = text.Substring(codeVIndex + "code-v-".Length);
                    Console.WriteLine(codeManager.InValidCode(code) ? "Code is Valide" : "Code is not valide");
                }
                else
                {
                    Console.WriteLine("Geçersiz keyword kullandınız lütfen read-me dosya içerisinden gerekli keyworda bakarak istediğinizi giriniz");
                }

                Console.WriteLine("Devam etmek için bir tuşa basın veya çıkmak için 'q' tuşuna basın.");
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.KeyChar == 'q')
                {
                    break;
                }
            }
           
        }
    }
}