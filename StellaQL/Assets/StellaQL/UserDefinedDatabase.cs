using System.Collections.Generic;
using System.Text;

namespace StellaQL
{
    /// <summary>
    /// Important.
    /// Link animator controller to generated classes.
    /// </summary>
    public class UserDefinedDatabase : AbstractUserDefinedDatabase
    {
        static UserDefinedDatabase() { Instance = new UserDefinedDatabase(); }
        public static UserDefinedDatabase Instance { get; private set; }

        UserDefinedDatabase()
        {
            AnimationControllerFilePath_to_table = new Dictionary<string, AControllable>()
            {
                // List here! File path to instance.
                {FileUtility_Engine.PATH_ANIMATOR_CONTROLLER_FOR_DEMO_TEST, StellaQL.Acons.Demo_Zoo.AControl.Instance },
            };
        }

        /// <summary>
        /// For error.
        /// </summary>
        public void Dump_Presentable(StringBuilder message)
        {
            message.Append("Registerd "); message.Append(AnimationControllerFilePath_to_table.Count); message.AppendLine(" paths.");
            int i = 0;
            foreach (string path in AnimationControllerFilePath_to_table.Keys)
            {
                message.Append("["); message.Append(i); message.Append("]"); message.AppendLine(path);
                i++;
            }
        }
    }
}
