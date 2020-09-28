﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Добавил свой объект
namespace WindowsFormsApp1
{
    class Planet : BaseObject
    {
        Image image = Image.FromFile(@"E:\GeekBrains\C# 02\DZ01Matveew\DZ0101AndreyMatveew\images\марс.jpg");
        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X + Size.Width, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
