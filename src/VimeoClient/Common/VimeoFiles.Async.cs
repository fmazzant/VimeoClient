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

namespace Mafesoft.VimeoClient.Common
{
    using Mafesoft.RestClient;
    using Mafesoft.VimeoClient.Model;
    using System.Threading.Tasks;

    // Asynchronous versions of the methods of VimeoFiles.
    public partial class VimeoFiles
    {
        #region [ View ]

        /// <summary>
        /// This method returns a single hosted file by its public ID.
        /// GET https://api.vimeo.com/files/{file_id}
        /// </summary>
        /// <param name="file_id">The public ID of the file.</param>
        /// <param name="password">The password required to view the file when its privacy is password.</param>
        /// <returns>
        /// 200 OK	The file was returned.
        /// 400 Bad Request	Error code 2209: the file is password protected and no password was supplied.
        /// </returns>
        public virtual Task<RestResult<HostedFile>> GetAFileAsync(string file_id, string password = null) => RootAuthorization()
            .Command($"/files/{file_id}")
            .OptionalParameter("password", password)
            .GetAsync<HostedFile>();

        #endregion
    }
}
