/// <summary>
/// 
/// The MIT License (MIT)
/// 
/// Copyright (c) 2020 Federico Mazzanti
/// 
/// Permission is hereby granted, free of charge, to any person
/// obtaining a copy of this software and associated documentation
/// files (the "Software"), to deal in the Software without
/// restriction, including without limitation the rights to use,
/// copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the
/// Software is furnished to do so, subject to the following
/// conditions:
/// 
/// The above copyright notice and this permission notice shall be
/// included in all copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
/// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
/// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
/// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
/// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
/// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
/// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
/// OTHER DEALINGS IN THE SOFTWARE.
/// 
/// </summary>

namespace VimeoClient.Filter.ShowCase
{
    /// <summary>
    /// The type of layout for presenting the showcase
    /// </summary>
    public enum ShowCasesLayout
    {
        /// <summary>
        /// The videos appear in a grid.
        /// </summary>
        grid,

        /// <summary>
        /// The videos appear in the player
        /// </summary>
        player
    }

    /// <summary>
    /// The privacy level of the showcase
    /// </summary>
    public enum ShowCasesPrivacy
    {
        /// <summary>
        /// Anyone can access the showcase, either on Vimeo or through an embed.
        /// </summary>
        anybody,

        /// <summary>
        /// The showcase doesn't appear on Vimeo, but it can be embedded on other sites.
        /// </summary>
        embed_only,

        /// <summary>
        /// No one can access the showcase, including the authenticated user.
        /// </summary>
        nobody,

        /// <summary>
        /// Only those with the password can access the showcase.
        /// </summary>
        password,

        /// <summary>
        /// Only members of the authenticated user's team can access the showcase.
        /// </summary>
        team
    }


    /// <summary>
    /// The default sort order of the videos as they appear in the showcase
    /// </summary>
    public enum ShowCasesSort
    {
        /// <summary>
        /// The videos appear according to when they were added to the showcase, with the most recently added first.
        /// </summary>
        added_first,

        /// <summary>
        /// The videos appear according to when they were added to the showcase, with the most recently added last.
        /// </summary>
        added_last,

        /// <summary>
        /// The videos appear alphabetically by their title.
        /// </summary>
        alphabetical,

        /// <summary>
        /// The videos appear as arranged by the owner of the showcase.
        /// </summary>
        arranged,

        /// <summary>
        /// The videos appear according to their number of comments.
        /// </summary>
        comments,

        /// <summary>
        /// The videos appear according to their number of likes.
        /// </summary>
        likes,

        /// <summary>
        /// The videos appear in chronological order with the newest first.
        /// </summary>
        newest,

        /// <summary>
        /// The videos appear in chronological order with the oldest first.
        /// </summary>
        oldest,

        /// <summary>
        /// The videos appear according to their number of plays.
        /// </summary>
        plays
    }

    /// <summary>
    /// The color theme of the showcase
    /// </summary>
    public enum ShowCasesTheme
    {
        /// <summary>
        /// The showcase uses the dark theme.
        /// </summary>
        dark,

        /// <summary>
        /// The showcase uses the standard theme.
        /// </summary>
        standard
    }
}
