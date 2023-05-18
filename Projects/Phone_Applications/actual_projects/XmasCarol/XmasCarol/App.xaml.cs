using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.Windows.Resources;

namespace XmasCarol
{
    public partial class App : Application
    {
        private static MainViewModel viewModel = null;

        public static string[] strList = new string[] {"away-manger.mid" ,"Away in a Manger", "come-all-ye-faithful.mid" ,"Oh Come, All Ye Faithful",					
"little-town-bethlehem.mid" ,"O Little Town of Bethlehem",				
"realms-of-glory.mid" ,"Angels, From the Realms of Glory",
"rudolph.mid" ,"Rudolph the Red-Nosed Reindeer",
"silent-night.mid" ,"Silent Night",
"heard-on-high.mid" ,"Angels We Have Heard on High",
"jingle-bells.mid" ,"Jingle Bells",
"wenceslas.mid" ,"Good King Wenceslas",
"saw-three-ships.mid" ,"I Saw Three Ships",
"joy-to-world.mid" ,"Joy to the World",
"three-kings.mid" ,"We Three Kings of Orient Are",
"drummer-boy.mid" ,"Little Drummer Boy",
"heard-the-bells.mid" ,"I Heard the Bells on Christmas Day",
"heaven-above.mid" ,"From Heaven Above to Earth I Come",
"do-you-hear.mid" ,"Do You Hear What I Hear",

"holly-ivy.mid" ,"The Holly and the Ivy",
"merry-christmas.mid" ,"We Wish You a Merry Christmas",
"first-noel.mid" ,"The First Noel",
"christmas-song.mid" ,"The Christmas Song",
              "here-comes-santa-claus.mid" ,"Here Comes Santa Claus",
"home-for-christmas.mid" ,"I'll be Home for Christmas",
"carol-of-bells.mid" ,"Carol of the Bells",

"still-still-still.mid" ,"Still, Still, Still",

"frosty.mid" ,"Frosty the Snowman",
"jingle-bell-rock.mid" ,"Jingle Bell Rock",

"twelve-days.mid" ,"The 12 Days of Christmas",

"jolly-saint-nick.mid" ,"Jolly Old Saint Nicholas",

"oh-holy-night.mid" ,"Oh Holy Night",

"all-i-want-for-christmas.mid" ,"All I Want For Christmas Is My Two Front Teeth",
"oh-christmas-tree.mid" ,"Oh Christmas Tree",
"deck-the-halls.mid" ,"Deck the Halls",

"santa-claus-coming-town.mid" ,"Santa Claus Is Coming To Town",
"up-housetop.mid" ,"Up On The Housetop",

"have-yourself-merry-little.mid" ,"Have Yourself A Merry Little Christmas",

"rocking-christmas-tree.mid" ,"Rocking Around the Christmas Tree",
"over-river-woods.mid" ,"Over the River and Through the Woods",
"sleigh-ride.mid" ,"Sleigh Ride",
 "grandma-reindeer.mid" ,"Grandma Got Run Over By A Reindeer",

"peace-on-earth.mid" ,"Let There Be Peace On Earth",
"winter-wonderland.mid" ,"Winter Wonderland",
"silver-bells.mid" ,"Silver Bells",
"saw-mommy-kissing-santa.mid" ,"I Saw Mommy Kissing Santa Claus",

"came-upon-midnight-clear.mid" ,"It Came Upon A Midnight Clear",
"let-it-snow.mid" ,"Let It Snow",
"ding-dong.mid" ,"Ding Dong! Merrily On High",
"here-we-come-awassailing.mid" ,"Here We Come A-Wassailing"
};


        /// <summary>
        /// A static ViewModel used by the views to bind against.
        /// </summary>
        /// <returns>The MainViewModel object.</returns>
        public static MainViewModel ViewModel
        {
            get
            {
                // Delay creation of the view model until necessary
                if (viewModel == null)
                    viewModel = new MainViewModel();

                return viewModel;
            }
        }

        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;

            // Standard Silverlight initialization
            InitializeComponent();
            CopyToIsolatedStorage();
            // Phone-specific initialization
            InitializePhoneApplication();

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are handed off GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Disable the application idle detection by setting the UserIdleDetectionMode property of the
                // application's PhoneApplicationService object to Disabled.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

        }

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
            // Ensure that application state is restored appropriately
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
            // Ensure that required application state is persisted here.
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }
        private void CopyToIsolatedStorage()
        {

            try
            {
                using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    // Copy audio files to isolated storage
                    //  string[] files = new string[] { "anubhav.wma"/*, "animal_2.wma", "animal_3.wma", "animal_4.wma"*/ };

                   // string strFileName;
                  //  foreach (var strFileName in App.strList)
                    for(int i =0; i<47;i++)
                    {
                        string strFileName = App.strList[i * 2 + 1] + ".html";
                        string strFilePath ="htmls\\" + strFileName  ;
                        string strFilePath2 =  App.strList[i * 2];
                       /* lock (storage)
                        {
                            if (storage.FileExists(strFileName))
                            {
                                storage.DeleteFile(strFileName);
                            }
                        }*/
                        StreamResourceInfo resource = Application.GetResourceStream(new Uri(strFilePath, UriKind.Relative));

                        using (IsolatedStorageFileStream file = storage.CreateFile(strFileName))
                        {
                            int chunkSize = 4096;
                            byte[] bytes = new byte[chunkSize];
                            int byteCount;


                            while ((byteCount = resource.Stream.Read(bytes, 0, chunkSize)) > 0)
                            {
                                file.Write(bytes, 0, byteCount);
                            }
                        }
                        if (i == 47)
                        {
                            i = 50;
                        }
                        /*strFileName = App.strList[i * 2];
                         strFilePath2 ="music\\" + strFileName;
                        StreamResourceInfo resource2 = Application.GetResourceStream(new Uri(strFilePath2, UriKind.Relative));

                        using (IsolatedStorageFileStream file = storage.CreateFile(strFileName))
                        {
                            int chunkSize = 4096;
                            byte[] bytes = new byte[chunkSize];
                            int byteCount;


                            while ((byteCount = resource2.Stream.Read(bytes, 0, chunkSize)) > 0)
                            {
                                file.Write(bytes, 0, byteCount);
                            }
                        }*/
                    }
                }
            }

            catch (Exception)
            {

            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion
    }
}