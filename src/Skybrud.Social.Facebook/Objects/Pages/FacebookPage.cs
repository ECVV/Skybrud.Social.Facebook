using System;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Time;
using Skybrud.Social.Facebook.Enums.Pages;
using Skybrud.Social.Facebook.Objects.Common;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Facebook.Objects.Pages {

    /// <summary>
    /// Class representing a Facebook page.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.8/page#Reading</cref>
    /// </see>
    public class FacebookPage : FacebookObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the page.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets information about the page.
        /// </summary>
        public string About { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="About"/> property was included in the response and has a value.
        /// </summary>
        public bool HasAbout {
            get { return !String.IsNullOrWhiteSpace(About); }
        }

        /// <summary>
        /// Gets or sets the access token you can use to act as the Page. Only visible to Page Admins. If your business requires two-factor authentication, and the person hasn't authenticated, this field may not be returned.
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="AccessToken"/> property was included in the response and has a value.
        /// </summary>
        public bool HasAccessToken {
            get { return !String.IsNullOrWhiteSpace(AccessToken); }
        }

        // TODO: Add support for the "ad_campaign" field

        /// <summary>
        /// Gets the affiliation of this person. Applicable to pages representing people.
        /// </summary>
        public string Affiliation { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Affiliation"/> property was included in the response and has a value.
        /// </summary>
        public bool HasAffiliation {
            get { return !String.IsNullOrWhiteSpace(Affiliation); }
        }

        // TODO: Add support for the "app_id" field (applies to app-owned pages)

        // TODO: Add support for the "app_links" field (applies to app-owned pages)

        /// <summary>
        /// Gets a list of artists the band likes. Applicable to <strong>Bands</strong>.
        /// </summary>
        public string ArtistsWeLike { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="ArtistsWeLike"/> property was included in the response and has a value.
        /// </summary>
        public bool HasArtistsWeLike {
            get { return !String.IsNullOrWhiteSpace(ArtistsWeLike); }
        }

        /// <summary>
        /// Gets the dress code of the business. Applicable to <strong>Restaurants</strong> or
        /// <strong>Nightlife</strong>. Can be one of <see cref="FacebookAttire.Casual"/>,
        /// <see cref="FacebookAttire.Dressy"/> or <see cref="FacebookAttire.Unspecified"/>.
        /// </summary>
        public FacebookAttire Attire { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Attire"/> property was included in the response and has a value.
        /// </summary>
        public bool HasAttire {
            get { return Attire != FacebookAttire.Unspecified; }
        }

        /// <summary>
        /// Gets the awards information of the film. Applicable to <strong>Films</strong>.
        /// </summary>
        public string Awards { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Awards"/> property was included in the response and has a value.
        /// </summary>
        public bool HasAwards {
            get { return !String.IsNullOrWhiteSpace(Awards); }
        }

        /// <summary>
        /// Gets the interests of the band.
        /// </summary>
        public string BandInterests { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="BandInterests"/> property was included in the response and has a value.
        /// </summary>
        public bool HasBandInterests {
            get { return !String.IsNullOrWhiteSpace(BandInterests); }
        }

        /// <summary>
        /// Gets the members of the band.
        /// </summary>
        public string BandMembers { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="BandMembers"/> property was included in the response and has a value.
        /// </summary>
        public bool HasBandMembers {
            get { return !String.IsNullOrWhiteSpace(BandMembers); }
        }

        // TODO: Add support for the "best_page" field

        /// <summary>
        /// Gets the biography of the band. Applicable to <strong>Bands</strong>.
        /// </summary>
        public string Bio { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Bio"/> property was included in the response and has a value.
        /// </summary>
        public bool HasBio {
            get { return !String.IsNullOrWhiteSpace(Bio); }
        }

        /// <summary>
        /// Gets the birthday of this person. Applicable to pages representing people.
        /// </summary>
        public EssentialsDateTime Birthday { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Birthday"/> property was included in the response and has a value.
        /// </summary>
        public bool HasBirthday {
            get { return Birthday != null; }
        }

        /// <summary>
        /// Gets the booking agent of the band. Applicable to <strong>Bands</strong>.
        /// </summary>
        public string BookingAgent { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="BookingAgent"/> property was included in the response and has a value.
        /// </summary>
        public bool HasBookingAgent {
            get { return !String.IsNullOrWhiteSpace(BookingAgent); }
        }

        /// <summary>
        /// Gets the year the vehicle was built. Applicable to <strong>Vehicles</strong>.
        /// </summary>
        public string Built { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Built"/> property was included in the response and has a value.
        /// </summary>
        public bool HasBuilt {
            get { return !String.IsNullOrWhiteSpace(Built); }
        }

        // TODO: Add support for the "business" field

        /// <summary>
        /// Gets whether this page has checkin functionality enabled.
        /// </summary>
        public bool CanCheckin { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="CanCheckin"/> property was included in the response.
        /// </summary>
        public bool HasCanCheckin {
            get { return JObject.HasValue("can_checkin"); }
        }

        /// <summary>
        /// Gets whether the authenticated user can post to the page.
        /// </summary>
        public bool CanPost { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="CanPost"/> property was included in the response.
        /// </summary>
        public bool HasCanPost {
            get { return JObject.HasValue("can_post"); }
        }

        /// <summary>
        /// Gets the main category of the page.
        /// </summary>
        public string Category { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Category"/> property was included in the response and has a value.
        /// </summary>
        public bool HasCategory {
            get { return !String.IsNullOrWhiteSpace(Category); }
        }

        /// <summary>
        /// Gets a list of all sub categories.
        /// </summary>
        public FacebookPageCategory[] CategoryList { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="CategoryList"/> property was included in the response and has a value.
        /// </summary>
        public bool HasCategoryList {
            get { return CategoryList.Length > 0; }
        }

        /// <summary>
        /// Gets the number of checkins at a place represented by the page.
        /// </summary>
        public int Checkins { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Checkins"/> property was included in the response.
        /// </summary>
        public bool HasCheckins {
            get { return JObject.HasValue("checkins"); }
        }

        /// <summary>
        /// Gets the company overview. Applicable to <strong>Companies</strong>.
        /// </summary>
        public string CompanyOverview { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="CompanyOverview"/> property was included in the response and has a value.
        /// </summary>
        public bool HasCompanyOverview {
            get { return !String.IsNullOrWhiteSpace(CompanyOverview); }
        }
        
        // TODO: Add support for the "contact_address" field
        
        // TODO: Add support for the "context" field
        
        // TODO: Add support for the "country_page_likes" field

        /// <summary>
        /// Gets information about the cover photo of the page.
        /// </summary>
        public FacebookCoverPhoto Cover { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Cover"/> property was included in the response.
        /// </summary>
        public bool HasCover {
            get { return Cover != null; }
        }

        /// <summary>
        /// Gets the culinary team of the business. Applicable to <strong>Restaurants</strong> or <strong>Nightlife</strong>.
        /// </summary>
        public string CulinaryTeam { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="CulinaryTeam"/> property was included in the response and has a value.
        /// </summary>
        public bool HasCulinaryTeam {
            get { return !String.IsNullOrWhiteSpace(CulinaryTeam); }
        }

        /// <summary>
        /// Gets the current location of the page.
        /// </summary>
        public string CurrentLocation { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="CurrentLocation"/> property was included in the response and has a value.
        /// </summary>
        public bool HasCurrentLocation {
            get { return !String.IsNullOrWhiteSpace(CurrentLocation); }
        }

        /// <summary>
        /// Gets the description of the page.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Description"/> property was included in the response and has a value.
        /// </summary>
        public bool HasDescription {
            get { return !String.IsNullOrWhiteSpace(Description); }
        }

        /// <summary>
        /// Gets the description of the page in raw HTML.
        /// </summary>
        public string DescriptionHtml { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="CompanyOverview"/> property was included in the response and has a value.
        /// </summary>
        public bool HasDescriptionHtml {
            get { return !String.IsNullOrWhiteSpace(DescriptionHtml); }
        }

        /// <summary>
        /// Gets the director of the film. Applicable to <strong>Films</strong>.
        /// </summary>
        public string DirectedBy { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="DirectedBy"/> property was included in the response and has a value.
        /// </summary>
        public bool HasDirectedBy {
            get { return !String.IsNullOrWhiteSpace(DirectedBy); }
        }
        
        // TODO: Add support for the "display_subtext" field
        
        // TODO: Add support for the "displayed_message_response_time" field

        /// <summary>
        /// Gets an array with the emails listed in the about section of the page.
        /// </summary>
        public string[] Emails { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Emails"/> property was included in the response and has a value.
        /// </summary>
        public bool HasEmails {
            get { return Emails.Any(); }
        }
        
        // TODO: Add support for the "engagement" field

        /// <summary>
        /// Gets the number of users who like the page. For <strong>Global Pages</strong> this is the count for all pages across the brand.
        /// </summary>
        public int FanCount { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="FanCount"/> property was included in the response.
        /// </summary>
        public bool HasFanCount {
            get { return JObject.HasValue("fan_count"); }
        }

        // TODO: Add support for the "fan_count" field
        
        // TODO: Add support for the "featured_video" field

        /// <summary>
        /// Gets an array with the features of the vehicle. Applicable to <strong>Vehicles</strong>.
        /// </summary>
        public string Features { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Features"/> property was included in the response and has a value.
        /// </summary>
        public bool HasFeatures {
            get { return !String.IsNullOrWhiteSpace(Features); }
        }

        /// <summary>
        /// Gets the restaurant's food styles. Applicable to <strong>Restaurants</strong>.
        /// </summary>
        public string[] FoodStyles { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="FoodStyles"/> property was included in the response and has a value.
        /// </summary>
        public bool HasFoodStyles {
            get { return FoodStyles.Any(); }
        }

        /// <summary>
        /// Gets when the company was founded. Applicable to <strong>Companies</strong>.
        /// </summary>
        public string Founded { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Founded"/> property was included in the response and has a value.
        /// </summary>
        public bool HasFounded {
            get { return !String.IsNullOrWhiteSpace(Founded); }
        }

        /// <summary>
        /// General information provided by the page.
        /// </summary>
        public string GeneralInfo { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="GeneralInfo"/> property was included in the response and has a value.
        /// </summary>
        public bool HasGeneralInfo {
            get { return !String.IsNullOrWhiteSpace(GeneralInfo); }
        }

        /// <summary>
        /// Gets the general manager of the business. Applicable to <strong>Restaurants</strong> or
        /// <strong>Nightlife</strong>.
        /// </summary>
        public string GeneralManager { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="GeneralManager"/> property was included in the response and has a value.
        /// </summary>
        public bool HasGeneralManager {
            get { return !String.IsNullOrWhiteSpace(GeneralManager); }
        }

        /// <summary>
        /// Gets the genre of the film. Applicable to <strong>Films</strong>.
        /// </summary>
        public string Genre { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Genre"/> property was included in the response and has a value.
        /// </summary>
        public bool HasGenre {
            get { return !String.IsNullOrWhiteSpace(Genre); }
        }

        // TODO: Add support for the "global_brand_page_name" field
        
        // TODO: Add support for the "global_brand_root_id" field
        
        // TODO: Add support for the "has_added_app" field

        /// <summary>
        /// Gets the hometown of the band. Applicable to <strong>Bands</strong>.
        /// </summary>
        public string Hometown { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Hometown"/> property was included in the response and has a value.
        /// </summary>
        public bool HasHometown {
            get { return !String.IsNullOrWhiteSpace(Hometown); }
        }

        /// <summary>
        /// Gets the opening hours for the page.
        /// </summary>
        public FacebookPageOpeningHours Hours { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Hours"/> property was included in the response.
        /// </summary>
        public bool HasHours {
            get { return Hours != null; }
        }

        /// <summary>
        /// Gets the legal information about the page publishers.
        /// </summary>
        public string Impressum { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Impressum"/> property was included in the response and has a value.
        /// </summary>
        public bool HasImpressum {
            get { return !String.IsNullOrWhiteSpace(Impressum); }
        }

        /// <summary>
        /// Gets the influences on the band. Applicable to <strong>Bands</strong>.
        /// </summary>
        public string Influences { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Influences"/> property was included in the response and has a value.
        /// </summary>
        public bool HasInfluences {
            get { return !String.IsNullOrWhiteSpace(Influences); }
        }

        // TODO: Add support for the "instant_articles_review_status" field

        /// <summary>
        /// Gets whether this location is always open.
        /// </summary>
        public bool IsAlwaysOpen { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="IsAlwaysOpen"/> property was included in the response.
        /// </summary>
        public bool HasIsAlwaysOpen {
            get { return JObject.HasValue("is_always_open"); }
        }

        /// <summary>
        /// Gets whether the page is a community page.
        /// </summary>
        public bool IsCommunityPage { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="IsCommunityPage"/> property was included in the response.
        /// </summary>
        public bool HasIsCommunityPage {
            get { return JObject.HasValue("is_community_page"); }
        }

        /// <summary>
        /// For businesses that are no longer operating.
        /// </summary>
        public bool IsPermantlyClosed { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="IsPermantlyClosed"/> property was included in the response.
        /// </summary>
        public bool HasIsPermantlyClosed {
            get { return JObject.HasValue("is_permanently_closed"); }
        }

        /// <summary>
        /// Gets whether the page is published and visible to non-admins.
        /// </summary>
        public bool IsPublished { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="IsPublished"/> property was included in the response.
        /// </summary>
        public bool HasIsPublished {
            get { return JObject.HasValue("is_published"); }
        }

        /// <summary>
        /// Gets whether the page is unclaimed.
        /// </summary>
        public bool IsUnclaimed { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="IsUnclaimed"/> property was included in the response.
        /// </summary>
        public bool HasIsUnclaimed {
            get { return JObject.HasValue("is_unclaimed"); }
        }

        /// <summary>
        /// Pages with a large number of followers can be manually verified by Facebook as having an authentic
        /// identity. This property indicates whether the page is verified by this process.
        /// </summary>
        public bool IsVerified { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="IsVerified"/> property was included in the response.
        /// </summary>
        public bool HasIsVerified {
            get { return JObject.HasValue("is_verified"); }
        }
        
        // TODO: Add support for the "is_webhooks_subscribed" field
        
        // TODO: Add support for the "leadgen_form_preview_details" field
        
        // TODO: Add support for the "leadgen_tos_acceptance_time" field
        
        // TODO: Add support for the "leadgen_tos_accepted" field
        
        // TODO: Add support for the "leadgen_tos_accepting_user" field

        /// <summary>
        /// Gets the Facebook URL of the page.
        /// </summary>
        public string Link { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Link"/> property was included in the response and has a value.
        /// </summary>
        public bool HasLink {
            get { return !String.IsNullOrWhiteSpace(Link); }
        }

        /// <summary>
        /// Gets the location of the place. Applicable to all <strong>Places</strong>.
        /// </summary>
        public FacebookLocation Location { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Location"/> property was included in the response and has a value.
        /// </summary>
        public bool HasLocation {
            get { return Location != null; }
        }

        /// <summary>
        /// Gets the members of this org. Applicable to pages representing <strong>Team Orgs</strong>.
        /// </summary>
        public string Members { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Members"/> property was included in the response and has a value.
        /// </summary>
        public bool HasMembers {
            get { return !String.IsNullOrWhiteSpace(Members); }
        }

        // TODO: Add support for the "merchant_id" field
        
        // TODO: Add support for the "merchant_review_status" field

        /// <summary>
        /// Gets the company mission. Applicable to <strong>Companies</strong>.
        /// </summary>
        public string Mission { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Mission"/> property was included in the response and has a value.
        /// </summary>
        public bool HasMission {
            get { return !String.IsNullOrWhiteSpace(Mission); }
        }

        /// <summary>
        /// Gets the MPG of the vehicle. Applicable to <strong>Vehicles</strong>.
        /// </summary>
        public string Mpg { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Mpg"/> property was included in the response and has a value.
        /// </summary>
        public bool HasMpg {
            get { return !String.IsNullOrWhiteSpace(Mpg); }
        }

        /// <summary>
        /// Gets the name of the page.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Name"/> property was included in the response.
        /// </summary>
        public bool HasName {
            get { return !String.IsNullOrWhiteSpace(Name); }
        }

        /// <summary>
        /// Gets the name of the page with its location and/or global brand descriptor.
        /// </summary>
        public string NameWithLocationDescriptor { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="NameWithLocationDescriptor"/> property was included in the response and has a value.
        /// </summary>
        public bool HasNameWithLocationDescriptor {
            get { return !String.IsNullOrWhiteSpace(NameWithLocationDescriptor); }
        }

        /// <summary>
        /// Gets the TV network for the TV show. Applicable to <strong>TV Shows</strong>.
        /// </summary>
        public string Network { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Network"/> property was included in the response and has a value.
        /// </summary>
        public bool HasNetwork {
            get { return !String.IsNullOrWhiteSpace(Network); }
        }

        /// <summary>
        /// Gets the number of people who have liked the page, since the last login. Only visible to a page admin.
        /// </summary>
        public int NewLikeCount { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="NewLikeCount"/> property was included in the response.
        /// </summary>
        public bool HasNewLikeCount {
            get { return JObject.HasValue("new_like_count"); }
        }
        
        // TODO: Add support for the "offer_eligible" field

        /// <summary>
        /// Gets the Overall page rating based on rating survey from users on a scale of 1-5. This value is normalized
        /// and is not guaranteed to be a strict average of user ratings.
        /// </summary>
        public float OverallStarRating { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="NewLikeCount"/> property was included in the response.
        /// </summary>
        public bool HasOverallStarRating {
            get { return JObject.HasValue("overall_star_rating"); }
        }

        /// <summary>
        /// Gets the parent page for this page.
        /// </summary>
        public FacebookPage ParentPage { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="ParentPage"/> property was included in the response.
        /// </summary>
        public bool HasParentPage {
            get { return ParentPage != null; }
        }

        /// <summary>
        /// Gets information about the parking available at a place.
        /// </summary>
        public FacebookPageParking Parking { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Parking"/> property was included in the response.
        /// </summary>
        public bool HasParking {
            get { return Parking != null; }
        }

        /// <summary>
        /// Gets information about the available payment options at a place.
        /// </summary>
        public FacebookPagePaymentOptions PaymentOptions { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="PaymentOptions"/> property was included in the response.
        /// </summary>
        public bool HasPaymentOptions {
            get { return PaymentOptions != null; }
        }

        /// <summary>
        /// Gets the personal information. Applicable to pages representing people.
        /// </summary>
        public string PersonalInfo { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="PersonalInfo"/> property was included in the response and has a value.
        /// </summary>
        public bool HasPersonalInfo {
            get { return !String.IsNullOrWhiteSpace(PersonalInfo); }
        }

        /// <summary>
        /// Gets the personal interests. Applicable to pages representing people.
        /// </summary>
        public string PersonalInterests { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="PersonalInterests"/> property was included in the response and has a value.
        /// </summary>
        public bool HasPersonalInterests {
            get { return !String.IsNullOrWhiteSpace(PersonalInterests); }
        }

        /// <summary>
        /// Gets pharmacy safety information. Applicable to pharmaceutical companies.
        /// </summary>
        public string PharmaSafetyInfo { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="PharmaSafetyInfo"/> property was included in the response and has a value.
        /// </summary>
        public bool HasPharmaSafetyInfo {
            get { return !String.IsNullOrWhiteSpace(PharmaSafetyInfo); }
        }

        /// <summary>
        /// Gets the phone number provided by a page.
        /// </summary>
        public string Phone { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Phone"/> property was included in the response and has a value.
        /// </summary>
        public bool HasPhone {
            get { return !String.IsNullOrWhiteSpace(Phone); }
        }

        /// <summary>
        /// For places, the category of the place.
        /// </summary>
        public string PlaceType { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="PlaceType"/> property was included in the response and has a value.
        /// </summary>
        public bool HasPlaceType {
            get { return !String.IsNullOrWhiteSpace(PlaceType); }
        }

        /// <summary>
        /// Gets the plot outline of the film. Applicable to <strong>Films</strong>.
        /// </summary>
        public string PlotOutline { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="PlotOutline"/> property was included in the response and has a value.
        /// </summary>
        public bool HasPlotOutline {
            get { return !String.IsNullOrWhiteSpace(PlotOutline); }
        }

        // TODO: Add support for the "preferred_audience" field

        /// <summary>
        /// Gets the press contact information of the band. Applicable to <strong>Bands</strong>.
        /// </summary>
        public string PressContact { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="PressContact"/> property was included in the response and has a value.
        /// </summary>
        public bool HasPressContact {
            get { return !String.IsNullOrWhiteSpace(PressContact); }
        }

        /// <summary>
        /// Price range of the business. Applicable to <strong>Restaurants</strong> or
        /// <strong>Nightlife</strong>.
        /// </summary>
        public string PriceRange { get; private set; }

        /// <summary>
        /// Gets the productor of the film. Applicable to <strong>Films</strong>.
        /// </summary>
        public string ProducedBy { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="ProducedBy"/> property was included in the response and has a value.
        /// </summary>
        public bool HasProducedBy {
            get { return !String.IsNullOrWhiteSpace(ProducedBy); }
        }

        /// <summary>
        /// Gets the products of this company. Applicable to <strong>Companies</strong>.
        /// </summary>
        public string Products { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Products"/> property was included in the response and has a value.
        /// </summary>
        public bool HasProducts {
            get { return !String.IsNullOrWhiteSpace(Products); }
        }

        /// <summary>
        /// Gets whether the page is eligible for promotion.
        /// </summary>
        public bool PromotionEligible { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="PromotionEligible"/> property was included in the response.
        /// </summary>
        public bool HasPromotionEligible {
            get { return JObject.HasValue("promotion_eligible"); }
        }

        /// <summary>
        /// Gets the reason, for which boosted posts are not eligible. Only visible to a page admin.
        /// </summary>
        public string PromotionIneligibleReason { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="PromotionIneligibleReason"/> property was included in the response and has a value.
        /// </summary>
        public bool HasPromotionIneligibleReason {
            get { return !String.IsNullOrWhiteSpace(PromotionIneligibleReason); }
        }

        /// <summary>
        /// Gets information about public transit to the business. Applicable to <strong>Restaurants</strong> or <strong>Nightlife</strong>.
        /// </summary>
        public string PublicTransit { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="PublicTransit"/> property was included in the response and has a value.
        /// </summary>
        public bool HasPublicTransit {
            get { return !String.IsNullOrWhiteSpace(PublicTransit); }
        }
        
        // TODO: Add support for the "publisher_space" field

        /// <summary>
        /// Gets the number of ratings for the page.
        /// </summary>
        public int RatingCount { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="RatingCount"/> property was included in the response.
        /// </summary>
        public bool HasRatingCount {
            get { return JObject.HasValue("rating_count"); }
        }

        // TODO: Add support for the "recipient" field

        /// <summary>
        /// Gets the record label of the band. Applicable to <strong>Bands</strong>.
        /// </summary>
        public string RecordLabel { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="RecordLabel"/> property was included in the response and has a value.
        /// </summary>
        public bool HasRecordLabel {
            get { return !String.IsNullOrWhiteSpace(RecordLabel); }
        }

        /// <summary>
        /// Gets the film's release date. Applicable to <strong>Films</strong>.
        /// </summary>
        public string ReleaseDate { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="ReleaseDate"/> property was included in the response and has a value.
        /// </summary>
        public bool HasReleaseDate {
            get { return !String.IsNullOrWhiteSpace(ReleaseDate); }
        }

        /// <summary>
        /// Services the restaurant provides. Applicable to <strong>Restaurants</strong>.
        /// </summary>
        public FacebookPageRestaurantServices RestaurantServices { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="RestaurantServices"/> property was included in the response.
        /// </summary>
        public bool HasRestaurantServices {
            get { return RestaurantServices != null; }
        }

        /// <summary>
        /// The restaurant's specialties. Applicable to <strong>Restaurants</strong>.
        /// </summary>
        public FacebookPageRestaurantSpecialties RestaurantSpecialties { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="RestaurantSpecialties"/> property was included in the response.
        /// </summary>
        public bool HasRestaurantSpecialties {
            get { return RestaurantSpecialties != null; }
        }

        /// <summary>
        /// Gets the air schedule of the TV show. Applicable to <strong>TV Shows</strong>.
        /// </summary>
        public string Schedule { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Schedule"/> property was included in the response and has a value.
        /// </summary>
        public bool HasSchedule {
            get { return !String.IsNullOrWhiteSpace(Schedule); }
        }

        /// <summary>
        /// Gets the screenwriter of the film. Applicable to <strong>Films</strong>.
        /// </summary>
        public string ScreenplayBy { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="ScreenplayBy"/> property was included in the response and has a value.
        /// </summary>
        public bool HasScreenplayBy {
            get { return !String.IsNullOrWhiteSpace(ScreenplayBy); }
        }

        /// <summary>
        /// Gets the season information of the TV Show. Applicable to <strong>TV Shows</strong>.
        /// </summary>
        public string Season { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Season"/> property was included in the response and has a value.
        /// </summary>
        public bool HasSeason {
            get { return !String.IsNullOrWhiteSpace(Season); }
        }

        /// <summary>
        /// Gets the page address, if any, in a simple single line format.
        /// </summary>
        public string SingleLineAddress { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="SingleLineAddress"/> property was included in the response and has a value.
        /// </summary>
        public bool HasSingleLineAddress {
            get { return !String.IsNullOrWhiteSpace(SingleLineAddress); }
        }

        /// <summary>
        /// Gets the cast of the film. Applicable to <strong>Films</strong>.
        /// </summary>
        public string Starring { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Starring"/> property was included in the response and has a value.
        /// </summary>
        public bool HasStarring {
            get { return !String.IsNullOrWhiteSpace(Starring); }
        }

        // TODO: Add support for the "start_info" field

        /// <summary>
        /// Gets the location page's store location descriptor.
        /// </summary>
        public string StoreLocationDescriptor { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="StoreLocationDescriptor"/> property was included in the response and has a value.
        /// </summary>
        public bool HasStoreLocationDescriptor {
            get { return !String.IsNullOrWhiteSpace(StoreLocationDescriptor); }
        }

        /// <summary>
        /// Gets the unique store number for this location page.
        /// </summary>
        public int StoreNumber { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="StoreNumber"/> property was included in the response.
        /// </summary>
        public bool HasStoreNumber {
            get { return JObject.HasValue("store_number"); }
        }

        /// <summary>
        /// Gets the studio for the film production. Applicable to <strong>Films</strong>.
        /// </summary>
        public string Studio { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Studio"/> property was included in the response and has a value.
        /// </summary>
        public bool HasStudio {
            get { return !String.IsNullOrWhiteSpace(Studio); }
        }
        
        // TODO: Add support for the "supports_instant_articles" field

        /// <summary>
        /// Gets the number of people talking about the page.
        /// </summary>
        public int TalkingAboutCount { get; private set; }
        
        // TODO: Add support for the "unread_message_count" field
        
        // TODO: Add support for the "unread_notif_count" field

        // TODO: Add support for the "unseen_message_count" field

        /// <summary>
        /// Gets the alias of the page. For example, for www.facebook.com/platform the username is <code>platform</code>.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Username"/> property was included in the response and has a value.
        /// </summary>
        public bool HasUsername {
            get { return !String.IsNullOrWhiteSpace(Username); }
        }

        /// <summary>
        /// Gets the URL to the website of the page.
        /// </summary>
        public string Website { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Website"/> property was included in the response and has a value.
        /// </summary>
        public bool HasWebsite {
            get { return !String.IsNullOrWhiteSpace(Website); }
        }

        /// <summary>
        /// Gets whether this page is verified and in what color e.g. <see cref="FacebookVerificationStatus.BlueVerified"/>,
        /// <see cref="FacebookVerificationStatus.GreyVerified"/> or <see cref="FacebookVerificationStatus.NotVerified"/>.
        /// </summary>
        public FacebookVerificationStatus VerificationStatus { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="VerificationStatus"/> property was included in the response.
        /// </summary>
        public bool HasVerificationStatus {
            get { return VerificationStatus != FacebookVerificationStatus.NotSpecified; }
        }

        // TODO: Add support for the "voip_info" field

        /// <summary>
        /// Gets the number of visits to location of the page.
        /// </summary>
        public int WereHereCount { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="WereHereCount"/> property was included in the response.
        /// </summary>
        public bool HasWereHereCount {
            get { return JObject.HasValue("were_here_count"); }
        }

        /// <summary>
        /// Gets the writer of the TV show. Applicable to <strong>TV Shows</strong>.
        /// </summary>
        public string WrittenBy { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="WrittenBy"/> property was included in the response and has a value.
        /// </summary>
        public bool HasWrittenBy {
            get { return !String.IsNullOrWhiteSpace(WrittenBy); }
        }

        #endregion

        #region Constructors

        private FacebookPage(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            About = obj.GetString("about");
            AccessToken = obj.GetString("access_token");
            // TODO: Add support for the "ad_campaign" field
            Affiliation = obj.GetString("affiliation");
            // TODO: Add support for the "app_id" field
            // TODO: Add support for the "app_links" field
            ArtistsWeLike = obj.GetString("artists_we_like");
            Attire = obj.GetEnum("attire", FacebookAttire.Unspecified);
            Awards = obj.GetString("awards");
            BandInterests = obj.GetString("band_interests");
            BandMembers = obj.GetString("band_members");
            // TODO: Add support for the "best_page" field
            Bio = obj.GetString("bio");
            Birthday = obj.GetString("birthday", ParseBirthday);
            BookingAgent = obj.GetString("booking_agent");
            Built = obj.GetString("built");
            // TODO: Add support for the "business" field
            CanCheckin = obj.GetBoolean("can_checkin");
            CanPost = obj.GetBoolean("can_post");
            Category = obj.GetString("category");
            CategoryList = obj.GetArrayItems("category_list", FacebookPageCategory.Parse);
            Checkins = obj.GetInt32("checkins");
            CompanyOverview = obj.GetString("company_overview");
            // TODO: Add support for the "contact_address" field
            // TODO: Add support for the "context" field
            // TODO: Add support for the "country_page_likes" field
            Cover = obj.GetObject("cover", FacebookCoverPhoto.Parse);
            CulinaryTeam = obj.GetString("culinary_team");
            CurrentLocation = obj.GetString("current_location");
            Description = obj.GetString("description");
            DescriptionHtml = obj.GetString("description_html");
            DirectedBy = obj.GetString("directed_by");
            // TODO: Add support for the "display_subtext" field
            // TODO: Add support for the "displayed_message_response_time" field
            Emails = obj.GetStringArray("emails");
            // TODO: Add support for the "engagement" field
            FanCount = obj.GetInt32("fan_count");
            // TODO: Add support for the "featured_video" field
            Features = obj.GetString("features");
            FoodStyles = obj.GetStringArray("food_styles");
            Founded = obj.GetString("founded");
            GeneralInfo = obj.GetString("general_info");
            GeneralManager = obj.GetString("general_manager");
            Genre = obj.GetString("genre");
            // TODO: Add support for the "global_brand_page_name" field
            // TODO: Add support for the "global_brand_root_id" field
            // TODO: Add support for the "has_added_app" field
            Hometown = obj.GetString("hometown");
            Hours = obj.GetObject("hours", FacebookPageOpeningHours.Parse);
            Impressum = obj.GetString("impressum");
            Influences = obj.GetString("influences");
            // TODO: Add support for the "instant_articles_review_status" field
            IsAlwaysOpen = obj.GetBoolean("is_always_open");
            IsCommunityPage = obj.GetBoolean("is_community_page");
            IsPermantlyClosed = obj.GetBoolean("is_permanently_closed");
            IsPublished = obj.GetBoolean("is_published");
            IsUnclaimed = obj.GetBoolean("is_unclaimed");
            IsVerified = obj.GetBoolean("is_verified");
            // TODO: Add support for the "is_webhooks_subscribed" field
            // TODO: Add support for the "leadgen_form_preview_details" field
            // TODO: Add support for the "leadgen_tos_acceptance_time" field
            // TODO: Add support for the "leadgen_tos_accepted" field
            // TODO: Add support for the "leadgen_tos_accepting_user" field
            Link = obj.GetString("link");
            Location = obj.GetObject("location", FacebookLocation.Parse);
            Members = obj.GetString("members");
            // TODO: Add support for the "merchant_id" field
            // TODO: Add support for the "merchant_review_status" field
            Mission = obj.GetString("mission");
            Mpg = obj.GetString("mpg");
            Name = obj.GetString("name");
            NameWithLocationDescriptor = obj.GetString("name_with_location_descriptor");
            Network = obj.GetString("network");
            NewLikeCount = obj.GetInt32("new_like_count");
            // TODO: Add support for the "offer_eligible" field
            OverallStarRating = obj.GetFloat("overall_star_rating");
            ParentPage = obj.GetObject("parent_page", Parse);
            Parking = obj.GetObject("parking", FacebookPageParking.Parse);
            PaymentOptions = obj.GetObject("payment_options", FacebookPagePaymentOptions.Parse);
            PersonalInfo = obj.GetString("personal_info");
            PersonalInterests = obj.GetString("personal_interests");
            PharmaSafetyInfo = obj.GetString("pharma_safety_info");
            Phone = obj.GetString("phone");
            PlaceType = obj.GetString("place_type");
            PlotOutline = obj.GetString("plot_outline");
            // TODO: Add support for the "preferred_audience" field
            PressContact = obj.GetString("press_contact");
            PriceRange = obj.GetString("price_range");
            ProducedBy = obj.GetString("produced_by");
            Products = obj.GetString("products");
            PromotionEligible = obj.GetBoolean("promotion_eligible");
            PromotionIneligibleReason = obj.GetString("promotion_ineligible_reason");
            PublicTransit = obj.GetString("public_transit");
            // TODO: Add support for the "publisher_space" field
            RatingCount = obj.GetInt32("rating_count");
            // TODO: Add support for the "recipient" field
            RecordLabel = obj.GetString("record_label");
            PriceRange = obj.GetString("price_range");
            ReleaseDate = obj.GetString("release_date");
            RestaurantServices = obj.GetObject("restaurant_services", FacebookPageRestaurantServices.Parse);
            RestaurantSpecialties = obj.GetObject("restaurant_specialties", FacebookPageRestaurantSpecialties.Parse);
            Schedule = obj.GetString("schedule");
            ScreenplayBy = obj.GetString("screenplay_by");
            Season = obj.GetString("season");
            SingleLineAddress = obj.GetString("single_line_address");
            Starring = obj.GetString("starring");
            // TODO: Add support for the "start_info" field
            StoreLocationDescriptor = obj.GetString("store_location_descriptor");
            StoreNumber = obj.GetInt32("store_number");
            Studio = obj.GetString("studio");
            // TODO: Add support for the "supports_instant_articles" field
            TalkingAboutCount = obj.GetInt32("talking_about_count");
            // TODO: Add support for the "unread_message_count" field
            // TODO: Add support for the "unread_notif_count" field
            // TODO: Add support for the "unseen_message_count" field
            Username = obj.GetString("username");
            VerificationStatus = obj.GetEnum("verification_status", FacebookVerificationStatus.NotSpecified);
            // TODO: Add support for the "voip_info" field
            Website = obj.GetString("website");
            WereHereCount = obj.GetInt32("were_here_count");
            WrittenBy = obj.GetString("written_by");
        }

        #endregion

        #region Member methods

        private EssentialsDateTime ParseBirthday(string str) {
            if (String.IsNullOrWhiteSpace(str)) return null;
            return DateTime.ParseExact(str, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        } 

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="FacebookPage"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="FacebookPage"/>.</returns>
        public static FacebookPage Parse(JObject obj) {
            return obj == null ? null : new FacebookPage(obj);
        }

        #endregion

    }

}