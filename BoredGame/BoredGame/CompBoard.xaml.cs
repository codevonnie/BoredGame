using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public object NotifyType { get; private set; }

        public CompBoard()
        {
            this.InitializeComponent();
            play();
        }

        public void play()
        {
            cScore = pScore = 0;
            selectedTile = null;
            tile.Clear();
            setBoard();
            pScores.Text = ("Player \n    " + pScore);
            cScores.Text = (" Comp \n    " + cScore);

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
            
            String name = selected.Name;
            ImageBrush img = new ImageBrush();

            if (tile.ContainsKey(name))
            {
                if (treasureTiles.Contains(name))
                {
                    tile.Remove(name);
                    img.ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/treasure.png"));
                    selected.Background = img;
                    pScore++;
                    treasureTiles.Remove(name);
                }
                else
                {
                    tile.Remove(name);
                    img.ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/cross.png"));
                    selected.Background = img;
                }
            }

            
        }//checkForTreasure

        private async void Showbutton_Click()
        {
            MessageDialog showDialog = new MessageDialog("Do you want to play again?");
            showDialog.Commands.Add(new UICommand("Yes")
            {
                Id = 0
            });
            showDialog.Commands.Add(new UICommand("No")
            {
                Id = 1
            });

            showDialog.DefaultCommandIndex = 0;
            showDialog.CancelCommandIndex = 1;

            
            var result = await showDialog.ShowAsync();
            if ((int)result.Id == 0)
            {
                this.Frame.Navigate(typeof(CompBoard), null);
            }
            else
            {
                this.Frame.Navigate(typeof(MainPage), null);
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
                    cScore++;
                    treasureTiles.Remove(compSelection);
                    tile[compSelection].IsHitTestVisible = false;
                    tile.Remove(compSelection);
                }

            }
            else
            {
                img.ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/cross.png"));
                tile[compSelection].Background = img;
                tile[compSelection].IsHitTestVisible = false;
                tile.Remove(compSelection);
            }

            pScores.Text = ("Player \n    " + pScore);
            cScores.Text = (" Comp \n    " + cScore);


            if (treasureTiles.Count == 0)
            {
                Showbutton_Click();
            }

        }

        private async void tile_Click(object sender, RoutedEventArgs e)
        {
            selectedTile = (Button)sender;
            checkForTreasure(selectedTile);
            selectedTile.IsHitTestVisible = false;
            pScores.Text = ("Player \n    " + pScore);
            await Task.Delay(500);
            compTurn();
            cScores.Text = (" Comp \n    " + cScore);

        }


    }

    

}
