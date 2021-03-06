# 마케팅 트래킹 가이드

마케팅 담당자는 마케팅 실행 후 유입된 이용자를 모니터링하고 성과를 측정할 도구가 필요합니다.  

Toast Analytics에서는 간편하게 트래킹 URL을 발급하여 채널별 유입되는 이용자를 실시간으로 모니터링 할 수 있고 Post-Install 성과측정을 위한 다양한 분석지표와 LTV 예측지표를 제공합니다.	 

채널별 비교분석을 통해서 효율이 높은 채널을 믹스하여 운영할 수 있습니다.


## 1. 트래킹URL 발급    

트래킹 URL을 발급하여 집행하는 광고에 적용하면 이용자가 어떤 경로를 통해 설치하였는지 트래킹할 수 있습니다.  

|용어|설명|
|---|---|
|트래킹URL |	이용자의 설치 경로를 트래킹하기 위해 Analytics에서 발급한 URL|
|유입채널|	게임을 설치한 채널을 의미합니다. 마케팅을 통해 게임을 설치한 경우 각 마케팅을 실행한 채널을 의미하며 스토어를 통해 바로 설치된 경우 자연유입입니다 |
|유입경로 |	유입채널에서 실행단위 경로를 의미합니다.예로 페이스북의 뉴스레터 상단 배너에 광고를 진행할 경우 유입채널은 페이스북, 유입경로는 뉴스레터 배너가 됩니다. |
|3rd Party Tracker|	Facebook과 같은 광고채널에 광고를 대행해 주는 업체로 MAT, AppsFlyer 등과 같은 업체가 있습니다.|
|이벤트|	게임내에서 발생하는 행동 단계 (예 레벨업, 재화, 설치, 구매 등)|  


### 1) 트래킹URL 발급방법

마케팅 > 트래킹URL발급 > "트래킹URL발급"을 통해서 트래킹 URL을 발급받을 수 있습니다.  

**(1) 발급방법**

![ 트래킹 URL발급, 외부URL등록 버튼]
(http://static.toastoven.net/prod_analytics/marketing/image026.png)

[ 트래킹 URL발급, 외부URL등록 버튼]  

* 1)트래킹URL발급 버튼을 클릭하면 입력창이 팝업됩니다. 
* 2) 채널을 선택합니다. 리스트에서 채널이 없는 경우 채널추가를 통해 신규로 등록할 수 있습니다.  
* 3) 유입경로명을 입력합니다. 경로의 특징을 잘 표현해 주는 명칭으로 자유롭게 기입합니다.  
   예) 티스토어_웹_검색창우측  
* 4) Target URL을 설정합니다.
   - 스토어를 설정한 경우 셀렉박스에서 스토어를 선택합니다. 선택 후 다운로드 URL이 맞는지 확인합니다.
   - 랜딩URL로 설정한 경우 트래킹이 필요한 웹페이지URL을 http:// 방식으로 등록합니다.
* 5) 집행 기간을 등록합니다.  
* 6) 과금방식과 집행비용은 옵션항목이며 집행비용을 입력하면 인당 비용을 지표에서 확인할 수 있습니다.  
* 7) 입력 후 추가를 클릭하면 유입경로가 등록되고 트래킹 URL을 확인할 수 있는 창이 나타납니다.  

![ 트래킹 URL발급 팝업1]
(http://static.toastoven.net/prod_analytics/marketing/image027.png)

[ 트래킹 URL발급 팝업1]

![ 트래킹 URL 확인 팝업2]
(http://static.toastoven.net/prod_analytics/marketing/image028.png)

[ 트래킹 URL 확인 팝업2]

※ 참고 : 다수의 트래킹 URL을 발급해야 하는 경우 필요 항목을 엑셀로 작성하여 일괄 발급이 가능합니다. 자세한 기능 설명은 등록페이지의 팝업 헬프에서 확인할 수 있습니다.  


**(2) 유입경로 구분**

1) 자체등록 : Analytics에서 직접 등록하여 트래킹 URL을 발급받은 유입경로  
2) 3rd Party Tracker 연동 : 3rd Party Tracker의 Postback 연동을 통해 자동으로 등록된 유입경로  
*참고:정확한 유입경로별 분석을 위해 등록한 정보를 수정하시는 것은 지양해 주시기 바랍니다.  


### 2) Facebook 광고트래킹**

- Analytics에서 발급받은 딥링크를 페이스북에 등록하여 이용자를 트래킹 할 수 있습니다.

