using ConwaysGameOfLife.Converter;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ConwaysGameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void CreateGrid(object sender, RoutedEventArgs e)
        {
            conwayGrid.Children.Clear();

            Rows = (int)rowSlider.Value;
            Columns = (int)columnSlider.Value;

            Rows = 3;
            Columns = 3;

            UniformGrid conwayUniformGrid = new UniformGrid { Rows = this.Rows, Columns = this.Columns };
            Board.CellBoard = new Cell[Columns, Rows];

            Rectangle rectangle;
            Cell cell;
            Binding b;

            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    cell = new Cell(false, x, y);
                    Board.CellBoard[x, y] = cell;

                    rectangle = new Rectangle
                    {
                        StrokeThickness = 1,
                        Margin = new Thickness(1)
                    };

                    b = new Binding
                    {
                        Path = new PropertyPath("Alive"),
                        Source = cell,
                        Converter = new DeadOrAliveConverter()
                    };

                    conwayUniformGrid.Children.Add(rectangle);
                    rectangle.SetBinding(Rectangle.FillProperty, b);
                    rectangle.MouseDown += cell.Cell_Clicked;
                }
            }

            conwayGrid.Children.Add(conwayUniformGrid);
        }

        private void BtnStepAhead_Click(object sender, RoutedEventArgs e)
        {
            bool[,] deadOrAlive = new bool[Columns, Rows];

            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    deadOrAlive[x, y] = Board.CellBoard[x, y].NextIteration();
                }
            }

            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    Board.CellBoard[x, y].Alive = deadOrAlive[x, y];
                }
            }
        }
    }
}
