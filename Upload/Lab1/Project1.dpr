program Project1;

uses
  Forms,
  Unit1 in 'Unit1.pas' {Form1},
  Unit3 in 'Unit3.pas' {frmSplash},
  ufrmAbout in 'ufrmAbout.pas' {AboutBox};

{$R *.res}

begin
  Application.Initialize;
  Application.Title := 'ИО Лабораторная работа №1';
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TAboutBox, AboutBox);
  Application.Run;
end.