* ① 딥링크발급 : 트래킹 URL 발급 팝업에서 채널을 Facebook으로 선택하면 딥링크가 생성됩니다.
(※ 시스템 등록된 Facebook 채널을 선택합니다. 임의로 추가된 채널에서는 딥링크가 발급되지 않습니다.)
* ② 광고만들기 : Facebook에 접속하여 광고를 생성하고 타겟, 예산, 일정 등을 설정합니다.
* ③ 딥링크등록 : 캠페인 설정 후 Facebook 광고 하단 딥링크에 발급받은 딥링크를 입력합니다.
 : 광고설정 완료 후 Analytics에서 Facebook 광고로 유입된 이용자를 트래킹할 수 있습니다.


** Facebook 트래킹 Flow**

![Facebook 트래킹 Flow]
(http://static.toastoven.net/prod_analytics/marketing/image037.png)

**(1) 딥링크 발급

![딥링크 발급]
(http://static.toastoven.net/prod_analytics/marketing/image038.png)

[딥링크 발급]

* 1) 채널선택 : 시스템으로 등록된 Facebook 채널을 선택합니다.
* 2) 유입경로명 : 페북에 실행하는 캠페인을 인식할 수 있는 명을 자유롭게 입력합니다. 
* 3) Target URL : 스토어 또는 랜딩URL을 입력합니다. (※ 딥링크 발급인 경우 필수 입력사항은 아닙니다.)
* 4) 기간 : 집행기간을 입력합니다. 
* 5) 과금방식, 비용 : 옵션사항입니다.
* 6) 추가 버튼을 누르면 딥링크가 발급됩니다.


![딥링크 확인]
(http://static.toastoven.net/prod_analytics/marketing/image039.png)

[딥링크 확인]

**(2) 광고만들기

![광고목표 및 앱선택]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing3_4.png)

[광고목표 및 앱선택]

![캠페인 설정]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing3_5.png)

[캠페인 설정]

* 1) 광고목표 : 앱 설치 늘리기 등 광고 목표를 설정합니다.
* 2) 앱선택 : 광고할 앱을 선택한 후 캠페인 명을 입력합니다.
* 3) 캠페인 : 광고에 노출될 타겟과 예산 및 일정 등을 설정합니다.


**(3) 딥링크 등록

![딥링크 등록]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing3_6.png)

[딥링크 등록]

* 1) 딥링크(선택사항) 박스에 발급받은 딥링크를 아래와 같은 포맷으로 입력합니다.

ex) appscheme://action?param1=val1&param2=val2&tafb=**channel_216,path_1075,charge_NON**


### 3) Facebook 딥링크 테스트 방법**

**(1) SDK버전확인 **
* 페이스북 딥링크 트래킹을 위해서는 SDK 1.3.7 버전 이상 설치되어 있어야 합니다. 

**(2) Facebook 설정 **
* Facebook 설정은 아래 URL에서 확인할 수 있습니다. 

  https://developers.facebook.com/docs/app-ads/deep-linking?locale=ko_KR

※ 정상적으로 호출되면 callback이 오는데, callback에 정상적으로 Deeplink URL이 담겨 있는지 확인이 필요합니다.

**(3) 딥링크 실행 테스트 **

* 1) 테스트 계정 권한 추가	

* 2) 테스트 계정 접속 후 권한 승인 버튼을 클릭합니다.	
- facebook for developers 에 접속하여 My Apps에 Request에 승인버튼을 클릭합니다.	
  https://developers.facebook.com/apps/	

![MyApps Request]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing3_7.png)

[MyApps Request]


* 3) Tools & Support > App Ads Helper 페이지로 이동합니다.
  (※ https://developers.facebook.com/tools/app-ads-helper/)

![Apps Ads Helper1]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing3_8.png)

[Apps Ads Helper1]


* 4) 승인받은 앱을 선택합니다. 
 
![Apps Ads Helper2]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing3_9.png)

[Apps Ads Helper2]


* 5) 하단 Developer Tools에서 DEEP LINK TESTER의 Test Deep Link를 클릭합니다. 

![Test Deep Link]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing3_10.png)

[Test Deep Link]

* 6) Test Deep Link에서 발급받은 Deeplink를 입력합니다.
- 입력포맷은 위의 딥링크 등록 포맷에서 제공된 포맷으로 입력합니다. 

![Send Deep Link]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing3_11.png)

[Send Deep Link]

- Send Notification, Send Deferred를 선택합니다. 
- 테스트할 OS에 따라서 Send to iOS or Send to Android를 클릭 합니다.

![Verify Deep Link]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing3_12.png)

[Verify Deep Link]

* 7) 딥링크 클릭 후 앱실행
- 페북 앱 알림에서 "Tap to launch your deep link" 클릭 후 앱을 실행합니다. 

