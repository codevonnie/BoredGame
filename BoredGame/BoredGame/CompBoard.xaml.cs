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
        private Dictionary<String, int> tile = new Dictionary<string, int>();
        private List<String> myRectangles = new List<String>();
        private Random r = new Random();

        public CompBoard()
        {
            this.InitializeComponent();
            
            setBoard();
            setRectangle();

        }

        public void setBoard()
        {
            int count = 8;
            int max = 8;
            char letter = 'a';
            int treasure = 0;
            String myRect;

            for (int i=1; i< count; i++)
            {

                for(int j=1; j< max; j++)
                {
                    myRect = letter + "" + i;
                    tile.Add(letter + "" + i, treasure);
                    myRectangles.Add(myRect);
                    letter++;
                }

                letter = 'a';
            }

            buryTreasure();

        }//textboxBoard

        public void buryTreasure()
        {
            int count = 5;
            int treasure = 1;
            String position;

            for(int i=0; i< count; i++)
            {
                position = getRandom();
                if (tile.ContainsKey(position))
                {
                    while (tile[position] == treasure)
                    {
                        position = getRandom();
                    }
                    tile[position] = treasure;
                }
            }

        }

        public String getRandom()
        {
            int num1 = r.Next(99) % 7;
            int num2 = r.Next(99) % 6;
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
                case 6:
                    letter = 'g';
                    break;
                
            }
            num2++;
            String pos = (letter + "" + num2);
            return pos;
        }//getRandom

        public void setRectangle()
        {
            List<Rectangle> myOtherRects = new List<Rectangle>();
            myOtherRects.Add(a1);myOtherRects.Add(a2);myOtherRects.Add(a3); myOtherRects.Add(a4); myOtherRects.Add(a5); myOtherRects.Add(a6); myOtherRects.Add(a7);
            myOtherRects.Add(b1); myOtherRects.Add(b2); myOtherRects.Add(b3); myOtherRects.Add(b4); myOtherRects.Add(b5); myOtherRects.Add(b6); myOtherRects.Add(b7);
            myOtherRects.Add(c1); myOtherRects.Add(c2); myOtherRects.Add(c3); myOtherRects.Add(c4); myOtherRects.Add(c5); myOtherRects.Add(c6); myOtherRects.Add(c7);
            myOtherRects.Add(d1); myOtherRects.Add(d2); myOtherRects.Add(d3); myOtherRects.Add(d4); myOtherRects.Add(d5); myOtherRects.Add(d6); myOtherRects.Add(d7);
            myOtherRects.Add(e1); myOtherRects.Add(e2); myOtherRects.Add(e3); myOtherRects.Add(e4); myOtherRects.Add(e5); myOtherRects.Add(e6); myOtherRects.Add(e7);
            myOtherRects.Add(f1); myOtherRects.Add(f2); myOtherRects.Add(f3); myOtherRects.Add(f4); myOtherRects.Add(f5); myOtherRects.Add(f6); myOtherRects.Add(f7);
            myOtherRects.Add(g1); myOtherRects.Add(g2); myOtherRects.Add(g3); myOtherRects.Add(g4); myOtherRects.Add(g5); myOtherRects.Add(g6); myOtherRects.Add(g7);
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/water.jpg"));

            foreach (Rectangle rect in myOtherRects)
            {
                rect.Fill = img;
            }
        }
    }
}
