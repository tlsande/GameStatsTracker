using Game_Stats_Tracker.api_calls.steam;
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

namespace Game_Stats_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private appSetup appData;

        public MainWindow()
        {
            InitializeComponent();
            appData = new appSetup();
            appData.loadConfig();
        }

        private void testButton_Click(object sender, RoutedEventArgs e)
        {
            //player testData = playerAchievements.getPlayerAchievements(appData.getKey("steam"), "76561198000713602", "211420", "EN");

            //testTextBox.Text += testData.playertsats.steamID + "\n";
            //testTextBox.Text += testData.playertsats.game + "\n";
            //foreach (achievement i in testData.playertsats.achievements)
            //{
            //    testTextBox.Text += "   " + i.apiname + "\n";
            //    testTextBox.Text += "   " + i.achieved + "\n";
            //    testTextBox.Text += "   " + i.unlockedTime + "\n";
            //    testTextBox.Text += "   " + i.name + "\n";
            //    testTextBox.Text += "   " + i.description + "\n";
            //}

            //string testData2 = schemaForGame.getSchemaForGame(appData.getKey("steam"), "211420", "EN");
            //testTextBox.Text += testData2;

            gameInfo testData2 = schemaForGame.getSchemaForGame(appData.getKey("steam"), "211420", "EN");

            testTextBox.Text += testData2.game.gameName + "\n";
            testTextBox.Text += testData2.game.version + "\n";
            foreach (achievementInfo i in testData2.game.gameStats.achievements)
            {
                testTextBox.Text += "   " + i.name + "\n";
                testTextBox.Text += "   " + i.defaultvalue + "\n";
                testTextBox.Text += "   " + i.displayName + "\n";
                testTextBox.Text += "   " + i.hidden + "\n";
                testTextBox.Text += "   " + i.description + "\n";
                testTextBox.Text += "   " + i.iconURL + "\n";
                testTextBox.Text += "   " + i.icongreyURL + "\n";
            }


            //testTextBox.Text += System.IO.Path.Combine(Directory.GetCurrentDirectory(), "\\data\\keys.xml");
            //testTextBox.Text += System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName, @"data\", "keys.xml");
            //testTextBox.Text += System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"data\keys.xml");
        }
    }
}
