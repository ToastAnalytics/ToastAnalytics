//
//  ViewController.m
//  ToastAnalyticsSample
//
//  Created by pivot on 2015. 2. 4..
//  Copyright (c) 2015년 NHNEnt. All rights reserved.
//

#import "ViewController.h"


@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view, typically from a nib.
    
    /*
     * 디버그 모드를 설정합니다.
     * true로 설정하면 콘솔에 로그가 출력됩니다. 또한 Webpage의 "웹 콘솔"에서 실시간 로그 확인이 가능합니다.
     * 출시 빌드에서는 반드시 false로 설정해야 합니다.
     */
    [TAGAnalytics setDebugModeEnabled:YES];
    
    
    /*
     * Campaign Delegator를 등록합니다.
     * 프로모션및 캠페인에서 callback을 받을 수 있습니다.
     */
    [TAGAnalytics setCampaignDelegate:self];
    
    
    /*
     * SDK를 초기화 합니다.
     * useLoggingUserId flag는 게임의 상황에 따라 사용하면 됩니다.
     * YES인 경우 사용자 기준이 게임에서 setUserId에서 제공하는 id입니다.
     * NO인 경우 사용자 기준이 IDFA입니다.
     * 각각의 특성이 있으니 게임에서 고려하여 결정하면 됩니다.
     * 단 YES를 사용하는 경우 setUserId를 이용하여 반드시 사용자 ID를 SDK에 전달해야 합니다.
     */
    [TAGAnalytics initializeSdk:@"APPID" companyId:@"COMPANY_ID" appVersion:@"APP_VER" useLoggingUserId:YES];
    
    
    /*
     * USERID를 설정합니다.
     * 이 함수는 로그인이 완료되어 사용자 ID를 가져올 수 있는 시점에 호출하면 됩니다.
     * USER_ID는 게임에서 사용하는 사용자 ID입니다. user id, member no, kakao id, facebook id 등 게임에서 사용자를 구분할때 사용하는 값을 이용하면 됩니다.
     * initializeSdk에서 useLoggingUserId를 YES로 설정하면 setUserId를 통해서 사용자 ID를 받는 시점에 로그 전송을 시작합니다.
     * initializeSdk에서 useLoggingUserId를 NO로 설정하더라도 프로모션을 사용하는 경우 setUserId를 호출해야 합니다.
     */
    [TAGAnalytics setUserId:@"USER_ID" useCampaignOrPromotion:YES];
    
    /*
     * Analytics 로그 전송을 시작합니다.
     */
    [TAGAnalytics traceActivation];
    
    [self appRunning];
}


- (void) appRunning {
    
    /*
     * 게임에서 적절한 상황에 맞게 trace* 함수들을 호출하면 됩니다.
     */
    [TAGAnalytics traceLevelUp:10];
    [TAGAnalytics traceEvent:@"EVENT_TYPE" eventCode:@"EVENT_CODE" param1:@"PARAM1" param2:@"PARAM2" value:10.0f level:10];
    [TAGAnalytics traceFriendCount:10];
    [TAGAnalytics traceMoneyAcquisition:@"USAGE_CODE" type:@"TYPE" acquisitionAmount:10.0f level:10];
    [TAGAnalytics traceMoneyConsumption:@"USAGE_CODE" type:@"TYPE" consumptionAmount:10.0f level:10];
    [TAGAnalytics tracePurchase:@"ITEM_CODE" payment:10.0f unitCost:10.0f currency:@"KRW" level:10];
    [TAGAnalytics traceStartSpeed:@"INTERVAL"];
    [TAGAnalytics traceEndSpeed:@"INTERVAL"];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}




# pragma mark - Camapaign Listener

-(void)analyticsDidMissionComplete:(NSArray*)missionList
{
    /*
     *  미션 정보가 있는 경우 이 Callback이 호출됩니다.
     *
     *  String은 MissionKey와 MissionValue로 구성되어 있습니다.
     *  '|'을 splitter로 가집니다.
     *
     *  여기서 받은 Key와 Value를 게임서버로 전송하고, 게임서버에서는 Promotion server의 check-mission API를 호출하여 보상 정보를 확인합니다.
     */
}

-(void)analyticsDidCampaignVisibilityChange:(NSString*)adspaceName show:(BOOL)show
{
    /*
     * 캠페인 팝업이나 배너가 화면에 보이고 닫힐때 호출됩니다.
     */
}

-(void)analyticsDidCampaignLoadSuccess:(NSString*)adspaceName
{
    /*
     * 디버깅용입니다.
     */
}

-(void)analyticsDidCampaignLoadFail:(NSString*)adspaceName errorCode:(int)errorCode errorMessage:(NSString*)errorMessage
{
    /*
     * 디버깅용입니다.
     */
}

-(void)analyticsDidPromotionVisibilityChange:(BOOL)show
{
    /*
     * iOS에서는 현재 사용하지 않습니다. Android이 인터페이스를 맞추기 위해 있습니다.
     */
}


@end
