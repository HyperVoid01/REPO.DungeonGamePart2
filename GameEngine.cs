using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dungeon_Game
{
    public class GameEngine
    {
        private Level level;
        private Random random;
        private int numLevels;
        private int levelnum = 1;
        private int successfulMoves = 0;
        private const int MIN_SIZE = 10;
        private const int MAX_SIZE = 20;
        GameState gameState = GameState.InProgress;

        // TEST
        public Position heroCoords = new Position(0,0);

        public GameEngine(int numLevels)
        {
            this.numLevels = numLevels;
            random = new Random();
            level = new Level(random.Next(MIN_SIZE, MAX_SIZE), random.Next(MIN_SIZE, MAX_SIZE), 1,levelnum);
        }

        public override string ToString() // Returns string of chars to visually represent level
        {
            if (gameState == GameState.InProgress)
            {
                return level.ToString();
            }
            else if (gameState == GameState.Complete)
            {
                return "YOU WIN";
            }
            else if (gameState == GameState.GameOver)
            {
                return "YOU LOSE";
            }
            else
            {
                return level.ToString();
            }
        }

        private bool MoveHero(Direction direction) // Moves player's character
        {
            // TEST
            heroCoords = level.Hero.Position;

            Tile targetTile;
            targetTile = level.Hero.Vision[(int)direction];
            
            if (targetTile is ExitTile && levelnum == numLevels)
            {
                gameState = GameState.Complete;
                return false;
            }
            else if (targetTile is ExitTile && levelnum < numLevels)
            {
                NextLevel();
                return true;
            }
            else if (targetTile is PickupTile)
            {
                foreach (PickupTile pickup in level.Pickups)
                {
                    if (targetTile.Position == pickup.Position)
                    {
                        pickup.ApplyEffect(level.Hero);
                        level.SwopTiles(level.Hero, targetTile);
                        level.Tiles[targetTile.XPosition,targetTile.YPosition] = new EmptyTile(targetTile.Position);
                        level.UpdateVision();
                        return true;
                    }
                }
                return false;
            }
            else if (targetTile is EmptyTile)
            {
                level.SwopTiles(level.Hero, targetTile);
                level.UpdateVision();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TriggerMovement(Direction direction)
        {
            if (gameState == GameState.InProgress)
            {
                level.UpdateVision();
                if (successfulMoves == 1)
                {
                    MoveHero(direction);
                    MoveEnemies();
                    successfulMoves = 0;
                }
                else if (MoveHero(direction))
                {
                    successfulMoves++;
                }
                level.UpdateVision();
            }
        }

        private void NextLevel()
        {
            levelnum++;
            HeroTile tempHero = this.level.Hero;
            Level level = new Level(random.Next(MIN_SIZE,MAX_SIZE), random.Next(MIN_SIZE, MAX_SIZE), levelnum, 1,tempHero);
            this.level = level;
        }

        private void MoveEnemies()
        {
            foreach (EnemyTile enemy in level.Enemies)
            {
                if (enemy.IsDead == false && enemy.GetMove(out Tile targetTile) == true)
                {
                    level.SwopTiles(enemy, targetTile);
                }
            }
        }

        private bool HeroAttack(Direction attackDirection)
        {
            if (level.Hero.Vision[(int)attackDirection] is CharacterTile)
            {
                level.Hero.Attack((CharacterTile)level.Hero.Vision[(int)attackDirection]);
                return true;
            }
            else { return false; }
        }

        private void EnemiesAttack()
        {
            foreach (EnemyTile enemy in level.Enemies)
            {
                if (enemy.IsDead == false)
                {
                    CharacterTile[] targetTiles = enemy.GetTargets();

                    foreach (CharacterTile target in targetTiles)
                    {
                        enemy.Attack(target);
                    }
                }
            }
        }

        public void TriggerAttack(Direction direction)
        {
            if (gameState == GameState.InProgress && HeroAttack(direction) == true)
            {
                EnemiesAttack();
                if (level.Hero.IsDead == true)
                {
                    gameState = GameState.GameOver;
                }
            }
        }

        public int LevelNum 
        { 
            get { return levelnum; } 
        }

        public string HeroStats
        {
            get
            {
                return $"{level.Hero.HitPoints}/{level.Hero.MaxHitPoints}";
            }
        }
    }

    public enum Direction // Index links with character vision array
    {
        Up,
        Right,
        Down,
        Left,
        None,
    }

    public enum GameState
    {
        InProgress,
        Complete,
        GameOver,
    }
}
