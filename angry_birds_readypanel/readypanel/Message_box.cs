using System;

using System.Windows;

using System.Windows.Controls;

using System.Windows.Input;

using System.Windows.Media;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace angry_birds
{
    class Message_box : Very_Global
    {
        static StackPanel stack;
        static Grid grid;
        static Button btn;
        static Label lbl;
        public Message_box(string m)
        {
            SizeToContent = SizeToContent.WidthAndHeight;
             

            SizeToContent = SizeToContent.WidthAndHeight;

            stack = new StackPanel();

            Content = stack;

            grid = new Grid();

            grid.Margin = new Thickness(5);

            stack.Children.Add(grid);

           

            for (int i = 0; i < 2; i++)
            {


                grid.RowDefinitions.Add(new RowDefinition());


            }
            lbl = new Label();
            lbl.Content = m;
            lbl.HorizontalContentAlignment = HorizontalAlignment.Center;
            btn = new Button();

            btn.Content = "OK";
            btn.IsDefault = true;
            btn.HorizontalContentAlignment = HorizontalAlignment.Center;
            grid.Children.Add(lbl);
            grid.Children.Add(btn);
            Grid.SetRow(lbl, 0);
            Grid.SetRow(btn, 1);
            btn.Click += delegate { Close(); };

            ShowDialog();

        }
    }
}