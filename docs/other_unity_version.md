# 2022.3.4f1 & 2022.3.5f1
## Project Settings - Player
![playerAndroidBuild22-3-4](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/b39e6a93-f0da-42a8-b0a1-656685c5fb9a)   
- `Build > Custom Main Manifest` 체크를 설정
- `Build > Custom Main Gradle Template` 체크를 설정
- `Build > Custom Base Gradle Template` 체크를 설정
- `Build > Custom Gradle Properties Template` 체크를 설정
- `Build > Custom Gradle Settings Template` 체크를 설정

## android.enableR8 제거
![playerAndroidproperties](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/1f874038-a23a-4486-ad18-267aa7fb326e)   
- Project folder에서 `Assets -> Plugins -> Android -> gradleTemplate.properties 파일 오픈

![playerAndroidenableR8](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/64b210df-74e1-4855-aea9-a6e9cb33ef27)   
- android.enableR8 해당 줄을 삭제
