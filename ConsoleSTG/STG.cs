using System.Diagnostics;
using ConsoleGameBase;
using EZInput;

namespace ConsoleSTG
{
    public partial class Entry
    {
        public string PlayerSprite = " ^\n< > ";
        public (int x, int y) PlayerPosition = (0, 0);

        public string playerBulletSprite = "^";
        public List<(int x, int y)> playerBullets = new List<(int x, int y)>();

        public bool onSpace;

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
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                if (!onSpace)
                {
                    playerBullets.Add((PlayerPosition.x + 1, PlayerPosition.y));
                }

                onSpace = true;
            }
            else
            {
                onSpace = false;
            }

            foreach (var item in playerBullets)
            {
                JConsole.Write(item.x, item.y, playerBulletSprite);
            }

            JConsole.Write(PlayerPosition.x, PlayerPosition.y, PlayerSprite);

            // 弾の位置を動かす
            for (int i = 0; i < playerBullets.Count; i++)
            {
                playerBullets[i] = (playerBullets[i].x, playerBullets[i].y - 1);
            }
        }
    }
}