#import "TAGAnalyticsUnityPluginBinder.h"
#import "TAGAnalytics.h"

#define IS_VALID_CSTRING( str ) ( (str) != NULL && strlen(str) > 0 )
#define CSTRING2NSSTRING( str ) ( ( IS_VALID_CSTRING( str ) == YES ) ? [NSString stringWithUTF8String:(str)] : nil )

// Log
#define LOG( s, ... ) NSLog( @"[%@:(%d)] %@", [[NSString stringWithUTF8String:__FILE__] lastPathComponent], __LINE__, [NSString stringWithFormat:(s), ##__VA_ARGS__] )


// Campaign Listener
@interface OnCampaignDelegator : NSObject<TAGCampaignDelegate>
@property (nonatomic, strong) NSString *unityObjectName;
@end

@implementation OnCampaignDelegator
-(void)analyticsDidMissionComplete:(NSArray*)missionList
{
    NSString *param = [missionList componentsJoinedByString:@"##"];
    UnitySendMessage(self.unityObjectName.UTF8String , "OnCampaignListener_OnMissionCompleted", param.UTF8String);
}

-(void)analyticsDidCampaignVisibilityChange:(NSString*)adspaceName show:(BOOL)show
{
    NSString *param = [NSString stringWithFormat:@"%@##%@", adspaceName, show==YES?@"true":@"false"];
    UnitySendMessage(self.unityObjectName.UTF8String , "OnCampaignListener_OnCampaignVisibilityChanged", param.UTF8String);
}

-(void)analyticsDidCampaignLoadSuccess:(NSString*)adspaceName
{
    UnitySendMessage([self.unityObjectName UTF8String], "OnCampaignListener_OnCampaignLoadSuccess", adspaceName.UTF8String);
}

-(void)analyticsDidCampaignLoadFail:(NSString*)adspaceName errorCode:(int)errorCode errorMessage:(NSString*)errorMessage
{
    NSString *param = [NSString stringWithFormat:@"%@##%d##%@", adspaceName, errorCode, errorMessage];
    UnitySendMessage(self.unityObjectName.UTF8String, "OnCampaignListener_OnCampaignLoadFail", param.UTF8String);
}
@end


char* AnalyticsMakeStringCopy(const char* string) {
    if (string == NULL)
        return NULL;
    char* res = (char*) malloc (strlen(string) + 1 );
    strcpy (res, string);
    return res;
}


// Configutraion
char* _getVersion()
{
    NSString *version = [TAGAnalytics version];
    return AnalyticsMakeStringCopy(version.UTF8String);
}

char* _getDeviceInfo(char* key)
{
    NSString *keyStr = CSTRING2NSSTRING(key);
    
    NSString *resultMessage = [TAGAnalytics deviceInfoWithKey:keyStr];
    return AnalyticsMakeStringCopy(resultMessage.UTF8String);
}

void _setDebugMode(bool enable)
{
    [TAGAnalytics setDebugModeEnabled:enable];
}

int _setUserId(char* userId, bool useCampaignOrPromotion)
{
    NSString *userIdStr = CSTRING2NSSTRING(userId);
    
    return [TAGAnalytics setUserId:userIdStr
            useCampaignOrPromotion:useCampaignOrPromotion];
}


// Analytics
int _initializeSdk(char* appId, char* companyId, char* appVersion, bool useLoggingUserId)
{
    NSString *appIdStr = CSTRING2NSSTRING(appId);
    NSString *companyIdStr = CSTRING2NSSTRING(companyId);
    NSString *appVersionStr = CSTRING2NSSTRING(appVersion);
    
    return [TAGAnalytics initializeSdk:appIdStr
                             companyId:companyIdStr
                            appVersion:appVersionStr
                      useLoggingUserId:useLoggingUserId];
}

int _traceActivation()
{
    return [TAGAnalytics traceActivation];
    
}

int _traceFriendCount(int friendCount)
{
    return [TAGAnalytics traceFriendCount:friendCount];
}

