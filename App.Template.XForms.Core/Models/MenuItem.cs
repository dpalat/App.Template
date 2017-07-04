using MvvmCross.Core.ViewModels;

namespace App.Template.XForms.Core.Models
{
    public class MenuItem
    {
        public string Text { get; set; }
        public string Image { get; set; }
        public MvxCommand Command { get; set; }
    }
}