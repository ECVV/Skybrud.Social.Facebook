using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Time;
using Skybrud.Social.Facebook.Objects.Albums;
using Skybrud.Social.Facebook.Objects.Common;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Facebook.Objects.Events;
using Skybrud.Social.Facebook.Objects.Places;

namespace Skybrud.Social.Facebook.Objects.Photos {
    
    /// <summary>
    /// Class representing a Facebook photo.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.8/photo#Reading</cref>
    /// </see>
    public class FacebookPhoto : FacebookObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the photo.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets a reference to the album this photo is in.
        /// </summary>
        public FacebookAlbum Album { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Album"/> property was included in the response.
        /// </summary>
        public bool HasAlbum {
            get { return Album != null; }
        }

        /// <summary>
        /// Gets a user-specified time for when this object was created.
        /// </summary>
        public EssentialsDateTime BackdatedTime { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Width"/> property was included in the response.
        /// </summary>
        public bool HasBackdatedTime {
            get { return BackdatedTime != null; }
        }

        /// <summary>
        /// Gets how accurate the backdated time is.
        /// </summary>
        public string BackdatedTimeGranularity { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="BackdatedTimeGranularity"/> property was included in the response.
        /// </summary>
        public bool HasBackdatedTimeGranularity {
            get { return !String.IsNullOrWhiteSpace(BackdatedTimeGranularity); }
        }

        /// <summary>
        /// Gets whether the viewer can backdate the photo.
        /// </summary>
        public bool CanBackdate { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="CanTag"/> property was included in the response.
        /// </summary>
        public bool HasCanBackdate {
            get { return JObject.HasValue("can_backdate"); }
        }

        /// <summary>
        /// Gets whether the viewer can delete the photo.
        /// </summary>
        public bool CanDelete { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="CanDelete"/> property was included in the response.
        /// </summary>
        public bool HasCanDelete {
            get { return JObject.HasValue("can_delete"); }
        }

        /// <summary>
        /// Gets whether the viewer can tag the photo.
        /// </summary>
        public bool CanTag { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="CanTag"/> property was included in the response.
        /// </summary>
        public bool HasCanTag {
            get { return JObject.HasValue("can_tag"); }
        }

        /// <summary>
        /// Gets the time this photo was published.
        /// </summary>
        public EssentialsDateTime CreatedTime { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="CreatedTime"/> property was included in the response.
        /// </summary>
        public bool HasCreatedTime {
            get { return CreatedTime != null; }
        }

        /// <summary>
        /// If this object has a place, the event associated with the place.
        /// </summary>
        public FacebookEvent Event { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Event"/> property was included in the response.
        /// </summary>
        public bool HasEvent {
            get { return Event != null; }
        }

        /// <summary>
        /// Gets a reference to the profile (user or page) that uploaded this photo.
        /// </summary>
        public FacebookEntity From { get; set; }

        /// <summary>
        /// Gets whether the <see cref="From"/> property was included in the response.
        /// </summary>
        public bool HasFrom {
            get { return From != null; }
        }

        /// <summary>
        /// Gets the height of this photo in pixels.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Height"/> property was included in the response.
        /// </summary>
        public bool HasHeight {
            get { return Height > 0; }
        }

        /// <summary>
        /// Gets the icon that Facebook displays when photos are published to News Feed.
        /// </summary>
        public string Icon { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Icon"/> property was included in the response.
        /// </summary>
        public bool HasIcon {
            get { return !String.IsNullOrWhiteSpace(Icon); }
        }

        /// <summary>
        /// Gets the different stored representations of the photo. Can vary in number based upon the size of the original photo.
        /// </summary>
        public FacebookImage[] Images { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Width"/> property was included in the response.
        /// </summary>
        public bool HasImages {
            get { return Images.Any(); }
        }

        /// <summary>
        /// Gets the link to the photo on Facebook.
        /// </summary>
        public string Link { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Link"/> property was included in the response.
        /// </summary>
        public bool HasLink {
            get { return !String.IsNullOrWhiteSpace(Link); }
        }

        /// <summary>
        /// Gets the user-provided caption given to this photo. Corresponds to <code>caption</code> when creating
        /// photos.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Name"/> property was included in the response.
        /// </summary>
        public bool HasName {
            get { return !String.IsNullOrWhiteSpace(Name); }
        }

        // TODO: Add support for the "name_tags" field

        /// <summary>
        /// Gets the ID of the page story this corresponds to. May not be on all photos. Applies only to published
        /// photos.
        /// </summary>
        public string PageStoryId { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="PageStoryId"/> property was included in the response.
        /// </summary>
        public bool HasPageStoryId {
            get { return !String.IsNullOrWhiteSpace(PageStoryId); }
        }

        /// <summary>
        /// Gets the link to the 100px wide representation of this photo.
        /// </summary>
        public string Picture { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Picture"/> property was included in the response.
        /// </summary>
        public bool HasPicture {
            get { return !String.IsNullOrWhiteSpace(Picture); }
        }

        /// <summary>
        /// Gets the place the photo was taken. It is possible to upload photos to Facebook without
        /// specifying a place, and in such cases the property will be <code>null</code>.
        /// </summary>
        public FacebookPlace Place { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Place"/> property was included in the response.
        /// </summary>
        public bool HasPlace {
            get { return Place != null; }
        }

        // TODO: Add support for the "target" field

        /// <summary>
        /// Gets the last time the photo was updated.
        /// </summary>
        public EssentialsDateTime UpdatedTime { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="UpdatedTime"/> property was included in the response.
        /// </summary>
        public bool HasUpdatedTime {
            get { return UpdatedTime != null; }
        }

        /// <summary>
        /// Gets the different stored representations of the photo in webp format. Can vary in number based upon the
        /// size of the original photo.
        /// </summary>
        public FacebookImage[] WebpImages { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="WebpImages"/> property was included in the response.
        /// </summary>
        public bool HasWebpImages {
            get { return WebpImages.Any(); }
        }

        /// <summary>
        /// Gets the width of this photo in pixels.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Width"/> property was included in the response.
        /// </summary>
        public bool HasWidth {
            get { return Width > 0; }
        }
        
        #endregion

        #region Constructors

        private FacebookPhoto(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            Album = obj.GetObject("album", FacebookAlbum.Parse);
            BackdatedTime = obj.GetString("backdated_time", EssentialsDateTime.Parse);
            BackdatedTimeGranularity = obj.GetString("backdated_time_granularity");
            CanBackdate = obj.GetBoolean("can_backdate");
            CanDelete = obj.GetBoolean("can_delete");
            CanTag = obj.GetBoolean("can_tag");
            CreatedTime = obj.GetString("created_time", EssentialsDateTime.Parse);
            Event = obj.GetObject("event", FacebookEvent.Parse);
            From = obj.GetObject("from", FacebookEntity.Parse);
            Height = obj.GetInt32("height");
            Icon = obj.GetString("icon");
            Images = obj.GetArray("images", FacebookImage.Parse);
            Link = obj.GetString("link");
            Name = obj.GetString("name");
            // TODO: Add support for the "name_tags" field
            PageStoryId = obj.GetString("page_story_id");
            Picture = obj.GetString("picture");
            Place = obj.GetObject("place", FacebookPlace.Parse);
            // TODO: Add support for the "target" field
            UpdatedTime = obj.GetString("updated_time", EssentialsDateTime.Parse);
            WebpImages = obj.GetArray("webp_images", FacebookImage.Parse);
            Width = obj.GetInt32("width");
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a best fit for an image that is larger than or equal to the specified <paramref name="width"/> and
        /// <paramref name="height"/>.
        /// </summary>
        /// <param name="width">The minimum width of the image.</param>
        /// <param name="height">The minimum height of the image.</param>
        /// <returns>An instance of <see cref="FacebookImage"/>, or <code>null</code> if no matching images were found.</returns>
        public FacebookImage GetImageGreaterThanOrEqualTo(int width, int height) {
            return Images.Reverse().FirstOrDefault(x => x.Width >= width && x.Height != height);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="FacebookPhoto"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="FacebookPhoto"/>.</returns>
        public static FacebookPhoto Parse(JObject obj) {
            return obj == null ? null : new FacebookPhoto(obj);
        }

        #endregion

    }

}