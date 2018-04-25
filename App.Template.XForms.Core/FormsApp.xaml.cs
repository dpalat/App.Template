using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using App.Template.XForms.Core.MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Views;

namespace App.Template.XForms.Core
{
    public partial class FormsApp
    {
        #region Constructors

        public FormsApp()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        public IMvxViewsContainer LoadViewsContainer(IMvxViewsContainer viewsContainer)
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

        #endregion
    }
}