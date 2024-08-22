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

#define AdiscopeAdapterVersion @"3.8.2"

@interface AdiscopeMediaMax : NSObject <Adapter, MARewardedAdDelegate, DTBAdCallback>

@end
