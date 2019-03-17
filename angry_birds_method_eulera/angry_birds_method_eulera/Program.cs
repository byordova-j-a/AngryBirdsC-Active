using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace angry_birds_version1
{
    class BirdFall
    {
        private List<Tuple<double, double>> x_y;
        private List<Tuple<double, double>> vx_vy;
        private string[] inputdata;
        // private List<double> dela_t;
        private double ugol, v0, m, k, x0, y0, t;

        public BirdFall(string path)
        {
            x_y = new List<Tuple<double, double>>();
            vx_vy = new List<Tuple<double, double>>();
            //t = new List<double>();
            inputdata = readData(path);
        }

        private string[] readData(string path)
        {
            return System.IO.File.ReadAllLines(path);
        }

        public void CalculateXY()
        {
            ugol = double.Parse(inputdata[0]); //(Console.ReadLine().Replace('.', ','));//в градусах
            v0 = double.Parse(inputdata[1]);
            m = double.Parse(inputdata[2]);
            k = double.Parse(inputdata[3]);
            x0 = double.Parse(inputdata[4]);
            y0 = double.Parse(inputdata[5]);

            t = double.Parse(inputdata[6]);
            double vx0 = v0 * Math.Cos(ugol * 3.14 / 180);
            double vy0 = v0 * Math.Sin(ugol * 3.14 / 180);
            double delta_t = t / 100;
            x_y.Add(new Tuple<double, double>(x0, y0));
            vx_vy.Add(new Tuple<double, double>(vx0, vy0));
            double mx, my;
            for (int i = 0; i < 100; i++)
            {
                mx = vx_vy[i].Item1 - (k / m) * vx_vy[i].Item1 * delta_t;


                my = vx_vy[i].Item2 - (9.8 + (k / m) * vx_vy[i].Item2) * delta_t;
                vx_vy.Add(new Tuple<double, double>(mx, my));

                mx = x_y[i].Item1 + vx_vy[i].Item1 * delta_t;

                my = x_y[i].Item2 + vx_vy[i].Item2 * delta_t;
                if (my > 0)
                    x_y.Add(new Tuple<double, double>(mx, my));
                else x_y.Add(new Tuple<double, double>(mx, 0));
            }
        }

        //Console.WriteLine(x[i] + ";" + y[i]);

        //for (int i = 2; i < inputdata.Length; i++)
        // {
        //    t.Add(double.Parse(inputdata[i]));
        //}


        /* double t0 = (2 * v0 * Math.Sin(ugol * 3.14 / 180)) / 9.8;
         double x0 = v0 * t0 * Math.Cos(ugol * 3.14 / 180);
         double x_promeg; double y_promeg;
         for (int i = 0; i < inputdata.Length - 2; i++)
         {
             if (t[i] < t0)
             {
                 x_promeg = v0 * t[i] * Math.Cos(ugol * 3.14 / 180);
                 y_promeg = v0 * t[i] * Math.Sin(ugol * 3.14 / 180) - ((9.8 / 2) * t[i] * t[i]);
 
                 x_y.Add(new Tuple<double, double>(x_promeg, y_promeg));
 
             }
             else
             {
                 x_y.Add(new Tuple<double, double>(x0, 0));
             }
         }
*/


        public void WriteData(string path)
        {
            TextWriter tw = new StreamWriter(path);

            foreach (Tuple<double, double> s in x_y)
                tw.WriteLine(s.Item1 + "\t" + s.Item2);

            tw.Close();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {


            string inpath = "vvod.txt", outpath = "output.txt";
            BirdFall bf = new BirdFall(inpath);
            bf.CalculateXY();
            bf.WriteData(outpath);
        }
    }
}