int _traceDeactivation()
{
    return [TAGAnalytics traceDeactivation];
    
}

int _tracePurchase(char* itemCode, float payment, float unitCost, char* currency, int level)
{
    NSString *itemCodeStr = CSTRING2NSSTRING(itemCode);
    NSString *currencyStr = CSTRING2NSSTRING(currency);
    
    return [TAGAnalytics tracePurchase:itemCodeStr
                               payment:payment
                              unitCost:unitCost
                              currency:currencyStr
                                 level:level];
}

int _traceMoneyAcquisition(char* usageCode, char* type, double amount, int level)
{
    NSString *usageCodeStr = CSTRING2NSSTRING(usageCode);
    NSString *typeStr = CSTRING2NSSTRING(type);
    
    return [TAGAnalytics traceMoneyAcquisition:usageCodeStr
                                          type:typeStr
                             acquisitionAmount:amount
                                         level:level];
    
}

int _traceMoneyConsumption(char* usageCode, char* type, double amount, int level)
{
    NSString *usageCodeStr = CSTRING2NSSTRING(usageCode);
    NSString *typeStr = CSTRING2NSSTRING(type);
    
    return [TAGAnalytics traceMoneyConsumption:usageCodeStr
                                          type:typeStr
                             consumptionAmount:amount
                                         level:level];
}

int _traceLevelUp(int level)
{
    return [TAGAnalytics traceLevelUp:level];
}

int _traceEvent(char* eventType, char* eventCode, char* param1, char* param2, double value, int level)
{
    NSString *eventTypeStr = CSTRING2NSSTRING(eventType);
    NSString *eventCodeStr = CSTRING2NSSTRING(eventCode);
    NSString *param1Str = CSTRING2NSSTRING(param1);
    NSString *param2Str = CSTRING2NSSTRING(param2);
    
    return [TAGAnalytics traceEvent:eventTypeStr
                          eventCode:eventCodeStr
                             param1:param1Str
                             param2:param2Str
                              value:value
                              level:level];
}

int _traceStartSpeed(char* intervalName)
{
    NSString *intervalNameStr = CSTRING2NSSTRING(intervalName);
    
    return [TAGAnalytics traceStartSpeed:intervalNameStr];
}

int _traceEndSpeed(char* intervalName)
{
    NSString *intervalNameStr = CSTRING2NSSTRING(intervalName);
    
    return [TAGAnalytics traceEndSpeed:intervalNameStr];
}


// Campaign
int _showCampaign(char* adspaceName)
{
    UIViewController* vc = UnityGetGLViewController();
    NSString *adspaceNameStr = CSTRING2NSSTRING(adspaceName);
    
    return [TAGAnalytics showCampaign:adspaceNameStr
                               parent:vc.view];
}

int _showCampaignAnimation(char* adspaceName, int animation, int lifeTime)
{
    UIViewController* vc = UnityGetGLViewController();
    NSString *adspaceNameStr = CSTRING2NSSTRING(adspaceName);
    
    return [TAGAnalytics showCampaign:adspaceNameStr
                               parent:vc.view
                            animation:animation
                             lifeTime:lifeTime];
}

int _hideCampaign(char* adspaceName)
{
    NSString *adspaceNameStr = CSTRING2NSSTRING(adspaceName);
    
    return [TAGAnalytics hideCampaign:adspaceNameStr];
}

int _hideCampaignAnimation(char* adspaceName, int animation)
{
    NSString *adspaceNameStr = CSTRING2NSSTRING(adspaceName);
    
    return [TAGAnalytics hideCampaign:adspaceNameStr
                            animation:animation];
}

void _setOnCampaignListener(char* objectName)
{
    OnCampaignDelegator* delegate = [[OnCampaignDelegator alloc] init];
    [delegate setUnityObjectName:[NSString stringWithUTF8String:objectName]];
    
    [TAGAnalytics setCampaignDelegate:delegate];
}
