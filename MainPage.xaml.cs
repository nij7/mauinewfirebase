﻿using mauinewfirebase.Googlesevices;

namespace mauinewfirebase
{
    public partial class MainPage : ContentPage
    {
        private readonly IAnalyticsService _analyticsService;

        public MainPage(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
            InitializeComponent();
        }
        private void AnalyticsLog_Clicked(object sender, EventArgs e)
        {

            _analyticsService.Log("Event_AnaliticsLogClicked");


        }


    }

}