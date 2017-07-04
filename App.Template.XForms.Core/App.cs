using App.Template.XForms.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Presenters;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using App.Template.XForms.Core.MvvmCross;

namespace App.Template.XForms.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            LoadServiceLocator();
            RegisterAppStart<MenuViewModel>();
        }

        public static IMvxViewsContainer LoadViewsContainer(IMvxViewsContainer viewsContainer)
        {
            var viewModelTypes = GetTypesInAssembly("App.Template.XForms.Core", MvvmConfig.ViewModelSuffix);

            var viewTypes = GetTypesInAssembly("App.Template.XForms.Core", MvvmConfig.ViewSuffix);
            foreach (var viewModelTypeAndName in viewModelTypes)
            {
                if (viewTypes.TryGetValue(viewModelTypeAndName.Key, out Type viewType))
                    viewsContainer.Add(viewModelTypeAndName.Value, viewType);
            }
            return viewsContainer;
        }

        private static Dictionary<string, Type> GetTypesInAssembly(string assembyName, string typeSuffix)
        {
            return Assembly.Load(new AssemblyName(assembyName)).CreatableTypes()
                .Where(t => t.Name.EndsWith(typeSuffix))
                .ToDictionary(t => t.Name.Remove(t.Name.LastIndexOf(typeSuffix, StringComparison.Ordinal)));
        }

        private void LoadServiceLocator()
        {
            RegisterAssemblyTypes("App.Template.XForms.Core");
            Mvx.RegisterSingleton<IMvxFormsPageLoader>(new MvxFormsViewLoader());
        }

        private void RegisterAssemblyTypes(string assemblyName)
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