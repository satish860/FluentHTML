using System;
using System.Net.Http.Headers;

namespace FluentHtml
{
    public static class HyperMediaControlExtensions
    {
        public const string Comma = ",";

        public static T Href<T>(this T hyperlinkBuilder, string link) where T : IHyperMediaControlBuilder
        {
            hyperlinkBuilder.Html.MergeAttribute(HTMLATTRIBUTE.HREF, link);
            return hyperlinkBuilder;
        }

        public static T Text<T>(this T hyperlinkBuilder, string text) where T : IHyperMediaControlBuilder
        {
            hyperlinkBuilder.Html.InnerHtml = text;
            return hyperlinkBuilder;
        }

        public static T OpenInNewWindow<T>(this T hyperlinkBuilder) where T : IHyperMediaControlBuilder
        {
            hyperlinkBuilder.Html.MergeAttribute(HTMLATTRIBUTE.Target, HTMLATTRIBUTE.BLANK);
            return hyperlinkBuilder;
        }

        /// <summary>
        /// Open in Parent Window is used for opening the Link in parent Windows Which essentially will be
        /// done from the POPUP. Its a very bad decision Until you are selling ADS ,Dont use Popup
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hyperlinkBuilder"></param>
        /// <returns></returns>
        public static T OpenInParentWindow<T>(this T hyperlinkBuilder) where T : IHyperMediaControlBuilder
        {
            hyperlinkBuilder.Html.MergeAttribute(HTMLATTRIBUTE.Target, HTMLATTRIBUTE.PARENT);
            return hyperlinkBuilder;
        }

        public static T OpenInTopWindow<T>(this T hyperlinkBuilder) where T : IHyperMediaControlBuilder
        {
            hyperlinkBuilder.Html.MergeAttribute(HTMLATTRIBUTE.Target, HTMLATTRIBUTE.TOP);
            return hyperlinkBuilder;
        }

        public static T OpenInFrame<T>(this T hyperlinkBuilder, string frame) where T : IHyperMediaControlBuilder
        {
            hyperlinkBuilder.Html.MergeAttribute(HTMLATTRIBUTE.Target, frame);
            return hyperlinkBuilder;
        }

        public static T Rel<T>(this T hyperlinkBuilder, string rel) where T : IHyperMediaControlBuilder
        {
            hyperlinkBuilder.Html.MergeAttribute(HTMLATTRIBUTE.REL, rel);
            return hyperlinkBuilder;
        }

        public static T AcceptType<T>(this T fileInputBuilder, params string[] acceptedMimeType) where T : IHyperMediaControlBuilder
        {
            foreach (var item in acceptedMimeType)
            {
                var mediatype = new MediaTypeHeaderValue(item);
            }
            var accept = String.Join(Comma, acceptedMimeType);
            fileInputBuilder.Html.MergeAttribute(HTMLATTRIBUTE.TYPE, accept);
            return fileInputBuilder;
        }

        public static T AcceptedLanguage<T>(this T hyperlinkBuilder, string language) where T : IHyperMediaControlBuilder
        {
            hyperlinkBuilder.Html.MergeAttribute(HTMLATTRIBUTE.Language, language);
            return hyperlinkBuilder;
        }
    }
}