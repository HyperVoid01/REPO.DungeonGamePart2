using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Game
{
    public class GruntTile : EnemyTile
    {
        public GruntTile(Position position) : base(position, 10, 1)
        {

        }

        public override char Display
        {
            get
            {
                if (IsDead == true)
                {
                    return 'x';
                }
                else
                {
                    return 'Ϫ';
                }
            }
        }

        public override bool GetMove(out Tile tile)
        {
            Random random = new Random();

            if (Vision[0] is EmptyTile || Vision[1] is EmptyTile || Vision[2] is EmptyTile || Vision[3] is EmptyTile)
            {
                do
                {
                    tile = Vision[random.Next(Vision.Length)];
                } while (!(tile is EmptyTile));

                return true;
            }
            else
            {
                tile = null;
                return false;
            }
        }

        public override CharacterTile[] GetTargets()
        {
            CharacterTile hero = Array.Find(Vision, tile => tile is HeroTile) as CharacterTile;

            if (hero != null)
            {
                return new CharacterTile[] { hero };
            }

            return new CharacterTile[0];
        }
    }
}
