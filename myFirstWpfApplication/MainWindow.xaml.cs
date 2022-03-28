using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace myFirstWpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static Label source;
        public static int h, w;
    

        private void Label_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;

        }

        private void Label_Drop(object sender, DragEventArgs e)
        {
            Label destination = (Label)sender;

            if (source != null)
            {
                 if (destination.Content.Equals(""))
                {

                    int td = (int)Canvas.GetTop((Label)destination);
                    int tl = (int)Canvas.GetLeft((Label)destination);

                    int sd = (int)Canvas.GetTop((Label)source);
                    int sl = (int)Canvas.GetLeft((Label)source);

                    if (((Math.Abs(td - sd) < 2 * h) && (tl == sl)) || ((Math.Abs(tl - sl) < 2 * w) && (td == sd)))
                    {

                        Brush newColor = destination.Background;
                        String text = destination.Content.ToString();
                        destination.Content = ((Label)source).Content.ToString();
                        destination.Background = ((Label)source).Background;

                        ((Label)source).Content = text;
                        ((Label)source).Background = newColor;
                    }
                }
            }

        }

        private void Canvas_Initialized(object sender, EventArgs e)
        {
            h = Convert.ToInt32(lbl1.Height);
            w = Convert.ToInt32(lbl1.Width);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            int[] x = new int[8];
            Random rnd = new Random();
            int i = 0, n;
            while (i < 8)
            {
                n = rnd.Next()%8;                
                    if (x[n] == 0)
                    {
                        x[n] = i + 1;
                        i++;
                    }
                }
            lbl1.Content = x[0].ToString();
            lbl2.Content = x[1].ToString();
            lbl3.Content = x[2].ToString();
            lbl4.Content = x[3].ToString();
            lbl5.Content = x[4].ToString();
            lbl6.Content = x[5].ToString();
            lbl7.Content = x[6].ToString();
            lbl8.Content = x[7].ToString();
            lbl9.Content = "";

        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            source = (Label)sender;
            DragDrop.DoDragDrop(source, source.Content, DragDropEffects.Copy);
           
        }
    }
}
