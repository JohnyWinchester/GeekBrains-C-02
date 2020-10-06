using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Ship : BaseObject
    {
        private static int fullHP = 100;
        private int hp = 100;
        public static event Message MessageDie;
        public int Energy => hp;
        Image image;

        public void EnergyLow(int n)
        {
            hp -= n;
        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = Image.FromFile(@"images\SpaceShip.png");
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width + 20, Size.Height + 20);
        }
        public override void Update()
        {
        }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }
        public void Die()
        {
            MessageDie?.Invoke();
        }
        public void HPFull(int power)
        {
            if (hp < fullHP)
            {
                if (hp + power > fullHP)
                {
                    hp = fullHP;
                }
                else
                {
                    hp += power;
                }
            }
        }
    }
}
