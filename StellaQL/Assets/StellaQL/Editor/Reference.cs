﻿using System.IO;
using System.Text;

namespace StellaQL
{
    /// <summary>
    /// A message that appears when you press the "How to use" button.
    /// </summary>
    public abstract class Reference
    {
        public static void ToContents(StringBuilder contents)
        {
            contents.AppendLine(@"---------------------------------------------------------------");
            contents.AppendLine(@"StellaQL コマンドライン・ウィンドウ (StateCmdline window) の使い方");
            contents.AppendLine(@"How to use StellaQL Command line (StateCmdline window)");
            contents.AppendLine(@"---------------------------------------------------------------");
            contents.AppendLine(@"    作者  : 高橋 智史 (ハンドルネーム: むずでょ)");
            contents.AppendLine(@"    Author: TAKAHASHI Satoshi (Handle. Muzudho)");
            contents.AppendLine(@"---------------------------------------------------------------");
            contents.AppendLine(@"");
            contents.AppendLine(@"(0) 注意書き");
            contents.AppendLine(@"(0) Attention");
            contents.AppendLine(@"");
            contents.AppendLine(@"    このツールは永遠のベータ版です。");
            contents.AppendLine(@"    This tool is a eternal beta version.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    Unityプロジェクトのバックアップを取っておいてください。");
            contents.AppendLine(@"    Please, Buckup your unity project.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    =================");
            contents.AppendLine(@"");
            contents.AppendLine(@"(1) 実践");
            contents.AppendLine(@"(1) Practice");
            contents.AppendLine(@"");
            contents.AppendLine(@"    メニューから[Window] - [State Machine Command Line (StellaQL)] をクリック。");
            contents.AppendLine(@"    [Window] - [State Machine Command Line (StellaQL)] is here.");
            contents.AppendLine(@"");
            contents.Append(@"    """); contents.Append(FileUtility_Engine.PATH_ANIMATOR_CONTROLLER_FOR_DEMO_TEST); contents.AppendLine(@"""ファイルを開いてださい。");
            contents.Append(@"    Please, open """); contents.Append(FileUtility_Engine.PATH_ANIMATOR_CONTROLLER_FOR_DEMO_TEST); contents.AppendLine(@""".");
            contents.AppendLine(@"");
            contents.Append(@"    また、その "); contents.Append(Path.GetFileName(FileUtility_Engine.PATH_ANIMATOR_CONTROLLER_FOR_DEMO_TEST)); contents.AppendLine(" ファイルを [Animation Controller Drag & Drop] 枠にドラッグ＆ドロップしてください。");
            contents.Append(@"    And Drag&Drop the "); contents.Append(Path.GetFileName(FileUtility_Engine.PATH_ANIMATOR_CONTROLLER_FOR_DEMO_TEST)); contents.AppendLine(" file to [Animation Controller Drag & Drop] box.");
            contents.AppendLine(@"");
            contents.AppendLine(@"");
            contents.AppendLine(@"    プログラムが正常に動くかテストすることができます。（任意）");
            contents.AppendLine(@"    And condition unit test check (Option).");
            contents.AppendLine(@"");
            contents.AppendLine(@"        [Window] - [Editor Tests Runner] ... [StellaQL] - [StellaQLTest].");
            contents.AppendLine(@"        [Window] - [Editor Tests Runner] ... [StellaQL] - [StellaQLTest].");
            contents.AppendLine(@"");
            contents.AppendLine(@"        そして [Run All]を押してください。チェックが全て緑色ならＯＫです。");
            contents.AppendLine(@"        And [Run All]. Please, click is all greens.");
            contents.AppendLine(@"");
            contents.AppendLine(@"(2) コメント");
            contents.AppendLine(@"(2) Comment");
            contents.AppendLine(@"");
            contents.AppendLine(@"    行コメントだけが使えます。");
            contents.AppendLine(@"    Line comment only.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # これはコメントです。");
            contents.AppendLine(@"    # This is a comment.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    FROM # ダメ！ 命令文の後ろにコメントは書けません。");
            contents.AppendLine(@"    FROM # No! This is not a comment.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # ダメ！ 複数行コメントには対応していません。");
            contents.AppendLine(@"    # No! Unfortunately, Multi line comment is nothing.");
            contents.AppendLine(@"    FROM TAG ( Tail /*Horn*/ Wing )");
            contents.AppendLine(@"");
            contents.AppendLine(@"(2) 基本的な書式");
            contents.AppendLine(@"(2) Basic format");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # 大文字、小文字は区別します。");
            contents.AppendLine(@"    # Unfortunately, upper case, lower case is sensitive.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # 単語は１つ以上のスペース区切りです。 次の文はどちらも同じです。");
            contents.AppendLine(@"    # A word is separated by one or more spaces. Both of the following sentences are the same.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # (1)");
            contents.AppendLine(@"        STATE INSERT SET name0 ""WhiteCat"" name1 ""WhiteDog"" WHERE ""Base Layer""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # (2)");
            contents.AppendLine(@"        STATE INSERT");
            contents.AppendLine(@"        SET");
            contents.AppendLine(@"            name0 ""WhiteCat""");
            contents.AppendLine(@"            name1 ""WhiteDog""");
            contents.AppendLine(@"        WHERE");
            contents.AppendLine(@"            ""Base Layer""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # 命令文はセミコロン区切りです。");
            contents.AppendLine(@"    # A statement is separated by semi colon(;).");
            contents.AppendLine(@"");
            contents.AppendLine(@"        # Sample");
            contents.AppendLine(@"        STATE SELECT WHERE "".*Dog"" THE Zoo001 ;");
            contents.AppendLine(@"        STATE SELECT WHERE "".*Cat"" THE Zoo002");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # 対応しているリテラル文字列のエスケープシーケンスは \\ \"" \r \n の４つです。");
            contents.AppendLine(@"    # There are four escape sequences of supported literal strings \\ \"" \r \n.");
            contents.AppendLine(@"");
            contents.AppendLine(@"        # Sample");
            contents.AppendLine(@"        LAYER INSERT WORDS NewLayer0 ""New Layer1"" ""\""New Layer2\"""" ""New\\Layer3"" ""New\rLayer4"" ""New\nLayer5"" ""New\r\nLayer6""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # リテラル文字列は検索時は正規表現です。 \ を検索したいときは \\ としてください。");
            contents.AppendLine(@"    # Literal strings are used as regular expressions when searching. If you want to search \, please set it to \\.");
            contents.AppendLine(@"");
            contents.AppendLine(@"        # Sample");
            contents.AppendLine(@"        LAYER DELETE WORDS ""New\\\\Layer3""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    =================");
            contents.AppendLine(@"");
            contents.AppendLine(@"    LAYER INSERT");
            contents.AppendLine(@"    WORDS");
            contents.AppendLine(@"        NewLayer1 ""New Layer2""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # - NewLayer1 レイヤー、New Layer2 レイヤーを新規追加します。");
            contents.AppendLine(@"    # - Add a NewLayer1 layer and New Layer2 layer.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    -----------------");
            contents.AppendLine(@"");
            contents.AppendLine(@"");
            contents.AppendLine(@"");
            contents.AppendLine(@"    =================");
            contents.AppendLine(@"");
            contents.AppendLine(@"    STATE INSERT");
            contents.AppendLine(@"    WORDS WhiteCat ""White Dog""");
            contents.AppendLine(@"    WHERE ""Base Layer""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # - ステートを新規追加します。");
            contents.AppendLine(@"    # - Add a new state.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # - WHERE句には、ステートマシンへのパスのみ使えます。");
            contents.AppendLine(@"    # - WHERE is Statemachine path.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    -----------------");
            contents.AppendLine(@"");
            contents.AppendLine(@"    STATE UPDATE");
            contents.AppendLine(@"    SET speed 1.23 speedParameterActive true");
            contents.AppendLine(@"         speedParameter 4.5");
            contents.AppendLine(@"    WHERE ""Base Layer\.Cat""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # - ステートのプロパティーをアップデートします。");
            contents.AppendLine(@"    # - Some States properties update.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    -----------------");
            contents.AppendLine(@"");
            contents.AppendLine(@"    STATE DELETE");
            contents.AppendLine(@"    WORDS WhiteCat ""White Dog""");
            contents.AppendLine(@"    WHERE ""Base Layer""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # - WHERE句には、ステートマシンへのパスのみ使えます。");
            contents.AppendLine(@"    # - WHERE is Statemachine path.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    -----------------");
            contents.AppendLine(@"");
            contents.AppendLine(@"    STATE SELECT");
            contents.AppendLine(@"    WHERE "".*Cat""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # 該当するステートをCSV形式ファイルに一覧します。");
            contents.AppendLine(@"    # List some states and write a csv file.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    STATE SELECT WHERE "".*Cat"" THE Zoo1 ;");
            contents.AppendLine(@"    STATE SELECT WHERE "".*Dog"" THE Zoo2");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # 出力先ファイル名に Zoo1, Zoo2 を付加します。");
            contents.AppendLine(@"    # Add Zoo1, Zoo2 to output file name.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    =================");
            contents.AppendLine(@"");
            contents.AppendLine(@"    TRANSITION INSERT");
            contents.AppendLine(@"    FROM ""Base Layer\.Cat""");
            contents.AppendLine(@"    TO   ""Base Layer\.Dog""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # トランジションを新規追加します。");
            contents.AppendLine(@"    # Add a new transition.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    -----------------");
            contents.AppendLine(@"");
            contents.AppendLine(@"    TRANSITION ANYSTATE INSERT");
            contents.AppendLine(@"    FROM ""Base Layer""");
            contents.AppendLine(@"    TO ""Base Layer\.Foo""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # [Any State] からステートへトランジションを引きます。");
            contents.AppendLine(@"    # Add a transition from [Any State] to a state.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # もし再描画されないなら、アニメーション・コントローラーの右上の[Auto Live Link]ボタンを２回押してください。");
            contents.AppendLine(@"    # Please, Click [Auto Live Link] Button on right top corner, twice(toggle). If not paint line.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    -----------------");
            contents.AppendLine(@"");
            contents.AppendLine(@"    TRANSITION ENTRY INSERT");
            contents.AppendLine(@"    FROM ""Base Layer""");
            contents.AppendLine(@"    TO ""Base Layer\.Foo""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # [Entry] からステートへトランジションを引きます。");
            contents.AppendLine(@"    # Add a transition from [Entry] to a state.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # もし再描画されないなら、アニメーション・コントローラーの右上の[Auto Live Link]ボタンを２回押してください。");
            contents.AppendLine(@"    # Please, Click [Auto Live Link] Button on right top corner, twice(toggle). If not paint line.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    -----------------");
            contents.AppendLine(@"");
            contents.AppendLine(@"    TRANSITION EXIT INSERT");
            contents.AppendLine(@"    FROM ""Base Layer\.Foo""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # ステートから [Exit] へトランジションを引きます。");
            contents.AppendLine(@"    # Add a transition from a state to [Exit].");
            contents.AppendLine(@"");
            contents.AppendLine(@"    -----------------");
            contents.AppendLine(@"");
            contents.AppendLine(@"    TRANSITION UPDATE");
            contents.AppendLine(@"    SET exitTime 1.0 duration 0");
            contents.AppendLine(@"    FROM ""Base Layer\.Cat""");
            contents.AppendLine(@"    TO   ""Base Layer\.Dog""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # トランジションのプロパティーを更新します。");
            contents.AppendLine(@"    # Update a transition properties.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    -----------------");
            contents.AppendLine(@"");
            contents.AppendLine(@"    TRANSITION DELETE");
            contents.AppendLine(@"    FROM ""Base Layer\.Cat""");
            contents.AppendLine(@"    TO   ""Base Layer\.Dog""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # トランジションを削除します。");
            contents.AppendLine(@"    # Delete a transition.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    -----------------");
            contents.AppendLine(@"");
            contents.AppendLine(@"    TRANSITION SELECT");
            contents.AppendLine(@"    FROM "".*""");
            contents.AppendLine(@"    TO   "".*""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # 該当するトランジションをCSV形式ファイルに一覧します。");
            contents.AppendLine(@"    # List some transitions and write a csv file.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    TRANSITION SELECT");
            contents.AppendLine(@"    FROM "".*""");
            contents.AppendLine(@"    TO   "".*""");
            contents.AppendLine(@"    THE  Zoo1");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # 出力先ファイル名に Zoo1 を付加します。");
            contents.AppendLine(@"    # Add Zoo1 to output file name.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    =================");
            contents.AppendLine(@"");
            contents.AppendLine(@"(3) FROM 句 と TO 句");
            contents.AppendLine(@"(3) FROM or TO phrase");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # 正規表現で書いてください。");
            contents.AppendLine(@"    # Regular Expression.");
            contents.AppendLine(@"    FROM ""Base Layer\.Cat""");
            contents.AppendLine(@"    TO   ""Base Layer\.Dog""");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # タグ (""AND"" 操作)");
            contents.AppendLine(@"    # Tag (""AND"" operation)");
            contents.AppendLine(@"    FROM TAG ( Alpha Beta )");
            contents.AppendLine(@"    TO TAG ( Cee Dee )");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # - タグは Unityのタグではなく、StellaQLのタグです。 C#のソースに定数で書いておいてください。");
            contents.AppendLine(@"    # - Tag is not unity tags. It's StellaQL tags. Please, read C# program. It's const string.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # - スペース区切り。");
            contents.AppendLine(@"    # - Space separated.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # - ( ) はすべてのタグ一致検索。");
            contents.AppendLine(@"    # - ( ) is choice everything words.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # - 入れ子可能。");
            contents.AppendLine(@"    # - Nest OK.");
            contents.AppendLine(@"    #   ((A B)(C D))");
            contents.AppendLine(@"");
            contents.AppendLine(@"    #   ただし");
            contents.AppendLine(@"    #   But,");
            contents.AppendLine(@"");
            contents.AppendLine(@"    #   ((A B)  C ) はダメ。");
            contents.AppendLine(@"    #   ((A B)  C ) is NG.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    #   ((A B) (C)) はＯＫ。");
            contents.AppendLine(@"    #   ((A B) (C)) is OK.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    -----------------");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # タグ (""OR"" 操作)");
            contents.AppendLine(@"    # Tag (""OR"" operation)");
            contents.AppendLine(@"    FROM TAG [ Alpha Beta ]");
            contents.AppendLine(@"    TO TAG [ Cee Dee ]");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # [ ] は、どれか１つでも一致検索。");
            contents.AppendLine(@"    # [ ] is choice anything words.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    -----------------");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # タグ (""NOT"" 操作)");
            contents.AppendLine(@"    # Tag (""NOT"" operation)");
            contents.AppendLine(@"    FROM TAG { Alpha Beta }");
            contents.AppendLine(@"    TO TAG { Cee Dee }");
            contents.AppendLine(@"");
            contents.AppendLine(@"    # { } は、１つも一致しない検索。");
            contents.AppendLine(@"    # { } is not choice everything words.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    =================");
            contents.AppendLine(@"");
            contents.AppendLine(@"(4) SET 句 (STATE 文の場合)");
            contents.AppendLine(@"(4) SET phrase (case of STATE statement)");
            contents.AppendLine(@"    ");
            contents.AppendLine(@"    SET name ""WhiteCat""");
            contents.AppendLine(@"        tag ""enjoy""");
            contents.AppendLine(@"        speed 1.23");
            contents.AppendLine(@"        speedParameterActive true");
            contents.AppendLine(@"        speedParameter ""Monday""");
            contents.AppendLine(@"        mirror true");
            contents.AppendLine(@"        mirrorParameterActive true");
            contents.AppendLine(@"        mirrorParameter ""Tuesday""");
            contents.AppendLine(@"        cycleOffset 4.56");
            contents.AppendLine(@"        cycleOffsetParameterActive true");
            contents.AppendLine(@"        cycleOffsetParameter ""Wednesday""");
            contents.AppendLine(@"        iKOnFeet true");
            contents.AppendLine(@"        writeDefaultValues false");
            contents.AppendLine(@"");
            contents.AppendLine(@"    -----------------");
            contents.AppendLine(@"");
            contents.AppendLine(@"(5) SET 句 (TRANSITION 文の場合)");
            contents.AppendLine(@"(5) SET phrase (case of TRANSITION statement)");
            contents.AppendLine(@"    ");
            contents.AppendLine(@"    SET solo true");
            contents.AppendLine(@"        mute true");
            contents.AppendLine(@"        hasExitTime true");
            contents.AppendLine(@"        exitTime 12.3");
            contents.AppendLine(@"        hasFixedDuration false");
            contents.AppendLine(@"        duration 4.56");
            contents.AppendLine(@"        offset 7.89");
            contents.AppendLine(@"        orderedInterruption false");
            contents.AppendLine(@"        tag ""excellent""");
            contents.AppendLine(@"        ");
            contents.AppendLine(@"");
            contents.AppendLine(@"    =================");
            contents.AppendLine(@"");
            contents.AppendLine(@"(6) その他");
            contents.AppendLine(@"(6) Other");
            contents.AppendLine(@"");
            contents.AppendLine(@"    CSHARPSCRIPT GENERATE_FULLPATH");
            contents.AppendLine(@"");
            contents.Append(@"    # ["); contents.Append(StateCmdline.BUTTON_LABEL_GENERATE_FULLPATH); contents.AppendLine("]ボタンを押下するのと同じです。");
            contents.Append(@"    # Same as pressing a ["); contents.Append(StateCmdline.BUTTON_LABEL_GENERATE_FULLPATH); contents.AppendLine("] button.");
            contents.AppendLine(@"");
            contents.AppendLine(@"    =================");
            contents.AppendLine(@"");
            contents.AppendLine(@"サンキュー☆（＾▽＾）");
            contents.AppendLine(@"Thank you:-)");
            contents.AppendLine(@"");
            contents.AppendLine(@"    ステラ キューエル");
            contents.AppendLine(@"    StellaQL");
            contents.AppendLine(@"");
            contents.AppendLine(@"    (ステートマシン コマンドライン)");
            contents.AppendLine(@"    (State Machine Command Line)");
            contents.AppendLine(@"");
            contents.AppendLine(@"    著作(C) TAKAHASHI satoshi / 2017年");
            contents.AppendLine(@"    (C) TAKAHASHI satoshi / 2017");
            contents.AppendLine(@"");
            contents.AppendLine(@"    日本在住");
            contents.AppendLine(@"    From    Japan");
            contents.AppendLine(@"");
            contents.AppendLine(@"    https://github.com/muzudho/KifuwarabeFighter2");
        }
    }
}
