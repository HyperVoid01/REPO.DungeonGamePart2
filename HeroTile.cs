using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Game
{
    public class HeroTile : CharacterTile
    {
        public HeroTile(Position position) : base(position, 40, 5)
        {

        }

        public override char Display
        {
            get 
            { 
                if (IsDead == true)
                {
                    return 'X';
                }
                else
                {
                    return '▼';
                }
            }
        }
    }
}
