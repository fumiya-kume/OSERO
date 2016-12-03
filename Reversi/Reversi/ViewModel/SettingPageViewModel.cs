using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Reversi.ViewModel
{
    public class SettingPageViewModel
    {
        private readonly Frame frame;

        public SettingPageViewModel(Frame frame)
        {
            this.frame = frame;
        }
    }
}
