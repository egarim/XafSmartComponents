using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using System;
using System.Linq;


namespace XafVsCodeEditor
{
    [DomainComponent()]
    public class SmartTextAreaEditorData : NonPersistentBaseObject, ISmartTextAreaEditorData
    {
        public SmartTextAreaEditorData()
        {
        }

        public SmartTextAreaEditorData(Guid oid) : base(oid)
        {
        }

        string text;
        public string Text
        {
            get => text; set
            {
                if (text == value)
                {
                    return;
                }

                SetPropertyValue(ref text, value);
            }
        }
        string userRole;
        public string UserRole
        {
            get => userRole; set
            {
                if (userRole == value)
                {
                    return;
                }

                SetPropertyValue(ref userRole, value);
            }
        }

        string[] userPhrases;
        public string[] UserPhrases
        {
            get => userPhrases; set
            {
                if (userPhrases == value)
                {
                    return;
                }

                SetPropertyValue(ref userPhrases, value);
            }
        }
    }
}

