
# FAQ

## initializeSdk에서 useLoggingUserId는 어떤 역할을 하나요?

Analytics에서 통계를 작성하기 위해서는 사용자를 구분하여 추적합니다. 이때 사용자를 구분하는 기준을 게임에서 지정할지 Analytics 내부에서 값을 생성(현재는 Android는 ADID, iOS는 IDFA를 사용합니다.)하여 사용할지를 결정하는 flag 입니다.

flag를 true로 설정하면 게임에서 SDK로 제공하는 UserID를 기준으로 사용자를 구분합니다. 그렇기 때문에 반드시 setUserId API를 통해서 SDK에게 User ID를 알려주어야 합니다. 반면 flag를 false로 설정하면 setUserId를 호출할 필요가 없습니다. (단 Campaign이나 Promotion을 사용하는 경우에는 flag를 false로 설정 하더라도 setUserId를 호출해야 합니다. 이때 setUserId를 통해 제공되는 사용자 정보는 통계에서 사용자 구분을 위한 값으로 사용되지 않고 Camapign, Promotion에서만 사용합니다.)

예를들어 useLoggingUserId flag를 false로 설정한 경우(즉, Analytics SDK 내부에서 생성한 사용자 구분 정보를 사용하는 경우) 하나의 디바이스에서 게임 탈퇴->재가입 하는 경우에도 기존과 동일한 사용자로 집계됩니다. 반면 flag를 treu로 설정한 경우(즉, 게임에서 사용자 구분 정보를 제공한 경우)에는 신규 사용자로 집계됩니다.
반면한명의 사용자가 두개의 디바이스를 사용하는 경우는 flag가 false인 게임의 경우 각각 다른 사용자로 집계되는 반면 true인 경우에는 동일한 사용자로 집계 됩니다.

각각의 장단점이 있기 때문에 게임의 상황에 따라 결정하여 사용하면 됩니다. 단 게임 출시 이후에 flag 설정을 변경하게 되면 통계 기준이 바뀌게 되어 변경 전/후 사용자 연결이 끊어지게 됩니다. 


## setUserId는 언제 호출하나요?

setUserId는 SDK에 사용자 정보를 제공하는 API입니다.

SDK에서는 사용자 정보를 통계 작성용과 Campaign/Promotion용 두가지로 사용합니다.
먼저 통계 작성에서 사용자 정보가 가지는 의미는 FAQ의 '1. initializeSdk에서 useLoggingUserId는 어떤 역할을 하나요?'을 참고하세요.

Campaign/Promotion을 위해서는 반드시 사용자 정보가 필요합니다. 즉 Campaign이나 Promotion을 사용하는 경우에는 initializeSdk에서 useLoggingUserId flag가 false인 경우라도 반드시 'setUserId("userid", true)'를 호출하여 Campaign이나 Promotion을 위한 사용자 정보를 제공해야 합니다.

여기에서 User ID는 사용자를 구분할 수 있는 unique한 값입니다. 일반적으로 게임에서 사용하는 User ID나 Member No 같은 값을 사용하면 됩니다. 비로그인 기반 게임에서는 게임에서 Random하게 생성한 값(UUID, Advertise ID등등)을 사용하면 됩니다.
