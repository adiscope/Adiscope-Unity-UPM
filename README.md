# Adiscope Unity Package Manager
[![GitHub package.json version](https://img.shields.io/badge/Unity-3.1.1-blue)](../../releases)
[![GitHub package.json version](https://img.shields.io/badge/Android-3.1.0-blue)](https://github.com/adiscope/Adiscope-Android-Sample)
[![GitHub package.json version](https://img.shields.io/badge/iOS-3.1.0-blue)](https://github.com/adiscope/Adiscope-iOS-Sample)

- Unity Editor : 2021.3.8f1, 2022.3.4f1, 2022.3.5f1
- Android Target API Level : 31+
- Android Minimum API Level : 16
- iOS Minimum Version : 12.0
<br/>

## Contents
#### [Add the Adiscope package to Your Project](#add-the-adiscope-package-to-your-project-1)
#### [Update the Adiscope package to Your Project](./docs/update.md)
#### [Adiscope Overview](#adiscope-overview-1)
- [Initialize](#2-initialize)
- [Offerwall](#4-offerwall)
- [RewardedVideo](#5-rewardedvideo)
- [Interstitial](#6-interstitial)
#### [웹사이트 필수 등록](#웹사이트-필수-등록-1)
#### [Xcode Archive Error 해결 방법](./docs/apple_store_error.md)
#### [iOS 16+ Offerwall 세로 모드 전환 적용 방법(가로모드 전용일 경우)](./docs/apple_orientations.md)
#### [Adiscope Sample App](./docs/sampleapp.md)
#### [Adiscope Error Information](./docs/error_info.md)
#### [Releases](../../releases)
#### [LICENSE](./LICENSE)
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
<br/>

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
> - [2022.3.4f1, 2022.3.5f1 변경 설정 확인](./docs/other_unity_version.md)
> - [결과 확인](./docs/upm_result.md#3-project-settings---player)
<br/>

### 4. AdiscopeSDK Settings
#### 가. Import to Stript
```csharp
FrameworkSettingsRegister.AdiscopeImportJson(<Android_Json_Path>, <iOS_Json_Path>);
```
- '/Library/PackageCache/com.tnk.adiscope/Editor/Scripts/FrameworkSettingsRegister.cs' 파일에 있는 함수 호출
- 관리자에게 전달 받은 Android & iOS의 Json 파일 위치 입력
> - [결과 확인](./docs/upm_result.md#4-adiscopesdk-settings)
<br/>

#### 나. Project Settings - AdiscopeSDK
![adiscopeJson](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/c45205bb-7533-4087-976a-ff228688f6eb)  
- Unity project를 열어서 navigate에서 `Edit -> Project Settings`로 Project Settings 창을 열어 `AdiscopeSDK`를 선택   
- `Settings Android from json file`를 선택하여 전달받은 Android.json 파일을 선택   
- `Settings iOS from json file`를 선택하여 전달받은 iOS.json 파일을 선택   
- Dashboard의 값은 Adiscope 설정 값들로 자동 세팅
- Dashboard의 값을 직접 수정 후 `Create Adiscope Android Files`를 선택하면 해당 값으로 앱 설정 됨
<br/>

![adiscopeMake](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/c000f8f1-5c9c-4730-94d1-86e0778faa5c)
- `Create Adiscope Android Files`를 선택
- 인터넷이 연결되어 있어야 함
> - [결과 확인](./docs/upm_result.md#4-adiscopesdk-settings)
<br/>

### 5. External Dependency Manager 설정
Unity project를 열어서 navigate에서 `Assets -> External Dependency Manager -> Android Resolver -> Resolver(or Force Resolver)`를 선택   
> - [결과 확인](./docs/upm_result.md#5-external-dependency-manager-%EC%84%A4%EC%A0%95)

<br/><br/>

## Update the Adiscope package to Your Project
> - [가이드 확인](./docs/update.md)

<br/><br/>

## Adiscope Overview

### 1. Namespace
```csharp
using Adiscope;
```
<br/>

### 2. Initialize
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
- `CHILD_YN`는 기본 "", 어린이 앱일 시 `"YES"`, 어린이 앱이 아닐 시 `"NO"`
    - Only Android
> - [Other Initialize API](./docs/other_api.md#initialize)
<br/>

### 3. 사용자 정보 설정
```csharp
private string USER_ID = "";        // set unique user id to identify the user in reward information
Adiscope.Sdk.GetCoreInstance().SetUserId(USER_ID);
```
- 64자까지 설정 가능
<br/>

### 4. Offerwall
#### A. Offerwall Ad Instance 생성
```csharp
// get singleton instance of offerwall ad
Adiscope.Feature.OfferwallAd offerwallAd = Adiscope.Sdk.GetOfferwallAdInstance();
```
- Offerwall Ad Instance는 global singleton instance이므로 여러개의 instance를 생성할 수 없음
- Offerwall Ad의 callback event handler는 등록과 해제가 자유로우나 globally static하므로 중복 등록되지 않도록 유의

#### B. Callback 등록
```csharp
offerwallAd.OnOpened += OnOfferwallAdOpenedCallback;
offerwallAd.OnClosed += OnOfferwallAdClosedCallback;
offerwallAd.OnFailedToShow += OnOfferwallFailedToShowCallback;
```

#### C. Show
```csharp
// show offerwall ad
OfferwallFilterType[] typeList = new OfferwallFilterType[] {  };
// new OfferwallFilterType[] { OfferwallFilterType.CPS }
if (offerwallAd.Show("unit1", typeList)) {
    // Success
} else {
    // This Show request is duplicated
}
```
- `Show`가 실행되면 (return값이 True일 경우) `OnOpened`와 `OnFailedToShow` 중 하나가 항상 호출되고, `OnOpened`가 호출되었다면 이후 `OnClosed`가 항상 호출

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
<br/>

### 5. RewardedVideo
#### A. RewardedVideo Ad Instance 생성
```csharp
// get singleton instance of rewardedvideo ad
Adiscope.Feature.RewardedVideoAd rewardedVideoAd = Adiscope.Sdk.GetRewardedVideoAdInstance();
```
- Rewarded Video Ad Instance는 global singleton instance이므로 여러개의 instance를 생성할 수 없음
- Rewarded Video Ad의 callback event handler는 등록과 해제가 자유로우나 globally static하므로 중복 등록되지 않도록 유의

#### B. Callback 등록
```csharp
rewardedVideoAd.OnLoaded += OnRewardedVideoAdLoadedCallback;
rewardedVideoAd.OnFailedToLoad += OnRewardedVideoAdFailedToLoadCallback;
rewardedVideoAd.OnOpened += OnRewardedVideoAdOpenedCallback;
rewardedVideoAd.OnClosed += OnRewardedVideoAdClosedCallback;
rewardedVideoAd.OnRewarded += OnRewardedCallback;
rewardedVideoAd.OnFailedToShow += OnRewardedVideoAdFailedToShowCallback;
```

#### C. Load
```csharp
private string UNIT_ID = "";      // 관리자를 통해 발급
// load a rewarded video ad which belongs to a specific unit
rewardedVideoAd.Load(UNIT_ID);
```
- 특정 유닛에 속한 ad 네크워크들의 광고를 load
- `OnRewardedVideoAdLoaded` callback이 호출되면 load가 완료
- `Load`가 실행되면 `OnLoaded` 와 `OnFailedToLoad` 중 하나의 callback은 항상 호출
- Rewarded Video Ad의 `Load`와 `Show`는 pair로 호출
- Load를 한 후 Show를 하고, 광고를 Show한 후에는 다시 Load를 하여 다음 번 Show를 준비
- Load & Show 후 다시 Load를 하려 할 때 Load 는 Show 이후 언제든 호출가능
- 광고가 Show되는 동안 다음 광고를 load를 할 수도 있지만 이는 사용하는 mediation ad network company의 종류에 따라 달라질 수 있으므로 항상 보장되는 동작은 아님
- Show의 callback 인 `OnClosed`에서 다시 Load를 하는 것을 권장 
  - Abusing 방지를 위해 Rewarded Video Ad를 연속으로 보여주는 것을 제한하여 한번 광고를 보고 나면 일정 시간이 지난 후에 다시 Show를 할 수 있도로록 Admin page에서 서비스 설정 가능

#### D. IsLoaded
```csharp
if (rewardedVideoAd.IsLoaded(UNIT_ID)) {
    // show ad here
} else {
    // do something else
}
```
- 광고가 load 되었는지 상태를 확인

#### E. Show
```csharp
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
```
- 마지막으로 load된 광고를 사용자에게 보여줌
- Show 호출 후에는 다시 load를 호출
- Show method는 중복하여 호출 할 수 없음
- `Show`가 실행되면 (return값이 True일 경우) `OnOpened`와 `OnFailedToShow` 중 하나가 항상 호출되고, `OnOpened`가 호출되었다면 이후 `OnClosed`가 항상 호출
- Rewarded Video Ad의 `Load`와 `Show`는 pair로 호출
    - Load를 한 후 Show를 하고, 광고를 Show한 후에는 다시 Load를 하여 다음번 Show를 준비

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
- Callback은 Unity의 main thread에서 호출
<br/>

### 6. Interstitial
#### A. RewardedVideo Ad Instance 생성
```csharp
// get singleton instance of interstitial ad
Adiscope.Feature.InterstitialAd interstitialAd = Adiscope.Sdk.GetInterstitialAdInstance();
```
- Interstitial Ad Instance는 global singleton instance이므로 여러개의 instance를 생성할 수 없음
- Interstitial Ad의 callback event handler는 등록과 해제가 자유로우나 globally static하므로 중복 등록되지 않도록 유의

#### B. Callback 등록
```csharp
interstitialAd.OnLoaded += OnInterstitialAdLoadedCallback;
interstitialAd.OnFailedToLoad += OnInterstitialAdFailedToLoadCallback;
interstitialAd.OnOpened += OnInterstitialAdOpenedCallback;
interstitialAd.OnClosed += OnInterstitialAdClosedCallback;
interstitialAd.OnFailedToShow += OnInterstitialAdFailedToShowCallback;
```

#### C. Load
```csharp
private string UNIT_ID = "";      // 관리자를 통해 발급
// load a interstitial ad which belongs to a specific unit
interstitialAd.Load(UNIT_ID);
```
- 특정 유닛에 속한 ad 네크워크들의 광고를 load
- `OnInterstitialAdLoaded` callback이 호출되면 load가 완료

#### D. IsLoaded
```csharp
if (interstitialAd.IsLoaded(UNIT_ID)) {
    // show ad here
} else {
    // do something else
}
```
- 광고가 load 되었는지 상태를 확인

#### E. Show
```csharp
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
```
- 마지막으로 load된 광고를 사용자에게 보여줌
- Show 호출 후에는 다시 load를 호출
- Show method는 중복하여 호출 할 수 없음
- `Show`가 실행되면 (return값이 True일 경우) `OnOpened`와 `OnFailedToShow` 중 하나가 항상 호출되고, `OnOpened`가 호출되었다면 이후 `OnClosed`가 항상 호출
- Rewarded Video Ad의 `Load`와 `Show`는 pair로 호출
    - Load를 한 후 Show를 하고, 광고를 Show한 후에는 다시 Load를 하여 다음번 Show를 준비

#### F. Callback
```csharp
private void OnInterstitialAdLoadedCallback(object sender, Adiscope.Model.LoadResult args) {
    // Interstitial Load Success
}
private void OnInterstitialAdFailedToLoadCallback(object sender, Adiscope.Model.LoadFailure args) {
    // Interstitial Load Fail
}
private void OnInterstitialAdOpenedCallback(object sender, EventArgs args) {
    // Interstitial 열림
}
private void OnInterstitialAdClosedCallback(object sender, EventArgs args) {
    // Interstitial 닫힘
}
private void OnInterstitialAdFailedToShowCallback(object sender, Adiscope.Model.ShowFailure args) {
    // Interstitial Show Fail
}
```
- `Load` 성공 시 `OnLoaded`, 실패 시 `OnFailedToLoad`가 호출
- `Show` 성공 시 `OnOpened`, `OnClosed`가 순차적으로 호출되고, 실패시 `OnFailedToShow`가 호출
- Callback은 Unity의 main thread에서 호출
<br/><br/>

### 7. Other API
> - [Other API](./docs/other_api.md#other-api-1)

<br/><br/>

## 웹사이트 필수 등록
- 관리자에게 전달받은 `app-ads.txt`를 웹사이트에 등록
> - [app-ads.txt 등록 방법 및 정보](./docs/app-ads.txt.md)

<br/><br/>

## Xcode Archive Error
> - [해결 방법](./docs/apple_store_error.md)

<br/><br/>

## iOS 16+ Offerwall 세로 모드 전환 적용 방법(가로모드 전용일 경우)
> - [적용 방법 확인](./docs/apple_orientations.md)

<br/><br/>

## Adiscope Sample App
> - [적용 방법 확인](./docs/sampleapp.md)

<br/><br/>

## Adiscope Error Information
> - [Error 정보](./docs/error_info.md)

<br/><br/>

## Releases
> - [Releases](../../releases)

<br/><br/>

## LICENSE
> - [LICENSE](./LICENSE)
