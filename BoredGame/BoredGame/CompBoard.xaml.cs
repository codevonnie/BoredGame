using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BoredGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class CompBoard : Page
    {
        private Dictionary<String, Button> tile = new Dictionary<String, Button>();
        private Random r = new Random();
        private Button selectedTile = new Button();
        private List<String> treasureTiles = new List<string>();
        private int pScore;
        private int cScore;
        private int turn;

        public object NotifyType { get; private set; }

        public CompBoard()
        {
            this.InitializeComponent();

            setBoard();
            turn = 0;
            txtScores.Text = ("Player: " + pScore + " Computer: " + cScore);
            //setRectangle();

        }

        public void setBoard()
        {
            tile.Add("a1", a1); tile.Add("a2", a2); tile.Add("a3", a3); tile.Add("a4", a4); tile.Add("a5", a5); tile.Add("a6", a6);
            tile.Add("b1",b1); tile.Add("b2", b2); tile.Add("b3", b3); tile.Add("b4", b4); tile.Add("b5", b5); tile.Add("b6", b6);
            tile.Add("c1", c1); tile.Add("c2", c2); tile.Add("c3", c3); tile.Add("c4", c4); tile.Add("c5", c5); tile.Add("c6", c6);
            tile.Add("d1", d1); tile.Add("d2", d2); tile.Add("d3", d3); tile.Add("d4", d4); tile.Add("d5", d5); tile.Add("d6", d6);
            tile.Add("e1", e1); tile.Add("e2", e2); tile.Add("e3", e3); tile.Add("e4", e4); tile.Add("e5", e5); tile.Add("e6", e6);
            tile.Add("f1", f1); tile.Add("f2", f2); tile.Add("f3", f3); tile.Add("f4", f4); tile.Add("f5", f5); tile.Add("f6", f6);

            buryTreasure();

        }//textboxBoard

        public void buryTreasure()
        {
            int count = 5;
            String position;

            for (int i = 0; i < count; i++)
            {
                position = getRandom();
                while (treasureTiles.Contains(position))
                {
                        position = getRandom();
                }
                treasureTiles.Add(position);
                
            }
        }//buryTreasure

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

        public void checkForTreasure(Button selected)
        {
            if (turn == 0)
            {
                String name = selected.Name;
                ImageBrush img = new ImageBrush();

                if (tile.ContainsKey(name))
                {
                    if (treasureTiles.Contains(name))
                    {
                        tile.Remove(name);
                        img.ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/treasure.png"));
                        selected.Background = img;
                        //tile.Add(name, selected);
                        turn = 1;
                        pScore++;
                        treasureTiles.Remove(name);
                    }
                    else
                    {
                        tile.Remove(name);
                        img.ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/cross.png"));
                        selected.Background = img;
                        //tile.Add(name, selected);
                        turn = 1;
                    }
                }
            }
            else
            {
                Showbutton_Click(selected);
            }

            txtScores.Text = ("Player: " + pScore + " Computer: " + cScore);
            compTurn();
        }//checkForTreasure

        private async void Showbutton_Click(object sender)
        {
            MessageDialog showDialog = new MessageDialog("It's the computers turn");
            showDialog.Commands.Add(new UICommand("Ok")
            {
                Id = 0
            });
            
            showDialog.DefaultCommandIndex = 0;
            
            var result = await showDialog.ShowAsync();
            if ((int)result.Id == 0)
            {
                //do your task  
            }
            
        }

        private void compTurn()
        {
            String compSelection = getRandom();
            ImageBrush img = new ImageBrush();

            while (!(tile.ContainsKey(compSelection)))
            {
                compSelection = getRandom();
            }
            if (treasureTiles.Contains(compSelection))
            {
                
                img.ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/treasure.png"));
                if (tile.ContainsKey(compSelection))
                {
                    tile[compSelection].Background = img;
                    //tile.Add(compSelection, selected);
                    turn = 0;
                    cScore++;
                    treasureTiles.Remove(compSelection);
                    tile.Remove(compSelection);
                }

            }
            else
            {
                img.ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/cross.png"));
                tile[compSelection].Background = img;
                //tile.Add(name, selected);
                turn = 0;
                tile.Remove(compSelection);
            }

            txtScores.Text = ("Player: " + pScore + " Computer: " + cScore);

        }

        private void a1_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void a2_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void a3_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void a4_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void a5_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void a6_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void b6_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void c1_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void c2_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void c3_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void c4_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void c5_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void c6_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void d1_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void d2_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void d3_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void d4_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void d5_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void d6_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            //selectedTile.IsEnabled = false;
            selectedTile.IsHitTestVisible = false;
        }

        private void e1_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void e2_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void e3_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void e4_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void e5_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void e6_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void f1_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void f2_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void f3_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void f4_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void f5_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }

        private void f6_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
        }
    }

}
