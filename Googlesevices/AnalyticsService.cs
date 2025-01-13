﻿
using Firebase.Analytics;

namespace mauinewfirebase.Googlesevices
{
    public class AnalyticsService : IAnalyticsService
    {
        public void Log(string eventName)
        {
#if IOS
            Analytics.LogEvent(eventName, (Dictionary<object, object>)null);
#endif 
#if ANDROID
            var firebaseAnalytics = FirebaseAnalytics.GetInstance(Platform.CurrentActivity);
            firebaseAnalytics.LogEvent(eventName, null);
#endif
        }
    }
}
