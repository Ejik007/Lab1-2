unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, TeEngine, Series, ExtCtrls, TeeProcs, Chart, Unit3, ufrmAbout;

type
  TForm1 = class(TForm)
    Chart1: TChart;
    Panel1: TPanel;
    GroupBox1: TGroupBox;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Edit4: TEdit;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    SaveDialog1: TSaveDialog;
    GroupBox2: TGroupBox;
    Label6: TLabel;
    Edit5: TEdit;
    Label7: TLabel;
    Edit7: TEdit;
    procedure Button1Click(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

  tDblArray = array of double;

var
  Form1: TForm1;
  Lmd,Mu:double;
  M,N:integer;

implementation

function MyFloatToStr(v:double; tdigits:word; sdigits:word):string;
var
  s:string;
  i:integer;
begin
  s:=FloatToStrF(v,ffFixed,100,100);
  i:=pos(',',s);
  if sDigits>0 then
    if length(s)-i>sdigits then
      s:=copy(s,1,i+sdigits)
  else
    if i>0 then s:=copy(s,1,i-1);
  while length(s)<tdigits do s:=' '+s;
  if length(s)>tdigits then s:=copy(s,1,tdigits);
  Result:=s;
end;

{$R *.dfm}

//Возвращает вектор производных dp/dt в момент при p=CurP
function f(const CurP:tDblArray):tDblArray;
var
  i:integer;
  tmp:double;
begin
  SetLength(Result,n+m+1);
  for i:=0 to n+m do
    begin
      if i=0 then
        tmp:=-Lmd*CurP[0]+Mu*CurP[1];
      if (i>=1) and (i<n) then
        tmp:=-(Lmd+i*Mu)*CurP[i]+Lmd*CurP[i-1]+(i+1)*Mu*CurP[i+1];
      if (i>=n) and (i<n+m) then
        tmp:=-(Lmd+n*Mu)*CurP[i]+Lmd*CurP[i-1]+n*Mu*CurP[i+1];
      if i=n+m then
        tmp:=-n*Mu*CurP[i]+Lmd*CurP[i-1];
      Result[i]:=tmp;
    end;
end;

//Возвращает вектор, равный V1+V2*C
function VectAM(const V1,V2:tDblArray;C:double):tDblArray;
var
  i:integer;
begin
  SetLength(Result,Length(V1));
  for i:=0 to length(V1)-1 do
    Result[i]:=V1[i]+C*V2[i];
end;

procedure TForm1.Button1Click(Sender: TObject);
var
  P:tDblArray;
  K1,K2,K3,K4:tDblArray;
  h:double;
  hstat:double;
  t:double;
  j:integer;
  NewSeries:TChartSeries;
  delta:double;
  sumdelta:double;
  fout:textfile;
  statsum:double;
begin
  Button3.Enabled:=true;
  assignfile(fout,'out');
  rewrite(fout);
  Lmd:=StrToFloat(Edit1.Text);
  N:=StrToInt(Edit2.Text);
  M:=StrToInt(Edit3.Text);
  Mu:=StrToFloat(Edit4.Text);
  h:=StrToFloat(Edit5.Text);
  hstat:=StrToFloat(Edit7.Text);
  Chart1.Title.Text.Clear;
  Chart1.Title.Text.Add('Интенсивность входного потока: '+MyFloatToStr(Lmd,6,3));
  Chart1.Title.Text.Add('Число каналов обслуживания: '+MyFloatToStr(N,6,3));
  Chart1.Title.Text.Add('Интенсивность обслуживания заявок: '+MyFloatToStr(Mu,6,3));
  Chart1.Title.Text.Add('Число мест в очереди: '+MyFloatToStr(M,6,3));
  writeln(fout);
  writeln(fout,'Параметры системы');
  writeln(fout);
  writeln(fout,'Интенсивность входного потока: ',Lmd:8:5);
  writeln(fout,'Число каналов обслуживания: ',N);
  writeln(fout,'Интенсивность обслуживания заявок: ',Mu:8:5);
  writeln(fout,'Число мест в очереди: ',M);
  writeln(fout);
  writeln(fout,'Шаг интегрирования: ',h:8:5);
  writeln(fout);
  write(fout,'  Время   ');
  SetLength(p,n+m+1);
  //Добавление заголовков
  for j:=0 to Chart1.SeriesCount-1 do
      Chart1.Series[0].Free;
  for j:=0 to n+m do
    begin
      if j<=9 then
        write(fout,'     P'+IntToStr(j),'    ')
      else
        write(fout,'    P'+IntToStr(j),'    ');
      NewSeries:=TFastLineSeries.Create(nil);
      NewSeries.Name:='P'+IntToStr(j);
      NewSeries.ParentChart:=Chart1;
      if j=0 then
        p[j]:=1
      else
        p[j]:=0;
      NewSeries.AddXY(0,p[j]);
    end;
  writeln(fout); writeln(fout);
  t:=0;
  statsum:=0;
  repeat
    K1:=f(p);
    K2:=f(VectAm(P,K1,h/2));
    K3:=f(VectAm(P,K2,h/2));
    K4:=f(VectAm(P,K3,h));
    t:=t+h;
    if statsum+h<hstat then
      statsum:=statsum+h
    else
      statsum:=0;
    if statsum=0 then
      write(fout,t:8:5,'   ');
    sumdelta:=0;
    for j:=0 to n+m do
      begin
        delta:=h*(K1[j]+2*K2[j]+2*K3[j]+K4[j])/6;
        sumdelta:=sumdelta+abs(delta);
        p[j]:=p[j]+delta;
        Chart1.Series[j].AddXY(t,p[j]);
        if statsum=0 then
          write(fout,p[j]:8:5,'   ');
      end;
    if statsum=0 then
      writeln(fout);
  until (t>=100) or (sumdelta<h/10);
  closefile(fout);
end;

procedure TForm1.FormShow(Sender: TObject);
begin
  if Self.Tag=1 then
    begin
      Self.Tag:=0;
      frmSplash:=TfrmSplash.Create(Self);
      frmSplash.ShowModal;
      frmSplash.Free;
    end;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  AboutBox.Position:=poScreenCenter;
  AboutBox.ShowModal;
end;

procedure TForm1.Button3Click(Sender: TObject);
var
  fname:string;
begin
  if SaveDialog1.Execute then
    begin
      fname:=SaveDialog1.FileName;
      fname:=copy(fname,1,length(fname)-length(ExtractFileExt(fname)));
      Chart1.SaveToBitmapFile(fname+'.bmp');
      copyfile(pChar(ExtractFilePath(Application.ExeName)+'out'),pChar(fname+'.txt'),false);
    end;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  SaveDialog1.InitialDir:=ExtractFilePath(Application.ExeName);
end;

end.
