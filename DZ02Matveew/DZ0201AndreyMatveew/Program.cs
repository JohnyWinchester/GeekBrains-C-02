using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

/* Матвеев Андрей. Задача 2 и 3.
   2)Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
   3)Сделать так, чтобы при столкновении пули с астероидом они регенерировались в разных концах экрана.
*/

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new Form1();
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
