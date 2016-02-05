using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BoredGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class CompBoard : Page
    {
        private Dictionary<Rectangle, int> tile = new Dictionary<Rectangle, int>();
        private List<String> myRectangles = new List<String>();
        private Random r = new Random();

        public CompBoard()
        {
            this.InitializeComponent();
            
            setBoard();
            //setRectangle();

        }

        public void setBoard()
        {
            int treasure = 0;

            tile.Add(a1, treasure); tile.Add(a2, treasure); tile.Add(a3, treasure); tile.Add(a4, treasure); tile.Add(a5, treasure); tile.Add(a6, treasure); 
            tile.Add(b1, treasure); tile.Add(b2, treasure); tile.Add(b3, treasure); tile.Add(b4, treasure); tile.Add(b5, treasure); tile.Add(b6, treasure); 
            tile.Add(c1, treasure); tile.Add(c2, treasure); tile.Add(c3, treasure); tile.Add(c4, treasure); tile.Add(c5, treasure); tile.Add(c6, treasure); 
            tile.Add(d1, treasure); tile.Add(d2, treasure); tile.Add(d3, treasure); tile.Add(d4, treasure); tile.Add(d5, treasure); tile.Add(d6, treasure); 
            tile.Add(e1, treasure); tile.Add(e2, treasure); tile.Add(e3, treasure); tile.Add(e4, treasure); tile.Add(e5, treasure); tile.Add(e6, treasure); 
            tile.Add(f1, treasure); tile.Add(f2, treasure); tile.Add(f3, treasure); tile.Add(f4, treasure); tile.Add(f5, treasure); tile.Add(f6, treasure); 
            
            buryTreasure();

        }//textboxBoard

        public void buryTreasure()
        {
            int count = 5;
            int treasure = 1;
            String position;
            Rectangle pos = new Rectangle();

            for(int i=0; i< count; i++)
            {
                position = getRandom();
                pos.Name = position;
                if (tile.ContainsKey(pos))
                {
                    while (tile[pos] == treasure)
                    {
                        position = getRandom();
                    }
                    tile[pos] = treasure;
                }
            }

        }

        public String getRandom()
        {
            int num1 = r.Next(99) % 6;
            int num2 = r.Next(99) % 5;
            char letter = ' ';

            switch (num1)
            {
                case 0:
                    letter = 'a';
                    break;
                case 1:
                    letter = 'b';
                    break;
                case 2:
                    letter = 'c';
                    break;
                case 3:
                    letter = 'd';
                    break;
                case 4:
                    letter = 'e';
                    break;
                case 5:
                    letter = 'f';
                    break;
                
            }
            num2++;
            String pos = (letter + "" + num2);
            return pos;
        }//getRandom

        public void setRectangle()
        {
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/water.jpg"));

            foreach (Rectangle rect in tile.Keys)
            {
                rect.Fill = img;
            }
        }

        private void a1_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void a2_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void a3_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void a4_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void a5_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void a6_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void b1_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void b2_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void b3_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void b4_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void b5_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void b6_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void c1_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void c2_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void c3_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void c4_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void c5_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void c6_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void d1_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void d2_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void d3_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void d4_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void d5_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void d6_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void e1_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void e2_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void e3_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void e4_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void e5_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void e6_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void f1_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void f2_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void f3_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void f4_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void f5_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void f6_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
