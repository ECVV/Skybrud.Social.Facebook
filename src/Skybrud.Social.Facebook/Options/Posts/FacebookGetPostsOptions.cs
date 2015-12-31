﻿using System;
using Skybrud.Social.Facebook.Fields;
using Skybrud.Social.Facebook.Options.Pagination;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Options.Posts {

    /// <summary>
    /// Class representing the options for a call to the Facebook Graph API to get a list of posts.
    /// </summary>
    public class FacebookGetPostsOptions : FacebookTimeBasedPaginationOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the identifier (ID) of the user.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the fields to be returned.
        /// </summary>
        public FacebookFieldsCollection Fields { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an instance with default options.
        /// </summary>
        public FacebookGetPostsOptions() {
            Fields = new FacebookFieldsCollection();
        }

        /// <summary>
        /// Initializes an instance with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier (ID) of the user.</param>
        public FacebookGetPostsOptions(string identifier) : this() {
            Identifier = identifier;
        }

        #endregion

        #region Member methods

        public override SocialQueryString GetQueryString() {

            // Get the query string
            SocialQueryString query = base.GetQueryString();

            // Convert the collection of fields to a string
            string fields = (Fields == null ? "" : Fields.ToString()).Trim();

            // Update the query string
            if (!String.IsNullOrWhiteSpace(fields)) query.Set("fields", fields);

            return query;

        }

        #endregion

    }

}