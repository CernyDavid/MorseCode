using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace morsecode
{
    internal class Translator : Dictionary<string, string>
    {
        public Translator() { }

        private Dictionary<string, string> MorseCode = new Dictionary<string, string>() {
            {"A", ".-"},
            {"B", "-..." },
            {"C", "-.-."},
            {"D", "-.."},
            {"E", "." },
            {"F", "..-."},
            {"G", "--."},
            {"H", "...." },
            {"CH", "----"},
            {"I", ".."},
            {"J", ".---" },
            {"K", "-.-" },
            {"L", ".-.."},
            {"M", "--"},
            {"N", "-." },
            {"O", "---"},
            {"P", ".--."},
            {"Q", "--.-" },
            {"R", ".-." },
            {"S", "..."},
            {"T", "-"},
            {"U", "..-" },
            {"V", "...-"},
            {"W", ".--"},
            {"X", "-..-" },
            {"Y", "-.--" },
            {"Z", "--.." },
            {"1", ".----" },
            {"2", "..---" },
            {"3", "...--" },
            {"4", "....-" },
            {"5", "....." },
            {"6", "-...." },
            {"7", "--..." },
            {"8", "---.." },
            {"9", "----." },
            {"0", "-----" },
            {" ", "/" }
        };

        public string Encode(string txt)
        {
            string EncodedText = "";
            char[] characters = SplitText(Convert(txt));
            for (int i = 0; i < characters.Length; i++)
            {
                if (string.Compare(characters[i].ToString(), "C") == 0 && string.Compare(characters[i + 1].ToString(), "H") == 0)
                {
                    EncodedText += MorseCode["CH"] + " ";
                    i += 1;
                }
                else
                {
                    EncodedText += MorseCode[characters[i].ToString()] + " ";
                }
            }
            return EncodedText;

        }
        public string Decode(string code)
        {
            string DecodedText = "";
            string[] symbols = SplitCoded(code);
            for (int i = 0; i < symbols.Length; i++)
            {
                DecodedText += MorseCode.FirstOrDefault(x => x.Value == symbols[i]).Key;
            }
            return DecodedText.ToLower();
        }
        private string Convert(string text)
        {
            string normalizedText = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            foreach (var x in normalizedText)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(x) != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(x);
                }
            }
            string result = sb.ToString().Normalize(NormalizationForm.FormC);
            Encoding srcEnc = Encoding.UTF8;
            Encoding dstEnc = Encoding.ASCII;
            var srcBytes = srcEnc.GetBytes(result);
            var dstBytes = Encoding.Convert(srcEnc, dstEnc, srcBytes);
            string newText = dstEnc.GetString(dstBytes);
            return newText.ToUpper();
        }
        private char[] SplitText(string text)
        {
            char[] result = text.ToCharArray();
            return result;
        }
        private string[] SplitCoded(string text)
        {
            string[] symbols = text.Split(" ");
            return symbols;
        }
    }
}
