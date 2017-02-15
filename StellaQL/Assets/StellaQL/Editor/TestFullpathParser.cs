﻿using NUnit.Framework;
using System.Collections.Generic;

namespace StellaQL
{
    public class TestFullpathParser
    {
        #region N70 Syntax Parser
        [Test]
        public void N80_Syntax_Fixed_LayerName()
        {
            string query = "Base Layer.Alpaca.Bear.Cat";
            int caret = 0;
            FullpathTokens ft = new FullpathTokens();

            bool successful = FullpathSyntaxP.Fixed_LayerName(query, ref caret, ref ft);

            Assert.IsTrue(successful);
            Assert.AreEqual(11, caret);
            Assert.AreEqual("Base Layer", ft.LayerNameEndsWithoutDot);
        }

        [Test]
        public void N80_Syntax_Fixed_LayerName_And_StatemachineNames()
        {
            string query = "Base Layer.Alpaca.Bear.Cat";
            int caret = 0;
            FullpathTokens ft = new FullpathTokens();

            bool successful = FullpathSyntaxP.Fixed_LayerName_And_StatemachineNames(query, ref caret, ref ft);

            Assert.IsTrue(successful);
            Assert.AreEqual(23, caret);
            Assert.AreEqual("Base Layer", ft.LayerNameEndsWithoutDot);
            Assert.AreEqual(2, ft.StatemachineNamesEndsWithoutDot.Count);
            Assert.AreEqual("Alpaca", ft.StatemachineNamesEndsWithoutDot[0]);
            Assert.AreEqual("Bear", ft.StatemachineNamesEndsWithoutDot[1]);
        }

        [Test]
        public void N80_Syntax_Fixed_LayerName_And_StatemachineNames_And_StateName()
        {
            string query = "Base Layer.Alpaca.Bear.Cat";
            int caret = 0;
            FullpathTokens ft = new FullpathTokens();

            bool successful = FullpathSyntaxP.Fixed_LayerName_And_StatemachineNames_And_StateName(query, ref caret, ref ft);

            Assert.IsTrue(successful);
            Assert.AreEqual(26, caret);
            Assert.AreEqual("Base Layer", ft.LayerNameEndsWithoutDot);
            Assert.AreEqual(2, ft.StatemachineNamesEndsWithoutDot.Count);
            Assert.AreEqual("Alpaca", ft.StatemachineNamesEndsWithoutDot[0]);
            Assert.AreEqual("Bear", ft.StatemachineNamesEndsWithoutDot[1]);
            Assert.AreEqual("Cat", ft.StateName);
        }

        [Test]
        public void N80_Syntax_Continued_Fixed_LayerName_And_StatemachineNames_And_StateName()
        {
            string query = "Base Layer.Alpaca.Bear.Cat";
            int caret = 0;
            FullpathTokens ft = new FullpathTokens();

            // Read until "~ Bear."
            bool successful1 = FullpathSyntaxP.Fixed_LayerName_And_StatemachineNames(query, ref caret, ref ft);
            Assert.IsTrue(successful1);

            // Continue reading "Cat".
            bool successful2 = FullpathSyntaxP.Continued_Fixed_StateName(query, ref caret, ft, ref ft);

            Assert.IsTrue(successful2);
            Assert.AreEqual(26, caret);
            Assert.AreEqual("Base Layer", ft.LayerNameEndsWithoutDot);
            Assert.AreEqual(2, ft.StatemachineNamesEndsWithoutDot.Count);
            Assert.AreEqual("Alpaca", ft.StatemachineNamesEndsWithoutDot[0]);
            Assert.AreEqual("Bear", ft.StatemachineNamesEndsWithoutDot[1]);
            Assert.AreEqual("Cat", ft.StateName);
        }
        #endregion



        #region N80 Lexical Parser
        [Test]
        public void N80_Lexical_VarLayerName()
        {
            string query = "Base Layer.Alpaca.Bear.Cat";
            int caret = 0;
            string layerNameEndsWithoutDot;

            bool successful = FullpathLexcalP.VarLayerName(query, ref caret, out layerNameEndsWithoutDot);

            Assert.IsTrue(successful);
            Assert.AreEqual(11, caret);
            Assert.AreEqual("Base Layer", layerNameEndsWithoutDot);
        }

        [Test]
        public void N80_Lexical_VarStatemachineNames()
        {
            string query = "Base Layer.Alpaca.Bear.Cat";
            int caret = "Base Layer.".Length; // From the continuation of scanning to "Base Layer."
            List<string> statemachinesNameEndsWithoutDot;

            bool successful = FullpathLexcalP.VarStatemachineNames(query, ref caret, out statemachinesNameEndsWithoutDot);

            Assert.IsTrue(successful);
            Assert.AreEqual(23, caret); // Next to "~ Bear.".
            Assert.AreEqual(2, statemachinesNameEndsWithoutDot.Count);
            Assert.AreEqual("Alpaca", statemachinesNameEndsWithoutDot[0]);
            Assert.AreEqual("Bear", statemachinesNameEndsWithoutDot[1]);
        }

        [Test]
        public void N80_Lexical_VarStateName()
        {
            string query = "Base Layer.Alpaca.Bear.Cat";
            int caret = "Base Layer.Alpaca.Bear.".Length; // From the continuation of scanning to "Base Layer.Alpaca.Bear.".
            string stateName;

            bool successful = FullpathLexcalP.VarStateName(query, ref caret, out stateName);

            Assert.IsTrue(successful);
            Assert.AreEqual(26, caret); // Next to "Cat".
            Assert.AreEqual("Cat", stateName);
        }
        #endregion
    }
}