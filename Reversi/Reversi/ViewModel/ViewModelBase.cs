using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Reversi.ViewModel
{
    public class ViewModelBase:Page
    {
        public Frame frame;

        public ViewModelBase(Frame frame)
        {
            this.frame = frame;
        }
        
    }
}
