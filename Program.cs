using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson41
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] fullName = new string[0, 4];
            for (int i = 0; i < fullName.GetLength(0); i++)
            {
                for (int j = 0; j < fullName.GetLength(1); j++)
                {
                    fullName[i, j] = "+";
                    Console.Write(fullName[i, j]);
                }
                Console.WriteLine();
            }
            string[] post = new string[1];
            string codeWord = "";
            while (codeWord != "5")
            {
                Console.WriteLine("Введите одну из следующих команд:\n1) добавить досье.\n2) вывести все досье\n3) удалить досье\n4) поиск по фамилии\n5) выход\n");
                codeWord = Console.ReadLine();
                switch (codeWord)
                {
                    case "1":
                        fullName = AddPerson(fullName);
                        break;
                    case "2":
                        ShowDossier(fullName);
                        break;
                    case "3":
                        fullName = DeleteDossier(fullName);
                        break;
                    case "4":
                        FindPerson(fullName);
                        break;
                }
            }
        }
        static string[,] AddPerson(string[,] fullName)
        {
            string[,] tempArray = new string[fullName.GetLength(0) + 1, 4];
            for (int i = 0; i < fullName.GetLength(0); i++)
            {
                for (int j = 0; j < fullName.GetLength(1); j++)
                {
                    tempArray[i, j] = fullName[i, j];
                }
            }
            Console.WriteLine("Введите ФИО");
            tempArray[tempArray.GetLength(0) - 1, 0] = Convert.ToString(tempArray.GetLength(0));
            for (int i = 1; i < fullName.GetLength(1); i++)
            {
                tempArray[tempArray.GetLength(0) - 1, i] = Console.ReadLine();
            }
            fullName = tempArray;
            return fullName;
        }
        static void ShowDossier(string[,] fullName)
        {
            for (int i = 0; i < fullName.GetLength(0); i++)
            {
                Console.Write(i + 1);
                for (int j = 1; j < fullName.GetLength(1); j++)
                {

                    Console.Write("-" + fullName[i, j]);
                }
                Console.WriteLine();
            }
        }
        static string[,] DeleteDossier(string[,] fullName)
        {
            Console.WriteLine("Введите индекс человека, досье которого вы хотите удалить");
            string index = Console.ReadLine();
            for (int i = 0; i < fullName.GetLength(0); i++)
            {
                if (index == fullName[i, 0])
                {
                    for (int j = 1; j < fullName.GetLength(1); j++)
                    {
                        fullName[Convert.ToInt32(index) - 1, j] = "";
                    }
                }
            }
            string[,] tempArray = new string[fullName.GetLength(0) - 1, fullName.GetLength(1)];
            int line = 0;
            for (int i = 0; i < fullName.GetLength(0); i++)
            {
                if (index == fullName[i, 0])
                {
                    continue;
                }
                else
                {
                    for (int j = 0; j < fullName.GetLength(1); j++)
                    {
                        tempArray[line, j] = fullName[i, j];
                    }
                }
            }
            fullName = tempArray;
            return fullName;
        }
        static void FindPerson(string[,] fullName)
        {
            Console.WriteLine("Введите фамилию человека, досье которого хотите увидеть");
            string surname = Console.ReadLine();
            for (int i = 0; i < fullName.GetLength(0); i++)
            {
                if (surname.ToLower() == fullName[i, 1].ToLower())
                {
                    for (int l = 1; l < fullName.GetLength(1); l++)
                    {
                        Console.Write(fullName[i, 0]);
                        Console.Write("-" + fullName[i, l]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
