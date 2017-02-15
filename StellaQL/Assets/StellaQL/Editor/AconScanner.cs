﻿using System.Collections.Generic;
using System.Text;
using UnityEditor.Animations;
using UnityEngine;

namespace StellaQL
{
    public abstract class AbstractAconScanner
    {
        public AbstractAconScanner(bool parameterScan)
        {
            this.parameterScan = parameterScan;
        }
        bool parameterScan;

        void ScanRecursive(string path, AnimatorStateMachine stateMachine, Dictionary<string, AnimatorStateMachine> statemachineList_flat)
        {
            path += stateMachine.name + ".";
            statemachineList_flat.Add(path, stateMachine);

            foreach (ChildAnimatorStateMachine caStateMachine in stateMachine.stateMachines)
            {
                if (null == caStateMachine.stateMachine) { throw new UnityException("Child statemachine is null. parent stateMachine.name=[" + stateMachine.name+"]"); }
                ScanRecursive(path, caStateMachine.stateMachine, statemachineList_flat);
            }
        }

        public void ScanAnimatorController(AnimatorController ac, StringBuilder message)
        {
            message.AppendLine("Animator controller Scanning...");

            // Parameter
            if(parameterScan){
                AnimatorControllerParameter[] acpArray = ac.parameters;
                int num = 0;
                foreach (AnimatorControllerParameter acp in acpArray)
                {
                    OnParameter( num, acp);
                    num++;
                }
            }

            int lNum = 0;
            foreach (AnimatorControllerLayer layer in ac.layers) // Layer
            {
                if(OnLayer( layer, lNum))
                {
                    Dictionary<string, AnimatorStateMachine> statemachineList_flat = new Dictionary<string, AnimatorStateMachine>(); // フルパス, ステートマシン

                    // Layers may not have a state machine. You are referring to the state machine of the other layer.
                    if (null == layer.stateMachine) { continue; } // To the next layer.
                    ScanRecursive("", layer.stateMachine, statemachineList_flat); // Scan recursion and make it flat.

                    int smNum = 0;
                    foreach (KeyValuePair<string, AnimatorStateMachine> statemachine_pair in statemachineList_flat)
                    { // Statemachine.

                        FullpathTokens ft1 = new FullpathTokens();
                        int caret1 = 0;
                        if(!FullpathSyntaxP.Fixed_LayerName_And_StatemachineNames(statemachine_pair.Key, ref caret1, ref ft1)) {
                            throw new UnityException("Parse failure. [" + statemachine_pair.Key + "] ac=[" + ac.name + "]"); }

                        if(OnStatemachine(
                            statemachine_pair.Key,
                            ft1.StatemachinePath, // If "Base Layer.Alpaca.Bear.Cat.Dog", It is "Alpaca.Bear.Cat".
                            statemachine_pair.Value, lNum, smNum))
                        {
                            int sNum = 0;
                            foreach (ChildAnimatorState caState in statemachine_pair.Value.states)
                            { // State wrapper

                                if (OnState( statemachine_pair.Key, caState, lNum, smNum, sNum))
                                {
                                    int tNum = 0; // Transition number
                                    foreach (AnimatorStateTransition transition in caState.state.transitions)
                                    {
                                        if(OnTransition( transition, lNum, smNum, sNum, tNum))
                                        {
                                            int cNum = 0; // Condition number
                                            foreach (AnimatorCondition condition in transition.conditions)
                                            {
                                                OnCondition( condition, lNum, smNum, sNum, tNum, cNum);
                                                cNum++;
                                            }
                                        }
                                        tNum++;
                                    }//transition
                                }
                                sNum++;
                            }//State wrapper
                        }
                        smNum++;
                    }//Statemachine
                }
                lNum++;
            }//Layer

            message.AppendLine("Scanned.");
        }

