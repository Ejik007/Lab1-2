object Progress: TProgress
  Left = 432
  Top = 550
  BorderIcons = [biMinimize, biMaximize]
  BorderStyle = bsSingle
  Caption = #1046#1076#1080#1090#1077'...'
  ClientHeight = 37
  ClientWidth = 371
  Color = clSkyBlue
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  PixelsPerInch = 96
  TextHeight = 13
  object Gauge1: TGauge
    Left = 8
    Top = 8
    Width = 353
    Height = 17
    ForeColor = clBlue
    Progress = 0
  end
end