![Tap to launch your Deep Link]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing3_13.png)

[Tap to launch your Deep Link] 

- 앱 첫실행 후 Deep link 정보가 TA에 전송됩니다. 
- 주) 앱이 설치된 디바이스에서는 테스트가 되지 않습니다. 기존 설치된 앱을 삭제 후 테스트를 진행해 주시기 바랍니다. 

* 8) TA에서 트래킹 결과를 확인합니다.
- TA > 마케팅 > SUMMARY 에서 실시간으로 유입된 건을 확인할 수 있습니다. 
- 아래 실시간 셀렉박스에서 Facebook 채널 선택 시 해당 채널로 유입된 설치건을 모니터링 할 수 있습니다. 

![Tap to launch your Deep Link]
(http://static.toastoven.net/prod_analytics/marketing/marketing3_14.png)





### 4) 채널등록  

**(1) 등록방법 ** 

① 마케팅 > 채널등록 > 채널추가 팝업에서 채널을 등록합니다.

![ 채널추가 팝업]
(http://static.toastoven.net/prod_analytics/marketing/image029.png)

[채널추가 팝업]

② 등록한 채널은 채널리스트에 노출됩니다. (※ 트래킹URL 발급시 유입채널로 설정됩니다.)

![ 채널등록 테이블]
(http://static.toastoven.net/prod_analytics/marketing/image030.png)

[채널등록 테이블]  

**(2) 채널유형**  
채널은 "자체등록", "시스템등록", "3rd Party Tracker 연동" 세가지 형태로 구분됩니다.

① 자체등록 : 채널추가를 통해서 직접 등록합니다.  
② 시스템등록 : 시스템에서 디폴트로 등록된 채널입니다.  
③ 3rd Party Tracker 연동 : 3rd Party Tracker를 등록하는 경우 Postback으로 유입되는 채널이 자동으로 등록됩니다.  
※ 시스템등록과 3rd Party Tracker 연동을 통해 자동으로 유입된 채널은 수정 및 삭제할 수 없습니다. 

### 3) 3rd Party Tracker 등록  

3rd Party Tracker를 통해 집행하는 경우 간단하게 Postback을 설정하고 필요 정보를 등록하면 Analytics에서도 유입이용자를 트래킹할 수 있습니다.  

이를 위해 3rd Party Tracker에서 발급받은 앱정보를 등록합니다. 추가적으로 Postback 설정방법은 "마케팅트래킹"에서 상세하게 설명합니다.  

(1) 등록방법  

① 추가버튼을 누르면 상단에 한줄이 추가되고 각 셀에 값을 입력할 수 있도록 활성화 됩니다.  
② 3rd Party Tracker와 OS를 선택합니다.  
③ 앱ID 정보를 입력합니다. (※ "(2) 3rd Party Tracker 앱id 확인 방법"에서 확인할 수 있습니다.)  
④ 저장을 누르면 3rd Party Tracker가 등록됩니다.	

![ 3rd Party Tracker 등록]
(http://static.toastoven.net/prod_analytics/marketing/image031.png)

[3rd Party Tracker 등록]  

- 3rd Party Tracker가 등록되면 채널등록 페이지에 3rd Party Tracker를 통해 유입된 채널이 자동으로 등록됩니다.
(※ 채널명은 "3rd Party Tracker@채널명, 예) AppsFlyer@Facebook"의 형태로 입력됩니다.)

- 3rd Party Tracker 채널을 통해 유입되는 경로는 트래킹URL발급 페이지에 자동으로 등록됩니다.
(※ 유입경로명은 3rd Party Tracker에 등록된 캠페인명이 등록됩니다.) 
- 채널이 등록된 3rd Party Tracker는 수정 및 삭제할 수 없습니다.  

(2) 3rd Party Tracker 앱id 확인 방법  

① Appsflyer 앱ID 확인  
: AppsFlyer에서 발급한 앱ID 확인 후 Analytics에 앱ID를 등록합니다. (Analytics > 앱설정 > 마케팅 > 3rd Party Tracker등록)  
※ AppsFlyer Dashboard > App 에서 앱id를 확인할 수 있습니다.

![ AppsFlyer 앱id 확인]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing7.png)

[AppsFlyer 앱id 확인] 

② MAT 앱ID 확인
: MAT에서 발급한 앱ID 확인 후 Analytics에 앱ID를 등록합니다.  
: Analytics > 앱설정 > 마케팅 > 3rd Party Tracker등록  
※ MAT Applications > Mobile Apps 에서 앱id를 확인할 수 있습니다.

![ MAT 앱id 확인]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing8.png)

[MAT 앱id 확인] 



### 4) Postback 설정  
Analyics에 3rd Party Tracker를 연동하기 위해 각 3rd Party Tracker 사이트에 접속하여 캠페인을 설정합니다.  
3rd Party Tracker에 Postback URL, Analytics에 앱ID를 등록하면 각 3rd Party Tracker를 통해 유입되는 로그가 수집됩니다.  

**(1) AppsFlyer 연동(= Push API 설정) ** 
① AppsFlyers에서 데이터를 제공받기 위해 API 설정 페이지로 이동합니다. (Export your data using the APIs)  
② 데이터를 이관받기 위해서 Push APIs 설정으로 이동합니다.  
③ install에 대한 로그를 수집할 수 있도록 ON/OFF를 설정합니다.3rd Party Tracker를 통해 유입된 로그만 수집할 경우 Organic은 OFF로 설정합니다.  
※ 설정방법에 대한 자세한 설명은 아래 사이트를 참고하시기 바랍니다.  
- https://support.appsflyer.com/entries/23657913-Push-APIs-Real-Time-Installation-Conversion-Notification-APIs)

![ AppsFlyer API 연동]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing9.png)

[AppsFlyer API 연동]  

**(2)  MAT 연동(= Postback URL 설정) **  
 ① Internal Partner를 추가합니다.  
![  Internal Partner 추가]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing10.png)

