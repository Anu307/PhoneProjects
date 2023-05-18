using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string filename;
        string textfilename;
        string[] strList;
        private static EventWaitHandle ewh;
        private static EventWaitHandle clearCount =
    new EventWaitHandle(false, EventResetMode.AutoReset);
        int iterator = 0;
        public Form1()
        {
            /*
             * "http://www.christmas-carols.net/carols/must-be-santa.html" ,"Must Be Santa",
             * "http://www.christmas-carols.net/carols/ring-those-bells.html" ,"Come On, Ring Those Bells",
             *"http://www.christmas-carols.net/carols/christmas-is-coming.html" ,"Christmas is Coming",
             "http://www.christmas-carols.net/carols/holiday-season.html" ,"The Holiday Season (or Happy Holiday)",
             * "http://www.christmas-carols.net/carols/c-h-r-i-s-t-m-a-s.html" ,"C-H-R-I-S-T-M-A-S",
             * "http://www.christmas-carols.net/carols/mistletoe-holly.html" ,"Mistletoe and Holly",

             * "http://www.christmas-carols.net/carols/friendly-beasts.html" ,"The Friendly Beasts",
             *  "http://www.christmas-carols.net/carols/most-wonderful-day.html" ,"The Most Wonderful Day Of The Year",
"http://www.christmas-carols.net/carols/white-christmas.html" ,"White Christmas",
             * 
"http://www.christmas-carols.net/carols/star-of-east.html" ,"Star of the East",
"http://www.christmas-carols.net/carols/nuttin-for-christmas.html" ,"Nuttin' For Christmas",
"http://www.christmas-carols.net/carols/when-child-born.html" ,"When A Child Is Born",
"http://www.christmas-carols.net/carols/birthday-king.html" ,"Birthday of a King",

             */
            InitializeComponent();
            strList = new string[] {"http://www.christmas-carols.net/carols/away-manger.html" ,"Away in a Manger", "http://www.christmas-carols.net/carols/come-all-ye-faithful.html" ,"Oh Come, All Ye Faithful",					
"http://www.christmas-carols.net/carols/little-town-bethlehem.html" ,"O Little Town of Bethlehem",				
"http://www.christmas-carols.net/carols/hark-angels-sing.html" ,"Hark! The Herald Angels Sing",
"http://www.christmas-carols.net/carols/realms-of-glory.html" ,"Angels, From the Realms of Glory",
"http://www.christmas-carols.net/carols/rudolph.html" ,"Rudolph the Red-Nosed Reindeer",
"http://www.christmas-carols.net/carols/silent-night.html" ,"Silent Night",
"http://www.christmas-carols.net/carols/heard-on-high.html" ,"Angels We Have Heard on High",
"http://www.christmas-carols.net/carols/jingle-bells.html" ,"Jingle Bells",
"http://www.christmas-carols.net/carols/wenceslas.html" ,"Good King Wenceslas",
"http://www.christmas-carols.net/carols/saw-three-ships.html" ,"I Saw Three Ships",
"http://www.christmas-carols.net/carols/joy-to-world.html" ,"Joy to the World",
"http://www.christmas-carols.net/carols/three-kings.html" ,"We Three Kings of Orient Are",
"http://www.christmas-carols.net/carols/drummer-boy.html" ,"Little Drummer Boy",
"http://www.christmas-carols.net/carols/heard-the-bells.html" ,"I Heard the Bells on Christmas Day",
"http://www.christmas-carols.net/carols/heaven-above.html" ,"From Heaven Above to Earth I Come",
"http://www.christmas-carols.net/carols/do-you-hear.html" ,"Do You Hear What I Hear",
"http://www.christmas-carols.net/carols/ding-dong.html" ,"Ding Dong! Merrily On High",
"http://www.christmas-carols.net/carols/holly-ivy.html" ,"The Holly and the Ivy",
"http://www.christmas-carols.net/carols/merry-christmas.html" ,"We Wish You a Merry Christmas",
"http://www.christmas-carols.net/carols/first-noel.html" ,"The First Noel",
"http://www.christmas-carols.net/carols/christmas-song.html" ,"The Christmas Song",
              "http://www.christmas-carols.net/carols/here-comes-santa-claus.html" ,"Here Comes Santa Claus",
"http://www.christmas-carols.net/carols/home-for-christmas.html" ,"I'll be Home for Christmas",
"http://www.christmas-carols.net/carols/carol-of-bells.html" ,"Carol of the Bells",

"http://www.christmas-carols.net/carols/still-still-still.html" ,"Still, Still, Still",

"http://www.christmas-carols.net/carols/frosty.html" ,"Frosty the Snowman",
"http://www.christmas-carols.net/carols/jingle-bell-rock.html" ,"Jingle Bell Rock",

"http://www.christmas-carols.net/carols/twelve-days.html" ,"The 12 Days of Christmas",

"http://www.christmas-carols.net/carols/jolly-saint-nick.html" ,"Jolly Old Saint Nicholas",

"http://www.christmas-carols.net/carols/oh-holy-night.html" ,"Oh Holy Night",

"http://www.christmas-carols.net/carols/all-i-want-for-christmas.html" ,"All I Want For Christmas Is My Two Front Teeth",
"http://www.christmas-carols.net/carols/oh-christmas-tree.html" ,"Oh Christmas Tree",
"http://www.christmas-carols.net/carols/deck-the-halls.html" ,"Deck the Halls",

"http://www.christmas-carols.net/carols/santa-claus-coming-town.html" ,"Santa Claus Is Coming To Town",
"http://www.christmas-carols.net/carols/up-housetop.html" ,"Up On The Housetop",

"http://www.christmas-carols.net/carols/have-yourself-merry-little.html" ,"Have Yourself A Merry Little Christmas",

"http://www.christmas-carols.net/carols/rocking-christmas-tree.html" ,"Rocking Around the Christmas Tree",
"http://www.christmas-carols.net/carols/over-river-woods.html" ,"Over the River and Through the Woods",
"http://www.christmas-carols.net/carols/sleigh-ride.html" ,"Sleigh Ride",
 "http://www.christmas-carols.net/carols/grandma-reindeer.html" ,"Grandma Got Run Over By A Reindeer",

"http://www.christmas-carols.net/carols/peace-on-earth.html" ,"Let There Be Peace On Earth",
"http://www.christmas-carols.net/carols/winter-wonderland.html" ,"Winter Wonderland",
"http://www.christmas-carols.net/carols/silver-bells.html" ,"Silver Bells",
"http://www.christmas-carols.net/carols/saw-mommy-kissing-santa.html" ,"I Saw Mommy Kissing Santa Claus",

"http://www.christmas-carols.net/carols/came-upon-midnight-clear.html" ,"It Came Upon A Midnight Clear",
"http://www.christmas-carols.net/carols/let-it-snow.html" ,"Let It Snow",

"http://www.christmas-carols.net/carols/here-we-come-awassailing.html" ,"Here We Come A-Wassailing"
};
            webBrowser1.DocumentCompleted +=
                         new WebBrowserDocumentCompletedEventHandler(PrintDocument);

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // LoadAllFiles();
            LoadNextFile();
            
           // LoadURL( );
            iterator++;
            
          // string str = htmldoc.Body.InnerText;

        }
        private void OnNavigated(WebBrowserNavigatedEventArgs e)
        {
            HtmlDocument htmldoc = webBrowser1.Document;
            //string str = htmldoc.Body.ToString();
            string str = htmldoc.Body.InnerText;

        }
        private void PrintDocument(object sender,WebBrowserDocumentCompletedEventArgs e)

        {
                HtmlDocument htmldoc = webBrowser1.Document;
               


                string str = htmldoc.Body.InnerText;
               // string str = htmldoc.Body.InnerHtml;
               // string str = htmldoc.Body.ToString();
                StreamWriter outfile = new StreamWriter(textfilename);
                outfile.Write(str);
                outfile.Close();
                File.Delete(filename);


        }
      /*  private void LoadAllFiles()
        {
            string sourceDirectory = @"L:\Phone_Applications\screens\arabian_nights\htms\folder";
            var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.htm");
           

            foreach (string currentFile in txtFiles)
            {
              //  string currentFile = sourceDirectory + "The Magic Egg.htm";
                webBrowser1.Navigate(currentFile);
               // string fileName = currentFile.Substring(sourceDirectory.Length + 1);
               // webBrowser1.n
                
                while (webBrowser1.ReadyState == WebBrowserReadyState.Loading)
                {
                    textfilename = currentFile.Replace(".htm", ".txt");
                    int i = 0;
                    i++;
                    i--;
                }
            }

        }*/
        private void LoadNextFile()
        {
            string sourceDirectory = @"C:\users\anubhavm\desktop\htms\folder";
            var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.htm");
            foreach (string currentFile in txtFiles)
          //  for (int i = 11; i <= 23;i++ )
            {
               webBrowser1.Navigate(currentFile);
              //  webBrowser1.Navigate("http://www.urdupoetry.com/ghalib" + i.ToString() + ".html");
               filename = currentFile;
             // filename = sourceDirectory + "ghalib" +i.ToString() +".html";
               textfilename = currentFile.Replace(".htm", ".txt");
               // textfilename =filename;
                break;
            }
        }
        private void LoadURL()
        {
           // string sourceDirectory = @"L:\Phone_Applications\screens\ghalib\";
            string sourceDirectory = "D:\\List\\";
           // var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.htm");
          
            string strnavigate;
            string strName;

                strnavigate = strList[iterator * 2];
                strName = strList[iterator * 2 +1];
                webBrowser1.Navigate(strnavigate);

                filename = sourceDirectory + strName + ".html";


            /*string str = "0";
             if(iterator <10)
                 str = str + iterator.ToString();
             else
                 str = iterator.ToString();
              
                webBrowser1.Navigate(strnavigate);

                filename = sourceDirectory + strName + ".html";*/
           

                
                textfilename = filename ;
              
              // textfilename =filename;

        }
    }
}
