using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Facebook.Options.Common.Pagination {
    
    /// <summary>
    /// Description from Facebook: Time pagination is used to navigate through results data using Unix timestamps which
    /// point to specific times in a list of data.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/using-graph-api/v2.2#time</cref>
    /// </see>
    public class FacebookTimeBasedPaginationOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the number of individual objects that are returned in each page.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or sets the timestamp that points to the start of the range of time-based data.
        /// </summary>
        public int Since { get; set; }

        /// <summary>
        /// Gets or sets the timestamp that points to the end of the range of time-based data.
        /// </summary>
        public int Until { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public virtual IHttpQueryString GetQueryString() {
            SocialHttpQueryString query = new SocialHttpQueryString();
            if (Limit != null && Limit.Value >= 0) query.Set("limit", Limit.Value);
            if (Since > 0) query.Set("since", Since);
            if (Until > 0) query.Set("until", Until);
            return query;
        }

        #endregion

    }

}