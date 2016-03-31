using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Media.Audio;

namespace BoredGame
{
 
    public sealed partial class CompBoard : Page
    {
        private Dictionary<String, Button> tile = new Dictionary<String, Button>(); 
        private Random r = new Random();
        private Button selectedTile = new Button();
        private List<String> treasureTiles = new List<string>();
        private int pScore;
        private int cScore;
        private Boolean coinCheckP, coinCheckC;
        private Boolean pWins;
        
        public CompBoard()
        {
            this.InitializeComponent();
            play(); //call the play method to begin setting up the board
        }

        public void play()
        {
            cScore = pScore = 0; //set/reset scores to 0
            selectedTile = null; 
            tile.Clear();
            setBoard();
            pScores.Text = pScore.ToString();
            cScores.Text = cScore.ToString();

        }
        
        public void setBoard()
        {
            //sets enteries in dictionary - board location name and button
            tile.Add("a1", a1); tile.Add("a2", a2); tile.Add("a3", a3); tile.Add("a4", a4); tile.Add("a5", a5); tile.Add("a6", a6);
            tile.Add("b1",b1); tile.Add("b2", b2); tile.Add("b3", b3); tile.Add("b4", b4); tile.Add("b5", b5); tile.Add("b6", b6);
            tile.Add("c1", c1); tile.Add("c2", c2); tile.Add("c3", c3); tile.Add("c4", c4); tile.Add("c5", c5); tile.Add("c6", c6);
            tile.Add("d1", d1); tile.Add("d2", d2); tile.Add("d3", d3); tile.Add("d4", d4); tile.Add("d5", d5); tile.Add("d6", d6);
            tile.Add("e1", e1); tile.Add("e2", e2); tile.Add("e3", e3); tile.Add("e4", e4); tile.Add("e5", e5); tile.Add("e6", e6);
            tile.Add("f1", f1); tile.Add("f2", f2); tile.Add("f3", f3); tile.Add("f4", f4); tile.Add("f5", f5); tile.Add("f6", f6);

            buryTreasure();

        }//textboxBoard

        public void buryTreasure() //sets the treasure to random locations on the board
        {
            int count = 5;
            String position;

            for (int i = 0; i < count; i++)
            {
                position = getRandom(); //get returned string from getRandom method
                while (treasureTiles.Contains(position))//checks list for this tile and if already contains, recalls getRandom
                {
                        position = getRandom();
                }
                treasureTiles.Add(position);//sets position to list containing tiles containing treasure
                
            }
        }//buryTreasure

        public String getRandom()
        {
            int num1 = r.Next(99) % 6; //random number for use in switch
            int num2 = r.Next(99) % 5; //random for number position on board
            char letter = ' ';

            switch (num1)//checks which case num1 matches and sets appropriate letter
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
            num2++; //increment num2 by 1 because board locations go from 1 not 0
            String pos = (letter + "" + num2); //returned string combines letter and number for board position
            return pos;
        }//getRandom

        public void checkForTreasure(Button selected)//method to check whether user chosen tile contains treasure
        {
            
            String name = selected.Name;//name takes name of button that was pressed
            ImageBrush img = new ImageBrush(); //new ImageBrush for button background change

            if (tile.ContainsKey(name))//check whether dictionary contains button name
            {
                if (treasureTiles.Contains(name))//then check whether the list of tiles containing treasure contain button name
                {
                    tile.Remove(name);//remove the dictionary entry so it cannot be chosen again
                    img.ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/treasure.png"));//set imagebrush as treasure image
                    img.Stretch = Stretch.Fill;//fill so the image will look correct on all size screens
                    selected.Background = img;//change tile background to treasure imagebrush
                    selected.Background.Opacity = 1;//change background opacity from 0 to 1
                    pScore++;//increment players score
                    treasureTiles.Remove(name);//remove the name of the button location from the treasure list
                    coinCheckP = true;//boolean for coin animation
                    treasureFound.Play();//play sound
                }
                else
                {
                    tile.Remove(name);//remove dictionary entry
                    img.ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/cross.png"));//set imagebrush to X image
                    img.Stretch = Stretch.Fill;
                    selected.Background = img;
                    coinCheckP = false;
                    notFound.Play();
                }
            }

            
        }//checkForTreasure

