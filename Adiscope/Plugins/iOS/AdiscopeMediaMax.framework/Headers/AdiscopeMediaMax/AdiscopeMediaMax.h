//
//  AdiscopeMediaMax.h
//  AdiscopeMediaMax
//
//  Created by 심경보 on 2023/05/31.
//

#import <Foundation/Foundation.h>
#import <AppLovinSDK/AppLovinSDK.h>
#import <DTBiOSSDK/DTBiOSSDK.h>
#import "Adapter.h"

#define AdiscopeAdapterVersion @"3.9.0"

@interface AdiscopeMediaMax : NSObject <Adapter, MARewardedAdDelegate>

@end
