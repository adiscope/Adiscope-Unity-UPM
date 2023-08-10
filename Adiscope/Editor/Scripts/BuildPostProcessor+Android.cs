using System;
using System.IO;
using System.Net;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Adiscope.Editor;

namespace Adiscope
{
    class BuildPostProcessorForAndroid
    {
        #region CONST VARIABLES
        private const string PATH_ADISCOPE_FILES        = "/Adiscope/AdiscopeAppSettingsFiles";
        private const string PATH_ADISCOPE_EDITOR       = "/Adiscope/AdiscopeAppSettingsFiles/Editor";
        private const string PATH_ADISCOPE_MANIFEST     = "/Adiscope/AdiscopeAppSettingsFiles/Adiscope.androidlib";
        private const string DISPLAY_PROGRESS_DIALOG_TITLE = "Adiscope Install";
        #endregion

        public static bool CreateAdiscopeAndroidFiles(bool isProgress)
        {
            bool isFrameworks = CopyAdiscopeFrameworks(
                new List<AdiscopeFrameworkAndroidType>()
                {
                    AdiscopeFrameworkAndroidType.Admob,
                    AdiscopeFrameworkAndroidType.ChartBoost,
                    AdiscopeFrameworkAndroidType.Ironsource,
                    AdiscopeFrameworkAndroidType.UnityAds,
                    AdiscopeFrameworkAndroidType.MAX,
                    AdiscopeFrameworkAndroidType.AppLovin,
                    AdiscopeFrameworkAndroidType.FAN,
                    AdiscopeFrameworkAndroidType.Inmobi,
                    AdiscopeFrameworkAndroidType.MobVista,
                    AdiscopeFrameworkAndroidType.Pangle,
                    AdiscopeFrameworkAndroidType.Smaato,
                    AdiscopeFrameworkAndroidType.Tapjoy,
                    AdiscopeFrameworkAndroidType.Vungle
                }
            , isProgress);
            bool isUpdate = UpdateAndroidManifest(isProgress);
            return (isFrameworks && isUpdate);
        }

        /*** AndroidManifest 파일 생성 start ***/
        private static bool UpdateAndroidManifest(bool isProgress)
        {
            if (isProgress) {
                if (EditorUtility.DisplayCancelableProgressBar(
                        DISPLAY_PROGRESS_DIALOG_TITLE,
                        "Update AndroidManifest.xml",
                        0.8f
                    )){
                    EditorUtility.ClearProgressBar();
                    return false;
                }
            }

            ManifestHandler manifestHandler = GetManifestHandler();     // Manifest에 필수 항목 추가
            string manifestPath = CreateAdiscopeManifestDirectory();    // 폴더 생성
            manifestPath += "/AndroidManifest.xml";                     // 파일명 지정

            return manifestHandler.WriteXmlFile(manifestPath);
        }

        private static ManifestHandler GetManifestHandler()
        {
            ManifestHandler handler = new ManifestHandler("com.nps.adiscope");
            handler.AddMetaData(
                "<meta-data android:name=\"adiscope_media_id\" android:value=\"" + GetMediaId_AOS() + "\" />"
            );
            handler.AddMetaData(
                "<meta-data android:name=\"adiscope_media_secret\" android:value=\"" + GetMediaSecret_AOS() + "\" />"
            );
            handler.AddMetaData(
                "<meta-data android:name=\"adiscope_sub_domain\" android:value=\"" + GetSubDomain() + "\" />"
            );
            handler.AddMetaData(
                "<meta-data android:name=\"com.google.android.gms.ads.APPLICATION_ID\" android:value=\"" + GetGoogleAdsApplicationId() + "\" />"
            );

            // 상세 이동을 위해서 추가
            handler.AddActivity(
                    "<activity android:name=\"com.nps.adiscope.core.offerwall.adv.act.AdvancedOfferwallActivity\" android:configChanges=\"orientation|screenSize|keyboardHidden\" " +
                    "android:exported=\"true\" android:theme=\"@android:style/Theme.NoTitleBar\" android:screenOrientation=\"portrait\" android:hardwareAccelerated=\"true\" >" +
                        "<intent-filter>" +
                            "<action android:name=\"android.intent.action.VIEW\"/>" +
                            "<category android:name=\"android.intent.category.DEFAULT\"/>" +
                            "<category android:name=\"android.intent.category.BROWSABLE\"/>" +
                            "<data android:host=\"*.adiscope.com\" android:pathPrefix=\"/" + GetMediaId_AOS() + "\" android:scheme=\"adiscope" + GetSubDomain() + "\"/>" +
                        "</intent-filter>" +
                        "<intent-filter android:autoVerify=\"true\">" +
                            "<action android:name=\"android.intent.action.VIEW\"/>" +
                            "<category android:name=\"android.intent.category.DEFAULT\"/>" +
                            "<category android:name=\"android.intent.category.BROWSABLE\"/>" +
                            "<data android:host=\"" + GetSubDomain() + ".adiscope.com\" android:scheme=\"https\" />" +
                        "</intent-filter>" +
                    "</activity>"
            );

            return handler;
        }

