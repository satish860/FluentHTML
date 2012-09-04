using System;
using System.Net.Http.Headers;

namespace FluentHtml
{
    public static class FileBuilderExtensions
    {
        public const string Comma = ",";

        public static T Accept<T>(this T fileInputBuilder, params string[] acceptedMimeType) where T : IFileInputBuilder
        {
            foreach (var item in acceptedMimeType)
            {
                var mediatype = new MediaTypeHeaderValue(item);
            }
            var accept = String.Join(Comma, acceptedMimeType);
            fileInputBuilder.Html.MergeAttribute(HTMLATTRIBUTE.ACCEPT, accept);
            return fileInputBuilder;
        }

        public static T AllowMultipleFileUpload<T>(this T fileInputBuilder, bool value) where T : IFileInputBuilder
        {
            if (value)
                fileInputBuilder.Html.MergeAttribute(HTMLATTRIBUTE.MULTIPLE, HTMLATTRIBUTE.MULTIPLE);
            return fileInputBuilder;
        }
    }
}