//
//  NEAFlat.h
//  NEAFlat
//
//  Created by NHNENT on 2014. 7. 24..
//  Copyright (c) 2014년 NHN Entertainments. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface NEAFlat : NSObject

+(int)initializeSdk:(NSString*)appId enterprizeId:(NSString*)entId appVersion:(NSString*)appVersion;
+(int)traceStart;
+(int)traceFinish;
+(int)traceActivate;
+(int)traceDeactivate;
+(int)traceAction:(NSDictionary*)mapParams;

+(NSString*)getResultString:(int)result;
+(void)setDebugMode:(BOOL)enable;

@end
