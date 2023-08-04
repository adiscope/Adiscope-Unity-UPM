//
//  ISDemandOnlyBannerDelegate.h
//  IronSource
//
//  Created by Jonathan Benedek on 28/10/2021.
//  Copyright © 2021 IronSource. All rights reserved.
//

#ifndef IS_DEMAND_ONLY_BANNER_DELEGATE_H
#define IS_DEMAND_ONLY_BANNER_DELEGATE_H

#import "ISBannerView.h"

@protocol ISDemandOnlyBannerDelegate <NSObject>

@required
/**
 Called after a banner ad has been successfully loaded
 @param instanceId The demand only instance id to be used to display the banner.
 */
- (void)bannerDidLoad:(ISBannerView *)bannerView instanceId:(NSString *)instanceId;

/**
 Called after a banner has attempted to load an ad but failed.
 @param error The reason for the error
 @param instanceId The demand only instance id that fail to load.
 */
- (void)bannerDidFailToLoadWithError:(NSError *)error instanceId:(NSString *)instanceId;



/**
 Called when a banner was shown
 @param instanceId The demand only instance id which did show.

 */
- (void)bannerDidShow:(NSString *)instanceId;

/**
 Called after a banner has been clicked.
 @param instanceId The demand only instance id which clicked.

 */
- (void)didClickBanner:(NSString *)instanceId;


/**
 Called when a user would be taken out of the application context.
 @param instanceId The demand only instance id that taken out of the application.

 */
- (void)bannerWillLeaveApplication:(NSString *)instanceId;

/**
 Called when a banner is about to present a full screen content.
 @param instanceId The demand only instance id that present a full screen.

 */
- (void)bannerWillPresentScreen:(NSString *)instanceId;

/**
 Called after a full screen content has been dismissed.
 @param instanceId The demand only instance id that full screen content has been dismissed.

 */
- (void)bannerDidDismissScreen:(NSString *)instanceId;

@end

#endif /* IS_DEMAND_ONLY_BANNER_DELEGATE_H */
