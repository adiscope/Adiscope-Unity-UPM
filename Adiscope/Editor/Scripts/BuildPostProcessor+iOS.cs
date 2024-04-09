#if UNITY_IOS

using System;
using System.IO;
using System.Net;
using UnityEditor;
using UnityEditor.iOS.Xcode;
using UnityEditor.iOS.Xcode.Extensions;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

using Adiscope.Extension;

namespace Adiscope.PostProcessor
{
    class BuildPostProcessorForIos {
        private static string prefixURI = "https://github.com/adiscope/Adiscope-iOS-Sample/releases/download/3.4.0/";
        private static string adiscopeFrameworkPath = "../Packages/com.tnk.adiscope/Plugins/iOS";
        private static string adiscopeUnityPath = "com.tnk.adiscope/Plugins/iOS";

        public static void OnPostProcessBuild(string path) {
            CopyAdiscopeFrameworks(path, new List<AdiscopeFrameworkType>() {
                AdiscopeFrameworkType.Core,
                AdiscopeFrameworkType.AppLovin,
                AdiscopeFrameworkType.Max,
            });
            UpdateBuildSetting(path);
            UpdateInfoPlist(path);
        }

        private static string GetDefaultTarget(PBXProject project) {
            return project.GetUnityMainTargetGuid();
        }

        private static string GetFrameworkTarget(PBXProject project) {
            return project.GetUnityFrameworkTargetGuid();
        }

        private static void CopyAdiscopeFrameworks(string path, List<AdiscopeFrameworkType> usingFrameworks) {
            string projectPath = PBXProject.GetPBXProjectPath(path);     
            string contents = File.ReadAllText(projectPath);

            PBXProject project = new PBXProject();
            project.ReadFromString(contents); 

            string buildTargetGUID = GetDefaultTarget(project);

            string embedSectionID = project.AddCopyFilesBuildPhase(buildTargetGUID, "Embed Frameworks", "", "10");
            string linkPhaseGuid = project.GetFrameworksBuildPhaseByTarget(buildTargetGUID);
            string resourcesGuid = project.GetResourcesBuildPhaseByTarget(buildTargetGUID);

            project.AddBuildProperty(buildTargetGUID, "VALIDATE_WORKSPACE", "YES");
            project.AddBuildProperty(buildTargetGUID, "FRAMEWORK_SEARCH_PATHS", "$(inherited)");
            project.AddBuildProperty(buildTargetGUID, "FRAMEWORK_SEARCH_PATHS", "$(PROJECT_DIR)/Frameworks/" + adiscopeUnityPath);
            
            bool isAddAppLovinSDK = false;
            foreach (AdiscopeFrameworkType type in usingFrameworks) {
                if (!type.GetAdapterEnable()) {
                    continue;
                }
                string fileID = project.AddFile(
                    "Frameworks/" + adiscopeUnityPath + "/" + type.GetFileName(),
                    "Frameworks/" + adiscopeUnityPath + "/" + type.GetFileName()
                );
                
                if (false == type.IsEmbedFramework()) {
                    List<string> childFiles = type.GetChildFrameworkName();
                    if (childFiles == null) { continue; }

                    foreach (string childFileName in childFiles) {
                        string childFileID = project.AddFile(
                            "Frameworks/" + adiscopeUnityPath + "/" + childFileName,
                            "Frameworks/" + adiscopeUnityPath + "/" + childFileName
                        );

                        // Only used when AppLovinSDK are Dynamic Frameworks
                        if (!isAddAppLovinSDK && childFileName == "AppLovinSDK.framework") {
                            isAddAppLovinSDK = true;
                            project.AddFileToBuildSection(buildTargetGUID, embedSectionID, childFileID);
                            PBXProjectExtensions.AddFileToEmbedFrameworks(project, buildTargetGUID, childFileID);
                        }
                    }
                    continue;
                }

                project.AddFileToBuildSection(buildTargetGUID, embedSectionID, fileID);
                PBXProjectExtensions.AddFileToEmbedFrameworks(project, buildTargetGUID, fileID);
            }

            File.WriteAllText(projectPath, project.WriteToString());

            UpdateDuplicateFrameworkSourceReference(projectPath, adiscopeFrameworkPath);
        }

