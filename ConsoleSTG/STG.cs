using System.Diagnostics;
using ConsoleGameBase;
using EZInput;

namespace ConsoleSTG
{
    public partial class Entry
    {
        public string PlayerSprite = "aa\naaaa\naaaa";

        public void Game()
        {
            JConsole.Write(10, 10, PlayerSprite);
        }
    }
}