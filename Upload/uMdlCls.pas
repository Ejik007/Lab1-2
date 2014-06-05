unit uMdlCls;

interface

uses classes,sysutils, stdctrls,Math, uDecl;

type

  TPutType=(ptFirstFree,ptRandom,ptMinBusiness);

  TEventType=(mIncS,mDecS,mStat); //������������ ��� - ��� ���������� �������

  pModelEvent=^TModelEvent; //��������� �� ��������� �������
  pModelClass=^TModelClass; //��������� �� ������� ����� ���������� �������
  pRandomStream=^TRandomStream; //��������� �� ����� ��������������� �����

  pEventQueue=^TEventQueue; //��������� �� ������� ��������� �������

  pRequest=^TRequest;       //��������� �� ������

  TEventQueue=class                                   //������� ��������� �������
    FirstEvent:pModelEvent;                           //��������� �� ������ ������� �������
    CurrentTime:Double;                               //����� ���������� �������
    constructor Create;                               //����������� ������
    destructor Destroy; override;
    procedure AddEvent(const NewEvent:pModelEvent);   //�������� ������� � �������
    procedure Clear;
    function GetFirstEvent:pModelEvent;               //�������� ������ ������� �� �������
  end;

  pQueue=^TQueue;                 //��������� �� ������� ������
  pChannel=^TChannel;             //��������� �� ����� ������������

  TTracer=class
    OutMemo:TMemo;
    procedure Add(s:string);
  end;

  TModelClass=class               //������� ����� ���������� �������
    Tracer:TTracer;               //������ ����� ��� �����������
    ObjName:string;               //��� ������� (��� ����������)
    EventQueue:pEventQueue;       //������� ������� ������
    LastEvent:Double;             //����� ���������� �������
    AutoOutput:boolean;           //���� �������������� �������� ������
    AutoInput:boolean;            //���� ��������������� ������ ������
    constructor Create(ptrEventQueue:pEventQueue); virtual;         //����������� ������
    function HandleEvent(ModelEvent:pModelEvent):pointer; virtual; abstract; //����� ��������� �������
    procedure UpdateStatistic; virtual; abstract; //����� ���������� ����������
    procedure ResetStatistic; virtual; abstract;  //����� ��������� ����������
    procedure Reset; virtual; abstract;           //����� ������ �������
    procedure PutRequest(Request:pRequest); virtual; abstract;      //����� ���������� ������
    function GetRequest:pRequest; virtual; abstract;                //����� ��������� ������
  end;

  TChannel=class(TModelClass)   //����� ������������
    InObject:pModelClass;       //��������� �� �������, �� ������� ���������� ������
    OutObject:pModelClass;      //��������� �� �������, � ������� ��������� ������ ����� ���������
    Busy:boolean;               //���� ��������� ������
    BusyTime:double;            //�����, � ������� �������� ����� ��� �����
    FreeTime:double;            //�����, � ������� �������� ����� ��� ��������
    CRequest:pRequest;          //��������� �� �������������� ������
    ServeStream:pRandomStream;  //��������� �� ���,����������� ����� ������������
    function HandleEvent(ModelEvent:pModelEvent):pointer; override; //����� ��������� �������
    procedure PutRequest(Request:pRequest); override; //����� ���������� ������ � �����
    procedure UpdateStatistic; override;          //����� ���������� ����������
    procedure ResetStatistic;  override;          //����� ��������� ����������
    procedure Reset;           override;          //����� ������ �������
    constructor Create(ptrEventQueue:pEventQueue); override; //����������� ������
    procedure MakeRequest;
  end;

  pChannelList=^TChannelList;     //��������� �� ������ ������� ������������

  TChannelList=array of TChannel; //������ ������� ������������

  TQueue=class(TModelClass)     //������� ������
    ChannelList:pChannelList;   //������ ���������� �� ������
    CNum:integer;               //����� ������ � �������
    NumIn:integer;              //����� ������, ����������� � �������
    NumOut:integer;             //����� ������, �������� �� ������� �� ������������
    NumLeave:integer;           //����� ������, ���������� �������
    NumBlock:integer;           //����� ������, ���������� �����
    BusyStat:array of double;   //������ ��� ����� ���������� �� ���������
    MaxLength:integer;          //������������ ����� ������ � �������
    PutType:TPutType;           //�������� ������ ���������� ������
    FirstRequest:pRequest;      //��������� �� ������ ������ � �������
    LastRequest:pRequest;       //��������� �� ��������� ������ � �������
    IncomeStream:pRandomStream; //��������� �� ���,����������� ��������� ����� ��������� ������
    LeaveStream:pRandomStream;  //��������� �� ���,����������� ��������� ����� ������� ������
    LeaveQueue:pQueue;          //��������� �� �������, � ������� ������ ������
    AvgWait:double;             //������� ����� �������� � �������
    constructor Create(ptrEventQueue:pEventQueue); override;  //����������� ������
    function HandleEvent(ModelEvent:pModelEvent):pointer; override; //����� ��������� �������
    procedure CreateAddEvent;                     //����� �������� ������� ����������
    procedure SetMaxLength(NewLength:integer);    //����� ��������� ����� �������
    procedure UpdateStatistic; override;          //����� ���������� ����������
    procedure ResetStatistic;  override;          //����� ��������� ����������
    procedure Reset;           override;          //����� ������ �������
    procedure PutRequest(Request:pRequest); override;       //����� ���������� ������ � �������
    function GetRequest:pRequest; override;                //����� ��������� ������ �� �������

  end;

  TRequest=record           //��� - ������
    ID:integer;             //������������� (�����) ������
    Value:double;           //��� ������
    InTime:double;          //����� ����� ������ � �������
    Next,Prev:pRequest;     //��������� ��� ������������ ������� ������
    Location:TModelClass;   //��������� �� ������, � ������� ��������� ������
  end;

  TModelEvent=record        //��������� �������
    EventTime:Double;       //����� �������
    EventType:TEventType;   //��� ���������� �������
    pObject:TModelClass;    //��������� �� ������, � ������� ���������� �������
    pRequest:pRequest;      //��������� �� ������, ��������� � ��������
    NextEvent:pModelEvent;  //��������� �� ��������� ������� �������
  end;

  //����� ��������� �����
  TRandomStream=class
    LastInitNumber:longint;
    RSType:TRandomType;
    Par1,Par2:double;
    function GetNumber:double;
    function GetBaseNumber:double;
    procedure Init(Number:longint);
  end;

