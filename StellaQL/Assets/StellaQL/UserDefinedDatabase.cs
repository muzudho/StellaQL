using System.Collections.Generic;

namespace StellaQL
{
    /// <summary>
    /// Important.
    /// Link animator controller to generated classes.
    /// </summary>
    public class UserDefinedDatabase : AbstractUserDefinedDatabase
    {
        UserDefinedDatabase()
        {
            AnimationControllerFilePath_to_table = new Dictionary<string, AControllable>()
            {
                //
                // List here! Animator controller file path to instance.
                //
                {"Assets/StellaQL/AnimatorControllers/Demo_Zoo.controller", StellaQL.Acons.Demo_Zoo.AControl.Instance },
                // ex.)
                //{"Assets/Your animator controllers/MainScene_Bird.controller", YourNamespace.MainScene_Bird.AControl.Instance },
                //{"Assets/Your animator controllers/Fish.controller", YourNamespace.Fish.AControl.Instance },
                //{"Assets/Your animator controllers/Tiger.controller", YourNamespace.Tiger.AControl.Instance },
            };
        }

        #region Singleton
        /// <summary>
        /// I am making this class as a singleton design pattern.
        /// </summary>
        static UserDefinedDatabase() { Instance = new UserDefinedDatabase(); }
        public static UserDefinedDatabase Instance { get; private set; }
        #endregion
    }
}
