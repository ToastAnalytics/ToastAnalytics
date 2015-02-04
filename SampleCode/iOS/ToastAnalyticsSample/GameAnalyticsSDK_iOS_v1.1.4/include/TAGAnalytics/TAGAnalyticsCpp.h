//
//  NEAFlatCpp.h
//  NEAFlat
//
//  Created by NHNENT on 2014. 8. 12..
//  Copyright (c) 2014년 NHN Entertainments. All rights reserved.
//

#ifndef NEAFlat_NEAFlatCpp_h
#define NEAFlat_NEAFlatCpp_h

#include <string>

#define DEVICE_INFO_DEVICEID_STR        ("deviceId")
#define DEVICE_INFO_TOKEN_STR           ("token")
#define DEVICE_INFO_CAMPAIGN_USERID_STR ("campaignUserId")

#define ITEM_TYPE_1_STR                 ("0")
#define ITEM_TYPE_2_STR                 ("1")

#define ANIMATION_NONE                  (0)
#define ANIMATION_FADE                  (1)
#define ANIMATION_SLIDE                 (2)

typedef void (*OnMissionComplete)(const char** missionList, int count);
typedef void (*OnCampaignVisibilityChanged)(const char* adspaceName, bool show);
typedef void (*OnCampaignLoadSuccess)(const char* adspaceName);
typedef void (*OnCampaignLoadFail)(const char* adspaceName, int errorCode, const char* errorMessage);
typedef void (*OnPromotionVisibilityChanged)(bool show);

typedef struct _NECampaignListener {
    OnMissionComplete onMissionComplete;
    OnCampaignVisibilityChanged onCampaignVisibilityChanged;
    OnCampaignLoadSuccess onCampaignLoadSuccess;
    OnCampaignLoadFail onCampaignLoadFail;
    OnPromotionVisibilityChanged onPromotionVisibilityChanged;
} NECampaignListener;

/***********************
 * NEAFlatGameCpp
 **/
namespace toast
{
    namespace analytics {
    std::string getResultString(int result);
    std::string getDeviceInfo(std::string key);
    void setDebugMode(bool enable);
    
    int traceFriendCount(int friendCount);
    int tracePurchase(std::string itemCode, float payment, float unitCost, std::string currency, int level);
    int traceMoneyAcquisition(std::string usageCode, std::string type, double acquisitionAmount, int level);
    int traceMoneyConsumption(std::string usageCode, std::string type, double consumptionAmount, int level);
    int traceLevelUp(int level);
    int traceEvent(std::string eventType, std::string eventCode, std::string param1, std::string param2, double value, int level);
    int traceStartSpeed(std::string intervalName);
    int traceEndSpeed(std::string intervalName);
    
    int showCampaign(std::string adspaceName);
    int showCampaign(std::string adspaceName, int animation, int lifeTime);
    int hideCampaign(std::string adspaceName);
    int hideCampaign(std::string adspaceName, int animation);

    void setCampaignDelegate(NECampaignListener* lister);
    int setUserId(std::string userId, bool useCampaignOrPromotion);
    }
}

#endif
