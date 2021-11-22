using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceLayer;
using DataAccessLayer;

namespace Курсовой_проект_2
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
            var view = new Form1();
            var db = new Database("Data/accounts.xml");
            view.Presenters = new PresentersContainer() { MainPresenter = new MainPresenter(db), LoginPresenter = new LoginPresenter(db) };
            view.Show();
            Application.Run();
        }
    }
}
