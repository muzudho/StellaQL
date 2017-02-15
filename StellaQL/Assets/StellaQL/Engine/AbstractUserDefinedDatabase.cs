using System.Collections.Generic;
using System.Text;

namespace StellaQL
{
    public abstract class AbstractUserDefinedDatabase
    {
        public Dictionary<string, AControllable> AnimationControllerFilePath_to_table { get; protected set; }

        /// <summary>
        /// For error.
        /// </summary>
        public void Dump_Presentable(StringBuilder message)
        {
            message.AppendLine("Please add the path of your animator controller.");
            message.Append(AnimationControllerFilePath_to_table.Count); message.AppendLine(" mappings of animator controller and generated C # script are registered.");
            int i = 0;
            foreach (string path in AnimationControllerFilePath_to_table.Keys)
            {
                message.Append("["); message.Append(i); message.Append("]"); message.AppendLine(path);
                i++;
            }
        }
    }
}
