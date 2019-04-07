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
    class Text_text : Very_Global
    {
        static List<TextBox> txtbox;
        static Label lbl1;

        static StackPanel stack;
        static Grid grid1;
        static Grid grid2;
        static Button btn;
        static Button btn2;

        static List<string> promeg_inpath;
       
        public Text_text()
        {

            promeg_inpath = new List<string>();

            MinWidth = 300;
            SizeToContent = SizeToContent.WidthAndHeight;

            stack = new StackPanel();

            Content = stack;

            grid1 = new Grid();

            grid1.Margin = new Thickness(5);
            stack.Children.Add(grid1);
            for (int i = 0; i < 6; i++)
            {

                RowDefinition rowdef = new RowDefinition();

                rowdef.Height = GridLength.Auto;

                grid1.RowDefinitions.Add(rowdef);

            }

            ColumnDefinition coldef = new ColumnDefinition();

            coldef.Width = GridLength.Auto;

            grid1.ColumnDefinitions.Add(coldef);

            coldef = new ColumnDefinition();

            coldef.Width = new GridLength(100, GridUnitType.Star);

            grid1.ColumnDefinitions.Add(coldef);  
            TextBox txtbx;
            txtbox = new List<TextBox>();
            for (int i = 0; i < 6; i++)
            {
                txtbx = new TextBox();
                txtbox.Add(txtbx);


            }


          

            string[] strLabels = { "х0:", "у0:", "Начальная скорость:", "Угол (в градусах):", "Масса тела:", "Сопротивление воздуха" };// задаётся массив строк
            for (int i = 0; i < strLabels.Length; i++)
            {
                lbl1 = new Label();
                lbl1.Content = strLabels[i];
                lbl1.VerticalContentAlignment = VerticalAlignment.Center;

                grid1.Children.Add(lbl1);

                Grid.SetRow(lbl1, i);

                Grid.SetColumn(lbl1, 0);

               

                txtbox[i].Margin = new Thickness(5);

                grid1.Children.Add(txtbox[i]);

                Grid.SetRow(txtbox[i], i);

                Grid.SetColumn(txtbox[i], 1);
            }

            grid2 = new Grid();

            grid2.Margin = new Thickness(10);

            stack.Children.Add(grid2);

            grid2.ColumnDefinitions.Add(new ColumnDefinition());

            grid2.ColumnDefinitions.Add(new ColumnDefinition());

            btn = new Button();
            btn.IsEnabled = false;
            btn.Content = "OK";

           

            btn.HorizontalAlignment = HorizontalAlignment.Center;

            btn.IsDefault = true;
            for (int i = 0; i < strLabels.Length; i++)
            {
                txtbox[i].TextChanged += vvod_texta;
            }
           
            btn.Click += get_information;
           
            grid2.Children.Add(btn);

            btn2 = new Button();

            btn2.Content = "Cancel";

            btn2.HorizontalAlignment = HorizontalAlignment.Center;

            btn2.IsCancel = true;

            btn2.Click += for_cancel;



            grid2.Children.Add(btn2);

            Grid.SetColumn(btn2, 1);

            (stack.Children[0] as Panel).Children[1].Focus();
           
            ShowDialog();

          

        }

        void vvod_texta(object sender, RoutedEventArgs args)
        {
            btn.IsEnabled = false;

            double z;
            if (
               (txtbox[0].Text.Length == 0) || (!double.TryParse(txtbox[0].Text, out z)) ||
                (txtbox[1].Text.Length == 0) || (!double.TryParse(txtbox[1].Text, out z)) || (txtbox[2].Text.Length == 0) || (!double.TryParse(txtbox[2].Text, out z)) ||
                (txtbox[3].Text.Length == 0) || (!double.TryParse(txtbox[3].Text, out z)) || (txtbox[4].Text.Length == 0) || (!double.TryParse(txtbox[4].Text, out z)) ||
                (txtbox[5].Text.Length == 0) || (!double.TryParse(txtbox[5].Text, out z))
                || (txtbox[0].Text.Length > 5) || (txtbox[1].Text.Length > 5) || (txtbox[2].Text.Length > 5) || (txtbox[3].Text.Length > 5) || (txtbox[4].Text.Length > 5)
                || (txtbox[5].Text.Length > 5) 
                )

            {


                
                btn.IsEnabled = false;
               

            }
            else { btn.IsEnabled = true; }
        }

       

        void get_information(object sender, RoutedEventArgs args)

        {
            


            TextWriter tw1 = new StreamWriter(inpath);

            for (int i = 0; i < 6; i++)
            {
                tw1.WriteLine(txtbox[i].Text + "\t");
            }
            tw1.Close();

        
            Close();
            Message_box bx = new Message_box("Данные сохранены");
            
        }

        void for_cancel(object sender, RoutedEventArgs args)
        {
            Close();
            

        }

       


    }
}