function CreateRequest(ID:integer; Value:double):pRequest;  

implementation

//������������� ���
procedure TRandomStream.Init(Number:longint);
begin
  LastInitNumber:=Number;
end;

//��������� ���������� ����� �� ���
function TRandomStream.GetBaseNumber:double;
begin
  RandSeed:=LastInitNumber;
  Result:=random;
  LastInitNumber:=RandSeed;
end;

//��������� ���������� ���������������� ����� ������
function TRandomStream.GetNumber:double;
var
   a,l,dn:real;
   i:integer;
begin
  case RSType of
    rtDet:
      Result:=Par1;
    rtEqual:
      Result:=GetBaseNumber*(Par2-Par1)+Par1;
    rtExp:
      Result:=-ln(GetBaseNumber)/Par1;
    rtErlang:
      begin
        a:=1;
        for i:=1 to round(Par2) do
          a:=a*GetBaseNumber;
        Result:=-Par1*ln(a);
      end;
    rtVb:
      begin
       l:=Power((-ln(GetBaseNumber)),1/Par2);
       Result:=Par1*l;
      end;
    rtGauss:
      begin
        dn:=1;
        for i:=1 to 12 do
          dn:=dn+GetBaseNumber;
        Result:=dn-6;
        Result:=Result*Par2;
        Result:=Result+Par1;
        if Result<0 then Result:=0.001;
      end;
    else
      Result:=0;
  end;
end;

//������� �������� ����� ������
function CreateRequest(ID:integer; Value:double):pRequest;
begin
  Result:=new(pRequest);
  Result^.ID:=ID;
  Result^.Value:=Value;
  Result^.Next:=nil;
  Result^.Prev:=nil;
  Result^.Location:=nil;
end;

procedure TTracer.Add(s:string);
begin
  if OutMemo<>nil then OutMemo.Lines.Add(s);
end;

//����������� ������ ���
constructor TEventQueue.Create;
begin
  FirstEvent:=nil;
end;

//���������� ������ ���
destructor TEventQueue.Destroy;
begin
  Clear;
end;

//������� ���
procedure TEventQueue.Clear;
var
  CurEvent,PrevEvent:pModelEvent;
begin
  CurEvent:=FirstEvent;
  while CurEvent<>nil do
    begin
      PrevEvent:=CurEvent;
      CurEvent:=CurEvent^.NextEvent;
      dispose(PrevEvent);
    end;
  FirstEvent:=nil;
end;

