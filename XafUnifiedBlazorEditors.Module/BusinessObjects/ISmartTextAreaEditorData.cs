using System;
using System.Linq;


namespace XafVsCodeEditor
{
    public interface ISmartTextAreaEditorData
    {



        string Text { get; set; }
        string UserRole { get; set; }
        string[] UserPhrases { get; set; }
    }
}

