using System.Diagnostics;
using ConsoleGameBase;
using EZInput;

namespace ConsoleSTG
{
    public partial class Entry
    {
        static void Main(string[] args)
        {
            JConsole.Init();

            Entry program = new Entry();

            JConsole.MainLoop(program.Game, 0);
        }
    }
}