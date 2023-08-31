# Check Adiscope Unity Package Manager

## 1-A. Unity Package Manager window - Git URL
![upm_installed_package_git_url](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/551f2489-39a0-4dd8-9538-d94dd4a49f19)<br/>
- 정상적으로 패키지가 추가되었다면 아래 화면과 같이 `Packages - ADISCOPE`에서 `Adiscope SDK` 확인
<br/><br/>

## 1-B. Unity Package Manager window - tarball
![upm_installed_package_tgz](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/6eac4eff-c1e8-4636-8968-58b4203b47ea)<br/>
- 정상적으로 패키지가 추가되었다면 아래 화면과 같이 `Packages - ADISCOPE`에서 `Adiscope SDK` 확인
<br/><br/>

## 2. Download External Dependency Manager for Unity
<img width="260" alt="upmResultGoogle" src="https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/2246d76a-9354-4ef4-ba50-a40e90b6b33e"><br/>
- Your Project 폴더 -> Assets -> ExternalDependencyManager` 폴더 생성 확인
<br/><br/><br/>

## 3. Project Settings - Player
<img width="239" alt="upmResultPlayer" src="https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/5dd3b4cf-dc9d-49b6-9130-8f4a2973be3d"><br/>
- `Your Project 폴더 -> Plugins -> Android`에서 "AndroidManifest.xml", "gradleTemplate.properties", "mainTemplate.gradle" 파일 생성 확인
<br/><br/><br/>

## 4. AdiscopeSDK Settings
![upmResultAdiscope1](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/96da65b4-a7f4-46fa-b654-4bedc1d97ba9)
![upmResultAdiscope2](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/b891640f-8800-45ff-8c7b-654cf4c68114)<br/>
- `Your Project 폴더 -> Assets -> Adiscope` 폴더 생성 확인<br/>
- `Your Project 폴더 -> Assets -> Adiscope -> AdiscopeAppSettingsFiles -> Plugins- > Adiscope.androidlib`에서 "AndroidManifest.xml" 파일 생성 확인<br/>
- `Your Project 폴더 -> Assets -> Adiscope -> AdiscopeAppSettingsFiles -> Editor`에서 "*Dependencies.xml" 파일 생성 확인
<br/><br/><br/>

## 5. External Dependency Manager 설정
![upmResultDependencies](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/f76f4625-c05d-4829-93b8-254568ed88f1)<br/>
- Unity project를 열어서 navigate에서 `Assets -> External Dependency Manager -> Android Resolver -> Display Libraries`를 선택<br/>
- Project Settings - AdiscopeSDK에 설정한 Android Network Adapter가 dependencies에 들어갔는지 확인
<br/>
