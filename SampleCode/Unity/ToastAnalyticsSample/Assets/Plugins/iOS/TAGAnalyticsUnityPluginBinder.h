// Configuration
extern "C" char* _getVersion();
extern "C" char* _getResultString(int result);
extern "C" char* _getDeviceInfo(char* key);
extern "C" void _setDebugMode(bool enable);
extern "C" int _setUserId(char* userId, bool useCampaignOrPromotion);

// Analytics
extern "C" int _initializeSdk(char* appId, char* companyId, char* appVersion, bool useLoggingUserId);
extern "C" int _traceActivation();
extern "C" int _traceDeactivation();
extern "C" int _traceFriendCount(int friendCount);
extern "C" int _tracePurchase(char* itemCode, float payment, float unitCost, char* currency, int level);
extern "C" int _traceMoneyAcquisition(char* usageCode, char* type, double amount, int level);
extern "C" int _traceMoneyConsumption(char* usageCode, char* type, double amount, int level);
extern "C" int _traceLevelUp(int level);
extern "C" int _traceEvent(char* eventType, char* eventCode, char* param1, char* param2, double value, int level);
extern "C" int _traceStartSpeed(char* intervalName);
extern "C" int _traceEndSpeed(char* intervalName);

// Campaign
extern "C" int _showCampaign(char* adspaceName);
extern "C" int _showCampaignAnimation(char* adspaceName, int animation, int lifeTime);
extern "C" int _hideCampaign(char* adspaceName);
extern "C" int _hideCampaignAnimation(char* adspaceName, int animation);

extern "C" void _setOnCampaignListener(char* objectName);