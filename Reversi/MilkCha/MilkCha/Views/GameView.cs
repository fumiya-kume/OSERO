using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MilkCha.Views
{
    public class GameView : ContentView
    {
        public GameView()
        {
            Content = new Label { Text = "Hello View" };
        }
    }
}
