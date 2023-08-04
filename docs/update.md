# Update the Adiscope package to Your Project

## 1. Unity Package Manager window
![adiscopeUpdate](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/cbd17d5e-ada5-4b28-9165-ed167b5cf98b)   
- Unity project를 열어서 navigate에서 `Window -> Package Manager -> Adiscope SDK`를 선택 후 Update 클릭
> - Network Adapter 변경이 없으면 [**3. Project Settings - AdiscopeSDK(세팅 파일 생성)**](#3-project-settings---adiscopesdk%EC%84%B8%ED%8C%85-%ED%8C%8C%EC%9D%BC-%EC%83%9D%EC%84%B1) 로 이동 후 진행
<br/>

## 2. Project Settings - AdiscopeSDK
![adiscopeJson](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/c45205bb-7533-4087-976a-ff228688f6eb)   
- Unity project를 열어서 navigate에서 `Edit -> Project Settings`로 Project Settings 창을 열어 `AdiscopeSDK`를 선택   
- `Settings Android from json file`를 선택하여 전달받은 Android.json 파일을 선택   
- `Settings iOS from json file`를 선택하여 전달받은 iOS.json 파일을 선택   
- 설정 값들이 자동 변경 세팅되며 확인 후 수정이 가능
<br/>

## 3. Project Settings - AdiscopeSDK(세팅 파일 생성)
![adiscopeMake](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/c000f8f1-5c9c-4730-94d1-86e0778faa5c)
- `Create Adiscope Android Files`를 선택   
> - [결과 확인](../docs/upm_result.md#3-project-settings---adiscopesdk)
<br/>

## 4. External Dependency Manager 설정
Unity project를 열어서 navigate에서 `Assets -> External Dependency Manager -> Android Resolver -> Resolver(or Force Resolver)`를 선택   
> - [결과 확인](../docs/upm_result.md#4-external-dependency-manager-%EC%84%A4%EC%A0%95)
