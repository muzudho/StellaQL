﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace StellaQL
{
    public abstract class Tutorial
    {
        public static void ToContents(StringBuilder contents)
        {
            contents.Append(@"---------------------------------------------------------------
StellaQL チュートリアル
Tutorial of StellaQL
---------------------------------------------------------------
    作者  : 高橋 智史 (ハンドルネーム: むずでょ)
    Author: TAKAHASHI Satoshi (Handle. Muzudho)
---------------------------------------------------------------


手順1
Step 1

    あなたのUnityプロジェクトのバックアップは取っておいてください。
    Please keep a backup of your data.

    エラー等で中断した際、データの復元機能は付いていません。
    There is no rollback at error suspension.


手順2
Step 2

    既にやっていると思いますが、メニューから[Window] - [State Machine Command Line (StellaQL)] をクリックしてください。
    I think you are doing it already. [Window] - [State Machine Command Line (StellaQL)] is here.

");
            contents.AppendLine(@"");
            contents.AppendLine(@"手順3");
            contents.AppendLine(@"Step 3");
            contents.AppendLine(@"");
            contents.Append(@"    """); contents.Append(FileUtility_Engine.PATH_ANIMATOR_CONTROLLER_FOR_DEMO_TEST); contents.AppendLine(@"""ファイルを開いてださい。");
            contents.Append(@"    Please, open """); contents.Append(FileUtility_Engine.PATH_ANIMATOR_CONTROLLER_FOR_DEMO_TEST); contents.AppendLine(@""".");
            contents.AppendLine(@"");
            contents.Append(@"    また、その "); contents.Append(Path.GetFileName(FileUtility_Engine.PATH_ANIMATOR_CONTROLLER_FOR_DEMO_TEST)); contents.AppendLine(" ファイルを [Animation Controller Drag & Drop] 枠にドラッグ＆ドロップしてください。");
            contents.Append(@"    And Drag&Drop the "); contents.Append(Path.GetFileName(FileUtility_Engine.PATH_ANIMATOR_CONTROLLER_FOR_DEMO_TEST)); contents.AppendLine(" file to [Animation Controller Drag & Drop] box.");
            contents.AppendLine(@"");
            contents.Append(@"
手順4 (任意)
Step 4 (Option)

    始める前に、開発者が夜中に StellaQL を壊していないか、テストすることができます。
    Before you begin, developers can test whether they break StellaQL at midnight.

        [Window] - [Editor Tests Runner] ... [StellaQL] - [StellaQLTest].
        [Window] - [Editor Tests Runner] ... [StellaQL] - [StellaQLTest].

    そして [Run All]を押してください。チェックが全て緑色ならＯＫです。
    And [Run All]. Please, click is all greens.

    ただし、既に Demo_Zoo を編集していた場合は結果が異なります。
    However, if you have already edited Demo_Zoo, the result will be different.


手順5
Step 5

    次の文をクエリー・テキストボックスに入力してください。
    Please enter the following statement in the Query text box.

    TRANSITION INSERT
    FROM ""Base Layer\.Cat""
    TO   ""Base Layer\.Dog""

    そして、Executeボタンを押してください。
    Then press the Execute button.

    Base Layer.Catステートから Base Layer.Dog ステートへ線が引かれていることを確認してください。
    Please confirm that a line is drawn from Base Layer.Cat state to Base Layer.Dog state.


手順6
Step 6

    次の文をクエリー・テキストボックスに入力してください。
    Please enter the following statement in the Query text box.

    # Hi!
    TRANSITION INSERT
    FROM ""Base Layer\.Foo""
    TO   ""Base Layer\..*[Nn].*""

    そして、Executeボタンを押してください。
    Then press the Execute button.

    Fooステートから、名前に N が含まれるステートに線が引かれました。
    From the Foo state, a line was drawn in the state whose name contained N.


手順7
Step 7

    次の文をクエリー・テキストボックスに入力してください。
    Please enter the following statement in the Query text box.

    # Are you fine?
    TRANSITION SELECT FROM ""Base Layer\.Foo"" TO "".*"" THE Zoo001

    そして、Executeボタンを押してください。
    Then press the Execute button.

    プロジェクト・フォルダの中に CSVファイルが作られています。
    A CSV file is created in the project folder.

    フーから伸びている線が一覧されています。
    The lines extending from Foo are listed.


手順8
Step 8

    次の文をクエリー・テキストボックスに入力してください。
    Please enter the following statement in the Query text box.

    # I am a great tool!
    TRANSITION UPDATE
    SET
        exitTime 1.0
        duration 0
        tag ""Enjoy programming!""
    FROM
        ""Base Layer\.Foo""
    TO
        ""Base Layer\..*[Nn].*""

    そして、Executeボタンを押してください。
    Then press the Execute button.

    exitTime と duration が一斉に更新されました。
    ExitTime and duration were updated all at once.

    SELECT してみるのもいいでしょう。
    You may want to SELECT it.

    # Zoo001 to Zoo002
    TRANSITION SELECT FROM ""Base Layer\.Foo"" TO "".*"" THE Zoo002

    でも、こんな線要らないですね。
    But, I do not need this line.


手順9
Step 9

    次の文をクエリー・テキストボックスに入力してください。
    Please enter the following statement in the Query text box.

    # This line is a comment!
            TRANSITION DELETE
    FROM ""Base Layer\.Foo""
    TO   ""Base Layer\..*""

    そして、Executeボタンを押してください。
    Then press the Execute button.

    Foo ステートから伸びている線が全て消えました。
    All the lines extending from the Foo state disappeared.

    Cat ステートから Dog ステートへの線はつながったままなことを確認してください。
    Please confirm that the line from Cat state to Dog state remains connected.


手順10
Step 10

    次の文をクエリー・テキストボックスに入力してください。
    Please enter the following statement in the Query text box.

    STATE UPDATE
    SET
        speedParameterActive true
        speedParameter       ""New Float""
        speed                1.23
    WHERE
        ""Base Layer\.Cat""

    そして、Executeボタンを押してください。
    Then press the Execute button.

    Inspector ウィンドウを見てプロパティーが更新されていることを確認してください。
    Please check the Inspector window and make sure the properties are updated.


手順11
Step 11

    次の文をクエリー・テキストボックスに入力してください。
    Please enter the following statement in the Query text box.

    STATE INSERT
    WORDS
        WhiteAlpaca
        ""White Bear""
        ""\""White\"" Cat""
        ""White\\Gray\\Black Dog""
    WHERE ""Base Layer""

    そして、Executeボタンを押してください。
    Then press the Execute button.

    ステートが４つ作成されました。
    Four states have been created.


手順12
Step 12

    次の文をクエリー・テキストボックスに入力してください。
    Please enter the following statement in the Query text box.

    STATE DELETE
    WORDS
        "".*(White).*""
    WHERE
        ""Base Layer""

    そして、Executeボタンを押してください。
    Then press the Execute button.

    名前に White を含むステートが削除されました。
    A state including White in the name has been deleted.
");
            contents.AppendLine(@"");
            contents.AppendLine(@"サンキュー☆（＾ｑ＾）");
            contents.AppendLine(@"Thank you.");
        }
    }
}
