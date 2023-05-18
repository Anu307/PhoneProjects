using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Resources;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using System.Windows.Markup;
using Microsoft.Phone.BackgroundAudio;
namespace SriSathyaSaiVani
{
    public partial class App : Application
    {
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
            CopyToIsolatedStorage();
            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;

            // Standard Silverlight initialization
            InitializeComponent();

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
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Disable the application idle detection by setting the UserIdleDetectionMode property of the
                // application,s PhoneApplicationService object to Disabled.
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
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
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
            if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
            {
                if (BackgroundAudioPlayer.Instance.Track.Title == "SriSathyaSaiVani_App")
                    return;

            }
            try
            {
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                // Copy audio files to isolated storage
                string[] files = new string[] { "AmbaShankari.mp3","Asathoma.mp3","bhajanbinasukha.mp3","bhajgovindam.mp3","BhavaBhaya.mp3","chandaKiran.mp3",
                    "ChitChor.mp3","Ganga.mp3","Girishwara.mp3","GovindaGopala.mp3","GovindaKrishna.mp3","Govind_Hare.mp3","HareRama.mp3","HariHariHari.mp3",
                    "HeyShiva.mp3","JayaPanduranga.mp3","madhavamurahara.mp3","MadhuraMurali.mp3","manasebhajare.mp3","Narayana.mp3","PibareRama.mp3","Ram_Kodana.mp3",
                    "Sathyam_Janam.mp3","SivayaParameshwara.mp3","Subramanyam.mp3" };


                foreach (var strFileName in files)
                {
                    string strFilePath ="audio\\" + strFileName;

                    lock (storage)
                    {
                        if (storage.FileExists(strFileName))
                        {
                            storage.DeleteFile(strFileName);
                        }
                    }
                    StreamResourceInfo resource = Application.GetResourceStream(new Uri(strFilePath, UriKind.Relative));
                    if (storage.FileExists(strFileName))
                    {
                        storage.DeleteFile(strFileName);
                    }


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

            // Create the frame but don,t set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Ensure we don,t initialize again
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