using System.Text.Encodings;
using System.Text;
using System.Timers;
using System.Diagnostics;
using EZInput;

namespace ConsoleGameBase
{
    public static class JConsole
    {
        private static StringBuilder builder;
        public static int Width;
        public static int Height;
        public static Action mainLoop;
        public static (int, int) PrevWindowSize;
        public static (int, int) WindowSize;

        public static void Init()
        {
            Width = Console.WindowWidth;
            Height = Console.WindowHeight;

            Resize();
        }

        public static void MainLoop(Action l, int speed)
        {
            mainLoop += l;
            Stopwatch sw = Stopwatch.StartNew();

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                WindowSize = (Console.WindowWidth, Console.WindowHeight);
                
                // ウィンドウサイズが変わった場合
                if (WindowSize != PrevWindowSize)
                {
                    Width = Console.WindowWidth;
                    Height = Console.WindowHeight;

                    Resize();
                }

                mainLoop();


                Flush();
                PrevWindowSize = WindowSize;
                Thread.Sleep(speed);

                Clear();
            }
        }

        public static void SetPoint(int x,int y, char c)
        {
            int p = y * Width + x;
            if (builder.Length > p)
            {
                builder[y * Width + x] = c;
            }
        }

        public static void Write(int x, int y, string s)
        {
            int _y = 0;
            int _x = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '\n')
                {
                    _y++;
                    _x = 0;
                }
                else
                {
                    SetPoint(x + _x, y + _y, s[i]);
                    _x++;
                }
            }
        }

        public static void Flush()
        {
            //Console.Out.WriteLine(builder.ToString());

            int cols = Console.WindowWidth, rows = Console.WindowHeight;
            //some sample text
            byte[] buffer = Encoding.UTF8.GetBytes(builder.ToString());
            //because output appends, ensure the window is reset
            Console.SetCursorPosition(0, 0);
            using (Stream stdout = Console.OpenStandardOutput())
            {
                stdout.Write(buffer, 0, buffer.Length);
            }
        }

        public static void Resize()
        {
            Console.CursorVisible = false;
            Console.Clear();

            builder = new StringBuilder();
            builder.Length = Height * Width;

            Clear();
        }

        public static void Clear()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    SetPoint(x, y, ' ');
                }
            }
        }
    }
}