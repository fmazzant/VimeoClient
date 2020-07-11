using System;
using System.Collections.Generic;
using System.Text;

namespace VimeoClient.Filter.Folder
{
    /// <summary>
    /// The sort direction of the results.Option descriptions:
    /// </summary>
    public enum FolderDirection
    {
        /// <summary>
        /// Sort the results in ascending order.
        /// </summary>
        asc,

        /// <summary>
        /// Sort the results in descending order.
        /// </summary>
        desc
    }

    /// <summary>
    /// The way to sort the results.
    /// </summary>
    public enum FolderSort
    {
        /// <summary>
        /// 
        /// </summary>
        date,

        /// <summary>
        /// default
        /// </summary>
        __default,

        /// <summary>
        /// modified_time
        /// </summary>
        modified_time,

        /// <summary>
        /// name
        /// </summary>
        name,
    }
}