        private static string CreateAdiscopeManifestDirectory()
        {
            string manifestPath = Application.dataPath + PATH_ADISCOPE_MANIFEST;
            if (!Directory.Exists(manifestPath))
            {
                Directory.CreateDirectory(manifestPath);
            }
            return manifestPath;
        }

        private static string GetMediaId_AOS() {
            var serialized = GetSettingsRegisterSerializedObject();
            return serialized.FindProperty("_mediaID_aos").stringValue;
        }

        private static string GetMediaSecret_AOS() {
            var serialized = GetSettingsRegisterSerializedObject();
            return serialized.FindProperty("_mediaSecret_aos").stringValue;
        }

        private static string GetSubDomain() {
            var serialized = GetSettingsRegisterSerializedObject();
            return serialized.FindProperty("_subDomain").stringValue;
        }

        private static string GetGoogleAdsApplicationId() {
            var serialized = GetSettingsRegisterSerializedObject();
            return serialized.FindProperty("_admobAppKey_aos").stringValue;
        }

        private static SerializedObject GetSettingsRegisterSerializedObject() {
            var settings = FrameworkSettingsRegister.Load();
            return new SerializedObject(settings);
        }
        /*** AndroidManifest 파일 생성 end ***/

        /*** edm4u를 설정 하기 위해 adapter 파일 생성 start ***/
        private static bool CopyAdiscopeFrameworks(List<AdiscopeFrameworkAndroidType> usingFrameworks, bool isProgress)
        {
            DeleteAdiscopeFrameworks(); // 기존 adapter edm4u 파일 삭제
            CreateAdiscopeFrameworksDirectory(); // edm4u 파일을 copy 할 폴더 생성
            return FileDownloadEdm4uAdapter(usingFrameworks, isProgress); // edm4u 파일 다운로드
        }

        private static void DeleteAdiscopeFrameworks()
        {
            if (Directory.Exists(Application.dataPath + PATH_ADISCOPE_EDITOR))
            {
                string path = Application.dataPath + PATH_ADISCOPE_FILES;
                foreach (string directory in Directory.GetDirectories(path))
                {
                    try
                    {
                        Directory.Delete(directory, true);
                    }
                    catch (IOException)
                    {
                        Directory.Delete(directory, true);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Directory.Delete(directory, true);
                    }
                }
            }
        }

        private static void CreateAdiscopeFrameworksDirectory()
        {
            if (!Directory.Exists(Application.dataPath + PATH_ADISCOPE_EDITOR))
            {
                Directory.CreateDirectory(Application.dataPath + PATH_ADISCOPE_EDITOR);
            }
        }

        private static bool FileDownloadEdm4uAdapter(List<AdiscopeFrameworkAndroidType> usingFrameworks, bool isProgress)
        {
            float progress = 0.4f / usingFrameworks.Count;
            float totalProgress = 0.4f + progress;
            foreach (AdiscopeFrameworkAndroidType type in usingFrameworks)
            {
                if (!type.GetAdapterEnable())
                {
                    continue;
                }

                if (isProgress) {
                    if (EditorUtility.DisplayCancelableProgressBar(
                            DISPLAY_PROGRESS_DIALOG_TITLE,
                            "Download Adapter Files",
                            totalProgress))
                    {
                        EditorUtility.ClearProgressBar();
                        return false;
                    }

                    totalProgress += progress;
                }

                if(!DownloadAdapterFile(type.GetFilePath(), type.GetFileName())){
                    EditorUtility.ClearProgressBar();
                    EditorUtility.DisplayDialog("Failed to install", "파일 생성 실패", "닫기");
                    return false;
                }
            }

            return true;
        }

        private static bool DownloadAdapterFile(string file_path, string file_name)
        {
            string uriString = file_path;
            uriString += file_name;
            try
            {
                (new WebClient()).DownloadFile(
                    new Uri(uriString),
                    Path.Combine(Application.dataPath + PATH_ADISCOPE_EDITOR, file_name)
                );
            }
            catch (Exception exception) { 
                Debug.LogError("failed to download adapter file: " + exception.Message);
                EditorUtility.ClearProgressBar();
                return false;
            }

            return true;
        }
        /*** edm4u를 설정 하기 위해 adapter 파일 생성 end ***/
    }

