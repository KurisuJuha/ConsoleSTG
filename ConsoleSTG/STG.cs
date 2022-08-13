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
            if (Keyboard.IsKeyPressed(Key.A))
            {
                PlayerPosition.x--;
                PlayerPosition.x--;
            }
            if (Keyboard.IsKeyPressed(Key.D))
            {
                PlayerPosition.x++;
                PlayerPosition.x++;
            }
            if (Keyboard.IsKeyPressed(Key.W))
            {
                PlayerPosition.y--;
            }
            if (Keyboard.IsKeyPressed(Key.S))
            {
                PlayerPosition.y++;
            }
            JConsole.Write(PlayerPosition.x, PlayerPosition.y, PlayerSprite);
        }
    }
}