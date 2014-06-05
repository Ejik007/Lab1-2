unit ufrDistrLaw;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms, 
  Dialogs, StdCtrls,uDecl;

type
  TfrDistrLaw = class(TFrame)
    ComboBox1: TComboBox;
    Param1: TEdit;
    Param2: TEdit;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    procedure ComboBox1Change(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
    CurRandomType:TRandomType;
  end;

implementation

{$R *.dfm}

procedure TfrDistrLaw.ComboBox1Change(Sender: TObject);
begin
  CurRandomType:=TRandomType(ComboBox1.ItemIndex);
  case TRandomType(ComboBox1.ItemIndex) of
    rtDet:
      begin
        Label4.Visible:=false;
        Param2.Visible:=false;
        Label3.Caption:='Величина';
      end;
    rtEqual:
      begin
        Label4.Visible:=true;
        Param2.Visible:=true;
        label3.Caption:='Левая граница';
        label4.Caption:='Правая граница';
      end;
    rtGauss:
       begin
         Label4.Visible:=true;
         Param2.Visible:=true;
         label3.Caption:='Мат.ожидание';
         label4.Caption:='СКО';
       end;
    rtExp:
      begin
        Label4.Visible:=false;
        Param2.Visible:=false;
        label3.Caption:='Интенсивность';
      end;
    rtErlang:
      begin
        Label4.Visible:=true;
        Param2.Visible:=true;
        label3.Caption:='Интенсивность';
        label4.Caption:='Порядок';
     end;
    rtVb:
      begin
        Label4.Visible:=true;
        Param2.Visible:=true;
        label3.Caption:='Масштаб';
        label4.Caption:='Форма';
      end;
    end;
end;

end.
