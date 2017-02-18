# Table of content
- [What is StellaQL?](#what-is-stellaql) ステラキューエルとは？
- [Price is free](#price-is-free) 無料です
- [License is MIT license](#license-is-mit-license) MIT ライセンスです
- [How to install](#how-to-install) 導入方法
- [Settings for use with your Unity project](#settings-for-use-with-your-unity-project) あなたのUnityプロジェクトで使うための設定
- [Command reference (brief introduction)](#command-reference-brief-introduction) コマンドリファレンス（簡単な紹介）

# What is StellaQL?
**ステラキューエルとは？**  

Unityのアニメーター・コントローラーを編集するツールです。  
It is a tool to edit Unity's animator controller.  

- クエリー風の操作で更新できます。  
It can be updated by query-like operation.  

![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702160552a8b.png?raw=true)  

- いくつかのフィールドを、スプレッドシートを用いて、一覧、更新できます。  
Several fields can be updated, list, updated using spreadsheet.  

![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702160552a9b.png?raw=true)  

![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702160552a10b.png?raw=true)  

免責  
Disclaimer  

- エラー等で中断した際に、データは復元しません。データのバックアップを残しておいてください。  
There is no rollback at error suspension. Please keep a backup of your data.  

![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702110107a41b.png?raw=true)  

# Price is free
**価格は無料です。**  

- 任意で作者に寄付することもできます。  
Optionally you can donate to the author.  

Payment : https://enty.jp/grayscale  
![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702160807a2b.png?raw=true)  

Wishlist : https://www.amazon.co.jp/gp/registry/wishlist/1VWBU6FPLQC3W/ref=nav_wishlist_lists_1

# License is MIT license
**ライセンス**  

オープンソースです。  
Open source.  

Copyright (c) 2017 TAKAHASHI Satoshi (Handle: Muzudho)(Dojin circle: "Grayscale")  
Released under the MIT license  
http://opensource.org/licenses/mit-license.php  

# How to install
**導入方法**  

(1) Git Hub の [Clone or download] - Download ZIP ボタンをクリックしてください。  
Click the [Clone or download] - Download ZIP button on Git Hub.  

![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702160807a1b.png?raw=true)  

(2) ダウンロードしたファイルを解凍してください。  
Decompression the downloaded file.   

ex.) 7zip : http://www.7-zip.org/  

(3) StellaQL-master/StellaQL/Assets/StellaQL フォルダーを、 Assets フォルダーの下にコピーしてください。  
StellaQL-master/StellaQL/Assets/StellaQL folder to Assets folder.  
![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702151752gif81.gif?raw=true)  

- No  StellaQL-master/StellaQL/
- Yes StellaQL-master/StellaQL/Assets/StellaQL

(4) メニューから [Window] - [State Machine Command line (StellaQL)] をクリックし、ウィンドウをドッキングさせてください。  
[Window] - [State Machine Command line (StellaQL)], And docking window.  
![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702151752gif82.gif?raw=true)  
                                     

(5) Assets/MayBeDeletedThisFolder/AnimatorControllers/Demo_Zoo をダブルクリックしてください。  
Double click Assets/AnimatorControllers/Demo_Zoo.  
![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702160428gif83.gif?raw=true)  

(6) チュートリアルは Assets/StellaQL/Document/チュートリアル.txt に書いてあります。

# Settings for use with your Unity project
**あなたのUnityプロジェクトで使うための設定**  

あなたのアニメーター・コントローラーで StellaQL を使う方法  
How to use StellaQL with your animator controller  

(1) あなたのアニメーター・コントローラー・ファイル（.controller）を、StateCmdline ウィンドウの [Animator Controller Drag & Drop]エリアにドラッグ＆ドロップしてください。  
Drag and drop your animator controller file (.controller) into the [Animator Controller Drag & Drop] area of the StateCmdline window.  

[Generate C# (Fullpath of states)]ボタンを押してください。  
Please press the Generate C # (Fullpath of states) button.  

アニメーター・コントローラー・ファイルと同じフォルダに、抽象クラスが自動で生成されます。  
An abstract class is automatically generated in the same folder as the animator controller file.  

![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702160428gif86.gif?raw=true)  

(2) Demo_Zoo.cs ファイルを参考に、自動生成された抽象クラスを継承して、クラスを作ってください。  
Please refer to the Demo_Zoo.cs file, inherit the automatically generated abstract class and create a class.  

![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702160807a7b.png?raw=true)  

(3) Assets/StellaQL/StellaQLUserSettings.cs ファイルを StellaQLフォルダーの外に出して、開いてください。  
Please put the Assets/StellaQL/StellaQLUserSettings.cs file out of the StellaQL folder and open it.  

![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702170817gif87.gif?raw=true)  

(4) アニメーター・コントローラー・ファイルのパスと、作った継承クラスのペアを追加してください。  
Add the animator controller file path and the inherited class pair you created.  

![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702170820a11b.png?raw=true)  

(5) **これで準備完了です。** Demo_Zoo と同じように StellaQL を使って扱えます。  
**You are ready.** You can handle it using StellaQL just like Demo_Zoo.  

# Command reference (brief introduction)
**コマンドリファレンス(簡単な紹介)** 
- [Add State](#Add-State) ステートの追加
- [State update](#State-update) ステートの更新
- [List of states](#List-of-states) ステートの一覧
- [Delete state](#Delete-state) ステートの削除
- [Add a transition](#Add-a-transition) トランジションの追加
- [Add transition from Any state](#Add-transition-from-Any-state) Any Stateからトランジションの追加
- [Add transition from Entry](#Add-transition-from-Entry) Entryからトランジションの追加
- [Add transition to Exit](#Add-transition-to-Exit) Exitへトランジションの追加
- [Transition update](#Transition-update) トランジションの更新
- [Delete transition](#Delete-transition) トランジションの削除
- [List of transitions](#List-of-transitions) トランジションの一覧

## Add State
**ステートの追加**  

    STATE INSERT
    WORDS
        WhiteAlpaca
        "White Bear"
        "\"White\" Cat"
        "White\\Gray\\Black Dog"
    WHERE "Base Layer"

WhiteAlpaca、White Bear、"White" Cat、White\Gray\Black Dog の４つのステートを作成します。  
Create four states of WhiteAlpaca, White Bear, "White" Cat, White\Gray\Black Dog.  

## State update
**ステートの更新**  

    STATE UPDATE
    SET
        speed                1.23
        speedParameterActive true
        speedParameter       4.5
    WHERE
        "Base Layer\.Cat"

Base Layer.Catステートのプロパティーを更新します。  
Update the properties of Base Layer.Cat state.  

## List of states
**ステートの一覧**  

    STATE SELECT
    WHERE
        ".*(White).*"
    THE
        White_Animals001

フルパスにWhiteを含むステートを一覧します。  
List states including White in the full path.  

## Delete state
**ステートの削除**  

    STATE DELETE
    WORDS
        ".*(White).*"
    WHERE
        "Base Layer"

箱のラベルにWhiteを含むステートを削除します。  
Delete the state containing White in the label of the box.  

## Add a transition
**トランジションの追加**  

    TRANSITION INSERT
        FROM
            "Base Layer\.Cat"
        TO
            "Base Layer\.Dog"

Base LayerのCatステートからDogステートへトランジションを引きます。  
Draw the transition from the Cat state of the Base Layer to the Dog state.  

## Add transition from Any state
**Any Stateからトランジションの追加**  

    TRANSITION ANYSTATE INSERT
    FROM
        "Base Layer"
    TO
        "Base Layer\.Foo"

Base LayerのAny Stateから Fooステートへトランジションを引きます。  
Draw transition from Any State of Base Layer to Foo state.  

## Add transition from Entry
**Entryからトランジションの追加**  

    TRANSITION ENTRY INSERT
    FROM
        "Base Layer"
    TO
        "Base Layer\.Foo"

Base LayerのEntryから Fooステートへトランジションを引きます。  
Draw transition from Base Layer Entry to Foo state.  

## Add transition to Exit
**Exitへトランジションの追加**  

    TRANSITION EXIT INSERT
    FROM
        "Base Layer\.Foo"

Base LayerのFooステートから Exitへトランジションを引きます。  
Draw transition from Base Fayer's Foo state to Exit.  

## Transition update
**トランジションの更新**  

    TRANSITION UPDATE
    SET
        exitTime 1.0
        duration 0
    FROM
        "Base Layer\.Cat"
    TO
        "Base Layer\.Dog"

Base LayerのCatからDogへ引かれているトランジションのプロパティーを更新します。  
Update the properties of the transition drawn from Cat to Dog in Base Layer.  

## Delete transition
**トランジションの削除**  

    TRANSITION DELETE
    FROM
        "Base Layer\.Cat"
    TO
        "Base Layer\.Dog"

Base LayerのCatからDogへ引かれているトランジションを削除します。  
Delete the transition drawn from Cat to Dog in Base Layer.  

## List of transitions
**トランジションの一覧**  

    TRANSITION SELECT
    FROM
        ".*"
    TO
        ".*"
    THE
        All_Animals001

全てのトランジションを一覧します。  
List all the transitions.  


