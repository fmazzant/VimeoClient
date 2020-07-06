namespace VimeoClient.Model
{
    /// <summary>
    /// The activity 3.1 representation consists of the following fields.
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// The category associated with the event. This field is present only when the activity type is category.
        /// </summary>
        public Category category { get; set; }

        /// <summary>
        /// The channel associated with the event. This field is present only when the activity type is channel.
        /// </summary>
        public Channel channel { get; set; }

        /// <summary>
        /// The video associated with the activity.
        /// </summary>
        public Video clip { get; set; }

        /// <summary>
        /// The group associated with the event. This field is present only when the activity type is group
        /// </summary>
        public Group group { get; set; }

        /// <summary>
        /// The tag associated with the event. This field is present only when the activity type is tag.
        /// </summary>
        public Tag tag { get; set; }

        /// <summary>
        /// The time that the event occurred.
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// The activity type.
        /// Option descriptions:
        ///     appearance       - The activity is an appearance action.
        ///     category         - The activity is a category action.
        ///     channel          - The activity is a channel action.
        ///     facebook_feed    - The activity is a Facebook feed action.
        ///     group            - The activity is a group action.
        ///     like             - The activity is a like action.
        ///     ondemand         - The activity is a Vimeo On Demand action.
        ///     share            - The activity is a share action.
        ///     tag              - The activity is a tag action.
        ///     twitter_timeline - The activity is a Twitter timeline action.
        ///     upload           - The activity is an upload action.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// The user associated with the event. This field is present only when the activity type is like, appearance, or share.
        /// </summary>
        public User user { get; set; }
    }
}