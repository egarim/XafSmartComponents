using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SmartComponents.Inference.OpenAI;
using System;
using System.Linq;
using XafVsCodeEditor;


namespace XafVsCodeEditor
{
    [HtmlTargetElement("head")]
    public class MonacoEditorTagHelper : TagHelperComponent
    {
        public static string AddScriptTags = @"
		<script src=""_content/BlazorMonaco/lib/monaco-editor/min/vs/loader.js""></script>
        <script>require.config({ paths: { 'vs': '_content/BlazorMonaco/lib/monaco-editor/min/vs' } });</script>
        <script src=""_content/BlazorMonaco/lib/monaco-editor/min/vs/editor/editor.main.js""></script>
        <script src=""_content/BlazorMonaco/jsInterop.js""></script>
		<link href = ""_content/XafVsCodeEditor/monacoeditor.css"" rel=""stylesheet"" />";
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "head", StringComparison.OrdinalIgnoreCase))
            {
                output.PostContent.AppendHtml(AddScriptTags).AppendLine();
            }
            return Task.CompletedTask;
        }
    }
}
