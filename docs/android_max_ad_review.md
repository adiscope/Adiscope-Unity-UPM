# Max Ad Review (Android 환경) 적용 방법

## Unity 21버전 이하 (gradle version ~6.x)
1. 애디스콥측으로부터 Ad Review 키를 전달받음

2. launcherTemplate.gradle, baseProjectTemplate.gradle 파일 생성
- `launcherTemplate.gradle`
  - Project Settings > Player > Build > **Custom Launcher Gradle Template** 체크박스 활성화
- `baseProjectTemplate.gradle`
  - Project Settings > Player > Build > **Custom Base Gradle Template** 체크박스 활성화

3. `launcherTemplate.gradle` 파일에 하기 코드 추가
```groovy
apply plugin: 'applovin-quality-service'
applovin {
    apiKey "AD_REVIEW_KEY"
}
```

4. `baseProjectTemplate.gradle` 파일에 하기 코드 추가
```groovy
allprojects {
    buildscript {
        repositories {
            google()
            jcenter()
            maven { url 'https://artifacts.applovin.com/android' }
        }

        dependencies {
            classpath 'com.android.tools.build:gradle:4.0.1'
            classpath "com.applovin.quality:AppLovinQualityServiceGradlePlugin:+"
        }
    }
}
```

<br></br>

## Unity 22버전 이상 (gradle version 7+)
1. 애디스콥측으로부터 Ad Review 키를 전달받음

2. `baseProjectTemplate.gradle` 파일 생성  
- Project Settings > Player > Build > **Custom Base Gradle Template** 체크박스 활성화

3. `baseProjectTemplate.gradle` 파일에 하기 코드 추가
```groovy
plugins {
    ...
    id 'com.applovin.quality' version '+' apply false
}
```

4. `launcherTemplate.gradle` 파일에 하기 코드 추가
```groovy
apply plugin: 'applovin-quality-service'
applovin {
    apiKey "AD_REVIEW_KEY"
}
```

5. ``settingsTemplate.gradle`` 파일에 하기 코드 추가
```groovy
pluginManagement {
    repositories {
        ...
        maven { url 'https://artifacts.applovin.com/android' }        
    }
}
```