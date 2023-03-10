using UnityEngine;

namespace ChatSonicAPI
{
    [CreateAssetMenu(fileName = "CompletionSettings", menuName = "ChatSonicAPI/CompletionSettings")]
    public class CompletionSettings : ScriptableObject
    {       
        [Tooltip("Include latest google data in reply will cost more generations")]
        public bool enableGoogle = false;

        [Tooltip("Enable memory in reply will cost more generations")]
        public bool enableMemory = false;

        [Tooltip("Select Language of the text")]
        public Language language = Language.en;

        [HideInInspector]
        public string Url
        {
            get
            {
                string languageString;
                switch (language)
                {
                    case Language.pt_br:
                        languageString = "pt-br";
                        break;
                    case Language.pt_pt:
                        languageString = "pt-pt";
                        break;
                    default:
                        languageString = language.ToString();
                        break;
                }

                return "https://api.writesonic.com/v2/business/content/chatsonic?engine=premium&language=" + languageString;
            }
        }


        public enum Language
        {
            en, nl, fr, de, it, pl, es, pt_pt, pt_br, ru, ja, zh, bg, cs, da, el, hu, lt, lv, ro, sk, sl, sv, fi, et
        };

        
    }

}