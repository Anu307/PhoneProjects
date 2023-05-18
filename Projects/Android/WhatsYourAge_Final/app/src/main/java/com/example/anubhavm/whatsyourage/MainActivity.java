package com.example.anubhavm.whatsyourage;

import android.app.Activity;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.AlertDialog;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.DatePicker;
import android.widget.TextView;
import android.widget.Toast;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import com.google.android.gms.ads.AdRequest;
import com.google.android.gms.ads.AdView;

public class MainActivity extends Activity {
    private DatePicker datePicker;
    private Calendar calendar;
    private TextView dateView;
    private TextView ResultsView;
    private TextView ResultsYearView;
    private TextView ResultsMonthsView;
    private TextView ResultsDaysView;
    private TextView AbsoluteView;
    private TextView AbsoluteDayView;
    private TextView AbsoluteHoursView;
    private TextView AbsoluteMinutesView;
    private TextView AbsoluteSecondsView;
    private int presentyear, presentmonth, presentday;
    private int birthyear, birthmonth, birthday;
    private GregorianCalendar birthcal;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        AdView mAdView1 = (AdView) findViewById(R.id.adView1);
        AdView mAdView2 = (AdView) findViewById(R.id.adView2);

        AdRequest request = new AdRequest.Builder()
                .addTestDevice(AdRequest.DEVICE_ID_EMULATOR)        // All emulators
                .addTestDevice("AC98C820A50B4AD8A2106EDE96FB87D4")  // My Galaxy Nexus test phone
                .build();
       /* mAdView1.loadAd(request);
        mAdView2.loadAd(request);*/

        AdRequest adRequest1 = new AdRequest.Builder().build();
        mAdView1.loadAd(adRequest1);
        AdRequest adRequest2 = new AdRequest.Builder().build();
        mAdView2.loadAd(adRequest2);


        calendar = Calendar.getInstance();
        presentyear = calendar.get(Calendar.YEAR);
        presentmonth = calendar.get(Calendar.MONTH);
        presentday = calendar.get(Calendar.DAY_OF_MONTH);
        SetUpView();
        SetVisibility(View.INVISIBLE);
    }
    protected void SetUpView()
    {
        dateView = (TextView) findViewById(R.id.Date_Birth);
        ResultsView =(TextView) findViewById(R.id.Results_View);
        ResultsYearView =(TextView) findViewById(R.id.Results_Years);
        ResultsMonthsView=(TextView) findViewById(R.id.Results_Months);
        ResultsDaysView=(TextView) findViewById(R.id.Results_Days);
        AbsoluteView=(TextView) findViewById(R.id.Results_Absolute);
        AbsoluteDayView=(TextView) findViewById(R.id.Absolute_Days);
        AbsoluteHoursView=(TextView) findViewById(R.id.Absolute_Hours);
        AbsoluteMinutesView=(TextView) findViewById(R.id.Absolute_Minutes);
        AbsoluteSecondsView=(TextView) findViewById(R.id.Absolute_Seconds);
    }
    protected void SetVisibility(int visibility)
    {
        ResultsView.setVisibility(visibility);
        ResultsYearView.setVisibility(visibility);
        ResultsMonthsView.setVisibility(visibility);
        ResultsDaysView.setVisibility(visibility);
        AbsoluteView.setVisibility(visibility);
        AbsoluteDayView.setVisibility(visibility);
        AbsoluteHoursView.setVisibility(visibility);
        AbsoluteMinutesView.setVisibility(visibility);
        AbsoluteSecondsView.setVisibility(visibility);
    }
    public void DateSelect(View view) {
        showDialog(999);
        Toast.makeText(getApplicationContext(), "ca", Toast.LENGTH_SHORT)
                .show();
       // AgeView.setVisibility(View.VISIBLE);
    }
    protected Dialog onCreateDialog(int id) {
        // TODO Auto-generated method stub
        if (id == 999) {
            return new DatePickerDialog(this, myDateListener, presentyear, presentmonth, presentday);
        }
        return null;
    }
    private DatePickerDialog.OnDateSetListener myDateListener = new DatePickerDialog.OnDateSetListener() {
        @Override
        public void onDateSet(DatePicker arg0, int arg1, int arg2, int arg3) {
            // TODO Auto-generated method stub
            // arg1 = year
            // arg2 = month
            // arg3 = day
            showDate(arg1, arg2+1, arg3);
        }
    };
    private void showDate(int year, int month, int day) {

       /*dateView.setText(new StringBuilder().append(day).append("/")
         .append(month).append("/").append(year));*/
        birthyear = year;
        birthmonth =month;
        birthday =day;
        birthcal = new GregorianCalendar(birthyear, birthmonth-1,birthday);

        SimpleDateFormat formatter = new SimpleDateFormat("EEEE-MMMM-dd-yyyy");
        String birth = formatter.format(birthcal.getTime());
        dateView.setText(birth);
        DoCalculations();
    }
    private boolean ShowMessageBox()
    {
        String strTitle="Tough chance for the app";
        String strmessage = "";
        if(calendar.compareTo(birthcal)<0) {

            strmessage="Date of birth in future. Its a calculator app, not a crystal ball gazer";

        }
        if(calendar.compareTo(birthcal)==0) {
            strmessage = "You are born today, enjoy life, why bother abt the age";
        }
        if(birthyear<1900) {
            strmessage ="You are more than a 100 years old, does it matter how old exactly it is";
        }
        if(strmessage =="") {
        return false;
        }

        AlertDialog alertDialog;
        alertDialog = new AlertDialog.Builder(this).create();
        alertDialog.setTitle(strTitle);
        alertDialog.setMessage(strmessage);
        alertDialog.show();

        SetVisibility(View.INVISIBLE);
        return true;
    }
    private void DoCalculations()
    {
        if(ShowMessageBox())
        {
            return;
        }
        SetVisibility(View.VISIBLE);
        int daysInBaseMonth = birthcal.getActualMaximum(birthcal.DATE);
        int rYears = presentyear- birthyear;
        int rMonths = presentmonth- birthmonth +1;
        if(rMonths<0) {
            rMonths+=12;
             rYears-=1;
        }
        int rDays = presentday - birthday;
        if (rDays < 0)
        {
            rDays += daysInBaseMonth;
            rMonths -= 1;
        }
        if (rMonths < 0)
        {
            rMonths += 12;
            rYears -= 1;//' add 1 year to months, and remove 1 year from years.
        }
        ResultsYearView.setText(new StringBuilder().append("Years: ").append(rYears));
        ResultsMonthsView.setText(new StringBuilder().append("Months: ").append(rMonths));
        ResultsDaysView.setText(new StringBuilder().append("Days: ").append(rDays));

        long totalMillis = calendar.getTimeInMillis() - birthcal.getTimeInMillis();
        long x= totalMillis/1000;
        long seconds =  x % 60;
        x/=60;
        long minutes =  x % 60;
        x/=60;
        long hours = x%24;
        x/=24;
        long days = x;
        hours = days*24;
        minutes = hours *60;
        seconds =minutes*60;


        AbsoluteDayView.setText(new StringBuilder().append("Days: ").append(days));
        AbsoluteHoursView.setText(new StringBuilder().append("Hours: ").append(hours));
        AbsoluteMinutesView.setText(new StringBuilder().append("Minutes: ").append(minutes));
        AbsoluteSecondsView.setText(new StringBuilder().append("Seconds: ").append(seconds));

    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
