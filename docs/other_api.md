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

### iOS Media Id
```csharp
Adiscope.FrameworkSettings.MediaID_IOS;
```

### Sub Domain (for showDetail)
```csharp
Adiscope.FrameworkSettings.SubDomain;
```

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
