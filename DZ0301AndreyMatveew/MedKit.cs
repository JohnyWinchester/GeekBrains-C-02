using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class MedKit : BaseObject
    {
        Image image;
        public int power = 5;
        public MedKit(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = Image.FromFile(@"images\Medkit.png");
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width + 20, Size.Height + 20);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0 - Size.Width)
            {
                AfterCollision();
            }
        }
        public void AfterCollision()
        {
            this.Pos.X = Game.Width + Size.Width;
            this.Pos.Y = new Random().Next(1, 600);
        }
    }
}
