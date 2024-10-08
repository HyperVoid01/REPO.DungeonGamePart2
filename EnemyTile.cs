using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Game
{
    public abstract class EnemyTile : CharacterTile
    {
        public EnemyTile(Position position, int hitPoints, int attackPower) : base(position, hitPoints, attackPower)
        {

        }

        public abstract bool GetMove(out Tile tile);

        public abstract CharacterTile[] GetTargets();
    }
}
