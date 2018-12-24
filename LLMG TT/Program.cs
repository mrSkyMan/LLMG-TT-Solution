using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LLMG_TT
{
    class Program
    {
        static BinaryTree<Guid> binaryTree;
        static void Main(string[] args)
        {

            binaryTree = new BinaryTree<Guid>();

            ShowMenu();
            ConsoleKey Key;
            do
            {
                Key = Console.ReadKey(true).Key;
                switch (Key)
                {
                    case ConsoleKey.D1:
                        OpenFile(); break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        binaryTree.Print();
                        ShowMenu(); break;
                    case ConsoleKey.D3:
                        Insert(); break;
                    case ConsoleKey.D4:
                        Delete(); break;
                    case ConsoleKey.D5:
                        Find(); break;
                    case ConsoleKey.D6:
                        SaveToFile(); break;
                }
                
            }
            while (Key != ConsoleKey.D0);
        }

        private static void OpenFile()
        {
            Console.Clear();
            Console.WriteLine("Open File\nEnter path to file");
            string path = Console.ReadLine();
            if (String.IsNullOrEmpty(path) || path.Split('.').Count() < 0)
            {
                Console.WriteLine("Incorrect path!!!!");
                return;
            }
            if (path.Split('.').LastOrDefault() == "json")
            {
                try
                {
                    binaryTree = Helpers.DeserializeJSON(path);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    ShowMenu();
                    return;
                }
            }
            else if(path.Split('.').LastOrDefault() == "xml")
            {
                try
                {
                    binaryTree = Helpers.DeserializeXML(path);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    ShowMenu();
                    return;
                }
            }
            else
            {
                Console.WriteLine("File not found!");
            }
            ShowMenu();
        }

        private static void SaveToFile()
        {
            Console.Clear();
            if (binaryTree == null) return;
            Console.WriteLine("Save To File");
            Console.WriteLine("Enter path to file: (xxx.json/xml)");
            try
            {
                string path = Console.ReadLine();
                if (path.Split('.').Last() == "json")
                {
                    Helpers.SerializeJSON(binaryTree, path);
                }
                else if (path.Split('.').Last() == "xml")
                {
                    Helpers.SerializeXML(binaryTree, path);
                }
                else
                {
                    path += ".xml";
                    Helpers.SerializeXML(binaryTree, path);
                }
                Console.WriteLine("File saved!");
            }
            catch
            {
                Console.WriteLine("Can`t save file =(");
            }
            ShowMenu();
        }

        private static void Find()
        {
            Console.WriteLine("Find user\nEnter user GUID: ");
            try
            {
                BinaryTreeNode<Guid> node = BinaryTreeSearch.FindNode(Guid.Parse(Console.ReadLine()), binaryTree.Root);
                Console.WriteLine($"Name: {node.User.Name}\tAge: {node.User.Age}");
            }
            catch(Exception e)
            {
                Console.WriteLine("User not exist!");
            }
            ShowMenu();
        }

        private static void Delete()
        {
            Console.WriteLine("Enter guid to Delete:");
            try
            {
                binaryTree.Delete(binaryTree.Root, Guid.Parse(Console.ReadLine()));
            }
            catch
            {
                Console.WriteLine("Incorrect GUID");
            }
            ShowMenu();
        }

        static void Insert()
        {
            Console.Clear();
            Console.WriteLine("Add new node to tree\nEnter user Name: ");
            User user = new User() { Name = Console.ReadLine() };
            Console.WriteLine("Enter user Age: ");
            try
            {
                int age = Int32.Parse(Console.ReadLine());
                user.Age = age;
            }
            catch {
                Console.WriteLine("Age must be numeric value!");
                ShowMenu();
                return;
            }
            binaryTree.Insert(Guid.NewGuid(), user);
            ShowMenu();
        }

        static void ShowMenu()
        {
            //Console.Clear();
            Console.WriteLine(@"1. Open File
2. Print tree
3. Insert
4. Delete
5. Find
6. SaveToFIle
0. Exit");
        }
    }
}
