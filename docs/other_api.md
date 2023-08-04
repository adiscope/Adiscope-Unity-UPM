# Other API
## Initialize
### Android & iOS
```
Adiscope.Sdk.GetCoreInstance().Initialize(MEDIA_ID, MEDIA_SECRET, CALLBACK_TAG, (isSuccess) => {
    if (isSuccess) {
        // Initialize Call Back
    } else {
        // Initialize Fail
    }
});
```

### Only Android
```
Adiscope.Sdk.GetCoreInstance().Initialize((isSuccess) => {
    if (isSuccess) {
        // Initialize Call Back
    } else {
        // Initialize Fail
    }
});
```
```
Adiscope.Sdk.GetCoreInstance().Initialize((isSuccess) => {
    if (isSuccess) {
        // Initialize Call Back
    } else {
        // Initialize Fail
    }
}, CALLBACK_TAG);
```
```
Adiscope.Sdk.GetCoreInstance().Initialize((isSuccess) => {
    if (isSuccess) {
        // Initialize Call Back
    } else {
        // Initialize Fail
    }
}, CALLBACK_TAG, CHILD_YN);
```

<br/>

## Other API
### IsInitialized
```
Adiscope.Sdk.GetCoreInstance().IsInitialized();
```

### SDK Versions
```
Adiscope.Sdk.GetOptionGetter().GetSDKVersion();
```

### Network Versions
```
Adiscope.Sdk.GetOptionGetter().GetNetworkVersions();
```

### Unit Status Info
```
Adiscope.Sdk.GetCoreInstance().GetUnitStatus(UNIT_ID, (error, unitStatus) => {
    if (error == null) {
        // unitStatus.isLive()    수익화 여부
        // unitStatus.isActive()  활성화 여부
    } else {
        // error
    }
});
```
