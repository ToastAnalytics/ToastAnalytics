| Version |	Release Date | Notes |
| ------- |	------------ | ----- |
| 1.3.2 | 2015-04-27 | [공통] 높은 확률로 푸시토큰 수집이 실패할 수 있는 경우에 대한 개선작업 적용<br>[Android] Rich Format Push 푸시메시지 기능지원을 위한 리소스파일 추가로 인해 기존 Jar파일 배포에서 프로젝트 배포방식으로 배포방식 변경 |
| 1.3.1 | 2015-04-20 | [공통] 설치지표의 수집 정확성을 높이기 위한 개선작업 적용 |
| 1.3.0 | 2015-04-15 | [공통] 캠페인 등록시 팝업/배너에 링크설정을 한 경우, 노출된 팝업/배너 클릭시 외부브라우저를 통해 해당 링크로 이동하는 기능 추가<br>[공통] 캠페인 팝업의 반복문구(오늘더안보기) 다국어지원<br>[Android] Rich Format 푸시메시지 기능 지원(타이틀, 타이틀색상, 본문색상, 아이콘, BigPicture 등) |
| 1.2.0 | 2015-03-05 | [공통] 동접을 위한 Heartbeat 기능 추가<br>[Android] 프로모션 보드에서 동영상 전체화면 재생 오류 수정<br>[Android] 보안/성능 지표 수집 기능 추가 |
| 1.1.4 |	2015-01-05 |[Android] NRU, DAU가 일부 누락되는 버그 수정<br>[iOS] idfa 수집이 불가능한 경우 UUID 생성 로직 변경<br>[iOS] tracePurchase에서 ‘Internal Error’ 발생 버그 수정|
| 1.1.3 |	2014-12-23 |[Android] 보안/성능 지표 수집 기능관련 버그 수정<br>[Android] targetSDK=21인 경우 Lollipop에서 Promotion 웹뷰 이미지가 표시되지 않는 문제 수정<br>[Android] 로그 전송시 URL Encoding방식을 iOS와 통일<br>[Android] install Referrer를 로그 서버로 보내는 시점 추가<br>[Android] 프로모션 polling 주기 변경 (5분 주기 -> Polling 하지 않음)|
| 1.1.2 | 2014-12-15 |[Android] 보안/성능 지표 수집 기능 추가<br>[Android] Promotion Webview에 버그 수정<br>[Android] Promotion 성과 분석을 위한 수집 지표 추가 (국가 코드)<br>[iOS] Memory Leak 수정<br>[iOS] Sqlite Crash 수정|
| 1.1.1 |	2014-12-01 |[Android] Promotion에서 국가 코드 잘못 전송하는 부분 수정.|
| 1.1.0 |	2014-11-25 |[공통] onPromotionVisibilityChanged callback 추가. (현재 안드로이드만 동작합니다)<br>[공통] setLoggingUserId, setCampaignUserId를 setUserId로 일원화.<br>[공통] 로그 필드에 SDK Version 정보 추가 (key=kv)<br>[Android] Googleplay Install Referrer 수집 방식 수정 (NRU가 실제보다 적게 집계되는 이슈 수정)<br>[Android] 기본 정보(Carrier, Locale, CountryCode, IP)가 수집되지 않는 문제 수정.<br>[iOS] Device Name 수집 오류 수정 (device name -> device model)|
| 1.0.2 |	2014-11-15 |[공통] Promotion 보상 지급 오류 수정.|
| 1.0.1 |	2014-11-14 |[Android/Unity] 앱 실행 정보를 받기 위한 Broadcast Receiver를 Install Recevier에서 분리.<br>[Android/Unity] 프로모션 진행시 Device ID를 잘못 보내는 버그 수정<br>[Android/Unity] Android 4.0.x에서 AsyncTask 오동작하는 버그 수정.|
| 1.0.0 |	2014-11-14 |[공통] traceMoneyAcquisition, traceMoneyConsumption API의 amount를 int->double 변경<br>[공통] traceEvent API의 value를 int->double로 변경|
| 0.9.5 |	2014-11-07 |[공통] CampaignListener에서 onReward 삭제, onMissionComplete 추가.<br>[공통] showReward, hideReward API 삭제.<br>[공통] 웹콘솔 지원을 위한 Debug Packet Info 추가.<br>[Android/Unity] Promotion API 추가 : isPromotionAvailable, getPromotionButtonImagePath, launchPromotionPage.<br>[iOS] simulator 라이브러리 추가.|
| 0.9.4 | 2014-10-28 |google-play-service.jar 최신버전으로 변경<br>android-support-v4.jar 추가<br>setGcmSenderId() 함수 추가 - 안드로이드에서만 동작합니다. iOS에서는 무조건 SUCCESS를 리턴합니다.|
| 0.9.3 |	2014-10-22 |Integrated SDK Guide 반영된 Android, iOS SDK 적용<br>프로젝트 구조 정리|
| 0.9.2 |	2014-10-15 | NameSpace 추가 Toast.Analytics<br>Class 이름 변경 : NEAFlatGame -> GameAnalytics<br>initializeSDK, traceActivation, traceDeactivation을 Unity에서 호출하도록 추가<br>getVersion API 추가||
