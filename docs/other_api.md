# Other API
## Initialize
### Android & iOS
```csharp
Adiscope.Sdk.GetCoreInstance().Initialize(MEDIA_ID, MEDIA_SECRET, CALLBACK_TAG, (isSuccess) => {
    if (isSuccess) {
        // Initialize Call Back
    } else {
        // Initialize Fail
    }
});
```
```csharp
Adiscope.Sdk.GetCoreInstance().Initialize((isSuccess) => {
    if (isSuccess) {
        // Initialize Call Back
    } else {
        // Initialize Fail
    }
});
```
```csharp
Adiscope.Sdk.GetCoreInstance().Initialize((isSuccess) => {
    if (isSuccess) {
        // Initialize Call Back
    } else {
        // Initialize Fail
    }
}, CALLBACK_TAG);
```

<br/>

## Other API
### IsInitialized
```csharp
Adiscope.Sdk.GetCoreInstance().IsInitialized();
```

### SDK Versions
```csharp
Adiscope.Sdk.GetOptionGetter().GetSDKVersion();
```

### Unity SDK Versions
```csharp
Adiscope.Sdk.GetOptionGetter().GetUnitySDKVersion();
```

### Network Versions
```csharp
Adiscope.Sdk.GetOptionGetter().GetNetworkVersions();
```

### Android Media Id
```csharp
Adiscope.FrameworkSettings.MediaID_AOS;
```
- Adiscope.FrameworkSettings(MediaID_AOS, MediaID_iOS, SubDomain 등)는 Unity 에디터에서만 동작하는 클래스
- Runtime 스크립트(게임플레이 코드)에서는 참조할 수 없음

### iOS Media Id
```csharp
Adiscope.FrameworkSettings.MediaID_IOS;
```
- Adiscope.FrameworkSettings(MediaID_AOS, MediaID_iOS, SubDomain 등)는 Unity 에디터에서만 동작하는 클래스
- Runtime 스크립트(게임플레이 코드)에서는 참조할 수 없음

### Sub Domain (for showDetail)
```csharp
Adiscope.FrameworkSettings.SubDomain;
```
- Adiscope.FrameworkSettings(MediaID_AOS, MediaID_iOS, SubDomain 등)는 Unity 에디터에서만 동작하는 클래스
- Runtime 스크립트(게임플레이 코드)에서는 참조할 수 없음

### Set Rewarded Check Param
```csharp
Adiscope.Sdk.GetCoreInstance().SetRewardedCheckParam(param);
```
- Rewarded callback 시 parameters을 추가
- 해당 정보는 Rewarded 지급 등에 있어 구분하는데 사용 할 수 있음
- 내부 설정 후 사용 가능 ( 담당자에게 요청 부탁 )
- param은 Base64 Encoded(UTF8)를 처리 후 1000자내로 설정

### Unit Status Info
```csharp
Adiscope.Sdk.GetCoreInstance().GetUnitStatus(UNIT_ID, (error, unitStatus) => {
    if (error == null) {
        // unitStatus.isLive()    수익화 여부
        // unitStatus.isActive()  활성화 여부
    } else {
        // error
    }
});
```
- RewardedVideo, Offerwall의 유닛 확인 용

### Volume
```csharp
Adiscope.Sdk.GetOptionSetter().SetVolumeOff(false);    // 광고 소리 킴(Default)
Adiscope.Sdk.GetOptionSetter().SetVolumeOff(true);     // 광고 소리 끔
```
- `Admob`, `AppLovin`, `Mintegral`, `Verve` 만 적용 가능


### iOS 광고 시청시 UnityPause 처리

```csharp
Adiscope.Feature.OptionSetter.SetiOSAppPauseOnBackground(true);
```

광고 시청 시 UnityPause(YES)를 호출하고 

광고 종료 후 UnityPause(NO)를 호출합니다.


### 광고 중복 호출 방지 

```csharp
Adiscope.Feature.OptionSetter.BlockMultiAdShow(true);
```

해당 값 설정시 서로 다른 광고를 중복으로 show 요청 했을 경우 첫번째 광고가 재생중이면 나머지 show 요청을 무시합니다.

**두번째 이후의 show() 함수는 false를 반환**

가능하면 다른 타입의 광고를 동시에 show하지 않도록 개발하시는 것이 좋습니다.

해당 옵션은 show 타이밍을 컨트롤 하기 어려운 경우에만 사용 하시는 것을 권장합니다.