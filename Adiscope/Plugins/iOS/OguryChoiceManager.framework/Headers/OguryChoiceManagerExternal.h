//
//  Copyright © 2020-present Ogury Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface OguryChoiceManagerExternal : NSObject

/*!
* @brief Pass TFC V2 consent to Ogury
* @discussion To pass consent status to Ogury, call this method after the consent has been collected
* @param assetKey the Asset Key of your application
* @param iabString the iabString IAB-specified Consent String generated by third-party CMP to transmit the consent of the vendors that are registered inside the IAB Vendor list.
* @param nonIABVendorsAccepted an NSNumber Array containing the Integer ID value of accepted vendors you need that are not registered in the IAB Vendor list. The ID corresponding to a vendor can be found inside our vendor list.
*/
+ (void)setConsentForTCFV2WithAssetKey:(NSString * _Nonnull)assetKey 
                             iabString:(NSString * _Nonnull)iabString
              andNonIABVendorsAccepted:(NSArray<NSNumber*> * _Nullable)nonIABVendorsAccepted;

+ (void)setTransparencyAndConsentStatus:(BOOL)status origin:(nonnull NSString *)origin assetKey:(NSString *)assetKey __deprecated_msg("setTransparencyAndConsentStatus is deprecated, and Ogury no longer provides support to manage this behavior. \nPlease use a Consent Management Platform (CMP) that is compatible with TCFv2 to manage and generate user consents. \nYou can then use OguryChoiceManagerExternal().setConsentForTCFV2WithAssetKey(...) to register yout TCFV2 consent");

@end

NS_ASSUME_NONNULL_END
