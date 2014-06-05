object Form1: TForm1
  Tag = 1
  Left = 320
  Top = 101
  Width = 692
  Height = 558
  Caption = #1048#1054' '#1051#1072#1073#1086#1088#1072#1090#1086#1088#1085#1072#1103' '#1088#1072#1073#1086#1090#1072' '#8470'1'
  Color = clSkyBlue
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnCreate = FormCreate
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object Chart1: TChart
    Left = 0
    Top = 201
    Width = 684
    Height = 330
    BackWall.Brush.Color = clWhite
    BackWall.Color = clWhite
    LeftWall.Brush.Color = clWhite
    LeftWall.Color = clWhite
    MarginBottom = 2
    MarginLeft = 2
    MarginRight = 2
    MarginTop = 2
    Title.Alignment = taRightJustify
    Title.Text.Strings = (
      '')
    BackColor = clWhite
    BottomAxis.Automatic = False
    BottomAxis.AutomaticMinimum = False
    BottomAxis.ExactDateTime = False
    BottomAxis.Increment = 0.010000000000000000
    Chart3DPercent = 1
    LeftAxis.Automatic = False
    LeftAxis.AutomaticMinimum = False
    LeftAxis.ExactDateTime = False
    LeftAxis.Increment = 0.010000000000000000
    Legend.ColorWidth = 70
    Legend.TopPos = 17
    View3D = False
    Align = alClient
    Color = clWhite
    TabOrder = 0
  end
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 684
    Height = 201
    Align = alTop
    Color = clSkyBlue
    TabOrder = 1
    object GroupBox1: TGroupBox
      Left = 8
      Top = 8
      Width = 329
      Height = 153
      Caption = #1055#1072#1088#1072#1084#1077#1090#1088#1099' '#1089#1080#1089#1090#1077#1084#1099
      TabOrder = 0
      object Label1: TLabel
        Left = 16
        Top = 24
        Width = 184
        Height = 13
        Caption = #1048#1085#1090#1077#1085#1089#1080#1074#1085#1086#1089#1090#1100' '#1087#1086#1089#1090#1091#1087#1083#1077#1085#1080#1103' '#1079#1072#1103#1074#1086#1082
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label2: TLabel
        Left = 16
        Top = 56
        Width = 153
        Height = 13
        Caption = #1063#1080#1089#1083#1086' '#1082#1072#1085#1072#1083#1086#1074' '#1086#1073#1089#1083#1091#1078#1080#1074#1072#1085#1080#1103
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label3: TLabel
        Left = 16
        Top = 120
        Width = 113
        Height = 13
        Caption = #1063#1080#1089#1083#1086' '#1084#1077#1089#1090' '#1074' '#1086#1095#1077#1088#1077#1076#1080
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label4: TLabel
        Left = 16
        Top = 88
        Width = 193
        Height = 13
        Caption = #1048#1085#1090#1077#1085#1089#1080#1074#1085#1086#1089#1090#1100' '#1086#1073#1089#1083#1091#1078#1080#1074#1072#1085#1080#1103' '#1079#1072#1103#1074#1086#1082
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Edit1: TEdit
        Left = 248
        Top = 21
        Width = 65
        Height = 21
        TabOrder = 0
        Text = '6'
      end
      object Edit2: TEdit
        Left = 248
        Top = 53
        Width = 65
        Height = 21
        TabOrder = 1
        Text = '2'
      end
      object Edit3: TEdit
        Left = 248
        Top = 117
        Width = 65
        Height = 21
        TabOrder = 2
        Text = '4'
      end
      object Edit4: TEdit
        Left = 248
        Top = 85
        Width = 65
        Height = 21
        TabOrder = 3
        Text = '3'
      end
    end
    object Button1: TButton
      Left = 8
      Top = 168
      Width = 105
      Height = 25
      Caption = #1047#1072#1087#1091#1089#1082
      TabOrder = 1
      OnClick = Button1Click
    end
    object Button2: TButton
      Left = 232
      Top = 168
      Width = 105
      Height = 25
      Caption = #1054' '#1087#1088#1086#1075#1088#1072#1084#1084#1077
      TabOrder = 2
      OnClick = Button2Click
    end
    object Button3: TButton
      Left = 120
      Top = 168
      Width = 105
      Height = 25
      Caption = #1057#1086#1093#1088#1072#1085#1080#1090#1100
      Enabled = False
      TabOrder = 3
      OnClick = Button3Click
    end
    object GroupBox2: TGroupBox
      Left = 344
      Top = 8
      Width = 329
      Height = 153
      Caption = #1055#1072#1088#1072#1084#1077#1090#1088#1099' '#1080#1085#1090#1077#1075#1088#1080#1088#1086#1074#1072#1085#1080#1103' '#1080' '#1089#1073#1086#1088#1072' '#1089#1090#1072#1090#1080#1089#1090#1080#1082#1080
      TabOrder = 4
      object Label6: TLabel
        Left = 16
        Top = 24
        Width = 105
        Height = 13
        Caption = #1064#1072#1075' '#1080#1085#1090#1077#1075#1088#1080#1088#1086#1074#1072#1085#1080#1103
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Label7: TLabel
        Left = 16
        Top = 56
        Width = 113
        Height = 13
        Caption = #1064#1072#1075' '#1089#1073#1086#1088#1072' '#1089#1090#1072#1090#1080#1089#1090#1080#1082#1080
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
      end
      object Edit5: TEdit
        Left = 248
        Top = 21
        Width = 65
        Height = 21
        TabOrder = 0
        Text = '0,001'
      end
      object Edit7: TEdit
        Left = 248
        Top = 53
        Width = 65
        Height = 21
        TabOrder = 1
        Text = '0,1'
      end
    end
  end
  object SaveDialog1: TSaveDialog
    DefaultExt = 'txt'
    Filter = #1060#1072#1081#1083#1099' '#1089#1090#1072#1090#1080#1089#1090#1080#1082#1080' '#1080' '#1080#1079#1086#1073#1088#1072#1078#1077#1085#1080#1081' (*.txt, *.bmp)|*.txt;*.bmp'
    Options = [ofOverwritePrompt]
    Left = 344
    Top = 168
  end
end