[ Internal Partner 추가]  

② MAT에 Postback URL을 등록합니다.

Step1.Interanl Partner에서 Postbacks으로 들어간 후 Add Postback URL 버튼을 눌러 생성합니다.  
Step2. Enter URL에 analytics 로그수집 URL을 등록합니다.  
Step3. Postback URL에서 수집될 URL을 입력합니다.  
: URL은 아래 고정된 URL을 입력하여 등록합니다.  
: 입력 시 3rd Party Tracker에서 발급받은 앱id를 기입합니다. (※ 아래 URL에서 붉은색 표시된 aid에 입력합니다.)   
: Postback URL (AOS)  

  * http://redirect-analytics.toast.com/postback/mat?aid=99716&package_nm={package_name}&advertising_id={google_aid}&uid={user_id}&timestamp={timestamp}&chnl_id={publisher_id}&chnl_nm={publisher_name}&path_id={campaign_id}&path_nm={campaign_name}&is_ad_tracking={google_ad_tracking}&is_attributted={is_attributed}&ip={device_ip}&osv={os_version}&dnm={device_model}&cc={country_code}&lc={language}&cr={device_carrier}&av={package_app_version

: Postback URL (iOS) 

* http://redirect-analytics.toast.com/postback/mat?aid=99716&package_nm={package_name}&advertising_id={ios_ifa}&uid={user_id}&timestamp={timestamp}&chnl_id={publisher_id}&chnl_nm={publisher_name}&path_id={campaign_id}&path_nm={campaign_name}&is_ad_tracking={google_ad_tracking}&is_attributted={is_attributed}&ip={device_ip}&osv={os_version}&dnm={device_model}&cc={country_code}&lc={language}&cr={device_carrier}&av={package_app_version

Step4. Postback Requirement에서 Partner와 앱, 이벤트를 입력 후 저장합니다.  

![  Postback URL 등록]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing11.png)

[ Postback URL 등록]  


Step5. 저장 후 Postbacks 페이지에 등록된 결과를 확인할 수 있습니다.  

![  Postbacks 설정 리스트]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing12.png)

[ Postbacks 설정 리스트]  


※ Internal Partner 에 대한 상세 내용은 아래 사이트를 참고하시기 바랍니다.

: http://support.mobileapptracking.com/entries/22389404-Setting-Up-an-Internal-Partner  

※ Postback URL 에 대한 상세 내용은 아래 사이트를 참고하시기 바랍니다.:  

:http://support.mobileapptracking.com/entries/22560357-Setting-Up-Postback-URLs



## 2. 마케팅 트래킹   
광고를 집행한 후 해당 채널로 유입되는 이용자를 분석하기 위해 이용자를 트래킹합니다. 

### 1) 광고를 매체에 직접 집행할 경우 (AOS인 경우)  
AOS인 경우 광고를 집행한 후 스토어를 통해 설치시 트래킹 URL에 레퍼러를 추가하여 유니크한 퍼블리셔를 식별할 수 있습니다.	

- 트래킹 URL을 발급한 후 광고매체에 적용합니다. 
- (※ 외부에서 발급받은 URL인 경우 직접 URL을 등록하여 트래킹 URL을 생성합니다.)  
- 이용자가 광고를 Click하여 스토어로 이동하면 Click 로그가 전송됩니다.
- 스토어 설치 후  레퍼러를 통해 앱 실행 후 레퍼러가 적용된 User 로그가 전송됩니다.  


