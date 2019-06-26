using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mvvm.ViewModel
{
    public class AboutViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
    }
}
