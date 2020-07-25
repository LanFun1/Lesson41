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
            string[,] fullName = new string[0, 3];
            string[] post = new string[1];
            string codeWord = "";
            while (codeWord != "5")
            {
                Console.WriteLine("Введите одну из следующих команд:\n1) добавить досье.\n2) вывести все досье\n3) удалить досье\n4) поиск по фамилии\n5) выход\n");
                codeWord = Console.ReadLine();
                switch (codeWord)
                {
                    case "1":
                        AddPerson(ref fullName, ref post);
                        break;
                    case "2":
                        ShowDossier(fullName, post);
                        break;
                    case "3":
                        DeleteDossier(ref fullName, ref post);
                        break;
                    case "4":
                        FindPerson(fullName, post);
                        break;
                }
            }
        }

        static void AddPerson(ref string[,] fullName, ref string[] post)
        {
            string[,] tempArray = new string[fullName.GetLength(0) + 1, 3];
            string[] tempPost = new string[fullName.GetLength(0) + 1];
            Console.WriteLine("Введите ФИО, затем должность");            
            for (int i = 0; i < tempArray.GetLength(0); i++)
            {
                for (int j = 0; j < tempArray.GetLength(1); j++)
                {
                    if (i < tempArray.GetLength(0) - 1)
                    {
                        tempArray[i, j] = fullName[i, j];
                    }
                    else if (j >= 0)
                    {
                        tempArray[tempArray.GetLength(0) - 1, j] = Console.ReadLine();
                    }
                }
                if (i < tempPost.GetLength(0) - 1)
                {
                    tempPost[i] = post[i];
                }
                else
                {
                    tempPost[tempPost.GetLength(0) - 1] = Console.ReadLine();
                }
            }
            fullName = tempArray;
            post = tempPost;
        }

        static void ShowDossier(string[,] fullName, string[] post)
        {
            for (int i = 0; i < fullName.GetLength(0); i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < fullName.GetLength(1); j++)
                {
                    Console.Write("-" + fullName[i, j]);
                }
                Console.WriteLine("-" + post[i]);
            }
        }

        static void DeleteDossier(ref string[,] fullName, ref string[] post)
        {
            Console.WriteLine("Введите фамилию человека, досье которого вы хотите удалить");
            string surname = Console.ReadLine();
            int deleteLineIndex = Int32.MinValue;
            for (int i = 0; i < fullName.GetLength(0); i++)
            {
                if (surname == fullName[i, 0])
                {
                    deleteLineIndex = i;
                    for (int j = 0; j < fullName.GetLength(1); j++)
                    {
                        fullName[i, j] = "";
                    }
                    post[i] = "";
                }
            }
            string[,] tempArray = new string[fullName.GetLength(0) - 1, fullName.GetLength(1)];
            string[] tempPost = new string[post.GetLength(0) - 1];
            int line = 0;
            for (int i = 0; i < fullName.GetLength(0); i++)
            {
                if (deleteLineIndex == i)
                {
                    continue;
                }
                else
                {
                    for (int j = 0; j < fullName.GetLength(1); j++)
                    {
                        tempArray[line, j] = fullName[i, j];
                    }
                    tempPost[line] = post[i];
                    line++;
                }
            }
            fullName = tempArray;
            post = tempPost;
        }

        static void FindPerson(string[,] fullName, string[] post)
        {
            Console.WriteLine("Введите фамилию человека, досье которого хотите увидеть");
            string index = Console.ReadLine();
            for (int i = 0; i < fullName.GetLength(0); i++)
            {
                if (index == fullName[i, 0])
                {
                    for (int j = 0; j < fullName.GetLength(1); j++)
                    {
                        Console.Write(fullName[i, j] + "-");
                    }
                    Console.WriteLine(post[i]);
                }
            }
        }
    }
}
