using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SmartComponents.Inference.OpenAI;
using System;
using System.Linq;
using XafVsCodeEditor;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupExtensions
    {
        /// <summary>
		/// This extension works for blazor server and client
        /// This extension does NOT work for windows because the tag Helper is never called
		/// you can use the value of UltraCodeEditorTagHelper.AddScriptTags in your _Host.cshtml or index.html
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMonacoEditorComponent(this IServiceCollection services)
        {
            services.AddTransient<ITagHelperComponent, MonacoEditorTagHelper>();
            return services;
        }
        public static IServiceCollection AddSmartComponentsPropertyEditors(this IServiceCollection services)
        {
            services.AddSmartComponents().WithInferenceBackend<OpenAIInferenceBackend>(); ;
            return services;
        }
    }
}
