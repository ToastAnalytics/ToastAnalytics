
# 시작하기

## 공통

* SDK에서 수집하는 개인정보가 있나요? 

SDK는 개인 식별이 가능한 정보는 수집하지 않습니다. 다만 통계를 위해서 단말기 정보 일부를 수집하고 있습니다. 현재 수집하고 있는 정보는 아래와 같습니다.
- iOS, Android 공통 : 단말 기종, 단말 제조사, 디바이스 해상도, 언어설정, Carrier(이통사), Time Zone, OS Version, App Version 
- OS : Language, Device Vendor ID, Device Token(APNS), Wifi MAC Address(수집 가능한 경우), IDFA 
- Android : Android Device ID, Registration ID(GCM), 광고 ID, WiFi MAC Address (권한이 있는 경우만) 


## setUserId는 언제 호출하나요?

setUserId는 SDK에 사용자 정보를 제공하는 API입니다.

SDK에서는 사용자 정보를 통계 작성용과 Campaign/Promotion용 두가지로 사용합니다.
먼저 통계 작성에서 사용자 정보가 가지는 의미는 FAQ의 '1. initializeSdk에서 useLoggingUserId는 어떤 역할을 하나요?'을 참고하세요.

Campaign/Promotion을 위해서는 반드시 사용자 정보가 필요합니다. 즉 Campaign이나 Promotion을 사용하는 경우에는 initializeSdk에서 useLoggingUserId flag가 false인 경우라도 반드시 'setUserId("userid", true)'를 호출하여 Campaign이나 Promotion을 위한 사용자 정보를 제공해야 합니다.

여기에서 User ID는 사용자를 구분할 수 있는 unique한 값입니다. 일반적으로 게임에서 사용하는 User ID나 Member No 같은 값을 사용하면 됩니다. 비로그인 기반 게임에서는 게임에서 Random하게 생성한 값(UUID, Advertise ID등등)을 사용하면 됩니다.
