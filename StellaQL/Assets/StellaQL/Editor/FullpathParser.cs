﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StellaQL
{
    public class FullpathTokens
    {
        public FullpathTokens():this("")
        {

        }
        public FullpathTokens(string matchedSyntaxName)
        {
            Clear(matchedSyntaxName);
        }
        public void Clear(string matchedSyntaxName)
        {
            MatchedSyntaxName = matchedSyntaxName;
            LayerNameEndsWithoutDot = "";
            StatemachineNamesEndsWithoutDot = new List<string>();
            StateName = "";
        }
        public FullpathTokens(FullpathTokens source) // clone
        {
            LayerNameEndsWithoutDot = source.LayerNameEndsWithoutDot;
            MatchedSyntaxCaret = source.MatchedSyntaxCaret;
            MatchedSyntaxName = source.MatchedSyntaxName;
            StatemachineNamesEndsWithoutDot = new List<string>(source.StatemachineNamesEndsWithoutDot);
            StateName = source.StateName;
        }

        /// <summary>
        /// Even if "Base Layer." Is hit, "Base Layer" is retained except for the last dot.
        /// </summary>
        public string LayerNameEndsWithoutDot { get; set; }
        public List<string> StatemachineNamesEndsWithoutDot { get; set; }
        /// <summary>
        /// For example, "Alpaca" "Bear" "Cat" is concatenated with "Alpaca.Bear.Cat" and returned.
        /// </summary>
        public string StatemachinePath { get { return string.Join(".", StatemachineNamesEndsWithoutDot.ToArray()); } }
        public string StateName { get; set; }

        /// <summary>
        /// Syntax When not applicable, a name for checking which syntax has the most number of characters.
        /// </summary>
        public string MatchedSyntaxName { get; set; }
        /// <summary>
        /// Syntax A number for checking which character of which syntax was applicable when not applicable.
        /// </summary>
        public int MatchedSyntaxCaret { get; set; }
    }

    /// <summary>
    /// Full path syntax parser
    /// </summary>
    public abstract class FullpathSyntaxP
    {
        public static bool NotMatched(FullpathTokens current, int caret, ref FullpathTokens max)
        {
            if (max.MatchedSyntaxCaret < caret) { current.MatchedSyntaxCaret = caret; max = current; }
            return false;
        }

        /// <summary>
        /// The dot (.) Or the end of the sentence is the layer name.
        /// (FIXME: Actually, although layer names can contain dots, they shall be avoided by operation)
        /// </summary>
        /// <param name="query"></param>
        /// <param name="caret"></param>
        /// <returns></returns>
        public static bool Fixed_LayerName(string query, ref int ref_caret, ref FullpathTokens maxFt)
        {
            FullpathTokens ft = new FullpathTokens("LayerName");
            int caret = ref_caret;
            string layerNameEndsWithoutDot;

            if (!FullpathLexcalP.VarLayerName(query, ref caret, out layerNameEndsWithoutDot)) { return NotMatched(maxFt, caret, ref maxFt); }
            ft.LayerNameEndsWithoutDot = layerNameEndsWithoutDot;

            maxFt = ft; ref_caret = caret; return true;
        }

        /// <summary>
        /// "Base Layer.", "Base Layer.Alpaca", "Base Layer.Alpaca.Bear" etc. OK.
        /// A state machine name may not exist.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="ref_caret"></param>
        /// <param name="maxFt"></param>
        /// <returns></returns>
        public static bool Fixed_LayerName_And_StatemachineNames(string query, ref int ref_caret, ref FullpathTokens maxFt)
        {
            FullpathTokens ft = new FullpathTokens("LayerName_And_StatemachineNames");
            int caret = ref_caret;
            string layerNameEndsWithoutDot;
            List<string> statemachineNamesEndsWithoutDot;

            if (!FullpathLexcalP.VarLayerName(query, ref caret, out layerNameEndsWithoutDot)) { return NotMatched(maxFt, caret, ref maxFt); }
            ft.LayerNameEndsWithoutDot = layerNameEndsWithoutDot;

            // State machine name is optional.
            if (FullpathLexcalP.VarStatemachineNames(query, ref caret, out statemachineNamesEndsWithoutDot)) { ft.StatemachineNamesEndsWithoutDot = statemachineNamesEndsWithoutDot; }

            maxFt = ft; ref_caret = caret; return true;
        }

        /// <summary>
        /// "Base Layer.Alpaca" and "Base Layer.Alpaca.Bear" etc are OK.
        /// A state machine name may not exist.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="ref_caret"></param>
        /// <param name="maxFt"></param>
        /// <returns></returns>
        public static bool Fixed_LayerName_And_StatemachineNames_And_StateName(string query, ref int ref_caret, ref FullpathTokens maxFt)
        {
            FullpathTokens ft = new FullpathTokens("LayerName_And_StatemachineNames_And_StateName");
            int caret = ref_caret;
            string layerNameEndsWithoutDot;
            List<string> statemachineNamesEndsWithoutDot;
            string stateName;

            if (!FullpathLexcalP.VarLayerName(query, ref caret, out layerNameEndsWithoutDot)) { return NotMatched(maxFt, caret, ref maxFt); }
            ft.LayerNameEndsWithoutDot = layerNameEndsWithoutDot;

            // State machine name is optional.
            if (FullpathLexcalP.VarStatemachineNames(query, ref caret, out statemachineNamesEndsWithoutDot)) { ft.StatemachineNamesEndsWithoutDot = statemachineNamesEndsWithoutDot; }

            if (!FullpathLexcalP.VarStateName(query, ref caret, out stateName)) { return NotMatched(maxFt, caret, ref maxFt); }
            ft.StateName = stateName;

            maxFt = ft; ref_caret = caret; return true;
        }

        /// <summary>
        /// "Base Layer.Alpaca" and "Base Layer.Alpaca.Bear" etc are OK.
        /// A state machine name may not exist.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="ref_caret"></param>
        /// <param name="maxFt"></param>
        /// <returns></returns>
        public static bool Continued_Fixed_StateName(string query, ref int ref_caret, FullpathTokens baseFt, ref FullpathTokens maxFt)
        {
            FullpathTokens ft = new FullpathTokens(baseFt); // Clone and add.
            int caret = ref_caret;
            string stateName;

            if (!FullpathLexcalP.VarStateName(query, ref caret, out stateName)) { return NotMatched(maxFt, caret, ref maxFt); }
            ft.StateName = stateName;

            maxFt = ft; ref_caret = caret; return true;
        }
    }

    /// <summary>
    /// Full path lexical parser
    /// </summary>
    public abstract class FullpathLexcalP
    {
        /// <summary>
        /// It hits "Base Layer." Or "Base Layer".
        /// The string to be returned is "Base Layer" who excludes the trailing dot.
        /// </summary>
        private static Regex regexLayerNameEndsWithDot = new Regex(@"^([\w\s]+)(\.)", RegexOptions.IgnoreCase);
        public static bool VarLayerName(string query, ref int caret, out string layerNameEndsWithoutDot)
        {
            Match match = regexLayerNameEndsWithDot.Match(query.Substring(caret));
            if (match.Success)
            {
                layerNameEndsWithoutDot = match.Groups[1].Value; caret += layerNameEndsWithoutDot.Length;
                if ("." == match.Groups[2].Value) { caret += match.Groups[2].Value.Length; }
                return true;
            }
            layerNameEndsWithoutDot = ""; return false;
        }

        public static bool VarStatemachineNames(string query, ref int ref_caret, out List<string> statemachineNamesEndsWithoutDot)
        {
            const int LEAF = 1;
            int caret = ref_caret;

            string[] nodes = query.Substring(caret).Split('.'); // Path without layer name. Is it state machine name except leaves? There may be no state machine name on the way.

            statemachineNamesEndsWithoutDot = new List<string>();
            if (1 < nodes.Length) // If the state machine is in the middle, it will get off to the last state machine.
            {
                for (int i = 0; i < nodes.Length - LEAF; i++)//Excluding leaves
                {
                    statemachineNamesEndsWithoutDot.Add(nodes[i]);
                    caret += nodes[i].Length + ".".Length;
                }
                ref_caret = caret; return true;
            }
            else { return false; }// Not applicable
        }

        public static bool VarStateName(string query, ref int ref_caret, out string stateName)
        {
            int caret = ref_caret;

            stateName = query.Substring(caret); // FIXME: Let's say that all behind the state name.
            caret += stateName.Length;
            ref_caret = caret; return true;
        }
    }
}