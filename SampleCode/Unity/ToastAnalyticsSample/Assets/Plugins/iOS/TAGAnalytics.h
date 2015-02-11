//
//  NEAFlatGame.h
//  NEAFlat
//
//  Created by NHNENT on 2014. 8. 6..
//  Copyright (c) 2014년 NHN Entertainments. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

#define DEVICE_INFO_DEVICEID            (@"deviceId")
#define DEVICE_INFO_TOKEN               (@"token")
#define DEVICE_INFO_CAMPAIGN_USERID     (@"campaignUserId")

#define ITEM_TYPE_1                     (@"0")
#define ITEM_TYPE_2                     (@"1")

#define ANIMATION_NONE                  (0)
#define ANIMATION_FADE                  (1)
#define ANIMATION_SLIDE                 (2)

/***********************
 * TAGCampaignDelegate
 **/
@protocol TAGCampaignDelegate <NSObject>
-(void)analyticsDidMissionComplete:(NSArray*)missionList;
-(void)analyticsDidCampaignVisibilityChange:(NSString*)adspaceName show:(BOOL)show;
-(void)analyticsDidCampaignLoadSuccess:(NSString*)adspaceName;
-(void)analyticsDidCampaignLoadFail:(NSString*)adspaceName errorCode:(int)errorCode errorMessage:(NSString*)errorMessage;
-(void)analyticsDidPromotionVisibilityChange:(BOOL)show;
@end

/***********************
 * TAGAnalytics
 **/
@interface TAGAnalytics : NSObject
+(int)initializeSdk:(NSString*)appId
          companyId:(NSString*)companyId
         appVersion:(NSString*)appVersion
   useLoggingUserId:(BOOL)useLoggingUserId;

+(NSString*)resultStringFromCode:(int)resultCode;
+(NSString*)deviceInfoWithKey:(NSString*)key;
+(NSString*)version;
+(void)setDebugModeEnabled:(BOOL)enabled;
+(int)setPushData:(NSDictionary*)userInfo;
//+(int)setLoggingUserId:(NSString*)userId;

//-- analytics
+(int)tracePushToken:(NSData *)deviceToken;
+(int)traceActivation;
+(int)traceDeactivation;
+(int)traceFriendCount:(int)friendCount;
+(int)tracePurchase:(NSString*)itemCode payment:(float)payment unitCost:(float)unitCost currency:(NSString*)currency level:(int)level;
+(int)traceMoneyAcquisition:(NSString*)usageCode type:(NSString*)type acquisitionAmount:(double)acquisitionAmount level:(int)level;
+(int)traceMoneyConsumption:(NSString*)usageCode type:(NSString*)type consumptionAmount:(double)consumptionAmount level:(int)level;
+(int)traceLevelUp:(int)level;
+(int)traceEvent:(NSString*)eventType eventCode:(NSString*)eventCode param1:(NSString*)param1 param2:(NSString*)param2 value:(double)value level:(int)level;
+(int)traceStartSpeed:(NSString*)intervalName;
+(int)traceEndSpeed:(NSString*)intervalName;

//-- campaign
+(int)showCampaign:(NSString*)adspaceName parent:(UIView*)parent;
+(int)showCampaign:(NSString*)adspaceName parent:(UIView*)parent animation:(int)animation lifeTime:(int)lifeTime;
+(int)hideCampaign:(NSString*)adspaceName;
+(int)hideCampaign:(NSString*)adspaceName animation:(int)animation;

+(void)setCampaignDelegate:(id<TAGCampaignDelegate>)campaignDelegate;
//+(int)setCampaignUserId:(NSString*)userId;
+(int)setUserId:(NSString*)userId useCampaignOrPromotion:(BOOL)useCampaignOrPromotion;

@end