        private async void Showbutton_Click()//async method for displaying message to user at end of game
        {

            MessageDialog showDialog;
            //called at end of game
            if (pWins)//if true
            {
                showDialog = new MessageDialog("You win!\nDo you want to play again?");//show dialog box with contained message
            }
            else
            {
                showDialog = new MessageDialog("Sorry you lose.\nDo you want to play again?");//show dialog box with contained message
            }
            
            showDialog.Commands.Add(new UICommand("Yes")//add command to showDialog - button saying Yes with id of 0
            {
                Id = 0
            });
            showDialog.Commands.Add(new UICommand("No")//add command to showDialog - button saying No with id of 1
            {
                Id = 1
            });

            showDialog.DefaultCommandIndex = 0;
            showDialog.CancelCommandIndex = 1;

            //result is not set until showDialog is shown and a value is set
            var result = await showDialog.ShowAsync();
            
            if ((int)result.Id == 0)//if Yes is chosen, reload game
            {
                this.Frame.Navigate(typeof(CompBoard), null);
            }
            else//if no is chosen, navigate to MainPage
            {
                this.Frame.Navigate(typeof(MainPage), null);
            }
            
        }
        
        private void compTurn()//method controlling the computers selection
        {
            String compSelection = getRandom(); //use getRandom method to chose a random location on the board
            ImageBrush img = new ImageBrush();

            while (!(tile.ContainsKey(compSelection)))//if the dictionary doesn't contain that entry it means it has already been chosen, getRandom is called again
            {
                compSelection = getRandom();
            }
            if (treasureTiles.Contains(compSelection))//check if list of treasure locations contains the computers choice
            {

                img.ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/treasure.png")); //set imageBrush to treasure image
                img.Stretch = Stretch.Fill;

                if (tile.ContainsKey(compSelection))//check dictionary for entry
                {
                    tile[compSelection].Background = img; //set background image to treasure image
                    cScore++;//increment computer score
                    treasureTiles.Remove(compSelection);//remove location from treasure list
                    tile[compSelection].IsHitTestVisible = false;//set chosen tile so that it cannot be reselected by user or computer
                    tile.Remove(compSelection);//remove location from dictionary
                    coinCheckC = true;//boolean for coin animation
                }

            }
            else
            {
                img.ImageSource = new BitmapImage(new Uri(this.BaseUri, "Assets/cross.png"));//set imagebrush to X image
                img.Stretch = Stretch.Fill;
                tile[compSelection].Background = img;
                tile[compSelection].IsHitTestVisible = false;
                tile.Remove(compSelection);
                coinCheckC = false;
            }

            //display up-to-date score in textbox
            pScores.Text = pScore.ToString();
            cScores.Text = cScore.ToString();

            //check if player or computer has won the game and if so trigger dialog message
            if (pScore >= 3){
                pWins = true;
                Showbutton_Click();
            }
            else if (cScore >= 3){
                Showbutton_Click();
            }
               
        }

        private async void tile_Click(object sender, RoutedEventArgs e)
        {
            //method called when player selectes a tile
            selectedTile = (Button)sender;//selected tile is a button which takes the value of the selected button
            checkForTreasure(selectedTile);//call method and pass the selected tile
            selectedTile.IsHitTestVisible = false;//change value so tile cannot be rechosen
            pScores.Text = pScore.ToString(); //update player score in textbox
            await Task.Delay(500); //wait for task to finish
            compTurn();//call method to have computer take turn
            cScores.Text = cScore.ToString();
            //play animation for player and/or computer if they have chosen a tile containing treasure
            if (coinCheckP == true)
            {
                sbCoinPlayer.Begin();
            }
            if(coinCheckC == true)
            {
                sbCoinComp.Begin();
            }

        }
    }
}
