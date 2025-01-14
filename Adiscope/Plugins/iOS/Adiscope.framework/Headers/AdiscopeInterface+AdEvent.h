//
//  AdiscopeInterface+AdEvent.h
//  Adiscope
//
//  Created by 심경보 on 8/23/24.
//  Copyright © 2024 Adiscope. All rights reserved.
//

#import "Adiscope.h"

NS_ASSUME_NONNULL_BEGIN

@interface AdiscopeInterface (AdEvent)

- (BOOL)showAdEvent:(NSString *)unitID;

- (BOOL)showAdEvent:(NSString *)unitID callback:(id<AdiscopeBridge4UnityDelegate>)delegate;

@end

NS_ASSUME_NONNULL_END