    public enum AdiscopeFrameworkAndroidType
    {
        Admob,
        ChartBoost,
        Ironsource,
        UnityAds,
        MAX,
        AppLovin,
        FAN,
        Inmobi,
        MobVista,
        Pangle,
        Smaato,
        Tapjoy,
        Vungle
    }

    static class AdiscopeFrameworkAndroidTypeExtension
    {
        private const string ADMOB_FILE_NAME        = "AdmobDependencies.xml";
        private const string CHARTBOOST_FILE_NAME   = "ChartboostDependencies.xml";
        private const string IRONSOURCE_FILE_NAME   = "IronsourceDependencies.xml";
        private const string UNITYADS_FILE_NAME     = "UnityadsDependencies.xml";
        private const string MAX_FILE_NAME          = "MaxDependencies.xml";
        private const string APPLOVIN_FILE_NAME     = "ApplovinDependencies.xml";
        private const string FAN_FILE_NAME          = "FanDependencies.xml";
        private const string INMOBI_FILE_NAME       = "InmobiDependencies.xml";
        private const string MOBVISTA_FILE_NAME     = "MobvistaDependencies.xml";
        private const string PANGLE_FILE_NAME       = "PangleDependencies.xml";
        private const string SMAATO_FILE_NAME       = "SmaatoDependencies.xml";
        private const string TAPJOY_FILE_NAME       = "TapjoyDependencies.xml";
        private const string VUNGLE_FILE_NAME       = "VungleDependencies.xml";

        private const string ADISCOPE_FILE_PATH     = "https://github.com/adiscope/Adiscope-Android-Sample/releases/download/";
        private const string ADMOB_FILE_PATH        = ADISCOPE_FILE_PATH + "3.0.0/";
        private const string CHARTBOOST_FILE_PATH   = ADISCOPE_FILE_PATH + "3.0.0/";
        private const string IRONSOURCE_FILE_PATH   = ADISCOPE_FILE_PATH + "3.0.0/";
        private const string UNITYADS_FILE_PATH     = ADISCOPE_FILE_PATH + "3.0.0/";
        private const string MAX_FILE_PATH          = ADISCOPE_FILE_PATH + "3.0.0/";
        private const string APPLOVIN_FILE_PATH     = ADISCOPE_FILE_PATH + "3.0.0/";
        private const string FAN_FILE_PATH          = ADISCOPE_FILE_PATH + "3.0.0/";
        private const string INMOBI_FILE_PATH       = ADISCOPE_FILE_PATH + "3.0.0/";
        private const string MOBVISTA_FILE_PATH     = ADISCOPE_FILE_PATH + "3.0.0/";
        private const string PANGLE_FILE_PATH       = ADISCOPE_FILE_PATH + "3.0.0/";
        private const string SMAATO_FILE_PATH       = ADISCOPE_FILE_PATH + "3.0.0/";
        private const string TAPJOY_FILE_PATH       = ADISCOPE_FILE_PATH + "3.0.0/";
        private const string VUNGLE_FILE_PATH       = ADISCOPE_FILE_PATH + "3.0.0/";

        public static string GetFileName(this AdiscopeFrameworkAndroidType type)
        {
            switch (type)
            {
                case AdiscopeFrameworkAndroidType.Admob:        return ADMOB_FILE_NAME;
                case AdiscopeFrameworkAndroidType.ChartBoost:   return CHARTBOOST_FILE_NAME;
                case AdiscopeFrameworkAndroidType.Ironsource:   return IRONSOURCE_FILE_NAME;
                case AdiscopeFrameworkAndroidType.UnityAds:     return UNITYADS_FILE_NAME;
                case AdiscopeFrameworkAndroidType.MAX:          return MAX_FILE_NAME;
                case AdiscopeFrameworkAndroidType.AppLovin:     return APPLOVIN_FILE_NAME;
                case AdiscopeFrameworkAndroidType.FAN:          return FAN_FILE_NAME;
                case AdiscopeFrameworkAndroidType.Inmobi:       return INMOBI_FILE_NAME;
                case AdiscopeFrameworkAndroidType.MobVista:     return MOBVISTA_FILE_NAME;
                case AdiscopeFrameworkAndroidType.Pangle:       return PANGLE_FILE_NAME;
                case AdiscopeFrameworkAndroidType.Smaato:       return SMAATO_FILE_NAME;
                case AdiscopeFrameworkAndroidType.Tapjoy:       return TAPJOY_FILE_NAME;
                case AdiscopeFrameworkAndroidType.Vungle:       return VUNGLE_FILE_NAME;
                default:                                        return null;
            }
        }

