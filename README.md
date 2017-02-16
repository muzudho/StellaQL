#ステラキューエル StellaQL
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

#価格 Price
無料。  
Free.  

- 任意で作者に寄付することもできます。  
Optionally you can donate to the author.  

Payment : https://enty.jp/grayscale  
![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702160807a2b.png?raw=true)  

Wishlist : https://www.amazon.co.jp/gp/registry/wishlist/1VWBU6FPLQC3W/ref=nav_wishlist_lists_1

#ライセンス License
オープンソースです。  
Open source.  

Copyright (c) 2017 TAKAHASHI Satoshi (Handle: Muzudho)(Dojin circle: "Grayscale")  
Released under the MIT license  
http://opensource.org/licenses/mit-license.php  

#導入方法 How to install.
(1) Git Hub の [Clone or download] - Download ZIP ボタンをクリックしてください。  
Click the [Clone or download] - Download ZIP button on Git Hub.  

![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702160807a1b.png?raw=true)  

(2) ダウンロードしたファイルを解凍してください。  
Decompression the downloaded file.   

ex.) 7zip : http://www.7-zip.org/  

(3) StellaQL-master/StellaQL/StellaQL_MacroApplication.ods ファイルを、あなたのプロジェクト・フォルダーにコピーしてください。  
Copy the StellaQL-master / StellaQL / StellaQL_MacroApplication.ods file to your project folder.  
![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702160428gif85.gif?raw=true)  

required.) LibreOffice Calc (Free) : http://www.libreoffice.org/  

(4) StellaQL-master/StellaQL/Assets/StellaQL フォルダーを、 Assets フォルダーの下にコピーしてください。  
StellaQL-master/StellaQL/Assets/StellaQL folder to Assets folder.  
![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702151752gif81.gif?raw=true)  

- No  StellaQL-master/StellaQL/
- Yes StellaQL-master/StellaQL/Assets/StellaQL

(5) メニューから [Window] - [State Machine Command line (StellaQL)] をクリックし、ウィンドウをドッキングさせてください。  
[Window] - [State Machine Command line (StellaQL)], And docking window.  
![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702151752gif82.gif?raw=true)  
                                     

(6) Assets/AnimatorControllers/Demo_Zoo をダブルクリックしてください。  
Double click Assets/AnimatorControllers/Demo_Zoo.  
![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702160428gif83.gif?raw=true)  

(7) [Tutorial (チュートリアル)] ボタンをクリックしてください。  
Please click the [Tutorial] button.  
![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702160428gif84.gif?raw=true)  

#あなた用の設定 Settings for you
あなたのアニメーター・コントローラーで StellaQL を使う方法  
How to use StellaQL with your animator controller  

(1) あなたのアニメーター・コントローラー・ファイル（.controller）を、StateCmdline ウィンドウの [Animator Controller Drag & Drop]エリアにドラッグ＆ドロップしてください。  
Drag and drop your animator controller file (.controller) into the [Animator Controller Drag & Drop] area of the StateCmdline window.  

[Generate C# (Fullpath of all states)]ボタンを押してください。  
Please press the Generate C # (Fullpath of all states) button.  

アニメーター・コントローラー・ファイルと同じフォルダに、抽象クラスが自動で生成されます。  
An abstract class is automatically generated in the same folder as the animator controller file.  

![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702160428gif86.gif?raw=true)  

(2) Demo_Zoo.cs ファイルを参考に、自動生成された抽象クラスを継承して、クラスを作ってください。  
Please refer to the Demo_Zoo.cs file, inherit the automatically generated abstract class and create a class.  

![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702160807a7b.png?raw=true)  

(3) Assets/StellaQL/StellaQLUserSettings.cs ファイルを開いてください。  
Open the Assets/StellaQL/StellaQLUserSettings.cs file.  

アニメーター・コントローラー・ファイルのパスと、作った継承クラスのペアを追加してください。  
Add the animator controller file path and the inherited class pair you created.  

Assets/StellaQL/StellaQLUserSettings.cs ファイルは、StellaQLのフォルダーを差し替えるときに消してしまいやすいので注意して扱いましょう。  
The Assets/StellaQL/StellaQLUserSettings.cs file is easy to erase when replacing the StellaQL folder, so treat it carefully.  

StellaQLフォルダーの外に出しておくといいでしょう。
It's a good idea to put it outside the StellaQL folder.

![Animation.gif](https://github.com/muzudho/StellaQL/blob/master/img/2017-02/201702160807a8b.png?raw=true)  

(4) **これで準備完了です。** Demo_Zoo と同じように StellaQL を使って扱えます。  
**You are ready.** You can handle it using StellaQL just like Demo_Zoo.  

