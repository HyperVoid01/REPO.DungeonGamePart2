using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Game
{
    // Represents an entire level in the game, stores collection of tiles
    public class Level
    {
        private Tile[,] tiles;
        private int width;
        private int height;
        private HeroTile hero;
        private ExitTile exit;
        private EnemyTile[] enemies;
        private PickupTile[] pickups;
        
        public Level(int width, int height, int numEnemies, int numPickups, HeroTile hero = null)
        {
            this.width = width;
            this.height = height;
            tiles = new Tile[width,height];
            enemies = new EnemyTile[numEnemies];
            pickups = new PickupTile[numPickups];
            InitiliseTiles();
            Position randomPosition = GetRandomEmptyPosition();

            if (hero == null)
            {
                this.hero = (HeroTile)CreateTile(TileType.Hero, randomPosition);
                hero = this.hero;
            }
            else if (hero != null)
            {
                hero.Position = randomPosition;
                this.hero = hero;
                tiles[randomPosition.XPosition,randomPosition.YPosition] = hero;
            }

            Position exitPosition = GetRandomEmptyPosition();
            exit = (ExitTile)CreateTile(TileType.Exit, exitPosition);

            for (int i = 0; i < numEnemies; i++)
            {
                enemies[i] = (EnemyTile)CreateTile(TileType.Enemy, GetRandomEmptyPosition());
            }

            for (int i = 0; i < numPickups; i++)
            {
                pickups[i] = (PickupTile)CreateTile(TileType.Pickup, GetRandomEmptyPosition());
            }
        }

        private Tile CreateTile(TileType type,Position position) // Creates different tiles for level
        {
            Tile tile = null;
            switch (type)
            {
                case TileType.Empty:
                    {
                        tile = new EmptyTile(position);
                        break;
                    }
                case TileType.Wall:
                    {
                        tile = new WallTile(position);
                        break;
                    }
                case TileType.Hero:
                    {
                        tile = new HeroTile(position);
                        break;
                    }
                case TileType.Exit:
                    {
                        tile = new ExitTile(position);
                        break;
                    }
                case TileType.Enemy:
                    {
                        tile = new GruntTile(position);
                        break;
                    }
                case TileType.Pickup:
                    {
                        tile = new HealthPickupTile(position);
                        break;
                    }
            }
            tiles[position.XPosition, position.YPosition] = tile;
            return tile;
        }

        private Tile CreateTile(TileType type,int x,int y) // Overloaded method
        {
            Position position = new Position(x,y);
            return CreateTile(type, position);
        }

        public void InitiliseTiles() // Creates empty tiles & walls tiles based on width & height
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        CreateTile(TileType.Wall, x, y);
                    }
                    else
                    {
                        CreateTile(TileType.Empty, x, y);
                    }
                }
            }
        }

        public override string ToString() // Constructs string to visually represent game
        {
            string tempString = "";

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    tempString += tiles[x, y].Display.ToString();
                }
                tempString += "\n";
            }
            return tempString;
        }

        private Position GetRandomEmptyPosition() // Returns position of random empty tile
        {
            Random random = new Random();
            int x, y;

            do
            {
                x = random.Next(1, width - 1);
                y = random.Next(1, height - 1);
            } while (!(tiles[x,y] is EmptyTile));

            return new Position(x, y);
        }

        public void SwopTiles(Tile tile1, Tile tile2)
        {
            Position tempPosition = tile1.Position;

            tile1.Position = tile2.Position;
            tile2.Position = tempPosition;

            tiles[tile1.Position.XPosition, tile1.Position.YPosition] = tile1;
            tiles[tile2.Position.XPosition, tile2.Position.YPosition] = tile2;
        }

        public void UpdateVision()
        {
            Hero.UpdateVision(this);

            foreach (EnemyTile enemy in Enemies)
            {
                enemy.UpdateVision(this);
            }
        }

        public HeroTile Hero // May need to add ref
        {
            get { return hero; }
        }

        public Tile[,] Tiles
        {
            get { return tiles; }
        }

        public EnemyTile[] Enemies
        {
            get
            {
                return enemies;
            }
        }

        public PickupTile[] Pickups
        {
            get { return pickups; }
        }


        enum TileType // Represents different tiles
        {
            Empty,
            Wall,
            Hero,
            Exit,
            Enemy,
            Pickup,
        }
    }
}