        public static string GetFilePath(this AdiscopeFrameworkAndroidType type)
        {
            switch (type)
            {
                case AdiscopeFrameworkAndroidType.Admob:        return ADMOB_FILE_PATH;
                case AdiscopeFrameworkAndroidType.ChartBoost:   return CHARTBOOST_FILE_PATH;
                case AdiscopeFrameworkAndroidType.Ironsource:   return IRONSOURCE_FILE_PATH;
                case AdiscopeFrameworkAndroidType.UnityAds:     return UNITYADS_FILE_PATH;
                case AdiscopeFrameworkAndroidType.MAX:          return MAX_FILE_PATH;
                case AdiscopeFrameworkAndroidType.AppLovin:     return APPLOVIN_FILE_PATH;
                case AdiscopeFrameworkAndroidType.FAN:          return FAN_FILE_PATH;
                case AdiscopeFrameworkAndroidType.Inmobi:       return INMOBI_FILE_PATH;
                case AdiscopeFrameworkAndroidType.MobVista:     return MOBVISTA_FILE_PATH;
                case AdiscopeFrameworkAndroidType.Pangle:       return PANGLE_FILE_PATH;
                case AdiscopeFrameworkAndroidType.Smaato:       return SMAATO_FILE_PATH;
                case AdiscopeFrameworkAndroidType.Tapjoy:       return TAPJOY_FILE_PATH;
                case AdiscopeFrameworkAndroidType.Vungle:       return VUNGLE_FILE_PATH;
                default:                                        return null;
            }
        }

        public static bool GetAdapterEnable(this AdiscopeFrameworkAndroidType type)
        {
            var settings = FrameworkSettingsRegister.Load();
            var serialized = new SerializedObject(settings);

            switch (type)
            {
                case AdiscopeFrameworkAndroidType.Admob:        return (serialized.FindProperty("_admobAdapter").intValue == 1 || serialized.FindProperty("_admobAdapter").intValue == 2);
                case AdiscopeFrameworkAndroidType.ChartBoost:   return (serialized.FindProperty("_chartboostAdapter").intValue == 1 || serialized.FindProperty("_chartboostAdapter").intValue == 2);
                case AdiscopeFrameworkAndroidType.Ironsource:   return (serialized.FindProperty("_ironsourceAdapter").intValue == 1 || serialized.FindProperty("_ironsourceAdapter").intValue == 2);
                case AdiscopeFrameworkAndroidType.UnityAds:     return (serialized.FindProperty("_unityadsAdapter").intValue == 1 || serialized.FindProperty("_unityadsAdapter").intValue == 2);
                case AdiscopeFrameworkAndroidType.MAX:          return (serialized.FindProperty("_maxAdapter").intValue == 1 || serialized.FindProperty("_maxAdapter").intValue == 2);
                case AdiscopeFrameworkAndroidType.AppLovin:     return (serialized.FindProperty("_applovinAdapter").intValue == 1 || serialized.FindProperty("_applovinAdapter").intValue == 2);
                case AdiscopeFrameworkAndroidType.FAN:          return (serialized.FindProperty("_fanAdapter").intValue == 1 || serialized.FindProperty("_fanAdapter").intValue == 2);
                case AdiscopeFrameworkAndroidType.Inmobi:       return (serialized.FindProperty("_inmobiAdapter").intValue == 1 || serialized.FindProperty("_inmobiAdapter").intValue == 2);
                case AdiscopeFrameworkAndroidType.MobVista:     return (serialized.FindProperty("_mobvistaAdapter").intValue == 1 || serialized.FindProperty("_mobvistaAdapter").intValue == 2);
                case AdiscopeFrameworkAndroidType.Pangle:       return (serialized.FindProperty("_pangleAdapter").intValue == 1 || serialized.FindProperty("_pangleAdapter").intValue == 2);
                case AdiscopeFrameworkAndroidType.Smaato:       return (serialized.FindProperty("_smaatoAdapter").intValue == 1 || serialized.FindProperty("_smaatoAdapter").intValue == 2);
                case AdiscopeFrameworkAndroidType.Tapjoy:       return (serialized.FindProperty("_tapjoyAdapter").intValue == 1 || serialized.FindProperty("_tapjoyAdapter").intValue == 2);
                case AdiscopeFrameworkAndroidType.Vungle:       return (serialized.FindProperty("_vungleAdapter").intValue == 1 || serialized.FindProperty("_vungleAdapter").intValue == 2);
                default:                                        return false;
            }
        }
    }
}
