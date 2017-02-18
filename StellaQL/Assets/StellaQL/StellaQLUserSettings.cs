using System.Collections.Generic;

/// <summary>
/// ネームスペースは StellaQL にしてください。
/// </summary>
namespace StellaQL
{
    /// <summary>
    /// あなたのUnityプロジェクトが StellaQL に設定する内容です。
    /// 
    /// StellaQLフォルダーを更新するたびに上書きされて消えてしまわないよう、注意して扱ってください。
    /// 
    /// StellaQLフォルダーの外に出しておくといいでしょう。
    /// </summary>
    public class UserSettings : AbstractUserSettings
    {
        static UserSettings()
        {
            Instance = new UserSettings();

            // 重要。
            // 
            // アニメーター・コントローラーのファイルパスと、自動生成したクラスを拡張したインスタンスを紐づけてください。
            Instance.AddMappings_AnimatorControllerFilepath_And_UserDefinedInstance( new Dictionary<string, AControllable>(){

                // 例。
                // ex.)
                { "Assets/StellaQL/MayBeDeletedThisFolder/AnimatorControllers/Demo_Zoo.controller", StellaQL.Acons.Demo_Zoo.AControl.Instance },

                //{ "Assets/New Animator Controller.controller", YourNamespace.Newanimatorcontroller.AControl.Instance },

            });
        }

        #region Singleton
        /// <summary>
        /// シングルトン・デザインパターンとして作っています。
        /// </summary>
        public static UserSettings Instance { get; private set; }
        #endregion
    }
}
