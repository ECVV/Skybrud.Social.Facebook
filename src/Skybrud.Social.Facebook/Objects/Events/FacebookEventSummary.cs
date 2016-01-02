using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Facebook.Objects.Events {

    /// <summary>
    /// Class representing the summary about an event.
    /// </summary>
    public class FacebookEventSummary : FacebookEvent {

        // TODO: Remove class for v1.0 (the class FacebookEvent should be used instead)

        #region Constructors

        private FacebookEventSummary(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>FacebookEventSummary</code> from the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>FacebookEventSummary</code>, or <code>null</code> if <code>obj</code>
        /// is <code>null</code>.</returns>
        public new static FacebookEventSummary Parse(JObject obj) {
            return obj == null ? null : new FacebookEventSummary(obj);
        }

        #endregion

    }

}