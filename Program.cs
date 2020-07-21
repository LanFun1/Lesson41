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
            string[,] indexAndFullName = new string[0, 4];
            string[,] indexAndPost = new string[0, 1];
            string[] post = new string[1];
            string codeWord = "";
            while (codeWord != "5")
            {
                Console.WriteLine("Введите одну из следующих команд:\n1) добавить досье.\n2) вывести все досье\n3) удалить досье\n4) поиск по фамилии\n5) выход\n");
                codeWord = Console.ReadLine();
                switch (codeWord)
                {
                    case "1":
                        AddPerson(ref indexAndFullName, ref indexAndPost);
                        break;
                    case "2":
                        ShowDossier(indexAndFullName, indexAndPost);
                        break;
                    case "3":
                        DeleteDossier(ref indexAndFullName, ref indexAndPost);
                        break;
                    case "4":
                        FindPerson(indexAndFullName, indexAndPost);
                        break;
                }
            }
        }

        static void AddPerson(ref string[,] fullName, ref string[,] post)
        {
            string[,] tempArray = new string[fullName.GetLength(0) + 1, 4];
            string[,] tempPost = new string[fullName.GetLength(0) + 1, 1];
            Console.WriteLine("Введите ФИО, затем должность");
            tempArray[tempArray.GetLength(0) - 1, 0] = Convert.ToString(tempArray.GetLength(0));
            for (int i = 0; i < tempArray.GetLength(0); i++)
            {
                for (int j = 0; j < tempArray.GetLength(1); j++)
                {
                    if (i < tempArray.GetLength(0) - 1)
                    {
                        tempArray[i, j] = fullName[i, j];
                    }
                    else if (j > 0)
                    {
                        tempArray[tempArray.GetLength(0) - 1, j] = Console.ReadLine();
                    }
                }
                if (i < tempPost.GetLength(0) - 1)
                {
                    tempPost[i, 0] = post[i, 0];
                }
                else
                {
                    tempPost[tempPost.GetLength(0) - 1, 0] = Console.ReadLine();
                }
            }
            fullName = tempArray;
            post = tempPost;
        }

        static void ShowDossier(string[,] fullName, string[,] post)
        {
            for (int i = 0; i < fullName.GetLength(0); i++)
            {
                Console.Write(i + 1);
                for (int j = 1; j < fullName.GetLength(1); j++)
                {
                    Console.Write("-" + fullName[i, j]);
                }
                Console.WriteLine("-" + post[i, 0]);
            }
        }

        static void DeleteDossier(ref string[,] fullName, ref string[,] post)
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
                    post[Convert.ToInt32(index) - 1, 0] = "";
                }
            }
            string[,] tempArray = new string[fullName.GetLength(0) - 1, fullName.GetLength(1)];
            string[,] tempPost = new string[post.GetLength(0) - 1, post.GetLength(1)];
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
                    tempPost[line, 0] = post[i, 0];
                    line++;
                }
            }
            fullName = tempArray;
            post = tempPost;
        }

        static void FindPerson(string[,] fullName, string[,] post)
        {
            Console.WriteLine("Введите индекс человека, досье которого хотите увидеть");
            string index = Console.ReadLine();
            for (int i = 0; i < fullName.GetLength(0); i++)
            {
                if (index == fullName[i, 0])
                {
                    for (int j = 0; j < fullName.GetLength(1); j++)
                    {
                        Console.Write(fullName[i, j] + "-");
                    }
                    Console.WriteLine(post[i, 0]);
                }
            }
        }
    }
}
