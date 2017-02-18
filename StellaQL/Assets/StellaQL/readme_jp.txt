//-----------------------------------------------------------------------------
// State Machine Query StellaQL
// (C) 2017 Dojin Circle Grayscale
// Version 1
//-----------------------------------------------------------------------------
State Machine Query StellaQL �́A�X�e�[�g�}�V���ł̖c��ȃg�����W�V�����̒ǉ��A
����с@�c��ȃf�[�^�̒��̕s��T���ɑ΂��āA��Ƃ̍������̉\����񎦂���
�c�[���ł��B�Q�[���J���̐��Y���������������̂ł��B

�ȉ��̃T�C�g�ł̓I�[�v���\�[�X�Ƃ��Ė����z�z���Ă��܂��B
https://github.com/muzudho/StellaQL

�������A�L���ł��w�����Ă����������ƂŊJ���̏����ɂȂ�܂��B


[�N�G���[�����K�\��]
�������������܂��B�Ⴆ�Έȉ��̃N�G���[�����s�����ꍇ�A

  # Foo���疼�O��N���܂ނ��̂�
  TRANSITION INSERT
  FROM "Base Layer\.Foo"
  TO   "Base Layer\..*[Nn].*"

Foo�X�e�[�g���疼�O��N���܂ޕ����̃X�e�[�g�ɑ΂��ăg�����W�V������������܂��B

[�N�G���[���^�O]
������������ɏ����܂��B���O�̑��ɁAStellaQL�Ǝ��̕��@�ŁAUnity�Ƃ͈قȂ�^�O
�i����͒P�ɕ�����j�𕡐��A�X�e�[�g�Ɏ������邱�Ƃ��ł��܂��B�Ⴆ��
���������K�v�ł����ȉ��̃N�G���[�����s�����ꍇ�A

  # �^�O Exs�AUai�AZi �����X�e�[�g��
  TRANSITION INSERT
  FROM "Base Layer\.Foo"
  TO TAG [ Eks Uai Zi ]

Foo�X�e�[�g����Ǝ��̃^�O Eks�AUai�AZi �̂����ꂩ�P�ł��������̃X�e�[�g��
�΂��Ĉ�ĂɃg�����W�V������������܂��B����ɂ��A�Ӗ��I�ɐ������̎w����
�ł��邱�Ƃ����҂ł��܂��B

[�X�v���b�h�V�[�g]
�ԈႦ�Ă��鐔���̐ݒ��ڎ��m�F���ĒT�����Ƃ������܂��B
�����̃c�[�� LibreOffice Calc ��p�����}�N���E�A�v���P�[�V������p�ӂ��܂����B
StellaQL ���g���� CSV�������o���A�X�v���b�h�V�[�g�̃}�N�����g���� CSV������
�V�[�g���쐬���܂��B�i������r���[�ƌĂԂƂ��܂��j

�r���[�ł͂������̃v���p�e�B�[���ҏW�\�ɂȂ��Ă���AOld��ł͌��݂̒l��
�m�F�ł��ANew��ɂ͕ҏW�������l�����܂��B
�}�N�������s����{�^�����������ƂŁ@�C���|�[�g�p��CSV���쐬���܂��B
�����StellaQL���Ǎ��ނ��ƂŃv���p�e�B�[���X�V�ł��܂��B

���g�p���@

StellaQL/StellaQL_Document �t�H���_�[�ɂ������J�����ł�PNG�摜�AGIF�����
�Y�t���Ă��܂��B

(1)StellaQL/Assets/StellaQL �t�H���_�[���A���Ȃ��� Assets�t�H���_�[�̒�����
�u���Ă��������B

���̂Ƃ��AAssets/StellaQL/StellaQLUserSettings.cs �t�@�C����
StellaQL�t�H���_�[�̊O�i�Ⴆ��Assets�t�H���_�[�̒����j�Ɉړ�������
�����Ă��������B

(2)Unity�̃��j���[����[Window] - [State Machine Query (StellaQL)]��I�сA
StateMachineQueryStellaQL�E�B���h�E���h�b�L���O�����Ă��������B

(3)Assets/StellaQL/MayBeDeletedThisFolder/AnimatorControllers/Demo_Zoo
�t�@�C�����J���Ă��������B
�iC#�X�N���v�g�ł͂Ȃ��A�A�j���[�^�[�E�R���g���[���[�̕��ł��j

(4)�܂��ADemo_Zoo�A�j���[�^�[�E�R���g���[���[���A
StateMachineQueryStellaQL�E�B���h�E��[Animator Controller Drag & Drop]��
������Ă���G���A�Ƀh���b�O���h���b�v���Ă��������B
���̃h���b�O���h���b�v��Unity���ċN�����邽�тɕK�v�ł��B

StellaQL�͑��슮���̂��тɃQ�[���̍Đ��{�^���������܂����A����͉�ʍĕ`���
���߂ł��BStellaQL���Đ��{�^�����������сA�Đ��{�^���������߂��Ă��������B

(5)[Generate C# (Fullpath of states)]�{�^���������Ă��������B

Assets/StellaQL/MayBeDeletedThisFolder/AnimatorControllers/Demo_Zoo_Abstract.cs
�t�@�C����������������܂��B

���̃{�^���������^�C�~���O�́A�X�e�[�g��ǉ��A�폜��������
�o���Ă����Ă��������B���̂悤�ȃR�[�h��������������܂��B

    public const string
        BASELAYER_ = "Base Layer.",
        BASELAYER_ALPACA = "Base Layer.Alpaca",
        BASELAYER_BEAR = "Base Layer.Bear",
        BASELAYER_CAT = "Base Layer.Cat",
        // �ȉ���

���̎����������ꂽ���ۃN���X���p�����č�����̂������t�H���_�[�ɂ���
Demo_Zoo.cs �t�@�C���ł��B���̃t�@�C���͏㏑������܂���̂ŁA���Ȃ��̐ݒ��
�������ނ̂Ɏg���܂��B���ɂ�

    public const string
        TAG_EI      = "Ei",     // A(ei)
        TAG_BI      = "Bi",     // B(bi)
        TAG_SI      = "Si",     // C(si)
        // �ȉ���

�Ƃ������悤�� StellaQL �œƎ��ɗ��p����^�O�̒�`�ƁA

    SetTag(BASELAYER_ALPACA ,new[] { TAG_EI ,TAG_SI ,TAG_EL ,TAG_PI });
    SetTag(BASELAYER_BEAR   ,new[] { TAG_EI ,TAG_BI ,TAG_I  ,TAG_AR });
    SetTag(BASELAYER_CAT    ,new[] { TAG_EI ,TAG_SI ,TAG_TI         });
    // �ȉ���

�Ƃ������悤�ȁA�^�O�t����������Ă��܂��B

Demo_Zoo�����ł͂Ȃ��A���Ȃ��̃A�j���[�^�[�E�R���g���[���[��StellaQL��
�g���ꍇ�������悤�� �����������ꂽ���ۃN���X���p�����ăN���X������Ă��������B

(6)�����قǂ�(2)�ňړ������� StellaQLUserSettings.cs �t�@�C�����J���Ă��������B

  { "Assets/StellaQL/MayBeDeletedThisFolder/AnimatorControllers/Demo_Zoo.controller",
        StellaQL.Acons.Demo_Zoo.AControl.Instance },

�Ƃ������s������܂��B����́@�A�j���[�^�[�E�R���g���[���[�ƁA(6)�ŗp�ӂ���
�p���N���X�̃C���X�^���X��R�Â�����̂ł��B
���Ȃ��̃A�j���[�^�[�E�R���g���[���[�ƁA�p���N���X�������ɒǋL���Ă��������B

����ŏ��������ł��B

(7)Assets/StellaQL/Document/�`���[�g���A��.txt �ɂ̓`���[�g���A����p�ӂ��܂����B
�N�G���[�̎��s���@�͂�������Q�Ƃ��Ă��������B

Assets/StellaQL/Document/�R�}���h���t�@�����X.txt �ɂ͗��p�ł���N�G���[�̋@�\��
�ꗗ���܂����B

�܂��AStellaQL/StellaQL/Work/StellaQL_MacroApplication.ods �t�@�C����
LibreOffice Calc �ŊJ�����Ƃ��ł��܂��B

    LibreOffice : https://www.libreoffice.org/

CSV�̓ǎ�A�r���[�̍쐬�̎菇�� StellaQL_MacroApplication.ods �̒���
�L�ڂ��Ă��܂��B

���o�[�W��������

1
- �����o�[�W����


���肪�Ƃ��������܂����B