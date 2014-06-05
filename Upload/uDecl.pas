unit uDecl;

interface

uses SysUtils,windows;

type
  TRandomType=(rtDet,rtEqual,rtGauss,rtExp,rtErlang,rtVb);

function MyFloatToStr(v:double; tdigits:word; sdigits:word):string;
function MySqrt(v:double):double;

implementation

function MyFloatToStr(v:double; tdigits:word; sdigits:word):string;
var
  s:string;
  i:integer;
  format:TFormatSettings;
begin
  GetLocaleFormatSettings(LOCALE_SYSTEM_DEFAULT, format);
  s:=FloatToStrF(v,ffFixed,50,10);
  i:=pos(format.DecimalSeparator,s);
  if sDigits>0 then
    if length(s)-i>sdigits then
      s:=copy(s,1,i+sdigits)
  else
    if i>0 then s:=copy(s,1,i-1);
  while length(s)<tdigits do s:=' '+s;
  if length(s)>tdigits then s:=copy(s,1,tdigits);
  Result:=s;
end;

function MySqrt(v:double):double;
begin
  if v>0 then
    Result:=sqrt(v)
  else
    Result:=0;
end;

end.
