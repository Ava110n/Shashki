using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shashki;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    int[,] shashki = new int[8,8];

    public MainWindow()
    {
        InitializeComponent();
        var canvas = new Canvas()
        {
            Name = "canvas",
            Width = 800,
            Height = 800
        };
        this.AddChild(canvas);

        drawBorder(canvas);//рисуется черный квадрат - для границы и черных клеток
        drawCell(canvas);//рисуются белые клетки 
        
        startPosition();//заполняем матрицу shaski
    }

    void drawBorder(Canvas canvas)
    {
        var points = new PointCollection();
        points.Add(new Point(0, 0));
        points.Add(new Point(800, 0));
        points.Add(new Point(800, 800));
        points.Add(new Point(0, 800));

        var polygon = new Polygon()
        {
            Fill = Brushes.Black,
            Points = points,
            Stroke = Brushes.Black,
            StrokeThickness = 5
        };
        canvas.Children.Add(polygon);        
    }
    void drawCell(Canvas canvas)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((i + j) % 2 == 0)
                {
                    var square = new Rectangle()
                    {
                        Fill = Brushes.White,//new SolidColorBrush(Color.FromRgb(0, 0, 0))
                        Width = canvas.Width / 8,
                        Height = canvas.Height / 8,
                        Margin = new Thickness(i * canvas.Width / 8, j * canvas.Height / 8, 0, 0),
                    };
                    canvas.Children.Add(square);
                }
            }
        }
    }

    void drawStartShaski(Canvas canvas)
    {

    }
    void startPosition()
    {
        for(int i=0; i<8; i++)
        {
            for(int j=0; j<8; j++)
            {
                if ((i + j) % 2 == 1)//только черные клетки
                {
                    if (i < 3) shashki[i, j] = 1;
                    if (i > 5) shashki[i, j] = -1;
                }
                
            }
        }
    }
}