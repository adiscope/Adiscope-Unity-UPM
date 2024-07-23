//
//  Copyright © 2020 Ogury Ltd. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "OguryOptinVideoAdDelegate.h"
#import "OguryMediation.h"

NS_ASSUME_NONNULL_BEGIN

@interface OguryOptinVideoAd : NSObject

@property(nonatomic, weak, nullable) id<OguryOptinVideoAdDelegate> delegate;
@property(nonatomic, strong, readonly) NSString *adUnitId;
@property(nonatomic, strong, nullable) NSString *userId;

- (instancetype)initWithAdUnitId:(NSString *)adUnitId;
- (instancetype)initWithAdUnitId:(NSString *)adUnitId mediation:(OguryMediation *_Nonnull)mediation;

- (void)load;

- (void)loadWithAdMarkup:(NSString *)adMarkup;

- (BOOL)isLoaded;

- (void)showAdInViewController:(UIViewController *)viewController;

@end

NS_ASSUME_NONNULL_END
