﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Comet : BaseObject
    {
        Image image;
        public Comet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = Image.FromFile(@"images\comet.jpg");
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width - Size.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height - Size.Height) Dir.Y = -Dir.Y;
        }
        public void AfterCollision()
        {
            this.Pos.X = 599;
            this.Pos.Y = 499;
        }
    }
}
