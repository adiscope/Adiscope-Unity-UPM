using System;
using System.Collections.Generic;
using UnityEngine;

namespace Adiscope
{
    public class FrameworkSettings : ScriptableObject
    {
        [SerializeField]
        string _mediaID_aos;

        [SerializeField]
        string _mediaSecret_aos;

        [SerializeField]
        string _mediaID_ios;

        [SerializeField]
        string _mediaSecret_ios;

        [SerializeField]
        string _subDomain;

        [SerializeField]
        int _admobAdapter;

        [SerializeField]
        string _admobAppKey_aos;

        [SerializeField]
        string _admobAppKey_ios;

        [SerializeField]
        int _maxAdapter;

        [SerializeField]
        int _applovinAdapter;

        [SerializeField]
        string _applovinKey;

        [SerializeField]
        int _admanagerAdapter;

        [SerializeField]
        int _chartboostAdapter;

        [SerializeField]
        int _fanAdapter;

        [SerializeField]
        int _inmobiAdapter;

        [SerializeField]
        int _ironsourceAdapter;

        [SerializeField]
        int _mobvistaAdapter;

        [SerializeField]
        int _pangleAdapter;

        [SerializeField]
        int _smaatoAdapter;

        [SerializeField]
        int _tapjoyAdapter;

        [SerializeField]
        int _unityadsAdapter;

        [SerializeField]
        int _vungleAdapter;

        public static string MediaID_AOS { get; private set; }

        public static string MediaSecret_AOS { get; private set; }

        public static string MediaID_iOS { get; private set; }

        public static string MediaSecret_iOS { get; private set; }

        public static string SubDomain { get; private set; }

        public static int AdmobAdapter { get; private set; }

        public static string AdMobAppKey_AOS { get; private set; }

        public static string AdMobAppKey_iOS { get; private set; }

        public static int MaxAdapter { get; private set; }

        public static int AppLovinAdapter { get; private set; }

        public static string AppLovinKey { get; private set; }

        public static int AdmanagerAdapter { get; private set; }

        public static int ChartboostAdapter { get; private set; }

        public static int FanAdapter { get; private set; }

        public static int InmobiAdapter { get; private set; }

        public static int IronsourceAdapter { get; private set; }

        public static int MobvistaAdapter { get; private set; }

        public static int PangleAdapter { get; private set; }

        public static int SmaatoAdapter { get; private set; }

        public static int TapjoyAdapter { get; private set; }

        public static int UnityAdsAdapter { get; private set; }

        public static int VungleAdapter { get; private set; }
    }

    public class ParsingPackageJson : MonoBehaviour
    {
        [Serializable]
        public class PackageJson
        {
            public string name;
            public string displayName;
            public string version;
            public string description;
            public string unity;
            public string[] keywords;
            public Dictionary<string, object> author;
            public Dictionary<string, object> dependencies;
        }
    }
}