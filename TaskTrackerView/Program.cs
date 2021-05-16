using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskTrackerBusinessLogic.Interfaces;
using Unity;

using TaskTrackerBusinessLogic.BusinessLogics;
using TaskTrackerBusinessLogic.ViewModels;
using TaskTrackerDatabase.Implements;
using Unity.Lifetime;


namespace TaskTrackerView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new UnityContainer().AddExtension(new Diagnostic());
            Application.Run(container.Resolve<FormEntry>());

        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IUserStorage, UserStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICustomerStorage, CustomerStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProjectStorage, ProjectStorage>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITaskStorage, TaskStorage>(new
          HierarchicalLifetimeManager());
            //currentContainer.RegisterType<ITaskProjectStorage, TaskofprojectStorage>(new HierarchicalLifetimeManager());


            currentContainer.RegisterType<UserLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<CustomerLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ProjectLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<TaskofprojectLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
