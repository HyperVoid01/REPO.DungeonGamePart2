using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Game
{
    public class HealthPickupTile : PickupTile
    {
        public HealthPickupTile(Position position) : base(position)
        {

        }

        public override void ApplyEffect(CharacterTile target)
        {
            target.Heal(10);
        }

        public override char Display
        {
            get { return '+'; }
        }
    }
}
