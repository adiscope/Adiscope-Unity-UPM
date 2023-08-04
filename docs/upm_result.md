# Check Adiscope Unity Package Manager

## 1. Download External Dependency Manager for Unity
<img width="260" alt="upmResultGoogle" src="https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/2246d76a-9354-4ef4-ba50-a40e90b6b33e"><br/>
<code>Your Project 폴더 -> Assets -> ExternalDependencyManager</code> 폴더 생성 확인
<br/><br/><br/>

## 2. Project Settings - Player
<img width="239" alt="upmResultPlayer" src="https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/5dd3b4cf-dc9d-49b6-9130-8f4a2973be3d"><br/>
<code>Your Project 폴더 -> Plugins -> Android</code>에서<br/>
"AndroidManifest.xml", "gradleTemplate.properties", "mainTemplate.gradle" 파일 생성 확인
<br/><br/><br/>

## 3. Project Settings - AdiscopeSDK
<img width="705" alt="upmResultAdiscope1" src="https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/933f69d1-5829-4971-ad50-13c87a716079"><br/>
<img width="736" alt="upmResultAdiscope2" src="https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/028ab3a6-cba2-4828-9599-6ab4ece48c8d"><br/>
<code>Your Project 폴더 -> Assets -> Adiscope</code> 폴더 생성 확인<br/>
<code>Your Project 폴더 -> Assets -> Adiscope -> Adiscope.androidlib</code>에서 "AndroidManifest.xml" 파일 생성 확인<br/>
<code>Your Project 폴더 -> Assets -> Adiscope -> Editor</code>에서 "*Dependencies.xml" 파일 생성 확인
<br/><br/><br/>

## 4. External Dependency Manager 설정
![upmResultDependencies](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/f76f4625-c05d-4829-93b8-254568ed88f1)<br/>
Unity project를 열어서 navigate에서 <code>Assets -> External Dependency Manager -> Android Resolver -> Display Libraries</code>를 선택하여<br/>
Project Settings - AdiscopeSDK에 설정한 Android Network Adapter가 dependencies에 들어갔는지 확인
<br/>