//�������� ������� � �������
procedure TEventQueue.AddEvent(const NewEvent:pModelEvent);
var
  CurEvent,PrevEvent:pModelEvent;
begin
  CurEvent:=FirstEvent; PrevEvent:=nil;
  //���� ����� ������� ������ ������� � �������
  while (CurEvent<>nil) and (CurEvent^.EventTime<NewEvent^.EventTime) do
    begin
      PrevEvent:=CurEvent;
      CurEvent:=CurEvent^.NextEvent;
    end;
  //��������� ����� ������� � �������
  NewEvent^.NextEvent:=CurEvent;
  //���������, ��� ����� ������� ����� ����� ������
  if PrevEvent=nil then
    FirstEvent:=NewEvent
  else
    PrevEvent^.NextEvent:=NewEvent;
end;

//�������� ������ ������� �� �������
function TEventQueue.GetFirstEvent:pModelEvent;
begin
  Result:=FirstEvent;                     //���������� ������ ������� �������
  if FirstEvent<>nil then
    begin
      CurrentTime:=FirstEvent^.EventTime; //������ ������� �����
      FirstEvent:=FirstEvent^.NextEvent;  //�������� ������ ��������� ������
    end;
end;

//����������� ������ ���������� �������
constructor TModelClass.Create(ptrEventQueue:pEventQueue);
begin
  EventQueue:=ptrEventQueue;
  LastEvent:=0;
  AutoOutput:=true;
  AutoInput:=true;
end;

//����������� ������ ���������� �������
constructor TQueue.Create(ptrEventQueue:pEventQueue);
begin
  inherited;
  ResetStatistic;
  PutType:=ptFirstFree;
  IncomeStream:=nil;
  LeaveStream:=nil;
  LeaveQueue:=nil;
end;

//����� ��������� ����������
procedure TQueue.ResetStatistic;
var
  i:integer;
begin
  AvgWait:=0;
  cNum:=0; NumIn:=0; NumOut:=0; NumLeave:=0; NumBlock:=0;
  LastEvent:=0;
  if MaxLength<>0 then
    for i:=0 to MaxLength do BusyStat[i]:=0;
end;

//����� ������ �������
procedure TQueue.Reset;
var
  Cur,Prev:pRequest;
begin
  ResetStatistic;
  Cur:=FirstRequest;
  while Cur<>nil do
    begin
      Prev:=Cur;
      Cur:=Cur^.Next;
      dispose(Prev);
    end;
  FirstRequest:=nil;
  LastRequest:=nil;
end;

//����� ���������� ������� ���������� ������
procedure TQueue.CreateAddEvent;
var
  tmp:pModelEvent;
begin
  //���� ������������� �������� ������ ���������
  if IncomeStream<>nil then
    begin
      //������� ����� ��������� ������� - ��������� ����� ������ � �������
      tmp:=new(pModelEvent);
      tmp^.EventTime:=EventQueue^.CurrentTime+IncomeStream^.GetNumber;
      tmp^.pObject:=Self;
      tmp^.EventType:=mIncS;
      //��������� ������� � ������� �������
      EventQueue^.AddEvent(tmp);
    end;
end;

//����� ��������� ����. ����� �������
procedure TQueue.SetMaxLength(NewLength:integer);
begin
  MaxLength:=NewLength;
  SetLength(BusyStat,MaxLength+1);
end;

//����� ���������� ���������� �������
procedure TQueue.UpdateStatistic;
begin
  //� ������� ���������� ������� (LastEvent) �� �������� ������� (EventQueue^.CurrentTime)
  //� ������� ���� cNum ������
  if cNum<=MaxLength then
    BusyStat[cNum]:=BusyStat[cNum]+EventQueue^.CurrentTime-LastEvent;
  //��������� ����� ���������� �������
  LastEvent:=EventQueue^.CurrentTime;
end;

//����� ���������� ������ � �������
procedure TQueue.PutRequest(Request:pRequest);

//����� ���������� ������
function GetFreeChannel:pChannel;
var
  i,j:integer;
  channels:array of pChannel;
begin
  //�������� ��������� �� ��������� ������ � ������� channels
  setlength(channels,length(ChannelList^));
  j:=-1;
  for i:=0 to length(ChannelList^)-1 do
    if not ChannelList^[i].Busy then
      begin
        inc(j);
        channels[j]:=@ChannelList^[i];
      end;
  SetLength(channels,j+1);
  Result:=nil;
  //���� ��������� ������� ���
  if j=-1 then exit;
  case PutType of
    ptFirstFree:
      Result:=channels[0];
    ptRandom:
      Result:=channels[random(length(channels))];
    ptMinBusiness:
      begin
        //���� ����� ����� ���� - ��� � ��������
        if length(channels)=1 then
          begin
            Result:=channels[0];
            exit;
          end;
        //����� ���� ����� � ���������� ����������
        j:=0;
        for i:=0 to length(channels)-1 do
          if channels[i]^.BusyTime<channels[j]^.BusyTime then j:=i;
        Result:=channels[j];
      end;
  end;
