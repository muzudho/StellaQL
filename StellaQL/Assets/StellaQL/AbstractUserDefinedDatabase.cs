using System.Collections.Generic;

namespace StellaQL
{
    public abstract class AbstractUserDefinedDatabase
    {
        public Dictionary<string, AControllable> AnimationControllerFilePath_to_table { get; protected set; }
    }
}