![  구글 레퍼러를 이용한 광고트래킹 Flow]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing13.png)
[ 구글 레퍼러를 이용한 광고트래킹 Flow] 



### 2) 광고를 매체에 직접 집행할 경우 (AOS 이외 스토어인 경우)  

AOS이외의 스토어인 경우 이용자를 트래킹할 수 있는 레퍼러와 같은 고유 식별자를 제공하지 않습니다. 이용자의 광고클릭시 발생하는 클릭로그 정보를 기반으로 고유한 핑거프린팅을 만들어 동일 이용자로 식별할 수 있습니다.  

앱스토어는 레퍼러를 포함시키지 않기에 광고 클릭시와 스토어를 통해 설치시 생성된 핑거프린팅을 매칭하여 광고로 유입된 이용자를 트래킹할 수 있습니다.



![  핑거프린팅을 이용한 광고트래킹 Flow](https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing14.png)

[ 핑거프린팅을 이용한 광고트래킹 Flow] 



### 3) 3rd Party Tracker를 통해 광고를 집행할 경우

직접 광고하지 않고 3rd Party Tracker를 통해 광고를 집행한 경우 3rd Party Tracker의 Postback URL을 통해 설치이벤트를 확인할 수 있습니다.											

- 3rd Party Tracker Postback에 Analytics 수집서버 URL과 이벤트를 등록합니다.
- 3rd Party Tracker에서 발급받은 앱ID를 Analytics에 등록합니다.
- 광고가 집행되면 3rd Party Tracker Postback을 통해 이용자를 트래킹할 수 있습니다.


![3rd Party Tracker를 통해 광고를 집행할 경우 Flow]
(https://raw.githubusercontent.com/ToastAnalytics/ToastAnalytics/master/docs/Developer/images/marketing15.png)

[ 3rd Party Tracker를 통해 광고를 집행할 경우 Flow] 


## 3. 트래킹이벤트 등록   
유입 이후 트래킹 할 이벤트를 설정하여 모니터링할 수 있습니다. 
커스텀 페이지에서 지표를 확인하기 위해서는 먼저 트래킹할 이벤트를 등록해야합니다.

### 1) 이벤트 등록  
등록된 이벤트는 '마케팅>커스텀' 에서 분석할 수 있습니다.   

**(1) 등록방법**  

① 추가 버튼을 눌러 신규 이벤트명을 입력합니다.  
② 이벤트와 파라미터를 선택합니다. 이벤트는 등록된 커스텀 이벤트에서 선택이 가능합니다.  
예로 RPG 게임에서 엔카두의둥지 던전에 상급엔카두 보스몹에 패배한 이벤트를 설정할 경우 아래와 같이 등록합니다.  
주) 커스텀 이벤트에서 발생된 이벤트에 한해서 등록이 가능합니다.  

