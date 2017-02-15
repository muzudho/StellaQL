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
