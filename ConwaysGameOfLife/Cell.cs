using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class Cell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool alive;

        public Cell() { }

        public Cell(bool alive, int x, int y)
        {
            this.Alive = alive;
            this.X = x;
            this.Y = y;
        }
        public bool Alive { get { return alive; } 
            set {
                alive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Alive"));
            }
        }

        public int X { get; set; }

        public int Y { get; set; }
        public void Cell_Clicked(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Alive = !this.Alive;
        }

        public bool NextIteration()
        {


            return true;
        }

    }
}
