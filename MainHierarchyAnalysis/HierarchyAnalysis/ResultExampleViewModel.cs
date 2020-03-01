using HierarchyAnalysis.mathPart;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyAnalysis
{
    public class ResultExampleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public string People { set; get; }
        public string Criterion { set; get; }
        public string Alternative { set; get; }
        public string Result { set; get; }
        public ResultExampleViewModel(List<double> people, List<List<double>> criterion, List<List<double>> alternatives)
        {
            People ="Оценка сторон:\n"+convertToString(people);
            Criterion = "Оценка критериев:\n"+convertToString(criterion);
            Alternative = "Оценка альтернатив:\n" + convertToString(alternatives);
            double[,] vs = MathCaclulations.MultiplyMatrix(convertToArray(people),convertToArray(criterion),convertToArray(alternatives));
            Result = "Result:\n"+convertToString(vs);
            
        }
        private  string convertToString(double[,] array)
        {
            string str = "";
            for(int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    str += $"{Math.Round(array[i,j], 4),-10}";
                }
                str += "\n";
            }
            return str;
        }
        private string convertToString(List<double> vs)
        {
            string str = "";
            foreach(double i in vs)
            {
                str += $"{Math.Round(i, 4),-10}";
            }
            return str;
        }
        private string convertToString(List<List<double>> array)
        {
            string str = "";
            List<List<string>> vs = new List<List<string>>();
            foreach(List<double> i in array)
            {
                str += convertToString(i) + "\n";
                
            }
            return str;
        }

        private double[,] convertToArray(List<List<double>> list)
        {
            double[,] arr = new double[list.Count, list[0].Count];
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[0].Count; j++)
                {
                    arr[i, j] = list[i][j];
                }
            }
            return arr;
        }
       private double[,] convertToArray(List<double> vs)
        {
            double[,] vs1 = new double[1,vs.Count] ;
            for(int i = 0; i < vs1.GetLength(1); i++)
            {
                vs1[0, i] = vs[i];
            }
            return vs1;
        }
    }
}
