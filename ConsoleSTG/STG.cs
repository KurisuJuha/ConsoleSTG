using System.Diagnostics;
using ConsoleGameBase;
using EZInput;

namespace ConsoleSTG
{
    public partial class Entry
    {
        public string PlayerSprite = " ^\n< > ";
        public (int x, int y) PlayerPosition = (0, 0);

        public void Game()
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                PlayerPosition.x--;
                PlayerPosition.x--;
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                PlayerPosition.x++;
                PlayerPosition.x++;
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                PlayerPosition.y--;
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                PlayerPosition.y++;
            }

            JConsole.Write(PlayerPosition.x, PlayerPosition.y, PlayerSprite);
        }
    }
}