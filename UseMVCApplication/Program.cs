using System;
using WinFormMVC.View;
using WinFormMVC.Controller;


namespace UseMVCApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UsersView view = new UsersView();
            Controller controller = new Controller(view);
            view.ShowDialog();
        }
    }
}
