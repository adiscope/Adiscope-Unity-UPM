//
//  AdiscopeInterface+RewarededInterstitial.h
//  Adiscope
//
//  Created by 심경보 on 2023/10/11.
//  Copyright © 2023 Neowiz-NPS-Adiscope. All rights reserved.
//

#import "Adiscope.h"

NS_ASSUME_NONNULL_BEGIN

@interface AdiscopeInterface (RewardedInterstitial)

- (void)preLoadAllRewardedInterstitial;
- (void)preLoadRewardedInterstitial:(NSArray *)unitIDs;
- (BOOL)showRewardedInterstitial:(NSString *)unitID;

- (BOOL)showRewardedInterstitial:(NSString *)unitID callback:(id<AdiscopeBridge4UnityDelegate>)delegate;

@end

NS_ASSUME_NONNULL_END
