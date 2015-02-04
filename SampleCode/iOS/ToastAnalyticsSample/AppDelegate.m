//
//  AppDelegate.m
//  ToastAnalyticsSample
//
//  Created by pivot on 2015. 2. 4..
//  Copyright (c) 2015년 NHNEnt. All rights reserved.
//

#import "AppDelegate.h"
#import "TAGAnalytics.h"

@interface AppDelegate ()

@end

@implementation AppDelegate


- (BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions {
    
    /*
     * InitializeSDK를 앱이 시작하는 시점에 호출해도 됩니다.
     * 혹은 Game의 MainViewController가 시작하는 시점에 호출해도 됩니다.
     * 게임의 상황에 맞게 적절한 타이밍에 호출합니다.
     * 샘플앱에서는 MainViewController에서 호출합니다.
     * Unity나 Cocos2dx를 이용하여 개발하는 게임에서도 일반적으로 Unity Code에서 InitializeSDK를 호출하기 때문에 MainViewController에서 호출됩니다.
     */
    return YES;
}

- (void)applicationWillResignActive:(UIApplication *)application {
}

- (void)applicationDidBecomeActive:(UIApplication *)application {
}

- (void)applicationWillTerminate:(UIApplication *)application {
}


// 앱이 Background로 가는 경우 traceDeactivation을 호출하여 로그 수집을 멈춥니다.
- (void)applicationDidEnterBackground:(UIApplication *)application {
    int result = [TAGAnalytics traceDeactivation];
    NSLog(@">> traceDeactivation : %@", [TAGAnalytics resultStringFromCode:result]);
}

// 앱이 Foreground로 가는 경우 traceActivation을 호출하여 로그 수집을 시작합니다.
- (void)applicationWillEnterForeground:(UIApplication *)application {
    int result = [TAGAnalytics traceActivation];
    NSLog(@">> traceActivation : %@", [TAGAnalytics resultStringFromCode:result]);
}

@end
