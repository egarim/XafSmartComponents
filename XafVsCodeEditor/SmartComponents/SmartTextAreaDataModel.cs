using DevExpress.ExpressApp.Blazor.Components.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XafVsCodeEditor.SmartComponents
{
    public class SmartTextAreaDataModel : ComponentModelBase
    {
        public ISmartTextAreaEditorData Value
        {
            get => GetPropertyValue<ISmartTextAreaEditorData>();
            set => SetPropertyValue(value);
        }

        public EventCallback<ISmartTextAreaEditorData> ValueChanged
        {
            get => GetPropertyValue<EventCallback<ISmartTextAreaEditorData>>();
            set => SetPropertyValue(value);
        }


        public override Type ComponentType => typeof(SmartTextAreaComponent);
    }
}
