using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Game
{
    public abstract class CharacterTile : Tile
    {
        private int hitPoints;
        private int maxHitPoints;
        private int attackPower;
        private Tile[] vision;

        public CharacterTile(Position position,int hitPoints,int attackPower) : base(position)
        {
            this.hitPoints = hitPoints;
            this.maxHitPoints = hitPoints;
            this.attackPower = attackPower;
            vision = new Tile[4];
        }

        public void UpdateVision(Level level)
        {
            int x = Position.XPosition;
            int y = Position.YPosition;

            vision[0] = level.Tiles[x, y - 1];
            vision[1] = level.Tiles[x + 1, y];
            vision[2] = level.Tiles[x, y + 1];
            vision[3] = level.Tiles[x - 1, y];
        }

        public void TakeDamage(int damageTaken)
        {
            hitPoints -= damageTaken;
            if (hitPoints < 0)
            {
                hitPoints = 0;
            }
        }

        public void Attack(CharacterTile target)
        {
            target.TakeDamage(attackPower);
        }

        public void Heal(int health)
        {
            hitPoints += health;
            if (hitPoints > maxHitPoints)
            {
                hitPoints = maxHitPoints;
            }
        }

        public bool IsDead
        {
            get
            {
                if (hitPoints > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int HitPoints
        {
            get { return hitPoints; }
            set { hitPoints = value; }
        }

        public int MaxHitPoints
        {
            get { return maxHitPoints; }
            set { maxHitPoints = value; }
        }

        public int AttackPower
        {
            get { return attackPower; }
            set { attackPower = value; }
        }

        public Tile[] Vision
        {
            get { return vision; }
            set { vision = value; }
        }
    }
}
