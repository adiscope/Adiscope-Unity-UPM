# Adiscope Sample App
"README.md"의 Add the Adiscope package to Your Project를 먼저 실행해야 합니다.
<br/><br/>

## 1. Download Files
[Sample App Files 위치 이동](https://github.com/adiscope/adiscope-unity-package-manager/tree/main/Samples)<br/>
"Sdk" 폴더를 다운받음
<br/>

## 2. Move Files
다운로드 한 "Sdk" 폴더를 <code>Your Project 폴더 -> Assets</code>로 이동
결과 : <code>Your Project 폴더 -> Assets/Sdk/Examples</code>에<br/>
"AdiscopeExample.cs", "AdiscopeExampleScene01.unity", "AdiscopeExampleScene02.unity" 파일 확인
<br/>

## 3. Change Value
![sampleappId](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/3ae6dbf5-feea-4db3-b02e-5cb5e6285dc2)<br/>
이동한 파일 중 "AdiscopeExample.cs" 파일을 열어서 ID등 값들을 추가(필요 값만 입력하면 됨)<br/><br/>
![sampleappScret](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/e7623a6f-5d8b-4aa7-872b-470d9f570853)<br/>
{ "adiscope_media_id" : "adiscope_media_secret" } 로 Android, iOS 값들을 추가
<br/>

## 4. Add Build Settings
![buildSettings](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/65da7df5-5b4c-44a9-bc66-56d5b4203e13)<br/>
Unity project를 열어서 navigate에서 <code>File -> Build Settings</code>로 Build Settings창을 열고<br/>
Unity project에서 Project 텝에서 이동한 파일 중 "AdiscopeExampleScene01.unity", "AdiscopeExampleScene02.unity"를 추가
<br/>

## 5. Android Build
Android Platform으로 Switch 후 Build(or Build And Run)
<br/>

## 6. iOS Build
iOS Platform으로 Switch 후 Build(or Build And Run)
<br/>