end;

var
  FreeChannel:pChannel;
  tmp:pModelEvent;
begin
  if Tracer<>nil then
    if Self.ObjName<>'4' then
      Tracer.Add('� ������� '+Self.ObjName+' ��������� ������ �'+IntToStr(Request^.ID)+'.')
    else
      Tracer.Add('������ �'+IntToStr(Request^.ID)+' ������� ���������.');
  //���������� ����� ����� ������ � �������
  Request^.InTime:=EventQueue^.CurrentTime;
  //��������� ����������
  UpdateStatistic;
  //����������� ����� ��������� ������
  inc(NumIn);
  CreateAddEvent;
  //���� ������� ����� � ���� ������ ������������
  if (AutoOutput) and (cNum=0) and (ChannelList<>nil) then
    begin
      //���� ��������� �����
      FreeChannel:=GetFreeChannel;
      if (FreeChannel<>nil) then
        begin
          //���� ��������� ����� - ���������� ������ �� ������������
          inc(NumOut);
          FreeChannel^.PutRequest(Request);
          exit;
        end;
    end;
  //���� ���� ����� � �������
  if cNum<MaxLength then
     //C����� ������ � �������
     begin
       //����������� ����� ������
       inc(cNum);
       //���� ������� ������ �����
       if FirstRequest=nil then
         FirstRequest:=Request
       else
         LastRequest^.Next:=Request;
       Request^.Prev:=LastRequest;
       Request^.Next:=nil;
       LastRequest:=Request;
       Request^.Location:=Self;
       //������� ������� �� ��������� ������
       if LeaveStream<>nil then
         begin
           //������� ����� ��������� ������� - ���� ������
           tmp:=new(pModelEvent);
           tmp^.EventTime:=EventQueue.CurrentTime+LeaveStream^.GetNumber;
           tmp^.EventType:=mDecS;
           tmp^.pObject:=Self;
           tmp^.pRequest:=Request;
           //��������� ������� � ������� ��������� �������
           EventQueue.AddEvent(tmp);
         end;
     end
  else
     //���� ��� - ����������� ����� �������
     begin
       inc(NumBlock);
       if Tracer<>nil then
         if Self.ObjName<>'4' then
           Tracer.Add('� ������� '+Self.ObjName+' ��� �����. ������ �'+IntToStr(Request^.ID)+' ��������');
     end;
end;

//����� ��������� ������ �� �������
function TQueue.GetRequest:pRequest;
begin
  //��������� ����������
  UpdateStatistic;
  AvgWait:=AvgWait*NumOut+(EventQueue^.CurrentTime-FirstRequest^.InTime);
  //����������� ����� ������� �� ������������ ������
  inc(NumOut);
  AvgWait:=AvgWait/NumOut;
  //��������� ����� ������ � �������
  dec(cNum);
  //���������� ������ ������ �� �������
  Result:=FirstRequest;
  Result^.Location:=nil;
  //�������� ��������� �� ������ ������� �������
  FirstRequest:=FirstRequest^.Next;
  //���� ������� �����, �� nil'��� ��������� �� ��������� �������, ����� - �������� ����� � ������� �������
  if FirstRequest=nil then
    LastRequest:=nil
  else
    FirstRequest^.Prev:=nil;
  //�������� ����� � �������
  Result^.Next:=nil;
  Result^.Prev:=nil;
end;

