using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungeon_Game
{
    public partial class Form1 : Form
    {
        private GameEngine engine;
        public Form1()
        {
            InitializeComponent();
            engine = new GameEngine(10);
            UpdateDisplay();
        }

        void UpdateDisplay()
        {
            lblDisplay.Text = engine.ToString();

            // TEST
            lblHeroCoordinates.Text = $"Coordinates:\nx: {engine.heroCoords.XPosition}\ny: {engine.heroCoords.YPosition}\n\nLevel: {engine.LevelNum}" +
                $"\n{engine.HeroStats}\n\nMovement: WASD\nAttack: Arrow Keys";
        }

        private void PlayerInput(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    {
                        engine.TriggerMovement(Direction.Up);
                        break;
                    }
                case Keys.D:
                    {
                        engine.TriggerMovement(Direction.Right);
                        break;
                    }
                case Keys.S:
                    {
                        engine.TriggerMovement(Direction.Down);
                        break;
                    }
                case Keys.A:
                    {
                        engine.TriggerMovement(Direction.Left);
                        break;
                    }
                case Keys.Up:
                    {
                        engine.TriggerAttack(Direction.Up);
                        break;
                    }
                case Keys.Right:
                    {
                        engine.TriggerAttack(Direction.Right);
                        break;
                    }
                case Keys.Down:
                    {
                        engine.TriggerAttack(Direction.Down);
                        break;
                    }
                case Keys.Left:
                    {
                        engine.TriggerAttack(Direction.Left);
                        break;
                    }
            }
            UpdateDisplay();
        }
    }
}
