using System;
using System.Collections.Generic;
using System.IO;

namespace Far_Manager
{
        enum FSIMode
        {
            DirectoryInfo = 1,
            File = 2,
            Rename = 3
        }

        class Layer
        {
            public FileSystemInfo[] Content
            {
                get;
                set;
            }
            public int SelectedIndex
            {
                get;
                set;
            }
            public void Draw() //function to show visual part of directory
            {
                Console.BackgroundColor = ConsoleColor.Black; //makes background black
                Console.Clear(); //clears
                for (int i = 0; i < Content.Length; ++i) //loop from 0 to length of content 
                {
                    if (i == SelectedIndex) //selected index is blue whiel others white
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.Write(i + 1 + ". "); //The numbered order of content
                    Console.WriteLine(Content[i].Name); //output the names of content
                }
            }

        }
        class Program
        {
            static void Main(string[] args)
            {
                DirectoryInfo dir = new DirectoryInfo(@"C:\Users\aknur\Desktop\CN"); //the path
                Layer l = new Layer //the layer
                {
                    Content = dir.GetFileSystemInfos(),
                    SelectedIndex = 0
                };

                FSIMode curMode = FSIMode.DirectoryInfo;

                Stack<Layer> history = new Stack<Layer>(); //creating stack of layher
                history.Push(l); //pushing the layer

                bool esc = false; //boolean false
                while (!esc) //while func which ends if esc is false
                {
                    if (curMode == FSIMode.DirectoryInfo)
                    {
                        history.Peek().Draw();
                    }
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                    switch (consoleKeyInfo.Key) //switch case to bind keys to some functions as like if func
                    {
                        case ConsoleKey.UpArrow://up arrow selected index decreases therefore it goes upwards
                            history.Peek().SelectedIndex--;
                            break;
                        case ConsoleKey.DownArrow: //same as up arrow but increase
                            history.Peek().SelectedIndex++;
                            break;
                        case ConsoleKey.Enter: //enter button
                            int index = history.Peek().SelectedIndex;
                            FileSystemInfo fsi = history.Peek().Content[index];
                            if (fsi.GetType() == typeof(DirectoryInfo)) //identifyes is selected index is file or directory
                            {
                                curMode = FSIMode.DirectoryInfo;
                                DirectoryInfo d = fsi as DirectoryInfo;
                                history.Push(new Layer
                                {
                                    Content = d.GetFileSystemInfos(),
                                    SelectedIndex = 0
                                }); //pushing new layer
                            }
                            else
                            {
                                curMode = FSIMode.File; //if file it opens it
                                using (FileStream fs = new FileStream(fsi.FullName, FileMode.Open, FileAccess.Read))
                                {
                                    using (StreamReader sr = new StreamReader(fs)) //reads and makes chance to edit file
                                    {
                                        Console.BackgroundColor = ConsoleColor.White;
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.Clear();
                                        Console.WriteLine(sr.ReadToEnd());
                                    }
                                }
                            }
                            break;
                        case ConsoleKey.Backspace: //back space
                            if (curMode == FSIMode.DirectoryInfo)
                            {
                                history.Pop(); //just pops the layer back
                            }
                            else
                            {
                                curMode = FSIMode.DirectoryInfo;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        case ConsoleKey.Delete: //delete file or folder
                            int indexDel = history.Peek().SelectedIndex;
                            FileSystemInfo fsidel = history.Peek().Content[indexDel];
                            string pathDelete = dir + "/" + fsidel; //the path
                            if (fsidel.GetType() == typeof(DirectoryInfo))//finds if folder of file
                            {
                                Directory.Delete(pathDelete); //delets
                            }
                            else
                            {
                                File.Delete(pathDelete);//delets
                            }
                            history.Push(new Layer //push as new layer
                            {
                                Content = dir.GetFileSystemInfos(),
                                SelectedIndex = 0
                            });
                            break;
                        case ConsoleKey.F4: //rename the file or folder the same as delete
                            Console.Clear();
                            int indexReName = history.Peek().SelectedIndex;
                            FileSystemInfo fsiReName = history.Peek().Content[indexReName];
                            string pathRename = Console.ReadLine();
                            string path1 = dir + "/" + fsiReName;           
                            string path2 = dir + "/" + pathRename;
                            if (fsiReName.GetType() == typeof(DirectoryInfo))
                            {
                                Directory.Move(path1, path2);
                            }
                            else
                            {
                                File.Move(path1, path2);
                            }
                            history.Push(new Layer
                            {
                                Content = dir.GetFileSystemInfos(),
                                SelectedIndex = 0
                            });
                            break;
                        case ConsoleKey.Escape: //escape turns the esc true then the program stops
                            esc = true;
                            break;
                    }
                }
            }
        }
    }