![ 트래킹이벤트 추가 팝업]
(http://static.toastoven.net/prod_analytics/marketing/image020.png)

[ 트래킹이벤트 추가 팝업]

추가된 이벤트는 마케팅 > 커스텀 페이지에 이벤트 항목으로 노출됩니다.  

![ 이벤트선택 셀렉박스]
(http://static.toastoven.net/prod_analytics/marketing/image021.png)

[ 이벤트선택 셀렉박스]

### 2) 등록시 확인 사항  
* 이벤트는 최대 10개까지 등록이 가능합니다.  
* 등록한 이벤트는 등록한 다음날부터 데이터 확인이 가능합니다.  
* 등록한 이벤트는 등록일이 지난 경우 수정이 불가능합니다. 수정이 필요한 경우 삭제 후 신규로 등록해 주시기 바랍니다.  
* 등록일 이전에는 이벤트 상세내역까지 수정이 가능합니다.  

## 4. Postback 등록   

Toast Analyics에 광고집행을 통해 발생된 이벤트 정보를 전송 받을 수 있습니다.  

**1) Postback 등록**

마케팅 > Postback등록 > "Postback추가"를 통해서 Postback 서비스를 등록할 수 있습니다.

(1) 등록방법
① Postback 등록 페이지에서 Postback 추가버튼을 클릭합니다.

![ Postback 등록]
(http://static.toastoven.net/prod_analytics/marketing/image033.png)

[ Postback 등록]

② Postback 등록 팝업에서 파트너사인 경우 Partner 템플릿, 직접등록할 경우 직접등록을 선택합니다.

③ Partner 템플릿인 경우 
 - Postback 이름을 입력합니다.
 - 파트너를 선택합니다. 파트너는 사전에 업무 협의된 파트너사가 노출됩니다. 
 - Postback URL을 확인합니다. Postback URL은 사전 정의된 포맷이 제공됩니다.

④ 직접등록인 경우 (※ 추후 오픈 예정입니다.)
 - Postback 이름을 입력합니다.
 - 채널을 선택합니다. 모든 채널을 대상으로할 경우 "전체"를 선택합니다.
 - Organic을 포함할 경우 체크박스에 표시합니다.
 - OS와 Event Type을 선택합니다. (※ Event는 현재 Install만 지원됩니다.)
 - Postback Data를 추가합니다.
   -> 파라미터값을 선택한 후 파라미터이름을 입력합니다. 
   -> 파라미터를 추가할 경우 우측 "+" 버튼을 누르면 하단에 파라미터 입력칸이 추가됩니다.
   -> 기존 추가된 파라미터는 우측 "x" 버튼을 누르면 삭제됩니다.
 - Postback Data를 추가를 완료한 후 상단에 자동생성된 Postback URL을 확인합니다.

⑤ 추가 버튼을 누른 후 등록페이지에서 내용을 확인할 수 있습니다. 
⑥ 등록페이지에서 "확인" 버튼을 누르면 등록한 Postback URL을 확인할 수 있습니다.
⑦ 수정 및 삭제 버튼으로 등록한 Postback을 수정 및 삭제할 수 있습니다.

![ Postback 등록 > Partner 템플릿 추가 팝업]
(http://static.toastoven.net/prod_analytics/marketing/image034.png)

[ Postback 등록 > Partner 템플릿 추가 팝업]

![ Postback 등록 > 직접등록 추가 팝업]
(http://static.toastoven.net/prod_analytics/marketing/image035.png)

[ Postback 등록 > 직접등록 추가 팝업]

![ Postback 등록 확인]
(http://static.toastoven.net/prod_analytics/marketing/image036.png)

[ Postback 등록 확인]

※ Postback 데이터는 POST 방식으로 제공됩니다.


**2) 제공되는 데이터 포맷**

|파라미터값			|파라미터명			|Data Type	|비고|
|---|---|---|---|
|app_id	|앱 ID	|String	|ToastAnalytics의 appKey|
|uid	|이용자ID	|String	|이용자ID|
|event_type	|이벤트 Type	|String	|1차 Open시에는 install만 지원|
|event_time	|로그 일시	|String	|“event_type=install”, 그 외의 경우, event 발생 시간|
|channel_name	|채널명	|String	|Tracking URL의 channel명|
|campaign_id	|캠페인 ID	|String	|Tracking URL의 path값|
|campaign_name	|캠페인명	|String	|Tracking URL의 path명|
|organic		|오가닉	|String	|“organic인 경우, yes”, 유입채널이 존재하는 경우, null|
|app_ver		|앱버전	|String	|앱버전|
|os_cd			|Device OS	|String	|클릭한 기기의 OS (ex. iOS/Android)|
|os_ver			|Device OS Version	|String	|클릭한 기기의 운영체제 버전|
|dev_locale		|Device locale	|String	|클릭한 기기의 지역|
|dev_nat_cd		|Device 국가코드 |String |클릭한 기기의 국가코드|
|time_zone		|타임존		 |String |클릭한 기기의 타임존|
|sdk_ver		|Analytics SDK Version	|String	|Analytics SDK버전|
|Refr			|레퍼러	|String	|Conversion이 이루어지기 위한 레퍼러 URL.|
|tracking_url	|트래킹 URL |String	|Tracking URL|
|context		|context  |String	|Tracking URL을 통해 전달한 파트너사의 Parameter|


**3) LTV, Retention (※ Partner사에만 API로 제공됩니다)**

|파라미터값|파라미터명|Data Type|비고|
|---|---|---|---|
|app_id	|앱ID|string	|ToastAnalytics의 appKey|
|log_dt	|생성일시|string|LTV,Retention 생성 일시|
|channel_name|채널명|string|Tracking URL의 channel명|
|campaign_id |캠페인id|string|Tracking URL의 path값|
|campaign_name|캠페인명|string|Tracking URL의 path명|
|ltv|LTV|number|Life Time Value|
|rt_day1|재방문율 D1|	number	|1일차 재방문율|
|rt_day2|재방문율 D2|	number	|2일차 재방문율|
|rt_day3|재방문율 D3|	number	|3일차 재방문율|
|rt_day4|재방문율 D4|	number	|4일차 재방문율|
|rt_day5|재방문율 D5|	number	|5일차 재방문율|
|rt_day6|재방문율 D6|	number	|6일차 재방문율|
|rt_day7|재방문율 D7|	number	|7일차 재방문율|
|rt_day14|재방문율 D14|	number	|14일차 재방문율|
|rt_day30|재방문율 D30|	number	|30일차 재방문율|
|rt_day60|재방문율 D60|	number	|60일차 재방문율|


## 5. 모니터링   
채널별 유입현황을 실시간으로 모니터링 할 수 있고 채널별 주요 지표를 한눈에 확인할 수 있습니다.  


|용어|설명|
|---|---|
|클릭수 |	광고를 클릭한 수|
|설치수|	유입경로를 통해 게임을 설치한 건수 |
|전환율(CVR)|	클릭 후 설치로 전환된 비율 (설치수/클릭수) |
|신규이용자|	최초 앱을 설치한 이용자. 재설치 이용자는 제외됨.|
|매출|	유료상품을 구매한 누적금액 (가입 후 60일까지 누적)|
|ARPU|	게임 실행 이용자의 인당 평균 구매금액 (가입 후 60일까지 집계)|  
|LTV|	한명의 이용자가 게임 설치 후 이탈할때까지 구매할 것으로 예상되는 금액 (Life Time Value)|  
|재방문율|	게임 설치 이후 경과된 일수에 따라 게임을 실행하는 이용자 비율|  


### 1) 실시간

 마케팅을 통해 유입되는 클릭수, 설치수, 전환율을 실시간으로 모니터링할 수 있습니다.  

**(1) 지표해석 가이드**  

* 실시간으로 유입현황을 확인하여 반응이 좋은 채널을 확인할 수 있습니다.  
* 유입채널별 실시간 마케팅 효과를 비교해 볼 수 있습니다.  

![  마케팅 채널별 실시간 유입현황 ]
(http://static.toastoven.net/prod_analytics/marketing/image016.png)

[ 마케팅 채널별 실시간 유입현황] 


###2) Summary

마케팅 채널별 주요지표에 대한 규모를 한눈에 비교해 볼 수 있습니다.  

**(1) 지표해석 가이드**  

* 다른 마케팅 채널과의 비교를 통해 게임운영시 신속한 의사결정을 진행할 수 있습니다.  
* 마케팅에 대한 상세한 성과분석이 필요한 경우 '성과분석' 을 통해 측정할 수 있습니다.  

![  마케팅 주요지표 SUMMARY 현황 ](http://static.toastoven.net/prod_analytics/marketing/image017.png)

[ 마케팅 주요지표 SUMMARY 현황] 

###3) 설치수

일별 추이를 확인할 수 있습니다.  

**(1) 지표해석 가이드**  

* 마케팅 채널별 설치수에 대한 일별 추이를 확인하여 타 채널대비 상승추세를 갖는 채널을 판단할 수 있습니다.
* 접속횟수와 게임이용시간으로 구분된 이용자의 일별 추이를 확인하여 접속패턴을 확인할 수 있습니다.  

![  일별 채널별 설치수 차트](http://static.toastoven.net/prod_analytics/marketing/image018.png)

[ 일별 채널별 설치수 차트] 

## 6. 성과분석
마케팅 채널에서 유입된 이용자를 필터링하여 성과를 분석하고 여러 채널 간 성과를 비교해 볼 수 있습니다.  

|용어|설명|
|---|---|
|설치수|	유입경로를 통해 노출된 팝업 등을 통해 실제 게임을 설치한 수 |
|전환율(CVR) |	클릭 후 설치로 전환된 비율 (설치수/클릭수) |
|신규이용자|	최초 앱을 설치한 이용자. 재설치 이용자는 제외됨.|
|매출|	유료상품을 구매한 누적금액 (가입 후 60일까지 누적)|
|구매건수|	유료상품을 구매한 건수|  
|PU비율|	조회기간 동안 게임이용자(DAU) 중 유료상품을 구매한 이용자 비율|  
|ARPU|	게임 실행 이용자의 인당 평균 구매금액 (가입 후 60일까지 집계)|   
|ARPT|	구매건당 평균 구매금액  (Average Revenue Per Transaction)|  
|재방문율|	게임 설치 이후 경과된 일수에 따라 게임을 실행하는 이용자 비율|


###1) 성과분석  

**(1) 지표해석 가이드**    

* 유입채널별 필터를 통해 선택된 대상자로 지표가 집계됩니다. (※ 유입채널과 필터는 다중선택이 가능합니다)   
* 선택된 대상자의 클릭수, 설치수, 신규이용자수, CVR에 대한 일별 추이를 확인할 수 있습니다.  
* 선택된 여러 유입경로별 주요지표를 한번에 비교해 볼 수 있습니다.  
* 마케팅 채널비교를 통해 효율이 높은 마케팅 채널에 집중하여 마케팅의 성과를 극대화 할 수 있습니다.

![  성과분석을 위한 주요지표 SUMMARY 현황]
(http://static.toastoven.net/prod_analytics/marketing/image019.png)

[ 성과분석을 위한 주요지표 SUMMARY 현황]

## 7. 채널분석  

마케팅 채널별로 주요지표 항목을 비교하여 효율이 좋은 채널을 판단할 수 있습니다.   

|용어|설명|
|---|---|
|재방문율|	게임 설치 이후 경과된 일수에 따라 게임을 실행하는 이용자 비율|
|ARPU|	게임 실행 이용자의 인당 평균 구매금액 (가입 후 60일까지 집계)|   
|레벨별Funnel|	최종레벨에 도달하기까지 설정된 레벨단계별 이용자 비율|   

###1) 재방문율 비교  

게임 설치 후 재방문한 이용자 비율을 채널별로 비교해 볼 수 있습니다.
마케팅 채널별로 재방문율을 비교하여 방문효과를 정량적으로 측정할 수 있습니다.

**(1) 지표해석 가이드**    

* 채널별 재방문율이 높은 채널을 확인할 수 있습니다. 
* 유입채널과 필터를 통해 선택된 대상자를 기준으로 집계됩니다.
* 자연유입 포함 최대 5개까지 비교할 수 있습니다.
* 가입 후 60일까지 재방문율을 제공합니다.

![ 채널별 재방문율 비교 차트]
(http://static.toastoven.net/prod_analytics/marketing/image022.png)

[ 채널별 재방문율 비교 차트]

###2) ARPU 비교  

이용자의 인당평균구매금액(ARPU)을 채널과 국가별로 비교해 볼 수 있습니다.
마케팅 채널별로 ARPU를 비교하여 매출효과를 정량적으로 측정할 수 있습니다.

**(1) 지표해석 가이드**    

* 채널별 ARPU가 높은 채널을 확인할 수 있습니다.  
* 채널별 ARPU를 비교하여 매출 효율이 높은 채널을 확인할 수 있습니다.   
* 유입채널과 필터를 통해 선택된 대상자를 기준으로 집계됩니다.  
* 자연유입 포함 최대 5개까지 비교할 수 있습니다.  
* 가입 후 60일까지 재방문율을 제공합니다.  

![ 채널별 ARPU 비교 차트]
(http://static.toastoven.net/prod_analytics/marketing/image023.png)

[ 채널별 ARPU 비교 차트]

###3) 레벨별Funnel 비교  

레벨 단계별 달성이용자에 대한 비율을 채널별로 비교해 볼 수 있습니다. 
마케팅 채널별로 달성율을 비교하여 레벨 달성 효과를 정량적으로 측정할 수 있습니다.

**(1) 지표해석 가이드**    

* 채널별 ARPU를 비교하여 재방문율이 높은 채널과 국가를 확인할 수 있습니다.  
* 채널별 레벨 도달율을 비교하여 게임이용이 높은 채널과 국가를 확인할 수 있습니다.   
* 유입채널과 필터를 통해 선택된 대상자를 기준으로 집계됩니다.  
* 자연유입 포함 최대 5개까지 비교할 수 있습니다.    

![ 채널별 레벨 Funnel 비교 차트]
(http://static.toastoven.net/prod_analytics/marketing/image024.png)

[ 채널별 레벨 Funnel 비교 차트]


## 8. 커스텀 지표  

마케팅 채널별 다양한 게임내 컨텐츠에서 발생한 이벤트에 대한 반응을 확인할 수 있습니다.   
예로 스테이지 클리어에 대한 이벤트인 경우 채널별로 해당 스테이지에 대한 성공률을 비교할 수 있습니다.


###1) 이벤트  

**(1) 지표해석 가이드**    

* 유입채널과 필터를 통해 선택된 대상자를 기준으로 집계됩니다.
* 사전에 정의된 커스텀 이벤트에 대해서만 이벤트 지표를 확인할 수 있습니다.
* 유입경로별로도 이벤트에 대한 반응을 비교할 수 있습니다. 
* 특정 국가 또는 신규로 출시된 이벤트가 있는 경우 이벤트에 대한 반응을 비교할 수 있습니다.

![ 채널별 이벤트 현황]
(http://static.toastoven.net/prod_analytics/marketing/image025.png)

[ 채널별 이벤트 현황]



