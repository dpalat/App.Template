using MvvmCross.Commands;

namespace App.Template.XForms.Core.Models
{
    public class MenuItem
    {
        public string Text { get; set; }
        public string Image { get; set; }
        public MvxAsyncCommand Command { get; set; }
    }
}