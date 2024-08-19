using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp;
using Microsoft.AspNetCore.Components;
using XafVsCodeEditor;
using XafVsCodeEditor.SmartComponents;

namespace XafUnifiedBlazorEditors.Blazor.Server.Editors
{
    [PropertyEditor(typeof(ISmartTextAreaEditorData), EditorsAlias.SmartTextAreaEditor, true)]
    public class SmartTextAreaPropertyEditorBlazor : BlazorPropertyEditorBase, IComplexViewItem
    {
        public SmartTextAreaPropertyEditorBlazor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }

        IObjectSpace _objectSpace;
        XafApplication _application;
        public void Setup(IObjectSpace objectSpace, XafApplication application)
        {
            _objectSpace = objectSpace;
            _application = application;


        }


        public override SmartTextAreaDataModel ComponentModel => (SmartTextAreaDataModel)base.ComponentModel;
        protected override IComponentModel CreateComponentModel()
        {


            var model = new SmartTextAreaDataModel();

            model.ValueChanged = EventCallback.Factory.Create<ISmartTextAreaEditorData>(this, value => {
                model.Value = value;
                OnControlValueChanged();
                WriteValue();
            });
            return model;
        }
        protected override void ReadValueCore()
        {
            base.ReadValueCore();
            ComponentModel.Value = (ISmartTextAreaEditorData)PropertyValue;
        }
        protected override object GetControlValueCore() => ComponentModel.Value;
        protected override void ApplyReadOnly()
        {
            base.ApplyReadOnly();
            ComponentModel?.SetAttribute("readonly", !AllowEdit);
        }


    }
}
