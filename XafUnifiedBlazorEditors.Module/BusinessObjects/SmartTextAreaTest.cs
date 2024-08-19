using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using XafVsCodeEditor;

namespace XafUnifiedBlazorEditors.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SmartTextAreaTest : BaseObject, IXafEntityObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public SmartTextAreaTest(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        public void OnCreated()
        {
            this.SmartTextArea = new SmartTextAreaEditorData() 
            { 
                UserRole= "HR administrator replying to an employee enquiry",
                UserPhrases = [
                    "Thankyou for your message.",
                    "Full-time employees have 28 days paid vacation per year.",
                    "We have no further information about the company sale at this time.",
                    "We always welcome your feedback about this system. Please fill out our survey at https://example.com/hrsurvey",
                    "Full details about the vacation policy can be found at https://example.com/policies/vacation",
                    "Information about the company car scheme is at https://example.com/benefits/car",
                    "Pets are not allowed in the office, as detailed at https://example.com/policies/pets.",
                    "If you have further questions, you can always email us at hr@example.com or ask your manager.",
                    "Could you provide further details about NEED_INFO",
                ]

            };
            SmartTextArea.PropertyChanged += SmartTextArea_PropertyChanged; ;
        }

        private void SmartTextArea_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.FinalText = this.SmartTextArea.Text;
        }

        void IXafEntityObject.OnSaving()
        {
            this.FinalText = this.SmartTextArea.Text;
        }

        void IXafEntityObject.OnLoaded()
        {
            this.SmartTextArea = new SmartTextAreaEditorData() { UserRole = "Generic professional", Text=this.FinalText };
            SmartTextArea.PropertyChanged += SmartTextArea_PropertyChanged; ;
        }

        SmartTextAreaEditorData smartTextArea;
        string finalText;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string FinalText
        {
            get => finalText;
            set => SetPropertyValue(nameof(FinalText), ref finalText, value);
        }
        
        public SmartTextAreaEditorData SmartTextArea
        {
            get => smartTextArea;
            set => SetPropertyValue(nameof(SmartTextArea), ref smartTextArea, value);
        }
    }
}