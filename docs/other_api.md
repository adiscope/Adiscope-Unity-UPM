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
