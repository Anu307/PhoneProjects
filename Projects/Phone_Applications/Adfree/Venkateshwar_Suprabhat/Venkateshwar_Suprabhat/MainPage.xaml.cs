using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.BackgroundAudio;
using Microsoft.Phone.Tasks;
using System.Windows.Threading;
namespace Venkateshwar_Suprabhat
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        static int ipicnumber;
        public MainPage()
        {
            InitializeComponent();
            ipicnumber = 1;
            ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            if (btn.Text == "Play")
            {

                if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
                {
                    btn.Text = "Pause";
                    btn.IconUri = new Uri("transport.pause.png", UriKind.Relative);
                }
            }
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 45000); // 60 Seconds  
            dt.Tick += new EventHandler(dt_Tick);
            dt.Start();

            MSAdControlAd1.AdRefreshed += MSAdControl_NewAd;

            MSAdControlAd1.ErrorOccurred += MSAdControl1_AdControlError;

            MSAdControlAd2.AdRefreshed += MSAdControl_NewAd;
            MSAdControlAd2.ErrorOccurred += MSAdControl2_AdControlError;
        }

        private void Toggle_Click(object sender, EventArgs e)
        {
            ApplicationBarIconButton mi = (ApplicationBarIconButton)ApplicationBar.Buttons[2];
           // mi.Text = "Next";
            ipicnumber++;
            if (ipicnumber == 9)
            {
                ipicnumber = 0;
                UpdateTextBoxText();
                Image.Visibility = Visibility.Collapsed;
                TextBox.Visibility = Visibility.Visible;
                TextBox.Background =new SolidColorBrush(Color.FromArgb(0xff, 0xaa, 0xbb, 0xcc));


                TextBox.Foreground = new SolidColorBrush(Colors.Red); 

            }
            else
            {
                TextBox.Visibility = Visibility.Collapsed;
                Image.Visibility = Visibility.Visible;
                Image.Source = new BitmapImage(new Uri("venkateshwara_" + ipicnumber + ".jpg", UriKind.RelativeOrAbsolute));
            }
            


        }
        private void Feedback_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailcomposetask = new EmailComposeTask();
            emailcomposetask.Subject = " Feedback for Venkateshwar Suprabhatam v2.00";
            emailcomposetask.To = "svam@outlook.com";
            emailcomposetask.Show();
        }
        private void Review_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }
        private void Search_Click(object sender, EventArgs e)
        {
            MarketplaceSearchTask marketplaceSearchTask = new MarketplaceSearchTask();

            marketplaceSearchTask.SearchTerms = "SVAM";

            marketplaceSearchTask.Show();

        }
        private void Play_Click(object sender, EventArgs e)
        {
            ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            if (btn.Text == "Play")
            {
                btn.Text = "Pause";
                btn.IconUri = new Uri("transport.pause.png", UriKind.Relative);
                //if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
                // {
                BackgroundAudioPlayer.Instance.Play();
                //}
            }
            else if (btn.Text == "Pause")
            {
                btn.Text = "Play";
                btn.IconUri = new Uri("transport.play.png", UriKind.Relative);
                if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
                {
                    BackgroundAudioPlayer.Instance.Pause();
                }
            }

            //Do work for your application here.
        }
        private void Pause_Click(object sender, EventArgs e)
        {




            //Do work for your application here.
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
            {
                BackgroundAudioPlayer.Instance.Stop();
            }
            ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            if (btn.Text == "Pause")
            {
                btn.Text = "Play";
                btn.IconUri = new Uri("transport.play.png", UriKind.Relative);
                if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
                {
                    BackgroundAudioPlayer.Instance.Pause();
                }
            }

        }

        void MSAdControl_NewAd(object sender, System.EventArgs e)
        {

            // use try/catch to minimize any possibility of Ad Control crashes
            MSAdControlAd1.Visibility = Visibility.Visible;
            MSAdControlAd2.Visibility = Visibility.Visible;
            AdDuplexAdControl.Visibility = Visibility.Collapsed;
            InneractiveXamlAd.Visibility = Visibility.Collapsed;

        }



        void MSAdControl1_AdControlError(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {

            MSAdControlAd1.Visibility = Visibility.Collapsed;

            AdDuplexAdControl.Visibility = Visibility.Visible;

        }
        void MSAdControl2_AdControlError(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {

            MSAdControlAd2.Visibility = Visibility.Collapsed;

            InneractiveXamlAd.Visibility = Visibility.Visible;

        }


        void dt_Tick(object sender, EventArgs e)
        {
            try
            {

                if (MSAdControlAd1.Visibility != Visibility.Visible)
                    MSAdControlAd1.Visibility = Visibility.Visible;
                MSAdControlAd1.Refresh();
                if (MSAdControlAd2.Visibility != Visibility.Visible)
                    MSAdControlAd2.Visibility = Visibility.Visible;
                MSAdControlAd2.Refresh();


            }
            catch { ;}

        }  

        private void UpdateTextBoxText()
        {
            TextBox.Text = " Kowsalya supraja Rama poorva sandhya pravarthathe \r\n" +
" Uthishta narasardoola karthavyam daivamahnikam\r\n" +
" Kowsalya supraja Rama poorva sandhya pravarthathe\r\n" +
" Uthishta narasardoola karthavyam daivamahnikam\r\n\r\n" +
" Uthishtothishta Govinda uthishta garudadhwaja\r\n" +
" Uthishta kamalakantha thrilokyam mangalam kuru\r\n" +
" Uthishtothishta Govinda uthishta garudadhwaja\r\n" +
" Uthishta kamalakantha thrilokyam mangalam kuru\r\n\r\n" +
" Mathassamasta jagatham madukaitabhare\r\n" +
" Vakshoviharini manohara divyamoorthe\r\n" +
" Sree swamini srithajana priya danaseele\r\n" +
" Sree Venkatesadayithe thava suprabhatham (twice)\r\n\r\n" +
" Thavasuprabhathamaravindalochane\r\n" +
" Bhavathu prasanna mukhachandra mandale\r\n" +
" Vidhisankarendra vanithabhirarchithe\r\n" +
" Vrishasaila nathadavithe, davanidhe\r\n\r\n" +
" Athriyadhi saptharushay ssamupasya sandyam\r\n" +
" Aakasa sindhu kamalani manoharani\r\n" +
" Aadaya padhayuga marchayithum prapanna:\r\n" +
" Seshadrisekhara vibho! Thava suprabhatham\r\n\r\n" +
" Panchananabja bhava shanmukavasavadhya:\r\n" +
" Tryvikramadhi charitham vibhudhasthuvanthi\r\n" +
" Bhashapathipatathi vasara shuddhi marath\r\n" +
" Seshadri sekhara vibho! thava subrabhatham\r\n\r\n" +
" Eeshathprapulla saraseeruha narikela\r\n" +
" Phoogadrumadi sumanohara Balikanam\r\n" +
" Aavaathi mandamanilassaha divya gandhai:\r\n" +
" Seshadri shekara vibho! thava suprabhatham\r\n\r\n" +
" Unmeelya nethrayugamuththama panjarasthaa:\r\n" +
" Paathraa vasishta kadhaleephala payasani Bhukthvaa\r\n" +
" saleelamatha keli sukha: patanthi\r\n" +
" Seshadri sekhara vibho! thava suprabhatham\r\n\r\n" +
" Thanthree prakarsha madhuraswanaya\r\n" +
" vipanchyaa Gayathyanantha charitham\r\n" +
" thava naradopi Bhashasamagrama sakruthkara sara ramyam\r\n" +
" Seshadri sekhara vibho! thava suprabhatham\r\n\r\n" +
" Brungavaleecha makaranda rashanuvidda\r\n" +
" Jhankara geetha ninadaissa sevanaya\r\n" +
" Niryathyupaantha sarasee kamalodarebhyaha\r\n" +
" Seshadri sekhara vibhol thava suprabhatham\r\n\r\n" +
" Yoshaganena varadhadni vimathyamaane\r\n" +
" Ghoshalayeshu dhadhimanthana\r\n" +
" theevraghoshaaha Roshaathkalim\r\n" +
" vidha-dhathe kakubhascha kumbhaha\r\n" +
" Seshadri sekhara vibho! thava suprabhatham\r\n\r\n" +
" Padmeshamithra sathapathra kathalivargha\r\n" +
" Harthum shriyam kuvalayasya nijanga Lakshmya\r\n" +
" Bheree ninadamiva bibrathi theevranadam\r\n" +
" Seshadri sekhara vibho! thava suprabhatham\r\n\r\n" +
" Sreemannabheeshta varadhakhila lookabandho\r\n" +
" Sree Sreenivasa Jagadekadayaika sindho\r\n" +
" Sree devathagruha bhujanthara divyamurthe\r\n" +
" Sree Venkatachalapathe! thava suprabhatham (twice)\r\n\r\n" +
" Sree swamy pushkarinikaplava nirmalangaa\r\n" +
" Sreyorthino hara viranchi sanadadhyaha\r\n" +
" Dware vasanthi varavethra hathothamangaha:\r\n" +
" Sree Venkatachalapathe! thava suprabhatham\r\n\r\n" +
" Sree seshasaila garudachala venkatadri\r\n" +
" Narayanadri vrishabhadri vrishadri mukhyam\r\n" +
" Akhyam thvadeeyavasathe ranisam vadanthi\r\n" +
" Sree Venkatachalapathe! thava suprabhatham\r\n\r\n" +
" Sevaaparaashiva suresa krusanudharma\r\n" +
" Rakshombhunatha pavamana dhanadhi nathaha:\r\n" +
" Bhaddanjali pravilasannija seersha deSaha:\r\n" +
" Sree Venkatachalapathe! thava suprabhatham\r\n\r\n" +
" Dhateeshuthevihagaraja mrugadhiraja\r\n" +
" Nagadhiraja gajaraja hayadhiraja:\r\n" +
" Swaswadhikara mahimadhika marthayanthe\r\n" +
" Sree Venkatachalapathe! thava suprabhatham\r\n\r\n" +
" Sooryendhubhouma bhudhavakpathi kavya souri\r\n" +
" Swarbhanukethu divishathparishathpradanaa:\r\n" +
" Twaddhasa dasa charamavadhidaasa daasa:\r\n" +
" Sree Venkatachalapathe! thava suprabhatham\r\n\r\n" +
" Thwathpadadhulibharita spurithothha manga:\r\n" +
" Swargapavarga nirapeksha nijantharanga:\r\n" +
" Kalpagamakalanaya kulatham labhanthe\r\n" +
" Sree Venkatachalapathe! thava suprabhatham\r\n\r\n" +
" Thvadgopuragra sikharani nireekshmana\r\n" +
" Swargapavarga padaveem paramam shrayantha:\r\n" +
" Marthyaa manushyabhuvane mathimashrayanthe\r\n" +
" Sree Venkatachalapathe! thava Suprabhatham\r\n\r\n" +
" Sree bhoominayaka dayadhi gunammruthabdhe\r\n" +
" Devadideva jagadeka saranya moorthe\r\n" +
" Sreemannanantha garudadibhirarchithangre\r\n" +
" Sree Venkatachalapathe! thava suprabhatham\r\n\r\n" +
" Sree Padmanabha Purushothama Vasudeva\r\n" +
" Vaikunta Madhava Janardhana chakrapane\r\n" +
" Sree vathsachinha saranagatha parijatha\r\n" +
" Sree Venkatachalapathe! thava suprabhatham\r\n\r\n" +
" Kandarpa darpa hara sundara divya murthe\r\n" +
" Kanthaa kuchamburuha kutmialola drishte\r\n" +
" Kalyana nirmala gunakara divyakeerthe\r\n" +
" Sree Venkatachalapathe! thava suprabhatham\r\n\r\n" +
" Meenakruthe kamatakola Nrusimha varnin\r\n" +
" Swamin parashvatha thapodana Ramachandra\r\n" +
" Seshamsharama yadhunandana kalki roopa\r\n" +
" Sree Venkatachalapathe! thava suprabhatham\r\n\r\n" +
" Elaa lavanga ghanasaara sugandhi theertham\r\n" +
" Divyam viyathsarithi hemaghateshu poornam\r\n" +
" Drutwadhya vaidika sikhamanaya: prahrushta:\r\n" +
" Thishtanthi Venkatapathe! thava suprabhatham\r\n\r\n" +
" Bhaswanudethi vikachani saroruhani\r\n" +
" Sampoorayanthi ninadai: kakubho vihangha:\r\n" +
" Sree vaishnavassathatha marthitha mangalasthe\r\n" +
" Dhamasrayanthi thava Venkata! Subrabhatham\r\n\r\n" +
" Bhramadayassuravarasamaharshayastthe\r\n" +
" Santhassa nandana mukhastvatha yogivarya:\r\n" +
" Dhamanthike thavahi mangala vasthu hasthaa:\r\n" +
" Sree Venkatachalapathe! thava suprabhatham\r\n\r\n" +
" Lakshminivasa niravadya gunaika sindo:\r\n" +
" Samsarasagara samuththaranaika setho\r\n" +
" Vedanta vedya nijavaibhava bhakta bhogya\r\n" +
" Sree Venkatachalapathe! thava suprabhatham (Twice)\r\n\r\n" +
" ltnam vnsnacnala pamerlna suprabhatham\r\n" +
" Ye manava: prathidinam patithum pravrutha:\r\n" +
" Thesham prabhatha samaye smruthirangabhhajam\r\n" +
" Pragnyam paraartha sulabham paramam prasoothe (Twice)";

        }


    }


}
