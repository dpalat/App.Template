using System.Linq;
using System.Reflection;
using App.Template.XForms.Core.ViewModels;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace App.Template.XForms.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<LoginViewModel>();
        }

        public static void LoadServiceLocator()
        {
            RegisterAssemblyTypes("App.Template.XForms.Core");
        }

        private static void RegisterAssemblyTypes(string assemblyName)
        {
            // By default register All types as interface and dynamic.
            Assembly.Load(new AssemblyName(assemblyName)).CreatableTypes()
                .AsInterfaces()
                .RegisterAsDynamic();

            // Override Models registration, are register as Types.
            // An POCO should not has behavior therefore not are required interfaces for testeability.
            Assembly.Load(new AssemblyName(assemblyName)).CreatableTypes()
                .Where(t => t.Namespace.EndsWith("Models"))
                .AsTypes()
                .RegisterAsDynamic();

            // Override Services registration. Are register as Singletons.
            Assembly.Load(new AssemblyName(assemblyName)).CreatableTypes()
                .Where(t => t.Namespace.EndsWith("Services") && t.Name.EndsWith("Service"))
                .AsInterfaces()
                .RegisterAsLazySingleton();
        }

    }
}