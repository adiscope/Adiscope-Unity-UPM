# Adiscope Unity Package Manager
[![GitHub package.json version](https://img.shields.io/badge/Unity-4.5.2-blue)](../../releases)
[![GitHub package.json version](https://img.shields.io/badge/Android-4.5.2-blue)](https://github.com/adiscope/Adiscope-Android-Sample)
[![GitHub package.json version](https://img.shields.io/badge/iOS-4.4.0-blue)](https://github.com/adiscope/Adiscope-iOS-Sample)
[![GitHub package.json version](https://img.shields.io/badge/Flutter-4.5.2-blue)](https://pub.dev/packages/adiscope_flutter_plugin)
[![GitHub package.json version](https://img.shields.io/badge/ReactNative-4.5.2-blue)](https://www.npmjs.com/package/@adiscope.ad/adiscope-react-native)

- ⚠️ **Unity Editor 2022.x ~ 2022.3.9f1 에서 iOS xcode16 빌드 시 사용 불가**
- Unity Editor : 2021.3.8f1+, 2022.3.10f1+, 6000.1.3f1, 6000.1.11f1, 6000.1.12f1
- Android Target API Level : 31+
- Android Minimum API Level : 21
- iOS Minimum Version : 13.0
- Xcode Minimum Version : Xcode 16.0
<details>
<summary>Networks Version</summary>
<div markdown="1">  

| Ad Network          | Android Version | iOS Version |
|---------------------|-----------------|-------------|
| AdMob               | 24.4.0          | 12.2.0      |
| Amazon              | 11.0.1          | 5.1.0       |
| AppLovin            | 13.3.1          | 13.1.0      |
| BidMachine          | 3.3.0           | 3.2.1       |
| Chartboost          | 9.8.3           | 9.8.1       |
| DT Exchange         | 8.3.7           | 8.3.5       |
| InMobi              | 10.8.3          | 10.8.2      |
| Ironsource          | 8.9.1           | 8.8.0.0     |
| Liftoff(Vungle)     | 7.5.0           | 7.4.4       |
| Meta(Fan)           | 6.20.0          | 6.17.1      |
| Mintegral(Mobvista) | 16.9.71         | 7.7.7       |
| Moloco              | 3.10.0          | 3.7.2       |
| Ogury               | 6.0.1           | 5.0.2       |
| Pangle              | 7.2.0.4         | 6.5.0.9     |
| Smaato              | 22.7.2          | 없음         |
| Unity Ads           | 4.15.0          | 4.14.0      |
| Yandex              | 7.13.0          | 없음         |

> 기존 gms SDK 사용중인 퍼블리셔는 admob 혹은 max 어댑터 사용 시 24버전으로 마이그레이션 필요 [(관련 문서)](https://developers.google.com/admob/android/migration?hl=en)
> - gms 22 버전: 애디스콥 `3.3.0`~`4.0.1`
> - gms 23 버전: 애디스콥 `4.1.0`~`4.3.2`
> - gms 24 버전: 애디스콥 `4.4.0` 이상

</div>
</details>
<br/>

## Contents
#### [Add the Adiscope package to Your Project](#add-the-adiscope-package-to-your-project-1)
- [Update the Adiscope package to Your Project](./docs/update.md)
#### [Adiscope Overview](#adiscope-overview-1)
- [Initialize](#2-initialize)
- [사용자 정보 설정](#3-사용자-정보-설정)
- [Offerwall](#4-offerwall)
- [RewardedVideo](#5-rewardedvideo)
- [Interstitial](#6-interstitial)
- [RewardedInterstitial](#7-rewardedinterstitial)
- [AdEvent](#8-adevent)
- [Other API](./docs/other_api.md#other-api-1)
#### [웹사이트 필수 등록](#웹사이트-필수-등록-android-전용)
#### [Adiscope Server 연동하기](./docs/reward_callback_info.md)
#### [Privacy Manifest 정책 적용](#privacy-manifest-정책-적용-ios-전용)
#### [Xcode에서의 Error 정리](#xcode에서의-error-정리-1)
- [Unity Editor 21.3.33f1, 21.3.34f1, 22.3.14f1, 22.3.15f1 Error 해결 방법](./docs/xcode_error.md#unity-editor-특정-버전에서-build-error)
- [Xcode Archive Error 해결 방법](./docs/xcode_error.md#xcode-archive-error)
- [Unity Editor 2022.3.9f1 이하에서 iOS xcode15 빌드 시 Error 내용](./docs/xcode_error.md#unity-editor-202239f1-이하에서-ios-xcode15-빌드-시-error)
#### [iOS 16+ Offerwall 세로 모드 전환 적용 방법(가로모드 전용일 경우)](./docs/apple_orientations.md)
#### [Adiscope Error Information](./docs/error_info.md)
#### [etc](.)
- [Adiscope Sample App](./docs/sampleapp.md)
- [Releases](../../releases)
- [LICENSE](./LICENSE)
<br/>


## Add the Adiscope package to Your Project
### 1. Unity Package Manager window
#### A. Git URL
![packagemanagerUrl](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/dc096371-e276-4386-b70f-d2bdec06c2ad)   
가. Unity의 `Window` > `Package Manager` 메뉴 클릭<br/>
나. Package Manager의 왼쪽 상단 `플러스(+)` 버튼 > `Add package from git URL` 버튼 클릭<br/>
다. 아래 링크를 붙여넣고 `Add` 버튼 클릭<br/>
```
https://github.com/adiscope/Adiscope-Unity-UPM.git?path=Adiscope
```
> - [결과 확인](./docs/upm_result.md#1-a-unity-package-manager-window---git-url)
<br/>

#### B. tarball
![packagemanagerTarball](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/5b1ed637-de37-4798-9520-8f2652f7059d)   
가. [Releases](../../releases) 페이지에서 필요한 SDK 버전의 `Assets` > `com.tnk.adiscope.tgz` 버튼을 클릭하여 tarball 파일 다운로드<br/>
나. Unity의 `Window` > `Package Manager` 메뉴 클릭<br/>
다. Package Manager의 왼쪽 상단 `플러스(+)` 버튼 > `Add package from tarball` 버튼 클릭<br/>
라. 다운로드받은 tgz 파일을 선택<br/>
> - [결과 확인](./docs/upm_result.md#1-b-unity-package-manager-window---tarball)

<br/><br/>

### 2. Download External Dependency Manager for Unity
![googleUnity](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/03a3b956-c7ce-498a-9d3d-12ada97c13f5)   
- [External Dependency Manager for Unity - 마지막 버전 파일로 이동](https://github.com/googlesamples/unity-jar-resolver/blob/master/external-dependency-manager-latest.unitypackage)   
- [External Dependency Manager for Unity - 사이트 이동](https://github.com/googlesamples/unity-jar-resolver#getting-started)   
- `external-dependency-manager-*.unitypackage` 파일을 다운로드
- Unity project를 열어서 navigate에서 `Assets -> Import Package -> Custom Package` 선택
- `external-dependency-manager-*.unitypackage` 파일을 선택 후 전체 `Import`
- Unity version `2022.2+` 에서는 `1.2.176+` 사용    
> - [결과 확인](./docs/upm_result.md#2-download-external-dependency-manager-for-unity) 
<br/>

#### A. iOS Resolver Settings
![external-dependency-manager-setting](https://github.com/user-attachments/assets/e4b56ded-48ae-4b4f-bf27-6c2d2018b002)   
-  Link frameworks statically 해지

<br/><br/>

### 3. Project Settings - Player
![playerAndroid](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/59b48ef5-493b-448f-be2a-f0954c109d72)   
- Unity project를 열어서 navigate에서 `Edit -> Project Settings`로 Project Settings 창 Open
- `Player`를 선택 후 `Android`탭으로 이동

![playerAndroidTarget](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/e9ce573d-1343-42a7-8b01-427b8c43db28)   
- `Other Settings`에서 `Target API Level`를 `API lovel 31`이상으로 설정

![playerAndroidKeystore](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/24d27a50-7f18-4c36-a438-54e40e90719e)   
- `Publishing Settings`에서 `Project Keystore`와 `Project Key`를 설정

![playerAndroidBuild21-3-8](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/e59443c1-7d2c-4c4f-80f3-514bb1c08ad4)   
- `Build > Custom Main Manifest` 체크를 설정
- `Build > Custom Main Gradle Template` 체크를 설정
- `Build > Custom Gradle Properties Template` 체크를 설정
> - [2022.3.+ 변경 설정 확인](./docs/other_unity_version.md)
> - [결과 확인](./docs/upm_result.md#3-project-settings---player) 

<br/><br/>

### 4. AdiscopeSDK Settings
#### 가. Project Settings - AdiscopeSDK
![adiscopeJson1](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/e6dfa19e-7f23-4cc9-9cab-4b24088c2b15)  
- Unity project를 열어서 navigate에서 `Edit -> Project Settings`로 Project Settings 창을 열어 `AdiscopeSDK`를 선택   
- `Settings Android from json file`를 선택하여 전달받은 Android.json 파일을 선택   
- `Settings iOS from json file`를 선택하여 전달받은 iOS.json 파일을 선택   
- Dashboard의 값은 Adiscope 설정 값들로 자동 세팅
- iOS의 Tracking Desc(NSUserTrackingUsageDescription)값을 추가하면 xcode의 plist에 해당 값으로 추가 됨
  - iOS의 앱 추적 팝업의 설명에 추가 됨
- Dashboard의 값을 직접 수정 후 `Create Adiscope Android & iOS Files`를 선택하면 해당 값으로 앱 설정 됨
<br/><br/>

![adiscopeMake1](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/7fdb4786-bf1b-4067-9b49-300abfa5884a)
- `Create Adiscope Android & iOS Files`를 선택
- ⚠️ 버전 변경 시 마다 `Create Adiscope Android & iOS Files`를 선택해야 해당 값으로 앱 설정 됨
- 인터넷이 연결되어 있어야 함
- Adapter Version이 상이할 경우 Initialize시 Log를 통해 확인 가능
  - Android<br/>
![adapter version checker log](https://github.com/user-attachments/assets/286e83f0-8b63-4e3f-bb09-ad86e15df83c)<br/>
  - iOS<br/>
![AdapterChecked](https://github.com/user-attachments/assets/c0c4e33f-d535-45fb-8115-115e57c70522)<br/>
> - [Android 결과 확인](./docs/upm_result.md#4-adiscopesdk-settings)
> - [iOS 결과 확인](./docs/upm_result.md#6-cocoapods-%EC%82%AC%EC%9A%A9-ios-%EC%A0%84%EC%9A%A9)
<br/>

#### 나. Import to Stript
```csharp
FrameworkSettingsRegister.AdiscopeImportJson(<Android_Json_Path>, <iOS_Json_Path>);
```
- '/Library/PackageCache/com.tnk.adiscope/Editor/Scripts/FrameworkSettingsRegister.cs' 파일에 있는 함수 호출
- 관리자에게 전달 받은 Android & iOS의 Json 파일 위치 입력
> - [결과 확인](./docs/upm_result.md#4-adiscopesdk-settings) 

<br/><br/>

### 5. External Dependency Manager 설정 (Android 전용)
- Unity project를 열어서 navigate에서 `Assets -> External Dependency Manager -> Android Resolver -> Resolver(or Force Resolver)`를 선택   
> - [결과 확인](./docs/upm_result.md#5-external-dependency-manager-%EC%84%A4%EC%A0%95-android-%EC%A0%84%EC%9A%A9) 

<br/><br/>

### 6. CocoaPods 사용 (iOS 전용)
- Build된 Project에서 Unity-iPhone.xcodeproj가 아닌 `Unity-iPhone.xcworkspace`로 실행
- CocoaPods가 설치 안 되어 있으면 수동 설치 
> - [결과 확인](./docs/upm_result.md#6-cocoapods-%EC%82%AC%EC%9A%A9-ios-%EC%A0%84%EC%9A%A9)
 
<br/><br/><br/>

## Update the Adiscope package to Your Project
> - [가이드 확인](./docs/update.md)
 
<br/><br/><br/>

## Adiscope Overview

### 1. Namespace
```csharp
using Adiscope;
``` 
<br/><br/><br/>

### 2. Initialize
#### 가. Code에서 Media 없이 Initialize 방법
```csharp
Adiscope.Sdk.GetCoreInstance().Initialize((isSuccess) => {
    if (isSuccess) {
        // Initialize Call Back
    } else {
        // Initialize Fail
    }
}, CALLBACK_TAG, CHILD_YN);
```
- Android는 `Adiscope.androidlib`폴더 내의 `AndroidManifest.xml`에 `adiscope_media_id`가 있어야 함 ([파일 위치 확인](./docs/upm_result.md#4-adiscopesdk-settings))
- iOS는 Build된 Project에서 `Info.plist` 파일에서 `AdiscopeMediaId`가 있어야 함 ([Info.plist 확인](./docs/upm_result.md#7-infoplist%EC%9D%98-adiscopemediaid-%ED%99%95%EC%9D%B8-ios-%EC%A0%84%EC%9A%A9))
- 반드시 unity의 main thread에서 실행
- App 실행 시 1회 설정 권장
- Adiscope에서는 Google Play 가족 정책을 준수해야 함 (Android 전용 - [Adiscope Google Play 가족 정책 확인](./docs/familiespolicy.md))
  - ⚠️ 정책 미준수시 광고에 제한이 생김 (광고 물량 축소 및 오퍼월 진입 불가)
> - [Other Initialize API](./docs/other_api.md#initialize)

<br/>

#### 나. Code에서 직접 Media 넣어서 Initialize 방법
```csharp
private string MEDIA_ID = "";        // 관리자를 통해 발급
private string MEDIA_SECRET = "";    // 관리자를 통해 발급
private string CALLBACK_TAG = "";    // 관리자를 통해 발급, 기본 ""
private string CHILD_YN = "";        // 어린이 여부를 설정 해주는 값(Google GMA에 세팅)
Adiscope.Sdk.GetCoreInstance().Initialize(MEDIA_ID, MEDIA_SECRET, CALLBACK_TAG, CHILD_YN, (isSuccess) => {
    if (isSuccess) {
        // Initialize Call Back
    } else {
        // Initialize Fail
    }
});
```
- 반드시 unity의 main thread에서 실행
- App 실행 시 1회 설정 권장
- Adiscope에서는 Google Play 가족 정책을 준수해야 함 (Android 전용 - [Adiscope Google Play 가족 정책 확인](./docs/familiespolicy.md))
  - ⚠️ 정책 미준수시 광고에 제한이 생김 (광고 물량 축소 및 오퍼월 진입 불가)
> - [Other Initialize API](./docs/other_api.md#initialize) 

<br/><br/>

### 3. 사용자 정보 설정
```csharp
private string USER_ID = "";        // set unique user id to identify the user in reward information
Adiscope.Sdk.GetCoreInstance().SetUserId(USER_ID);
```
- ⚠️ `Offerwall`, `RewardedVideo`, `RewardedInterstitial`를 사용하기 위해 필수 설정
- 64자까지 설정 가능 
<br/><br/><br/>

### 4. Offerwall
#### A. Offerwall Ad Instance 생성
```csharp
if (Adiscope.Sdk.GetCoreInstance().IsInitialized()) {
    // get singleton instance of offerwall ad
    Adiscope.Feature.OfferwallAd offerwallAd = Adiscope.Sdk.GetOfferwallAdInstance();
} else {
    // Reinitialize
}
```
- Offerwall Ad Instance는 global singleton instance이므로 여러개의 instance를 생성할 수 없음
- Offerwall Ad의 callback event handler는 등록과 해제가 자유로우나 globally static하므로 중복 등록되지 않도록 유의
<br/>

#### B. Callback 등록
```csharp
if (offerwallAd != null) {
    offerwallAd.OnOpened += OnOfferwallAdOpenedCallback;
    offerwallAd.OnClosed += OnOfferwallAdClosedCallback;
    offerwallAd.OnFailedToShow += OnOfferwallFailedToShowCallback;
}
```
<br/>

#### C. Show
```csharp
// show offerwall ad
OfferwallFilterType[] typeList = new OfferwallFilterType[] {  };
// new OfferwallFilterType[] { OfferwallFilterType.CPS }
if (offerwallAd != null) {
    if (offerwallAd.Show("unit1", typeList)) {
        // Success
    } else {
        // This Show request is duplicated
    }
} else {
    // Reinitialize
}
```
- `Show`가 실행되면 (return값이 True일 경우) `OnOpened`와 `OnFailedToShow` 중 하나가 항상 호출되고, `OnOpened`가 호출되었다면 이후 `OnClosed`가 항상 호출
<br/>

#### D. Callbacks
```csharp
private void OnOfferwallAdOpenedCallback(object sender, Adiscope.Model.ShowResult args) {
    // Offerwall이 열림
}
private void OnOfferwallAdClosedCallback(object sender, Adiscope.Model.ShowResult args) {
    // Offerwall이 닫힘
}
private void OnOfferwallAdFailedToShowCallback(object sender, Adiscope.Model.ShowFailure args) {
    // Offerwall이 Fail
}
```
- Show 성공 시 `OnOpened`, `OnClosed` callback이 순차적으로 호출
- Callback은 Unity의 main thread에서 호출
- `OnFailedToShow`시 [ApdiscopeError 참고](./docs/error_info.md)
<br/>

#### E. 상세 이동
##### 가. URL 전달 방식
```csharp
if (Adiscope.Sdk.GetCoreInstance().IsInitialized()) {
    private string URL = "";        // 관리자를 통해 발급
    Adiscope.Sdk.GetOfferwallAdInstance().ShowOfferwallDetailFromUrl(URL);
} else {
    // Reinitialize
}
```

##### 나. 값 전달 방식
```csharp
if (Adiscope.Sdk.GetCoreInstance().IsInitialized()) {
    private string UNIT_ID = "";        // 관리자를 통해 발급
    private string FILTERS = "";        // 관리자를 통해 확인
    private string ITEM_ID = "";        // 관리자를 통해 발급
    Adiscope.Sdk.GetOfferwallAdInstance().ShowOfferwallDetail(UNIT_ID, FILTERS, ITEM_ID);
} else {
    // Reinitialize
}
```
<br/><br/><br/>

### 5. RewardedVideo
#### A. RewardedVideo Ad Instance 생성
```csharp
if (Adiscope.Sdk.GetCoreInstance().IsInitialized()) {
    // get singleton instance of rewardedvideo ad
    Adiscope.Feature.RewardedVideoAd rewardedVideoAd = Adiscope.Sdk.GetRewardedVideoAdInstance();
} else {
    // Reinitialize
}
```
- Rewarded Video Ad Instance는 global singleton instance이므로 여러개의 instance를 생성할 수 없음
- Rewarded Video Ad의 callback event handler는 등록과 해제가 자유로우나 globally static하므로 중복 등록되지 않도록 유의
<br/>

#### B. Callback 등록
```csharp
if (rewardedVideoAd != null) {
    rewardedVideoAd.OnLoaded += OnRewardedVideoAdLoadedCallback;
    rewardedVideoAd.OnFailedToLoad += OnRewardedVideoAdFailedToLoadCallback;
    rewardedVideoAd.OnOpened += OnRewardedVideoAdOpenedCallback;
    rewardedVideoAd.OnClosed += OnRewardedVideoAdClosedCallback;
    rewardedVideoAd.OnRewarded += OnRewardedCallback;
    rewardedVideoAd.OnFailedToShow += OnRewardedVideoAdFailedToShowCallback;
} else {
    // Reinitialize
}
```
<br/>

#### C. Load
```csharp
if (rewardedVideoAd != null) {
    private string UNIT_ID = "";      // 관리자를 통해 발급
    // load a rewarded video ad which belongs to a specific unit
    rewardedVideoAd.Load(UNIT_ID);
} else {
    // Reinitialize
}
```
- 해당 유닛에 속한 ad 네크워크들의 광고를 Load
- `OnLoaded` callback이 호출되면 Load가 완료
- `Load`가 실행되면 `OnLoaded` 와 `OnFailedToLoad` 중 하나의 callback은 항상 호출
- Rewarded Video Ad의 `Load`와 `Show`는 pair로 호출
- Load를 한 후 Show를 하고, 광고를 Show한 후에는 다시 Load를 하여 다음 번 Show를 준비
- Load & Show 후 다시 Load를 하려 할 때 Load 는 Show 이후 언제든 호출가능
  - 광고가 Show되는 동안 다음 광고를 Load를 할 수도 있지만 이는 사용하는 mediation ad network company의 종류에 따라 달라질 수 있으므로 항상 보장되는 동작은 아님
- Show의 callback 인 `OnClosed`에서 다시 Load를 하는 것을 권장 
  - Abusing 방지를 위해 Rewarded Video Ad를 연속으로 보여주는 것을 제한하여 한번 광고를 보고 나면 일정 시간이 지난 후에 다시 Show를 할 수 있도로록 Admin page에서 서비스 설정 가능
- Load 동작 수행 중에 Load를 여러 번 호출할 수 없음
- (**Optional**) Load의 시간이 필요해 ProgressBar 노출 추천
<br/>

#### D. IsLoaded
```csharp
if (rewardedVideoAd != null) {
    if (rewardedVideoAd.IsLoaded(UNIT_ID)) {
        // show ad here
    } else {
        // do something else
    }
} else {
    // Reinitialize
}
```
- 광고가 Load 되었는지 상태를 확인
<br/>

#### E. Show
```csharp
if (rewardedVideoAd != null) {
    if (rewardedVideoAd.IsLoaded(UNIT_ID)) {
        // only one "Show" can not be requested at a time
        // if Show() returns false, show is in progress somewhere else
        if (rewardedVideoAd.Show()) {
            // Success
        } else {
            // This Show request is duplicated
        }
    } else {
        // ad is not loaded
    }
} else {
    // Reinitialize
}
```
- 마지막으로 Load된 광고를 사용자에게 보여줌
- Show 호출 후에는 다시 Load를 호출
- Show method는 중복하여 호출 할 수 없음
- `Show`가 실행되면 (return값이 True일 경우) `OnOpened`와 `OnFailedToShow` 중 하나가 항상 호출되고, `OnOpened`가 호출되었다면 이후 `OnClosed`가 항상 호출
- Rewarded Video Ad의 `Load`와 `Show`는 pair로 호출
    - Load를 한 후 Show를 하고, 광고를 Show한 후에는 다시 Load를 하여 다음번 Show를 준비
<br/>

#### F. Callback Reward
```csharp
private void OnRewardedCallback(object sender, Adiscope.Model.RewardItem args) {
    // RewardItem.UnitId - 해당 rewarded video ad의 unitId (Show 시 입력한 값)
    // RewardItem.Type - 보상 type
    // RewardItem.Amount - 보상의 양
}
```
- 보상이 주어져야 할 경우 `OnRewarded`가 호출되며 그 parameter로 관련 정보가 전달
- 이 보상 정보를 바탕으로 게임 내에서 보상을 지급
- `OnRewarded`는 보통 `OnOpened` 와 `OnClosed` 사이에 호출되는 경우가 많으나 광고 System의 상황에 따라 달라 질 수 있음
- `OnRewarded`가 호출되지 않는 경우도 존재할 수 있음(Reward 설정을 Server-to-server로 하였다면, Video 시청 후에는 `OnRewarded`가 호출되지 않음)
- Reward 정보는 abusing 방지를 위해서 Server-to-server 방식으로 전달 받는 것을 권장
- Server-to-server 방식을 선택하더라도 보상이 전달 될 시에는 `OnRewarded`가 호출
  - 이때는 Server를 통해 전달받은 정보를 기준으로 처리하고, `OnRewarded`를 통해 전달받은 정보는 검증용으로 사용하거나 무시하도록 함
<br/>

#### G. Callback Others
```csharp
private void OnRewardedVideoAdLoadedCallback(object sender, Adiscope.Model.LoadResult args) {
    // Rewarded Video Load Success
}
private void OnRewardedVideoAdFailedToLoadCallback(object sender, Adiscope.Model.LoadFailure args) {
    // Rewarded Video Load Fail
}
private void OnRewardedVideoAdOpenedCallback(object sender, Adiscope.Model.ShowResult args) {
    // Rewarded Video 열림
}
private void OnRewardedVideoAdClosedCallback(object sender, Adiscope.Model.ShowResult args) {
    // Rewarded Video 닫힘
}
private void OnRewardedVideoAdFailedToShowCallback(object sender, Adiscope.Model.ShowFailure args) {
    // Rewarded Video Show Fail
}
```
- `Load` 성공 시 `OnLoaded`, 실패 시 `OnFailedToLoad`가 호출
- `Show` 성공 시 `OnOpened`, `OnClosed`가 순차적으로 호출되고, 실패시 `OnFailedToShow`가 호출
- `OnFailedToLoad`, `OnFailedToShow`시 [ApdiscopeError 참고](./docs/error_info.md) 
- Callback은 Unity의 main thread에서 호출 
<br/><br/><br/>

### 6. Interstitial
#### A. RewardedVideo Ad Instance 생성
```csharp
if (Adiscope.Sdk.GetCoreInstance().IsInitialized()) {
    // get singleton instance of interstitial ad
    Adiscope.Feature.InterstitialAd interstitialAd = Adiscope.Sdk.GetInterstitialAdInstance();
} else {
    // Reinitialize
}
```
- Interstitial Ad Instance는 global singleton instance이므로 여러개의 instance를 생성할 수 없음
- Interstitial Ad의 callback event handler는 등록과 해제가 자유로우나 globally static하므로 중복 등록되지 않도록 유의
<br/>

#### B. Callback 등록
```csharp
if (interstitialAd != null) {
    interstitialAd.OnLoaded += OnInterstitialAdLoadedCallback;
    interstitialAd.OnFailedToLoad += OnInterstitialAdFailedToLoadCallback;
    interstitialAd.OnOpened += OnInterstitialAdOpenedCallback;
    interstitialAd.OnClosed += OnInterstitialAdClosedCallback;
    interstitialAd.OnFailedToShow += OnInterstitialAdFailedToShowCallback;
} else {
    // Reinitialize
}
```
<br/>

#### C. Load
```csharp
if (interstitialAd != null) {
    private string UNIT_ID = "";      // 관리자를 통해 발급
    // load a interstitial ad which belongs to a specific unit
    interstitialAd.Load(UNIT_ID);
} else {
    // Reinitialize
}
```
- 해당 유닛에 속한 ad 네크워크들의 광고를 Load
- `OnInterstitialAdLoaded` callback이 호출되면 Load가 완료
- Interstitial의 `Load`와 `Show`는 pair로 호출
- Load를 한 후 Show를 하고, 광고를 Show한 후에는 다시 Load를 하여 다음 번 Show를 준비
- 광고가 Show되는 동안 다음 광고를 Load를 할 수도 있지만 이는 사용하는 mediation ad network company의 종류에 따라 달라질 수 있으므로 항상 보장되는 동작은 아님
- Load 동작 수행 중에 Load를 여러 번 호출할 수 없음
- (**Optional**) Load의 시간이 필요해 ProgressBar 노출 추천
<br/>

#### D. IsLoaded
```csharp
if (interstitialAd != null) {
    if (interstitialAd.IsLoaded(UNIT_ID)) {
        // show ad here
    } else {
        // do something else
    }
} else {
    // Reinitialize
}
```
- 광고가 Load 되었는지 상태를 확인
<br/>

#### E. Show
```csharp
if (interstitialAd != null) {
    if (interstitialAd.IsLoaded(UNIT_ID)) {
        // only one "Show" can not be requested at a time
        // if Show() returns false, show is in progress somewhere else
        if (interstitialAd.Show()) {
            // Success
        } else {
            // This Show request is duplicated
        }
    } else {
        // ad is not loaded
    }
} else {
    // Reinitialize
}
```
- 마지막으로 Load된 광고를 사용자에게 보여줌
- Show 호출 후에는 다시 Load를 호출
- Show method는 중복하여 호출 할 수 없음
- `Show`가 실행되면 (return값이 True일 경우) `OnOpened`와 `OnFailedToShow` 중 하나가 항상 호출되고, `OnOpened`가 호출되었다면 이후 `OnClosed`가 항상 호출
- Rewarded Video Ad의 `Load`와 `Show`는 pair로 호출
    - Load를 한 후 Show를 하고, 광고를 Show한 후에는 다시 Load를 하여 다음번 Show를 준비
<br/>

#### F. Callback
```csharp
private void OnInterstitialAdLoadedCallback(object sender, Adiscope.Model.LoadResult args) {
    // Interstitial Load Success
}
private void OnInterstitialAdFailedToLoadCallback(object sender, Adiscope.Model.LoadFailure args) {
    // Interstitial Load Fail
}
private void OnInterstitialAdOpenedCallback(object sender, Adiscope.Model.ShowResult args) {
    // Interstitial 열림
}
private void OnInterstitialAdClosedCallback(object sender, Adiscope.Model.ShowResult args) {
    // Interstitial 닫힘
}
private void OnInterstitialAdFailedToShowCallback(object sender, Adiscope.Model.ShowFailure args) {
    // Interstitial Show Fail
}
```
- `Load` 성공 시 `OnLoaded`, 실패 시 `OnFailedToLoad`가 호출
- `Show` 성공 시 `OnOpened`, `OnClosed`가 순차적으로 호출되고, 실패시 `OnFailedToShow`가 호출
- `OnFailedToLoad`, `OnFailedToShow`시 [ApdiscopeError 참고](./docs/error_info.md) 
- Callback은 Unity의 main thread에서 호출 
<br/><br/><br/>

### 7. RewardedInterstitial
#### A. RewardedInterstitial Ad Instance 생성
```csharp
if (Adiscope.Sdk.GetCoreInstance().IsInitialized()) {
    // get singleton instance of rewardedinterstitial ad
    Adiscope.Feature.RewardedInterstitialAd rewaredInterstitialAd = Adiscope.Sdk.GetRewardedInterstitialAdInstance();
} else {
    // Reinitialize
}
```
- RewardedInterstitial Ad Instance는 global singleton instance이므로 여러개의 instance를 생성할 수 없음
- RewardedInterstitial Ad의 callback event handler는 등록과 해제가 자유로우나 globally static하므로 중복 등록되지 않도록 유의
<br/>

#### B. Callback 등록
```csharp
if (rewaredInterstitialAd != null) {
    rewaredInterstitialAd.OnGetUnitStatus += OnRewardedInterstitialGetUnitStatusCallback;
    rewaredInterstitialAd.OnSkip += OnRewardedInterstitialAdSkipCallback;
    rewaredInterstitialAd.OnOpened += OnRewardedInterstitialAdOpenedCallback;
    rewaredInterstitialAd.OnClosed += OnRewardedInterstitialAdClosedCallback;
    rewaredInterstitialAd.OnFailedToShow += OnRewardedInterstitialAdFailedToShowCallback;
    rewaredInterstitialAd.OnRewarded += OnRewardedInterstitialRewardedCallback;
} else {
    // Reinitialize
}
```
<br/>

#### C. PreLoadAll
```csharp
if (rewaredInterstitialAd != null) {
    rewaredInterstitialAd.PreLoadAllRewardedInterstitial();
} else {
    // Reinitialize
}
```
- Initialize Call Back 후 1회 설정 권장
- 관리자가 설정된 활성화된 모든 유닛들을 Load 진행
<br/>

#### D. Unit 지정 PreLoad
```csharp
if (rewaredInterstitialAd != null) {
    rewaredInterstitialAd.PreLoadRewardedInterstitial(new string[] { UNIT_ID1, UNIT_ID2, ... });
} else {
    // Reinitialize
}
```
- Initialize Call Back 후 1회 설정 권장
- 입력된 유닛들을 Load 진행
<br/>

#### E. Show
```csharp
if (rewaredInterstitialAd != null) {
    rewaredInterstitialAd.ShowRewardedInterstitial(UNIT_ID);
} else {
    // Reinitialize
}
```
- 해당 유닛이 Load되어 있으면 안내 팝업을 보여 준 뒤 해당 광고를 사용자에게 보여줌
- ShowRewardedInterstitial method는 중복하여 호출 할 수 없음
- `ShowRewardedInterstitial`가 실행되면 (return값이 True일 경우) `OnSkip`와 `OnOpened`와 `OnFailedToShow` 중 하나가 항상 호출되고, `OnOpened`가 호출되었다면 이후 `OnClosed`가 항상 호출
- `OnClosed`와 `OnFailedToShow`가 호출 되면 내부에서 해당 유닛을 자동 Load 시킴
<br/>

#### F. Unit Status Info
```csharp
if (rewaredInterstitialAd != null) {
    rewaredInterstitialAd.GetUnitStatusRewardedInterstitial(UNIT_ID);
} else {
    // Reinitialize
}
```
- 해당 유닛의 수익화 여부, 활성화 여부를 알 수 있음
<br/>

#### G. Callback Reward
```csharp
private void OnRewardedInterstitialRewardedCallback(object sender, Adiscope.Model.RewardItem args) {
    // RewardItem.UnitId - 해당 rewarded video ad의 unitId (ShowRewardedInterstitial 시 입력한 값)
    // RewardItem.Type - 보상 type
    // RewardItem.Amount - 보상의 양
}
```
- 보상이 주어져야 할 경우 `OnRewarded`가 호출되며 그 parameter로 관련 정보가 전달
- 이 보상 정보를 바탕으로 게임 내에서 보상을 지급
- `OnRewarded`는 보통 `OnOpened` 와 `OnClosed` 사이에 호출되는 경우가 많으나 광고 System의 상황에 따라 달라 질 수 있음
- `OnRewarded`가 호출되지 않는 경우도 존재할 수 있음(Reward 설정을 Server-to-server로 하였다면, Video 시청 후에는 `OnRewarded`가 호출되지 않음)
- Reward 정보는 abusing 방지를 위해서 Server-to-server 방식으로 전달 받는 것을 권장
- Server-to-server 방식을 선택하더라도 보상이 전달 될 시에는 `OnRewarded`가 호출
  - 이때는 Server를 통해 전달받은 정보를 기준으로 처리하고, `OnRewarded`를 통해 전달받은 정보는 검증용으로 사용하거나 무시하도록 함
<br/>

#### H. Callback Others
```csharp
private void OnRewardedInterstitialGetUnitStatusCallback(object sender, Adiscope.Model.UnitStatus args) {
    // args.isLive()    수익화 여부
    // args.isActive()  활성화 여부
}
private void OnRewardedInterstitialAdSkipCallback(object sender, Adiscope.Model.ShowResult args) {
    // RewardedInterstitial Skip for 안내 팝업
}
private void OnRewardedInterstitialAdOpenedCallback(object sender, Adiscope.Model.ShowResult args) {
    // Rewarded Video 열림
}
private void OnRewardedInterstitialAdClosedCallback(object sender, Adiscope.Model.ShowResult args) {
    // Rewarded Video 닫힘
}
private void OnRewardedInterstitialAdFailedToShowCallback(object sender, Adiscope.Model.ShowFailure args) {
    // Rewarded Video Show Fail
}
```
- `GetUnitStatusRewardedInterstitial` 조회 시 `OnGetUnitStatus`가 호출
- `ShowRewardedInterstitial` Skip 시 `OnSkip`, 성공 시 `OnOpened`, `OnClosed`가 순차적으로 호출되고, 실패시 `OnFailedToShow`가 호출
- `OnFailedToShow`시 [ApdiscopeError 참고](./docs/error_info.md) 
- Callback은 Unity의 main thread에서 호출 
<br/><br/><br/>

### 8. AdEvent
#### A. AdEvent Ad Instance 생성
```csharp
if (Adiscope.Sdk.GetCoreInstance().IsInitialized()) {
    // get singleton instance of AdEvent
    Adiscope.Feature.AdEvent adEvent = Adiscope.Sdk.GetAdEventInstance();
} else {
    // Reinitialize
}
```
- AdEvent Instance는 global singleton instance이므로 여러개의 instance를 생성할 수 없음
- AdEvent의 callback event handler는 등록과 해제가 자유로우나 globally static하므로 중복 등록되지 않도록 유의
<br/>

#### B. Callback 등록
```csharp
if (adEvent != null) {
    adEvent.OnOpened += OnAdEventOpenedCallback;
    adEvent.OnClosed += OnAdEventClosedCallback;
    adEvent.OnFailedToShow += OnAdEventFailedToShowCallback;
} else {
    // Reinitialize
}
```
<br/>

#### C. Show
```csharp
// show adEvent
if (adEvent != null) {
    if (adEvent.Show("unit1")) {
        // Success
    } else {
        // This Show request is duplicated
    }
} else {
    // Reinitialize
}
```
- `Show`가 실행되면 (return값이 True일 경우) `OnOpened`와 `OnFailedToShow` 중 하나가 항상 호출되고, `OnOpened`가 호출되었다면 이후 `OnClosed`가 항상 호출
<br/>

#### D. Callbacks
```csharp
private void OnAdEventOpenedCallback(object sender, Adiscope.Model.ShowResult args) {
    // AdEvent가 열림
}
private void OnAdEventClosedCallback(object sender, Adiscope.Model.ShowResult args) {
    // AdEvent가 닫힘
}
private void OnAdEventFailedToShowCallback(object sender, Adiscope.Model.ShowFailure args) {
    // AdEvent가 Fail
}
```
- Show 성공 시 `OnOpened`, `OnClosed` callback이 순차적으로 호출
- Callback은 Unity의 main thread에서 호출
- `OnFailedToShow`시 [ApdiscopeError 참고](./docs/error_info.md) 
<br/><br/><br/>

### 9. Other API
> - [Other API](./docs/other_api.md#other-api-1)
 
<br/><br/><br/>

## 웹사이트 필수 등록 (Android 전용)
- 관리자에게 전달받은 `app-ads.txt`를 웹사이트에 등록
> - [app-ads.txt 등록 방법 및 정보](./docs/app-ads.txt.md)

<br/><br/>

## Adiscope Server 연동하기
> - [연동하기](./docs/reward_callback_info.md)

<br/><br/>

## Privacy Manifest 정책 적용 (iOS 전용)
- 2024년 5월 1일부터 출시/업데이트 되는 앱에 대해 3rd Party Framework의 개인정보 추가
> - [참고](https://developer.apple.com/videos/play/wwdc2023/10060)

<br/><br/>

## Xcode에서의 Error 정리
### Unity Editor 21.3.33f1, 21.3.34f1, 22.3.14f1, 22.3.15f1에서의 Error
- 'Unexpected duplicate tasks' Error
> - [해결 방법](./docs/xcode_error.md#unity-editor-특정-버전에서-build-error)

<br/><br/>

### Xcode Archive Error
> - [해결 방법](./docs/xcode_error.md#xcode-archive-error)

<br/><br/>

### Unity Editor 2022.3.9f1 이하에서 iOS xcode15 빌드 시 Error
> - [오류 내용](./docs/xcode_error.md#unity-editor-202239f1-이하에서-ios-xcode15-빌드-시-error)

<br/><br/>

## iOS 16+ Offerwall 세로 모드 전환 적용 방법(가로모드 전용일 경우)
> - [적용 방법 확인](./docs/apple_orientations.md)

<br/><br/>

## Adiscope Error Information
> - [Error 정보](./docs/error_info.md)

<br/><br/>

## Adiscope Sample App
> - [적용 방법 확인](./docs/sampleapp.md)

<br/><br/>

## Releases
> - [Releases](../../releases)

<br/><br/>

## LICENSE
> - [LICENSE](./LICENSE)
