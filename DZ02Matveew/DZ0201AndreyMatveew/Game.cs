using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        private static List<BaseObject> _objs = new List<BaseObject>();
        private static Bullet _bullet;
        private static List<Comet> _asteroids = new List<Comet>();

        static public Timer timer = new Timer { Interval = 100 };
        static Game()
        {
        }
        public static void Init(Form1 form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();
            
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Comet obj in _asteroids)
                obj.Draw();
            _bullet.Draw();
            Buffer.Render();
        }
        public static void Load()
        {
            int amountPlanets = 8;
            int amountStars = 25;
            int amountComets = 15; 
            Random rand = new Random();
            var min = 10;
            var max = 40;
            var minDir = 3;
            var maxDir = 6;
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));

            for (int i = 0; i < amountComets; i++)
            {
                int size = rand.Next(min, max);
                _asteroids.Add(new Comet(new Point(Convert.ToInt32(rand.NextDouble() * (double)(Game.Width - size)),
                    Convert.ToInt32(rand.NextDouble() * (double)(Game.Height - size))), new Point(rand.Next(minDir, maxDir),
                    rand.Next(minDir, maxDir)), new Size(size, size)));
            }
            for (int i = 0; i < amountStars; i++)
            {
                int size = rand.Next(min, max);
                _objs.Add(new Star(new Point(Convert.ToInt32(rand.NextDouble() * (double)Game.Width),
                    Convert.ToInt32(rand.NextDouble() * (double)Game.Height)), 
                    new Point(rand.Next(1 * 2, 2), 0), new Size(size - 5, size - 5)));
            }
            for (int i = 0; i < amountPlanets; i++)
            {
                int size = rand.Next(min, max);
                _objs.Add(new Planet(new Point(Convert.ToInt32(rand.NextDouble() * (double)Game.Width),
                    Convert.ToInt32(rand.NextDouble() * (double)Game.Height)),
                    new Point(rand.Next(1 * 2, 2), 0), new Size(size - 5, size - 5)));
            }
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            foreach (Comet ast in _asteroids)
            {
                ast.Update();
                if (ast.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _bullet.AfterCollision();
                    ast.AfterCollision();
                }
            }
            _bullet.Update();
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
