# Applovin Ad Review (Only Android)
> 해당 플러그인이 설정된 상태로 빌드 시 빌드 시간이 오래 걸리는 점 참고 바랍니다.

![adiscope_setttings_applovin_ad_review](https://github.com/user-attachments/assets/22453056-aea9-4701-b55b-c109a70bc430)
- 4.5.4 버전에서 지원
- MAX를 사용하는 매체에서 동영상 소재에 따른 효율 파악을 위한 기능
- 아래 조건이 모두 성립한 상태로 빌드 시 `Assets/Plugins/Android` 경로의 gradle 파일에 ad review 관련 스크립트가 추가되어 동작함
  - 애디스콥 설정 IDE > `Applovin Ad Review` 체크박스 ON
  - 애디스콥 설정 IDE > `Applovin Ad Review Key`의 필드에 값 존재할 경우
    - 관리자에게 애디스콥 설정 json 파일을 재발급 > `Settings Android from json file` 버튼 클릭 > 새로운 json 파일 불러오기 시 킷값이 필드에 자동으로 기입됨  
  - Unity build profiles > `Build App Bundle (Google Play)` 체크박스 ON
  - 조건이 하나라도 성립되지 않을 경우 해당 스크립트는 제거됨

![unity_android_settings_aab](https://github.com/user-attachments/assets/f9745522-31d9-4cc6-9830-df18478008c5)