        private static void UpdateDuplicateFrameworkSourceReference(string projectPath, string adiscopeUnityPath) {
            string contents = File.ReadAllText(projectPath);

            string[] contentList = contents.Split(new char[] {'\n'});
            List<string> result = new List<string>();

            foreach (string line in contentList) {
                bool isMatch = Regex.IsMatch(line, ".*Frameworks/" + adiscopeUnityPath + "/; sourceTree = SOURCE_ROOT;");
                if (!isMatch) { result.Add(line); }
            }

            contents = String.Join("\n", result);

            PBXProject project = new PBXProject();
            project.ReadFromString(contents);
            File.WriteAllText(projectPath, project.WriteToString());
        }

        private static void UpdateBuildSetting(string path) {
            string projectPath = PBXProject.GetPBXProjectPath(path);     
            string contents = File.ReadAllText(projectPath);

            PBXProject project = new PBXProject();
            project.ReadFromString(contents); 

            string defaultTarget = GetDefaultTarget(project);
            string buildFrameworkTarget = GetFrameworkTarget(project);

            // Add `-ObjC` to "Other Linker Flags".
            project.AddBuildProperty(defaultTarget, "OTHER_LDFLAGS", "-ObjC");
            project.AddBuildProperty(defaultTarget, "LD_RUNPATH_SEARCH_PATHS", "/usr/lib/swift");
            // Update 'NO' to "ENABLE_BITCODE"
            project.UpdateBuildProperty(defaultTarget, "ENABLE_BITCODE", new  string [] { "NO" }, new  string [] { "YES" });
            project.UpdateBuildProperty(buildFrameworkTarget, "ENABLE_BITCODE", new  string [] { "NO" }, new  string [] { "YES" });

            File.WriteAllText(projectPath, project.WriteToString());
        }
        
        private static void UpdateInfoPlist(string path) {
            string plistPath = Path.Combine (path, "Info.plist" );
            PlistDocument root = new PlistDocument();
            root.ReadFromFile(plistPath);
            
            Dictionary<string, object> injectPlistInfo = new Dictionary<string, object>{
                // Admob, AdManager
                { "GADIsAdManagerApp", true },

                // Permissions
                { "NSUserTrackingUsageDescription", "Some ad content may require access to the user tracking." },

                // Scheme
                { "LSApplicationQueriesSchemes", new List<string>{
                    "fb", "instagram", "tumblr", "twitter"
                }},
            };

            foreach(KeyValuePair<string, object> item in injectPlistInfo) {
                InsertInfoPlist(root.root, item.Key, item.Value);
            }

            // SKAdNetwork
            PlistElementArray targetArray = root.root.CreateArray("SKAdNetworkItems");
            DownloadSkAdNetworkPlistFile(path);
            
            string downloadedPath = Path.Combine(path, "AdiscopeSkAdNetworks.plist");
            PlistDocument skAdNetwork = new PlistDocument();
            skAdNetwork.ReadFromFile(downloadedPath);

            PlistElementArray array = (PlistElementArray)skAdNetwork.root["SKAdNetworkItems"];
            foreach(PlistElementDict item in array.values) {
                PlistElementDict dict = targetArray.AddDict();
                dict.SetString("SKAdNetworkIdentifier", item["SKAdNetworkIdentifier"].AsString());
            }

            File.Delete(downloadedPath);

            // Media Properties (Admob, Admanager)
            if (root.root.values.ContainsKey("GADApplicationIdentifier")) {
                root.root.values.Remove("GADApplicationIdentifier");
            }
            
            var settings = FrameworkSettingsRegister.Load();
            var serialized = new SerializedObject(settings);
            string googleAppKey = serialized.FindProperty("_admobAppKey_ios").stringValue;
            string appLovinKey = serialized.FindProperty("_applovinKey").stringValue;
            string mediaID_ios = serialized.FindProperty("_mediaID_ios").stringValue;
            string mediaSecret_ios = serialized.FindProperty("_mediaSecret_ios").stringValue;
            if (googleAppKey != null && googleAppKey.Length > 0) {
                InsertInfoPlist(root.root, "GADApplicationIdentifier", googleAppKey);
            }
            if (appLovinKey != null && appLovinKey.Length > 0) {
                InsertInfoPlist(root.root, "AppLovinSdkKey", appLovinKey);
            }
            if (mediaID_ios != null && mediaID_ios.Length > 0) {
                InsertInfoPlist(root.root, "AdiscopeMediaId", mediaID_ios);
            }
            if (mediaSecret_ios != null && mediaSecret_ios.Length > 0) {
                InsertInfoPlist(root.root, "AdiscopeMediaSecret", mediaSecret_ios);
            }

            string filePath = "Packages/com.tnk.adiscope/package.json";
            string json = File.ReadAllText(filePath);
            ParsingPackageJson.PackageJson pj = JsonUtility.FromJson<ParsingPackageJson.PackageJson>(json);
            InsertInfoPlist(root.root, "AdiscopeUnitySDKVersion", pj.version);
            InsertInfoPlist(root.root, "UnityRuntimeVersion", Application.unityVersion);

            root.WriteToFile(plistPath);
        }

