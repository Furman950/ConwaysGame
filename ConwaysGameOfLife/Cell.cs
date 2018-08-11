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
            int neighborsCount = 0;

            //Top Left
            try
            {
                if (Board.CellBoard[(X - 1), (Y - 1)].Alive)
                    neighborsCount++;
            }
            catch (IndexOutOfRangeException e)
            { }


            //Top
            try
            {
                if (Board.CellBoard[X, (Y - 1)].Alive)
                    neighborsCount++;
            }
            catch (IndexOutOfRangeException e)
            { }


            //Top Right
            try
            {
                if (Board.CellBoard[(X - 1), (Y - 1)].Alive)
                    neighborsCount++;
            }
            catch (IndexOutOfRangeException e)
            { }


            //Left
            try
            {
                if (Board.CellBoard[(X - 1), Y].Alive)
                    neighborsCount++;
            }
            catch (IndexOutOfRangeException e)
            { }


            //Right
            try
            {
                if (Board.CellBoard[(X + 1), Y].Alive)
                    neighborsCount++;
            }
            catch (IndexOutOfRangeException e)
            { }


            //Bottom Left
            try
            {
                if (Board.CellBoard[(X - 1), (Y + 1)].Alive)
                    neighborsCount++;
            }
            catch (IndexOutOfRangeException e)
            { }

            //Bottom
            try
            {
                if (Board.CellBoard[X, (Y + 1)].Alive)
                    neighborsCount++;
            }
            catch (IndexOutOfRangeException e)
            { }


            //Bottom Right
            try
            {
                if (Board.CellBoard[(X + 1), (Y + 1)].Alive)
                    neighborsCount++;
            }
            catch (IndexOutOfRangeException e)
            { }
            


            if (neighborsCount < 2)
                return false;


            if (neighborsCount > 3)
                return false;

            if (neighborsCount == 3)
                return true;

            if (this.Alive && (neighborsCount == 2 || neighborsCount == 3))
                return true;

            return false;

        }

    }
}
