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
        private string[] inputdata;
        private List<double> t; 
        private double ugol, v0;

        public BirdFall(string path)
        {
            x_y = new List<Tuple<double, double>>();
            t = new List<double>();
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
            for (int i = 2; i < inputdata.Length; i++)
            {
                t.Add(double.Parse(inputdata[i]));
            }


            double t0 = (2 * v0 * Math.Sin(ugol * 3.14 / 180)) / 9.8;
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

        }

        public void WriteData(string path)
        {
            TextWriter tw = new StreamWriter(path);

            foreach (Tuple<double, double> s in x_y)
                tw.WriteLine(s);

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


            /*
                        double m;
                        //int n = int.Parse(Console.ReadLine());
                        List<Tuple<double, double>> xy = new List<Tuple<double, double>>();
                        List<double> y = new List<double>();


                        string[] lines = System.IO.File.ReadAllLines(@"vvod.txt");

                        double ugol =  double.Parse(lines[0]); //(Console.ReadLine().Replace('.', ','));//в градусах
                        double v0 = double.Parse(lines[1]);
                        for (int i = 2; i < lines.Length; i++)
                        {
                            t.Add(double.Parse(lines[i]));
                        }


                        double t0 = (2 * v0 * Math.Sin(ugol * 3.14 / 180)) / 9.8;
                        double x0 = v0 * t0 * Math.Cos(ugol * 3.14 / 180);
                        double x_promeg; double y_promeg;
                        for (int i = 0; i < lines.Length-2; i++)
                        {
                            if (t[i] < t0)
                            {
                                x_promeg = v0 * t[i] * Math.Cos(ugol * 3.14 / 180);
                                y_promeg = v0 * t[i] * Math.Sin(ugol * 3.14 / 180) - ((9.8 / 2) * t[i] * t[i]);

                                xy.Add(new Tuple<double,double> (x_promeg, y_promeg));

                            }
                            else
                            {
                                xy.Add(new Tuple<double, double>(x0,0));
                            }
                        }//Console.WriteLine(x0 + ";" + 0);}}

                       // t.AddRange(x);
                        //t.AddRange(y);
                        //File.WriteAllText("file.txt", string.Join(" ", t));
                        //double[] res1 = File.ReadAllText("file.txt").Split().Select(double.Parse).ToArray();

                        TextWriter tw = new StreamWriter("output.txt");

                        foreach (Tuple<double,double> s in xy)
                            tw.WriteLine(s);

                        tw.Close();

                        // File.WriteAllText("file.txt", string.Join(" ", x));double[] res2 = File.ReadAllText("file.txt").Split().Select(double.Parse).ToArray();
                        //File.WriteAllText("file.txt", string.Join(" ", y));double[] res3 = File.ReadAllText("file.txt").Split().Select(double.Parse).ToArray();
                        //File.WriteAllLines("vivod.txt",new Array[]= {xy});

                        //File.WriteAllText("file.txt", string.Join(" ", t + Environment.NewLine));
                        // File.AppendAllText("file.txt", string.Join(" ", x + Environment.NewLine));
                        //File.AppendAllText("file.txt", string.Join(" ", y + Environment.NewLine));
                        //List<double> x1 = new List<double>();
                        //List<double> y1 = new List<double>();
                        //List<double> t1 = new List<double>();
                        //for (int i = 0; i < n; i++)
                        //{
                        //    t.Add(res1[i]);
                        //    Console.WriteLine(t[i] + " ");
                        //}
                        //for (int i = n; i < 2 * n; i++)
                        //{
                        //    xy.Add(res1[i]);
                        //    Console.WriteLine(x[i] + " ");
                        //}
                        //for (int i = 2 * n; i < 3 * n; i++)
                        //{
                        //    y.Add(res1[i]);
                        //    Console.WriteLine(y[i] + " ");
                        //}
                        //Console.WriteLine(string.Join(" ", res1));

                        // Console.WriteLine(string.Join(" ", res2));
                        //Console.WriteLine(string.Join(" ", res3));
            */

        }
    }
}

