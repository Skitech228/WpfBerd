using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool znach = false;
        bool znach2 = false;
        string Datte = DateTime.Now.ToLongTimeString();
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {

            Timer.Content = DateTime.Now.ToLongTimeString();
        }




        private void Water_Click(object sender, RoutedEventArgs e)
        {
            rectangle.VerticalAlignment = VerticalAlignment.Top;
            DoubleAnimation rectangleanimation = new DoubleAnimation();
            rectangleanimation.From = rectangle.ActualHeight;
            rectangleanimation.To = rectangle.ActualHeight - 10;
            rectangleanimation.Duration = TimeSpan.FromSeconds(2);
            rectangle.BeginAnimation(Rectangle.HeightProperty, rectangleanimation);
            rectangle.VerticalAlignment = VerticalAlignment.Bottom;
        }

        private void Feed_Click(object sender, RoutedEventArgs e)
        {
            rectangle2.VerticalAlignment = VerticalAlignment.Bottom;
            DoubleAnimation rectangleanimation = new DoubleAnimation();
            rectangleanimation.From = rectangle2.ActualHeight;
            rectangleanimation.To = rectangle2.ActualHeight - 10;
            rectangleanimation.Duration = TimeSpan.FromSeconds(2);
            rectangle2.BeginAnimation(Rectangle.HeightProperty, rectangleanimation);

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime date1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 00, 00);
            double a = DateTime.Now.Subtract(date1).TotalMinutes / 60;
            if (a > 0)
            {
                Water.IsEnabled = false;
                Feed.IsEnabled = false;
                ColorAnimation col = new ColorAnimation();
                col.Duration = TimeSpan.FromSeconds(2);
                col.From = Colors.White;
                col.To = Colors.Gray;
                Greed.Background = new SolidColorBrush(Colors.White);
                Greed.Background.BeginAnimation(SolidColorBrush.ColorProperty, col);
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri("spyashhij-popugaj.jpg", UriKind.Relative);
                bi3.EndInit();
                Berd.Source = bi3;
            }
        }

        private void Zadat_Click(object sender, RoutedEventArgs e)
        {
            if (myTextBox.Text != "" && int.Parse(myTextBox_Copy.Text) < 420)
                znach = true;
        }

        private void Greed_MouseMove(object sender, MouseEventArgs e)
        {
            string[] words = myTextBox.Text.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (znach2 == true && DateTime.Now.Hour==int.Parse(words[0]) && DateTime.Now.Minute == int.Parse(words[1]))
            {
                rectangle2.VerticalAlignment = VerticalAlignment.Bottom;
                DoubleAnimation rectangleanimation = new DoubleAnimation();
                rectangleanimation.From = rectangle2.ActualHeight;
                rectangleanimation.To = int.Parse(myTextBox_Copy.Text);
                rectangleanimation.Duration = TimeSpan.FromSeconds(2);
                rectangle2.BeginAnimation(Rectangle.HeightProperty, rectangleanimation);
            }
            if(znach==true && DateTime.Now.Hour == int.Parse(words[0]) && DateTime.Now.Minute == int.Parse(words[1]))
            {
                rectangle.VerticalAlignment = VerticalAlignment.Top;
                DoubleAnimation rectangleanimation = new DoubleAnimation();
                rectangleanimation.From = rectangle.ActualHeight;
                rectangleanimation.To = int.Parse(myTextBox_Copy.Text);
                rectangleanimation.Duration = TimeSpan.FromSeconds(2);
                rectangle.BeginAnimation(Rectangle.HeightProperty, rectangleanimation);
                rectangle.VerticalAlignment = VerticalAlignment.Bottom;
            }
        }

        private void Zadat_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (myTextBox.Text != "" && int.Parse(myTextBox_Copy.Text) < 420)
                znach2 = true;
        }

        private void Greed_KeyDown(object sender, KeyEventArgs e)
        {   
           
        }

        private void MyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

      
    }
}
