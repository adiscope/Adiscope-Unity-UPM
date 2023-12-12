# Unity Editor 22.3.14f1~ 에서 iOS 중복 Framework

## Unexpected Duplicate Tasks Error
![unity22_3_14_xcode_build_error](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/dd037a20-6290-49af-ab08-e1e402dc0bbb)<br/>
<br/>

## 해결 방법 (A, B 모두 처리)
### A. Unity-iPhone 처리
![unity22_3_14_xcode_build_error_fix1](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/543bcc97-370c-4a17-a97e-84b97851090e)<br/>
#### 1. Xcode에서 프로젝트 선택
#### 2. TARGETS에서 Unity-iPhone 선택
#### 3. Build Phases 선택
#### 4. Embed Frameworks에서 UnityFramework.framework가 있는 것에서 Adiscope.framework의 Code Sign On Copy 선택
#### 5. Embed Frameworks에서 UnityFramework.framework가 없는 것을 삭제
<br/><br/>

### B. UnityFramework 처리
![unity22_3_14_xcode_build_error_fix2](https://github.com/adiscope/Adiscope-Unity-UPM/assets/60415962/c95489e0-f28d-48db-993e-4610f6805b62)
#### 1. Xcode에서 프로젝트 선택
#### 2. TARGETS에서 UnityFramework 선택
#### 3. Build Phases 선택
#### 4. Embed Frameworks에서 Code Sign On Copy 선택 안 되어 있는 것을 삭제
