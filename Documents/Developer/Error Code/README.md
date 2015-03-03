Return Value | 값 | 설명
--- | --- | --- |
S_SUCCESS | 0x0000 | 성공
W_ALREADY_INITIALIZED | 0x1000 | SDK가 이미 초기화됨.
E_NOT_INITIALIZED | 0x8000 | SDK가 초기화 되지 않은 상태에서 api 가 호출됨.
E_SESSION_CLOSED | 0x8001 | traceStart 가 호출되지 않은 상태에서 api 가 호출됨.
E_INVALID_PARAMS | 0x8002 | 유효하지 않은 인자값이 전달됨.
E_ALREADY_EXISTS | 0x8003 | 동일한 screenCode 값으로 traceStartSpeed가 2회이상 호출됨.
E_INTERNAL_ERROR | 0x8004 | 내부에러
E_INSUFFICIENT_OPERATION | 0x8005 | traceStartSpeed가 호출되지 않은 screenCode값으로 traceEndSpeed가 호출됨.
E_APP_ID_IS_EMPTY | 0x8006 | SDK 초기화시 필수 입력값인 앱 ID 값이 NULL임.
E_ENTERPRISE_ID_IS_EMPTY | 0x8007 | SDK 초기화시 필수 입력값인 Enterprise ID 값이 NULL임.
E_APP_VERSION_IS_EMPTY | 0x8008 | SDK 초기화시 필수 입력값인 앱 버전값이 NULL임.
E_TOKEN_EMPTY | 0x8009 | 디바이스 토근값이 NULL임
E_ACTIVITY_EMPTY | 0x800A | 액티비티 값이 NULL임
E_LOGGING_USER_ID_EMPTY | 0x800B | Analytics용 유저 ID값이 NULL임
E_MANIFEST_APPSTORE_MISSING | 0x800C | AndroidManifest.xml 메타 데이터중 com.nhnent.aflat.appstore 값이 존재하지 않음.
E_CAMPAIGN_SHOW_EXPIRED | 0x7000 | 만료기간이 지난 캠페인에 대해 요청함.
E_CAMPAIGN_SHOW_ALREADY | 0x7001 | 이미 표출되고 있는 캠페인 뷰를 show 요청하거나, 표출되거나 큐잉되지 않은 캠페인 뷰를 hide 요청함.
E_CAMPAIGN_SHOW_PENDING | 0x7002 | 이미 다른 캠페인 뷰가 표출되고 있어서 캠페인 뷰 show 요청이 큐잉됨..
E_CAMPAIGN_SHOW_FAIL | 0x7034 | 캠페인 뷰의 리소스중 일부를 로드할수 없음.
E_CAMPAIGN_SHOW_BLOCKED | 0x7004 | 캠페인 노출이 사용자에 의해 블록되었거나, 이미 실행이 완료된 캠페인임.
E_CAMPAIGN_NOTEXIST | 0x7005 | 캠페인이 존재하지 않음.
E_CAMPAIGN_DISABLED | 0x7006 | 디바이스에서 캠페인이 disable 됨
E_CAMPAIGN_USER_ID_IS_EMPTY | 0x7007 | 캠페인 실행용 유저ID값이 설정되지 않음.