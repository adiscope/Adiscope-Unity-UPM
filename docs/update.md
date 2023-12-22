# Update the Adiscope package to Your Project

## 1. Unity Package Manager window
![adiscopeUpdate](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/cbd17d5e-ada5-4b28-9165-ed167b5cf98b)   
- Unity project를 열어서 navigate에서 `Window -> Package Manager -> Adiscope SDK`를 선택 후 Update 클릭
> - Json 변경이 없고 값이 세팅 되어 있으면 [**3. Project Settings - AdiscopeSDK(세팅 파일 생성)**](#3-project-settings---adiscopesdk%EC%84%B8%ED%8C%85-%ED%8C%8C%EC%9D%BC-%EC%83%9D%EC%84%B1) 로 이동 후 진행
<br/>

### 가. target version 지정하여 패키지 추가하기
```
https://github.com/adiscope/Adiscope-Unity-UPM.git?path=Adiscope#3.0.0
```
* Target Version을 붙이면 최신 버전으로 Update 안 됨
* 업데이트가 필요할 경우 해당 target version으로 다시 패키지 추가
<br/>

## 2. Project Settings - AdiscopeSDK
![adiscopeJson1](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/e6dfa19e-7f23-4cc9-9cab-4b24088c2b15)   
- Unity project를 열어서 navigate에서 `Edit -> Project Settings`로 Project Settings 창을 열어 `AdiscopeSDK`를 선택   
- `Settings Android from json file`를 선택하여 전달받은 Android.json 파일을 선택   
- `Settings iOS from json file`를 선택하여 전달받은 iOS.json 파일을 선택   
- 설정 값들이 자동 변경 세팅되며 확인 후 수정이 가능
<br/>

## 3. Project Settings - AdiscopeSDK(세팅 파일 생성)
![adiscopeMake1](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/7fdb4786-bf1b-4067-9b49-300abfa5884a)
- 업데이트 시 마다 `Create Adiscope Android & iOS Files`를 선택
- Android 와 iOS의 변경 파일들이 새로 생성   
> - [Android 결과 확인](../docs/upm_result.md#4-adiscopesdk-settings)
> - [iOS 결과 확인](../docs/upm_result.md#6-cocoapods-%EC%82%AC%EC%9A%A9-ios-%EC%A0%84%EC%9A%A9)
<br/>

## 4. External Dependency Manager 설정
Unity project를 열어서 navigate에서 `Assets -> External Dependency Manager -> Android Resolver -> Resolver(or Force Resolver)`를 선택   
> - [결과 확인](../docs/upm_result.md#4-external-dependency-manager-%EC%84%A4%EC%A0%95)
