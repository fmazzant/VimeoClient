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

namespace VimeoClient.Model
{
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// The response of the video AI features (transcription, translation, dubbing, ask, metadata).
    /// A 202 status code means that the job is queued or the video is still being prepared: retry after a few seconds.
    /// The fields not mapped by the library are available in <see cref="AdditionalData"/>.
    /// </summary>
    /// <typeparam name="TData">The type of the data field</typeparam>
    public class AiResponse<TData>
    {
        /// <summary>
        /// The ID of the video.
        /// </summary>
        [JsonPropertyName("video_id")]
        public long? VideoId { get; set; }

        /// <summary>
        /// The status of the job: not_started, processing, completed, failed...
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// The language of the job.
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// The ID of the generated text track, when it exists.
        /// </summary>
        [JsonPropertyName("texttrack_id")]
        public long? TextTrackId { get; set; }

        /// <summary>
        /// The total number of jobs.
        /// </summary>
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        /// <summary>
        /// The data of the response.
        /// </summary>
        [JsonPropertyName("data")]
        public TData Data { get; set; }

        /// <summary>
        /// The fields of the response not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }

    /// <summary>
    /// The response of the AI features without data (transcription status, job queued).
    /// </summary>
    public class AiStatus : AiResponse<JsonElement?>
    {
    }

    /// <summary>
    /// A language supported by the AI features.
    /// </summary>
    public class AiLanguage
    {
        /// <summary>
        /// The language code.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// The language name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The available accents (dubbing only).
        /// </summary>
        [JsonPropertyName("accents")]
        public AiAccent[] Accents { get; set; }
    }

    /// <summary>
    /// An accent available for AI dubbing.
    /// </summary>
    public class AiAccent
    {
        /// <summary>
        /// The accent key to send as accent.
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// The accent label.
        /// </summary>
        [JsonPropertyName("label")]
        public string Label { get; set; }

        /// <summary>
        /// The accent locale.
        /// </summary>
        [JsonPropertyName("locale")]
        public string Locale { get; set; }
    }

    /// <summary>
    /// A question about a video with its AI-generated answer.
    /// </summary>
    public class AiQuestion
    {
        /// <summary>
        /// The question.
        /// </summary>
        [JsonPropertyName("question")]
        public string Question { get; set; }

        /// <summary>
        /// The AI-generated answer.
        /// </summary>
        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        /// <summary>
        /// The relevant quotes of the video.
        /// </summary>
        [JsonPropertyName("relevant_quotes")]
        public AiQuote[] RelevantQuotes { get; set; }

        /// <summary>
        /// The related questions.
        /// </summary>
        [JsonPropertyName("related_questions")]
        public string[] RelatedQuestions { get; set; }
    }

    /// <summary>
    /// A quote of the video.
    /// </summary>
    public class AiQuote
    {
        /// <summary>
        /// The quote.
        /// </summary>
        [JsonPropertyName("quote")]
        public string Quote { get; set; }

        /// <summary>
        /// The timecode of the quote.
        /// </summary>
        [JsonPropertyName("timecode")]
        public double? Timecode { get; set; }
    }

    /// <summary>
    /// The AI-generated metadata of a video.
    /// </summary>
    public class AiMetadata
    {
        /// <summary>
        /// The suggested title.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// The suggested description.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The suggested tags.
        /// </summary>
        [JsonPropertyName("tags")]
        public string[] Tags { get; set; }
    }

    /// <summary>
    /// An AI translation or dubbing job.
    /// </summary>
    public class AiTranslationJob
    {
        /// <summary>
        /// The target language.
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// The status: processing, completed, failed, completed_with_deleted_texttrack, completed_with_deleted_audiotrack.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// The accent (dubbing only).
        /// </summary>
        [JsonPropertyName("accent")]
        public string Accent { get; set; }

        /// <summary>
        /// The ID of the generated text track.
        /// </summary>
        [JsonPropertyName("texttrack_id")]
        public long? TextTrackId { get; set; }

        /// <summary>
        /// The URI of the generated audio track (dubbing only).
        /// </summary>
        [JsonPropertyName("audiotrack_uri")]
        public string AudioTrackUri { get; set; }

        /// <summary>
        /// The status of the latest regeneration, when the last action was a regeneration.
        /// </summary>
        [JsonPropertyName("latest_regeneration")]
        public AiRegeneration LatestRegeneration { get; set; }
    }

    /// <summary>
    /// The status of a regeneration.
    /// </summary>
    public class AiRegeneration
    {
        /// <summary>
        /// The status of the regeneration.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// The fields not mapped by the library.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalData { get; set; }
    }

    /// <summary>
    /// A segment of a text track to edit.
    /// </summary>
    public class AiTextTrackSegment
    {
        /// <summary>
        /// The segment UUID.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The updated text of the segment; null for timestamp-only changes.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        /// The start time in milliseconds.
        /// </summary>
        [JsonPropertyName("start_time")]
        public long? StartTime { get; set; }

        /// <summary>
        /// The end time in milliseconds.
        /// </summary>
        [JsonPropertyName("end_time")]
        public long? EndTime { get; set; }
    }

    /// <summary>
    /// The result of a text track segments edit.
    /// </summary>
    public class AiTextTrackEdit
    {
        /// <summary>
        /// The ID of the video.
        /// </summary>
        [JsonPropertyName("video_id")]
        public long? VideoId { get; set; }

        /// <summary>
        /// The ID of the text track.
        /// </summary>
        [JsonPropertyName("texttrack_id")]
        public long? TextTrackId { get; set; }

        /// <summary>
        /// The type of the text track.
        /// </summary>
        [JsonPropertyName("track_type")]
        public string TrackType { get; set; }

        /// <summary>
        /// The number of segments updated.
        /// </summary>
        [JsonPropertyName("segments_updated")]
        public int? SegmentsUpdated { get; set; }

        /// <summary>
        /// The status of any triggered downstream action (translations, dubbing).
        /// </summary>
        [JsonPropertyName("regeneration")]
        public JsonElement? Regeneration { get; set; }
    }

    /// <summary>
    /// The type of AI feature for the supported languages.
    /// </summary>
    public enum AiLanguageType
    {
        /// <summary>
        /// Audio dubbing.
        /// </summary>
        dubbing,

        /// <summary>
        /// Subtitle translation.
        /// </summary>
        subtitling,

        /// <summary>
        /// Transcription.
        /// </summary>
        transcription
    }

    /// <summary>
    /// The dubbing backend: v1 is the legacy model (default), v2 the new one.
    /// </summary>
    public enum AiDubbingApiVersion
    {
        /// <summary>
        /// Legacy dubbing model.
        /// </summary>
        v1,

        /// <summary>
        /// New dubbing model.
        /// </summary>
        v2
    }
}