        private static void DownloadSkAdNetworkPlistFile(string path) {
            string fileName = "AdiscopeSkAdNetworks.plist";
            string uriString = prefixURI;
            uriString += "/" + fileName;
            (new WebClient()).DownloadFile(new Uri(uriString), Path.Combine(path, fileName));
        }

        private static void InsertInfoPlist(object plist, string key, object value) {
            if (value is string) {
                if (plist is PlistElementDict) {
                    PlistElementDict plistElementDict = (PlistElementDict)plist;
                    plistElementDict.SetString(key, (string)value);
                } else if (plist is PlistElementArray) {
                    PlistElementArray plistElementArray = (PlistElementArray)plist;
                    if (plistElementArray.IsExistPlist((string)value)) { return; }
                    plistElementArray.AddString((string)value);
                }
                return;  
            } else if  (value is bool) {
                PlistElementDict plistElementDict = (PlistElementDict)plist;
                plistElementDict.SetBoolean(key, (bool)value);
            } 

            if (value is List<string>) {
                PlistElementDict rootPlistElementDict = (PlistElementDict)plist;
                PlistElementArray targetPlistElementArray = (PlistElementArray)rootPlistElementDict[key];
                if (targetPlistElementArray == null) { targetPlistElementArray = rootPlistElementDict.CreateArray(key); }

                foreach (string item in (List<string>)value) {
                    InsertInfoPlist(targetPlistElementArray, null, item);
                }
            } else if (value is Dictionary<string, object>) {
                PlistElementDict rootPlistElementDict = (PlistElementDict)plist;
                PlistElementDict targetPlistElementDict = (PlistElementDict)rootPlistElementDict[key];
                if (targetPlistElementDict == null) { rootPlistElementDict.CreateDict(key); }

                foreach (KeyValuePair<string, object> valueItem in (Dictionary<string, object>)value) {
                    InsertInfoPlist(targetPlistElementDict, valueItem.Key, valueItem.Value);
                }
            }
        }
    }

    public enum AdiscopeFrameworkType {
        Core,
        AppLovin,
        Max
    }

    static class AdiscopeFrameworkTypeExtension {

        public static bool IsEmbedFramework(this AdiscopeFrameworkType type) {
            return type == AdiscopeFrameworkType.Core;
        }

        public static string GetFileName(this AdiscopeFrameworkType type) {
            switch (type) {
                case AdiscopeFrameworkType.Core:        return "Adiscope.framework";
                case AdiscopeFrameworkType.AppLovin:    return "AdiscopeMediaAppLovin.framework";
                case AdiscopeFrameworkType.Max:         return "AdiscopeMediaMax.framework";
                default: return null;
            }
        }

        public static List<string> GetChildFrameworkName(this AdiscopeFrameworkType type) {
            switch (type) {
                case AdiscopeFrameworkType.Core:
                    return null;
                case AdiscopeFrameworkType.AppLovin:
                    return new List<string>() {
                        "AppLovinSDK.framework"
                    };
                case AdiscopeFrameworkType.Max:
                    return new List<string>() {
                        "AppLovinSDK.framework"
                    };
                default:
                    return null;
            }
        }

        public static bool GetAdapterEnable(this AdiscopeFrameworkType type) {
            var settings = FrameworkSettingsRegister.Load();
            var serialized = new SerializedObject(settings);

            switch (type) {
                case AdiscopeFrameworkType.Core:        return true;
                case AdiscopeFrameworkType.AppLovin:    return (serialized.FindProperty("_applovinAdapter").intValue == 1 || serialized.FindProperty("_applovinAdapter").intValue == 3);
                case AdiscopeFrameworkType.Max:         return (serialized.FindProperty("_maxAdapter").intValue == 1 || serialized.FindProperty("_maxAdapter").intValue == 3);
                default: return false;
            }
        }
    }
}

#endif