        public virtual void OnParameter(int num, AnimatorControllerParameter acp) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="layer"></param>
        /// <returns>True if you want to search the lower level</returns>
        public virtual bool OnLayer(AnimatorControllerLayer layer, int lNum) { return false; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullnameEndWithDot"></param>
        /// <param name="statemachine"></param>
        /// <returns>True if you want to search the lower level</returns>
        public virtual bool OnStatemachine(string fullnameEndWithDot, string statemachinePath, AnimatorStateMachine statemachine, int lNum, int smNum) { return false; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentPath"></param>
        /// <param name="caState"></param>
        /// <returns>True if you want to search the lower level</returns>
        public virtual bool OnState(string parentPath, ChildAnimatorState caState, int lNum, int smNum, int sNum) { return false; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        /// <returns>True if you want to search the lower level</returns>
        public virtual bool OnTransition(AnimatorStateTransition transition, int lNum, int smNum, int sNum, int tNum) { return false; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>True if you want to search the lower level</returns>
        public virtual bool OnCondition(AnimatorCondition condition, int lNum, int smNum, int sNum, int tNum, int cNum) { return false; }
    }

    /// <summary>
    /// Full scan.
    /// </summary>
    public class AconScanner : AbstractAconScanner
    {
        public AconScanner() : base(true)
        {
            AconData = new AconData();
        }
        public AconData AconData { get; private set; }

        public override void OnParameter( int num, AnimatorControllerParameter acp)
        {
            ParameterRecord record = new ParameterRecord(num, acp.name, acp.defaultBool, acp.defaultFloat, acp.defaultInt, acp.nameHash, acp.type);
            AconData.table_parameter.Add(record);
        }

        public override bool OnLayer( AnimatorControllerLayer layer, int lNum)
        {
            LayerRecord layerRecord = new LayerRecord(
                lNum,
                layer);
            AconData.table_layer.Add(layerRecord); return true;
        }

        public override bool OnStatemachine(string fullnameEndWithDot, string statemachinePath, AnimatorStateMachine statemachine, int lNum, int smNum)
        {
            StatemachineRecord stateMachineRecord = new StatemachineRecord(
                lNum,
                smNum,
                statemachinePath,
                statemachine, AconData.table_position);
            AconData.table_statemachine.Add(stateMachineRecord); return true;
        }

        /// <param name="parentPath"></param>
        /// <param name="caState"></param>
        /// <param name="lNum">layer</param>
        /// <param name="smNum">statemachine</param>
        /// <param name="sNum">state</param>
        /// <returns></returns>
        public override bool OnState( string parentPath, ChildAnimatorState caState, int lNum, int smNum, int sNum)
        {
            StateRecord stateRecord = StateRecord.CreateInstance(
                lNum,
                smNum,
                sNum,
                parentPath,
                caState, AconData.table_position);
            AconData.table_state.Add(stateRecord); return true;
        }

        /// <param name="transition"></param>
        /// <param name="lNum">layer</param>
        /// <param name="smNum">statemachine</param>
        /// <param name="sNum">state</param>
        /// <param name="tNum">transition</param>
        /// <returns></returns>
        public override bool OnTransition( AnimatorStateTransition transition, int lNum, int smNum, int sNum, int tNum)
        {
            TransitionRecord transitionRecord = new TransitionRecord(
                lNum,
                smNum,
                sNum,
                tNum,
                transition, "");
            AconData.table_transition.Add(transitionRecord); return true;
        }

        /// <param name="condition"></param>
        /// <param name="lNum">layer</param>
        /// <param name="smNum">statemachine</param>
        /// <param name="sNum">state</param>
        /// <param name="tNum">transition</param>
        /// <param name="cNum">condition</param>
        /// <returns></returns>
        public override bool OnCondition( AnimatorCondition condition, int lNum, int smNum, int sNum, int tNum, int cNum)
        {
            ConditionRecord conditionRecord = new ConditionRecord(
                lNum,
                smNum,
                sNum,
                tNum,
                cNum,
                condition);
            AconData.table_condition.Add(conditionRecord); return true;
        }
    }

    /// <summary>
    /// State machine, scan all states.
    /// </summary>
    public class AconStateNameScanner : AbstractAconScanner
    {
        public AconStateNameScanner() : base(false)
        {
            FullpathSet = new HashSet<string>();
        }
        public HashSet<string> FullpathSet { get; private set; }

        public override bool OnLayer( AnimatorControllerLayer layer, int lNum)
        {
            return true;
        }

        public override bool OnStatemachine(string fullnameEndWithDot, string statemachinePath, AnimatorStateMachine statemachine, int lNum, int smNum)
        {
            FullpathSet.Add(fullnameEndWithDot); return true;
        }

        public override bool OnState( string parentPath, ChildAnimatorState caState, int lNum, int smNum, int sNum)
        {
            FullpathSet.Add(parentPath + caState.state.name); return false;
        }

        public string Dump()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string path in this.FullpathSet)
            {
                sb.Append(path);
                sb.Append(" To26= ");
                sb.AppendLine(FullpathConstantGenerator.String_split_toUppercaseAlphabetFigureOnly_join(path,".","_"));
            }
            return sb.ToString();
        }
    }
}