//����� ��������� ������� �������
function TQueue.HandleEvent(ModelEvent:pModelEvent):pointer;
begin
  Result:=nil;
  if Tracer<>nil then
    begin
      Tracer.Add('');
      Tracer.Add('��������� �����: '+copy(FloatToStr(ModelEvent^.EventTime),1,pos(',',FloatToStr(ModelEvent^.EventTime))+3));
    end;
  case ModelEvent^.EventType of
    mIncS:
      begin
        //���������� ����� ������ � ������������ ID (��� �������) � ��������� �����
        Self.PutRequest(CreateRequest(random(1000),1));
      end;
    mDecS:
      begin
        //���� ������ ��� ��� ��������� � ������ �������
        if ModelEvent^.pRequest^.Location=Self then
          begin
            ModelEvent^.pRequest^.Location:=nil;
            Tracer.Add('������ ������ �'+IntToStr(ModelEvent^.pRequest^.ID)+' � ������� '+Self.ObjName);
            if ModelEvent^.pRequest^.Prev<>nil then
              ModelEvent^.pRequest^.Prev^.Next:=ModelEvent^.pRequest^.Next
            else
              FirstRequest:=ModelEvent^.pRequest^.Next;
            if ModelEvent^.pRequest^.Next<>nil then
              ModelEvent^.pRequest^.Next^.Prev:=ModelEvent^.pRequest^.Prev
            else
              LastRequest:=ModelEvent^.pRequest^.Prev;
            //����� ������ �� �������
            if LeaveQueue=nil then
              dispose(ModelEvent^.pRequest)
            else
              LeaveQueue^.PutRequest(ModelEvent^.pRequest);
            dec(cNum);
            inc(NumLeave);
          end
      end;
  end;
end;

//����������� ������ ��
constructor TChannel.Create;
begin
  inherited;
  ServeStream:=nil;
end;

//����� ���������� ���������� ������
procedure TChannel.UpdateStatistic;
begin
  //� ������� ���������� ������� (LastEvent) �� �������� ������� (EventQueue^.CurrentTime)
  //����� ��� �������� ���� �����
  if Busy then
    BusyTime:=BusyTime+EventQueue^.CurrentTime-LastEvent
  else
    FreeTime:=FreeTime+EventQueue^.CurrentTime-LastEvent;
  LastEvent:=EventQueue^.CurrentTime;
end;

//����� ��������� ����������
procedure TChannel.ResetStatistic;
begin
  //
  BusyTime:=0;
  FreeTime:=0;
end;

//����� ������ ������
procedure TChannel.Reset;
begin
  Busy:=false;
  ResetStatistic;
  if cRequest<>nil then
    begin
      dispose(cRequest);
    end;
  cRequest:=nil;
end;

procedure TChannel.MakeRequest;
begin
  //���� �� ����� ������� � ��� �� �����
  if (InObject^ is TQueue) and ((InObject^ as TQueue).CNum>0) then
    Self.PutRequest(InObject^.GetRequest);
  //������� �� ����� ����� - ����������� �����
  if InObject^ is TChannel then
    (InObject^ as TChannel).MakeRequest;
end;

//����� ��������� ������� ������ ������������
function TChannel.HandleEvent(ModelEvent:pModelEvent):pointer;
begin
  Result:=nil;
  UpdateStatistic;
  if Tracer<>nil then
    begin
      Tracer.Add('');
      Tracer.Add('��������� �����: '+copy(FloatToStr(ModelEvent^.EventTime),1,pos(',',FloatToStr(ModelEvent^.EventTime))+3));
    end;
  case ModelEvent^.EventType of
    mDecS:
      begin
        if CRequest<>nil then
          begin
            if Tracer<>nil then
              Tracer.Add('������ �'+IntToStr(CRequest^.ID)+' ������ ������������ � ������ '+Self.Objname);
            //�������� ������ � ������� �����
            CRequest^.Location:=nil;
            Busy:=false;
            OutObject^.PutRequest(CRequest);
            CRequest:=nil;
            if (InObject^ is TChannel) then (InObject^ as TChannel).Busy:=False;
          end;
        //���� �� ����� ���� ������
        if (InObject<>nil) and (AutoInput) then
          MakeRequest;
      end;
  end;
end;

//����� ���������� ������ � �����
procedure TChannel.PutRequest(Request:pRequest);
var
  tmp:pModelEvent;
begin
  CRequest:=Request;
  CRequest^.Location:=Self;
  if Tracer<>nil then
    Tracer.Add('������ �'+IntToStr(CRequest^.ID)+' ��������� � ����� '+Self.Objname);
  //��������� ����������
  UpdateStatistic;
  //�������� ��������� ������
  Busy:=True;
  if (InObject^ is TChannel) then (InObject^ as TChannel).Busy:=True; 
  //������� ����� ��������� ������� - ������������ ������
  tmp:=new(pModelEvent);
  tmp^.EventTime:=EventQueue.CurrentTime+ServeStream^.GetNumber;
  tmp^.EventType:=mDecS;
  tmp^.pObject:=Self;
  //��������� ������� � ������� ��������� �������
  EventQueue.AddEvent(tmp);
end;


end.
