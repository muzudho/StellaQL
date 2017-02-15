using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor.Animations;

namespace StellaQL
{
    public abstract class FullpathConstantGenerator
    {
        public static void WriteCshapScript(AnimatorController ac, StringBuilder message)
        {
            AconStateNameScanner aconScanner = new AconStateNameScanner();
            aconScanner.ScanAnimatorController(ac, message);

            StringBuilder contents = new StringBuilder();

            // Conversion example:
            // "Main_Char3" is "Main_Char3", (same)
            // "BattleFloor_char@arm@finger" is "Battolefloor_Chararmfinger"
            string className = FullpathConstantGenerator.String_to36_pascalCase(ac.name, "_", "_");
            // Conversion example:
            // "Main_Char3" is "Main_Char3_AbstractAControl"
            // "Battolefloor_Chararmfinger" is "Battolefloor_Chararmfinger_AbstractAControl"
            string abstractClassName = className + "_AbstractAControl";

            contents.AppendLine("using System.Collections.Generic;");
            contents.AppendLine();
            contents.Append("namespace StellaQL.Acons."); contents.AppendLine(className);
            contents.AppendLine("{");
            contents.AppendLine("    /// <summary>");
            contents.AppendLine("    /// This file was automatically generated.");
            contents.Append("    /// It was created by ["); contents.Append(StateCmdline.BUTTON_LABEL_GENERATE_FULLPATH); contents.AppendLine("] button.");
            contents.AppendLine("    /// </summary>");
            contents.Append("    public abstract class "); contents.Append(abstractClassName);
            contents.AppendLine(" : AbstractAControl");
            contents.AppendLine("    {");
            List<string> fullpaths = new List<string>(aconScanner.FullpathSet);
            fullpaths.Sort();
            if(0< fullpaths.Count)
            {
                contents.Append("        public const string");
                foreach (string fullpath in fullpaths)
                {
                    contents.AppendLine(); // Bring newlines first. Make the process of attaching the final semicolon easier.
                    contents.Append("            ");
                    contents.Append(FullpathConstantGenerator.String_split_toUppercaseAlphabetFigureOnly_join(fullpath, ".", "_"));
                    contents.Append(@" = """);
                    contents.Append(fullpath);
                    contents.Append(@""","); // Line breaks are not the last, but attach them first.
                }
                contents.Length--; // Cut the last comma.
                contents.AppendLine(@"; // semi colon"); // Add a semicolon instead.
                contents.AppendLine();
            }

            contents.Append("        public "); contents.Append(abstractClassName); contents.AppendLine("()");
            contents.AppendLine("        {");
            contents.AppendLine("            Code.Register(StateHash_to_record, new List<AcStateRecordable>()");
            contents.AppendLine("            {");

            foreach (string fullpath in fullpaths)
            {
                contents.Append("                new DefaultAcState( ");
                contents.Append(FullpathConstantGenerator.String_split_toUppercaseAlphabetFigureOnly_join(fullpath, ".", "_"));
                contents.AppendLine("),");
            }

            contents.AppendLine("            });");
            contents.AppendLine("        }");
            contents.AppendLine("    }");
            contents.AppendLine("}");

            StellaQLWriter.Write(StellaQLWriter.Filepath_GenerateFullpathConstCs(ac), contents, message);
        }

        /// <summary>
        /// It fills in only 26 letters of the alphabet and 10 numeric characters. Ignore characters that can not be converted to alphabetic or numeric characters.
        /// I will make it Pascal case. (White.alpaca -> WhiteAlpaca)
        /// Commonly designated "To36"
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string String_to36_pascalCase(string source1, string splitSeparator, string joinSeparator)
        {
            string[] tokens = source1.Split(new string[] { splitSeparator }, StringSplitOptions.None);
            for (int iToken = 0; iToken < tokens.Length; iToken++)
            {
                StringBuilder sb = new StringBuilder();
                string token = tokens[iToken];
                for (int caret = 0; caret < token.Length; caret++)
                {
                    if (sb.Length == 0) // First character
                    {
                        if (Char.IsUpper(token[caret]) || Char.IsDigit(token[caret])) { sb.Append(token[caret]); } // Capital letters and numbers are added as they are
                        else if (Char.IsLower(token[caret])) { sb.Append(Char.ToUpper(token[caret])); } // Add lowercase letters in uppercase letters
                                                                                                        // Ignore other characters
                    }
                    else // Characters after the first character
                    {
                        if (Char.IsLower(token[caret]) || Char.IsDigit(token[caret])) { sb.Append(token[caret]); } // Add lowercase letters and numbers directly
                        else if (Char.IsUpper(token[caret])) { sb.Append(Char.ToLower(token[caret])); } // Add capital letters in lowercase letters
                                                                                                        // Ignore other characters
                    }
                }
            }
            return string.Join(joinSeparator, tokens);
        }

        /// <summary>
        /// Capitalize only 26 letters and 10 letters of the alphabet. Ignore characters that can not be converted to alphabetic or numeric characters.
        /// Commonly designated "To36"
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string String_split_toUppercaseAlphabetFigureOnly_join(string source1, string splitSeparator, string joinSeparator)
        {
            string[] tokens = source1.Split(new string[] { splitSeparator }, StringSplitOptions.None);
            for (int iToken = 0; iToken < tokens.Length; iToken++)
            {
                string token = tokens[iToken];
                StringBuilder sb = new StringBuilder();
                for (int caret = 0; caret < token.Length; caret++)
                {
                    if (Char.IsUpper(token[caret]) || Char.IsDigit(token[caret])) { sb.Append(token[caret]); } // Capital letters and numbers are added as they are
                    else if (Char.IsLower(token[caret])) { sb.Append(Char.ToUpper(token[caret])); } // Add lowercase letters in uppercase letters
                                                                                                    // Ignore other characters
                }
                tokens[iToken] = sb.ToString();
            }
            return string.Join(joinSeparator, tokens);
        }

        /// <summary>
        /// Capitalize only 26 letters and 10 letters of the alphabet. Ignore characters that can not be converted to alphabetic or numeric characters.
        /// Commonly designated "To36"
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string String_to_UppercaseAlphabetFigureOnly(string source)
        {
            StringBuilder sb = new StringBuilder();
            for (int caret = 0; caret < source.Length; caret++)
            {
                if (Char.IsUpper(source[caret]) || Char.IsDigit(source[caret])) { sb.Append(source[caret]); } // Capital letters and numbers are added as they are
                else if (Char.IsLower(source[caret])) { sb.Append(Char.ToUpper(source[caret])); } // Add lowercase letters in uppercase letters
                // Ignore other characters
            }
            return sb.ToString();
        }

    }
}
