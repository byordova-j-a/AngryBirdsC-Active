using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace angry_birds
{
    class BirdFall : Very_Global

    {
        private List<Tuple<double, double>> x_y;
        private List<Tuple<double, double>> vx_vy;
        private string[] inputdata;
        //static Line line;
        //static Canvas canv;
        private double ugol, v0, m, k, x0, y0, t;

        public BirdFall(string path)
        {
            x_y = new List<Tuple<double, double>>();
            vx_vy = new List<Tuple<double, double>>();
           
            inputdata = readData(path);


        }

        

        private string[] readData(string path)
        {
            return System.IO.File.ReadAllLines(path);
        }

        public void CalculateXY()
        {

            //line = new Line();
            //canv = new Canvas();
          //  lne.X1 = 10;
          //  lne.X2 = 11;
           // lne.Y1 = 10;
           // lne.Y2 = 10;
           // canvas1.Children.Add(lne);


            x0 = double.Parse(inputdata[0]);
            y0 = double.Parse(inputdata[1]);
            v0 = double.Parse(inputdata[2]);
            ugol = double.Parse(inputdata[3]); //в градусах

            m = double.Parse(inputdata[4]);
            k = double.Parse(inputdata[5]);

            t = double.Parse(inputdata[6]);
            double vx0 = v0 * Math.Cos(ugol * 3.14 / 180);
            double vy0 = v0 * Math.Sin(ugol * 3.14 / 180);
            double delta_t = t / 100;
            x_y.Add(new Tuple<double, double>(x0, y0));
            vx_vy.Add(new Tuple<double, double>(vx0, vy0));
          // line.X1 = x0;
           // line.Y1 = y0;
            double mx, my;
            for (int i = 0; i < 100; i++)
            {
                mx = vx_vy[i].Item1 - (k / m) * vx_vy[i].Item1 * delta_t;


                my = vx_vy[i].Item2 - (9.8 + (k / m) * vx_vy[i].Item2) * delta_t;
                vx_vy.Add(new Tuple<double, double>(mx, my));

                mx = x_y[i].Item1 + vx_vy[i].Item1 * delta_t;

                my = x_y[i].Item2 + vx_vy[i].Item2 * delta_t;
                if (my > 0)
                {
                    x_y.Add(new Tuple<double, double>(mx, my));
                   // line.X2 = mx;
                   // line.Y2 = my;
                   // canv.Children.Add(line);
                    //line.X1 = mx;
                   // line.Y1 = my;
                }
                else  {x_y.Add(new Tuple<double, double>(mx, 0));
               
                   // line.X2 = mx;
                  // line.Y2 = 0;
                   // canv.Children.Add(line);

                    return;
                }

            }
        }

       
        public void WriteData(string path)
        {
            TextWriter tw = new StreamWriter(path);

            foreach (Tuple<double, double> s in x_y)
                tw.WriteLine(s.Item1 + "\t" + s.Item2);

            tw.Close();
        }

    }
}