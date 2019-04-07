using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace angry_birds
{
    class Grafic : Window
    {
        static Polyline graf;
        static Grid grid3;
        //private List<Tuple<double, double>> inputdata;
        static Canvas canv;
        static PointCollection grafPoints;
        static string[] inputdata;
        static double masshtabx;
        static double masshtaby;
        static int j;
        public Grafic(string path)
        {
            //Console.WriteLine
            inputdata = readData(path);

            double a = double.Parse(inputdata[inputdata.Length - 2]);
            double b = double.Parse(inputdata[inputdata.Length - 1]);

            MinHeight = 600;
            MinWidth = 800;
            masshtabx = a / MinWidth;
            masshtaby = b / MinHeight;
            //MinWidth =(int)(a)+20;
            //MinHeight = (int)(b)+20;

            SizeToContent = SizeToContent.WidthAndHeight;

            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;
           // double z;
            grid3 = new Grid();
            grid3.Margin = new Thickness(5);
            canv = new Canvas();
            Content = grid3;
            grid3.RowDefinitions.Add(new RowDefinition());
            graf = new Polyline();
            graf.Stroke = blackBrush;
            graf.StrokeThickness = 4;
            grafPoints = new PointCollection();
            j = 0;



           // for (int i = 0; i < inputdata.Length - 1; i = i + 2)
           // {
           //     if ((!double.TryParse(inputdata[i], out z)) || (!double.TryParse(inputdata[i + 1], out z))) return;
             //   ;
           // }
               

           // TimerCallback tm = new TimerCallback(Count);
            // создаем таймер
            //Timer timer = new Timer(tm, 0, 0, 2000);
           grid3.Children.Add(graf); Grid.SetRow(graf, 0);
            // Console.ReadLine();
            DispatcherTimer tmr = new DispatcherTimer();//создаётся таймер
            tmr.Interval = TimeSpan.FromMilliseconds(10);// таймер на 10 секунд
            tmr.Tick += TimerOnTick;// добавляется обработчик, который срабатывает по истечению интервала
            tmr.Start();//запускается таймер
        

        ShowDialog();

            
            //grid3.Children.Remove(graf);
            //DispatcherTimer tmr = new DispatcherTimer();//создаётся таймер
            //tmr.Interval = TimeSpan.FromMilliseconds(100);// таймер на 10 секунд
            //tmr.Tick += timer;// добавляется обработчик, который срабатывает по истечению интервала
           


        }

        void TimerOnTick(object sender, EventArgs args)
        {
           




            grafPoints.Add(
                     new System.Windows.Point(double.Parse(inputdata[j]) / masshtabx, 600 - double.Parse(inputdata[j + 1]) / masshtaby));
            j=j+2;
            graf.Points = grafPoints; 
           if (j>= (inputdata.Length - 3)) (sender as DispatcherTimer).Stop();
            
              }
                // {

               
               

            



        
        private void timer(object sender, EventArgs e)
        {



        }
        private string[] readData(string path)
        {
            return System.IO.File.ReadAllLines(path);
        }



    }
}