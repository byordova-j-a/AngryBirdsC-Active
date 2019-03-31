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

    class vneshnya_Panel : Very_Global
    {
        
        static string inpathnul;
        
        [STAThread]
        public static void Main()
        {
            inpathnul = "vvod.txt";
            TextWriter tw = new StreamWriter(inpathnul);

            for (int i = 0; i < 7; i++)
            {
                tw.WriteLine("0" + "\t");
            }

            tw.Close();
            
            inpath = inpathnul;
            BirdFall bf0 = new BirdFall(inpath);
            bf0.CalculateXY();
            string outpath = "output.txt";
            bf0.WriteData(outpath);
            Application app = new Application();
            app.Run(new vneshnya_Panel());
        }
        public vneshnya_Panel()
        {

           
            Title = "Полёт";
            MinWidth = 1000;
            MinHeight = 600;
            SizeToContent = SizeToContent.WidthAndHeight;

           
            Grid grid1 = new Grid(); Content = grid1;
          
            grid1.Margin = new Thickness(5);


            RowDefinition rowdef1 = new RowDefinition();
            rowdef1.Height = new GridLength(90, GridUnitType.Star);
            grid1.RowDefinitions.Add(rowdef1);
                                             
            RowDefinition rowdef2 = new RowDefinition();
            rowdef2.Height = new GridLength(10, GridUnitType.Star);

            grid1.RowDefinitions.Add(rowdef2);
            Grid grid2 = new Grid();
            Label lbl1 = new Label();
            lbl1.Content = "cat1";
            Uri uri = new Uri("pack://application:,,/catcat.png"); 
            //.//не забыть в свойствах действие при сборке resource
            BitmapImage bitmap = new BitmapImage(uri);
            Image img = new Image();


            img.Margin = new Thickness(0, 10, 0, 0);
            img.Source = bitmap;
            img.Stretch = Stretch.None;
            grid1.Children.Add(img);
            grid1.Children.Add(grid2);
            
            Grid.SetRow(img, 0);
            Grid.SetRow(grid2, 1);
            RowDefinition rowdef3 = new RowDefinition();
            grid2.RowDefinitions.Add(rowdef3);
            rowdef3.Height = new GridLength(30, GridUnitType.Star);
            for (int i = 0; i < 3; i++)
            {
                grid2.ColumnDefinitions.Add(new ColumnDefinition());

            }


            Button btn1 = new Button();
            Button btn2 = new Button();

            Button btn3 = new Button();
           
            btn1.VerticalAlignment = VerticalAlignment.Bottom;
            btn2.VerticalAlignment = VerticalAlignment.Bottom;
            btn3.VerticalAlignment = VerticalAlignment.Bottom;
            btn1.Content = "Ввод данных";
            btn2.Content = "Пуск";
            btn3.Content = "Сброс данных";
           
            btn1.Click += ButtonOnClick_for_one;
            btn2.Click += ButtonOnClick_for_two;
            btn3.Click += ButtonOnClick_for_three;
           
            grid2.Children.Add(btn1);
            grid2.Children.Add(btn2);
            grid2.Children.Add(btn3);
            Grid.SetColumn(btn1, 0);
            Grid.SetColumn(btn2, 1);

            Grid.SetColumn(btn3, 2);

        }
        void ButtonOnClick_for_one(object sender, RoutedEventArgs args)
        {
            Text_text a = new Text_text();

        }

        void ButtonOnClick_for_two(object sender, RoutedEventArgs args)
        {
            BirdFall bf = new BirdFall(inpath);
            bf.CalculateXY();
            string outpath = "output.txt";
            bf.WriteData(outpath);
            

            Message_box bx = new Message_box("Тело летит");
        }
        void ButtonOnClick_for_three(object sender, RoutedEventArgs args)
        {
            inpathnul = "vvod.txt";
            TextWriter tw = new StreamWriter(inpathnul);

            for (int i = 0; i < 7; i++)
            {
                tw.WriteLine("0" + "\t");
            }

            tw.Close();
            inpath = inpathnul;
            BirdFall bf = new BirdFall(inpath);
            bf.CalculateXY();
            string outpath = "output.txt";
            bf.WriteData(outpath);
            Message_box bx = new Message_box("Данные сброшены");
        }


    }
}