unit uMdlCls;

interface

uses classes,sysutils, stdctrls,Math, uDecl;

type

  TPutType=(ptFirstFree,ptRandom,ptMinBusiness);

  TEventType=(mIncS,mDecS,mStat); //Перечислимый тип - тип модельного события

  pModelEvent=^TModelEvent; //Указатель на модельное событие
  pModelClass=^TModelClass; //Указатель на базовый класс модельного объекта
  pRandomStream=^TRandomStream; //Указатель на поток псевдослучайных чисел

  pEventQueue=^TEventQueue; //Указатель на очередь модельных событий

  pRequest=^TRequest;       //Указатель на заявку

  TEventQueue=class                                   //Очередь модельных событий
    FirstEvent:pModelEvent;                           //Указатель на первый элемент очереди
    CurrentTime:Double;                               //Время последнего события
    constructor Create;                               //Конструктор класса
    destructor Destroy; override;
    procedure AddEvent(const NewEvent:pModelEvent);   //Добавить событие в очередь
    procedure Clear;
    function GetFirstEvent:pModelEvent;               //Получить первое событие из очереди
  end;

  pQueue=^TQueue;                 //Указатель на очередь заявок
  pChannel=^TChannel;             //Указатель на канал обслуживания

  TTracer=class
    OutMemo:TMemo;
    procedure Add(s:string);
  end;

  TModelClass=class               //Базовый класс модельного объекта
    Tracer:TTracer;               //Список строк для трассировки
    ObjName:string;               //Имя объекта (для статистики)
    EventQueue:pEventQueue;       //Очередь событий модели
    LastEvent:Double;             //Время последнего события
    AutoOutput:boolean;           //Флаг автоматической передачи заявок
    AutoInput:boolean;            //Флаг автоматического приема заявок
    constructor Create(ptrEventQueue:pEventQueue); virtual;         //Конструктор класса
    function HandleEvent(ModelEvent:pModelEvent):pointer; virtual; abstract; //Метод обработки события
    procedure UpdateStatistic; virtual; abstract; //Метод обновления статистики
    procedure ResetStatistic; virtual; abstract;  //Метод обнуления статистики
    procedure Reset; virtual; abstract;           //Метод сброса объекта
    procedure PutRequest(Request:pRequest); virtual; abstract;      //Метод добавления заявки
    function GetRequest:pRequest; virtual; abstract;                //Метод получения заявки
  end;

  TChannel=class(TModelClass)   //Канал обслуживания
    InObject:pModelClass;       //Указатель на очередь, из которой выбираются заявки
    OutObject:pModelClass;      //Указатель на очередь, в которую поступают заявки после обработки
    Busy:boolean;               //Флаг занятости канала
    BusyTime:double;            //Время, в течение которого канал был занят
    FreeTime:double;            //Время, в течение которого канал был свободен
    CRequest:pRequest;          //Указатель на обрабатываемую заявку
    ServeStream:pRandomStream;  //Указатель на псч,описывающий время обслуживания
    function HandleEvent(ModelEvent:pModelEvent):pointer; override; //Метод обработки события
    procedure PutRequest(Request:pRequest); override; //Метод добавления заявки в канал
    procedure UpdateStatistic; override;          //Метод обновления статистики
    procedure ResetStatistic;  override;          //Метод обнуления статистики
    procedure Reset;           override;          //Метод сброса объекта
    constructor Create(ptrEventQueue:pEventQueue); override; //Конструктор класса
    procedure MakeRequest;
  end;

  pChannelList=^TChannelList;     //Указатель на список каналов обслуживания

  TChannelList=array of TChannel; //Список каналов обслуживания

  TQueue=class(TModelClass)     //Очередь заявок
    ChannelList:pChannelList;   //Массив указателей на каналы
    CNum:integer;               //Число заявок в очереди
    NumIn:integer;              //Число заявок, поступивших в очередь
    NumOut:integer;             //Число заявок, вышедших из очереди на обслуживание
    NumLeave:integer;           //Число заявок, покинувших очередь
    NumBlock:integer;           //Число заявок, получивших отказ
    BusyStat:array of double;   //Массив для сбора статистики по занятости
    MaxLength:integer;          //Максимальное число заявок в очереди
    PutType:TPutType;           //Алгоритм выбора свободного канала
    FirstRequest:pRequest;      //Указатель на первую заявку в очереди
    LastRequest:pRequest;       //Указатель на последнюю заявку в очереди
    IncomeStream:pRandomStream; //Указатель на псч,описывающий интервалы между приходами заявок
    LeaveStream:pRandomStream;  //Указатель на псч,описывающий интервалы между уходами заявок
    LeaveQueue:pQueue;          //Указатель на очередь, в которую уходит заявка
    AvgWait:double;             //Среднее время ожидания в очереди
    constructor Create(ptrEventQueue:pEventQueue); override;  //Конструктор класса
    function HandleEvent(ModelEvent:pModelEvent):pointer; override; //Метод обработки события
    procedure CreateAddEvent;                     //Метод создания события добавления
    procedure SetMaxLength(NewLength:integer);    //Метод установки длины очереди
    procedure UpdateStatistic; override;          //Метод обновления статистики
    procedure ResetStatistic;  override;          //Метод обнуления статистики
    procedure Reset;           override;          //Метод сброса объекта
    procedure PutRequest(Request:pRequest); override;       //Метод добавления заявки в очередь
    function GetRequest:pRequest; override;                //Метод получения заявки из очереди

  end;

  TRequest=record           //Тип - заявка
    ID:integer;             //Идентификатор (номер) заявки
    Value:double;           //Вес заявки
    InTime:double;          //Время входа заявки в очередь
    Next,Prev:pRequest;     //Указатели для формирования очереди заявок
    Location:TModelClass;   //Указатель на объект, в котором находится заявка
  end;

  TModelEvent=record        //Модельное событие
    EventTime:Double;       //Время события
    EventType:TEventType;   //Тип модельного события
    pObject:TModelClass;    //Указатель на объект, с которым происходит событие
    pRequest:pRequest;      //Указатель на заявку, связанную с событием
    NextEvent:pModelEvent;  //Указатель на следующий элемент очереди
  end;

  //Поток случайных чисел
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

//Инициализация БПЧ
procedure TRandomStream.Init(Number:longint);
begin
  LastInitNumber:=Number;
end;

//Получение очередного числа из БПЧ
function TRandomStream.GetBaseNumber:double;
begin
  RandSeed:=LastInitNumber;
  Result:=random;
  LastInitNumber:=RandSeed;
end;

//Получение очередного псевдослучайного числа потока
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

//Функция создания новой заявки
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

//Конструктор класса СБС
constructor TEventQueue.Create;
begin
  FirstEvent:=nil;
end;

//Деструктор класса СБС
destructor TEventQueue.Destroy;
begin
  Clear;
end;

//Очистка СБС
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

//Добавить событие в очередь
procedure TEventQueue.AddEvent(const NewEvent:pModelEvent);
var
  CurEvent,PrevEvent:pModelEvent;
begin
  CurEvent:=FirstEvent; PrevEvent:=nil;
  //Ищем место вставки нового события в очередь
  while (CurEvent<>nil) and (CurEvent^.EventTime<NewEvent^.EventTime) do
    begin
      PrevEvent:=CurEvent;
      CurEvent:=CurEvent^.NextEvent;
    end;
  //Вставляем новое событие в очередь
  NewEvent^.NextEvent:=CurEvent;
  //Учитываем, что новое событие может стать первым
  if PrevEvent=nil then
    FirstEvent:=NewEvent
  else
    PrevEvent^.NextEvent:=NewEvent;
end;

//Получить первое событие из очереди
function TEventQueue.GetFirstEvent:pModelEvent;
begin
  Result:=FirstEvent;                     //Возвращаем первый элемент очереди
  if FirstEvent<>nil then
    begin
      CurrentTime:=FirstEvent^.EventTime; //Меняем текущее время
      FirstEvent:=FirstEvent^.NextEvent;  //Сдвигаем первый указатель вперед
    end;
end;

//Конструктор класса модельного объекта
constructor TModelClass.Create(ptrEventQueue:pEventQueue);
begin
  EventQueue:=ptrEventQueue;
  LastEvent:=0;
  AutoOutput:=true;
  AutoInput:=true;
end;

//Конструктор класса модельного объекта
constructor TQueue.Create(ptrEventQueue:pEventQueue);
begin
  inherited;
  ResetStatistic;
  PutType:=ptFirstFree;
  IncomeStream:=nil;
  LeaveStream:=nil;
  LeaveQueue:=nil;
end;

//Метод обнуления статистики
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

//Метод сброса очереди
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

//Метод добавления события добавления заявки
procedure TQueue.CreateAddEvent;
var
  tmp:pModelEvent;
begin
  //Если интенсивность входного потока ненулевая
  if IncomeStream<>nil then
    begin
      //Создаем новое модельное событие - появление новой заявки в очереди
      tmp:=new(pModelEvent);
      tmp^.EventTime:=EventQueue^.CurrentTime+IncomeStream^.GetNumber;
      tmp^.pObject:=Self;
      tmp^.EventType:=mIncS;
      //Добавляем событие в очередь событий
      EventQueue^.AddEvent(tmp);
    end;
end;

//Метод установки макс. длины очереди
procedure TQueue.SetMaxLength(NewLength:integer);
begin
  MaxLength:=NewLength;
  SetLength(BusyStat,MaxLength+1);
end;

//Метод обновления статистики очереди
procedure TQueue.UpdateStatistic;
begin
  //С момента последнего события (LastEvent) до текущего момента (EventQueue^.CurrentTime)
  //в очереди было cNum заявок
  if cNum<=MaxLength then
    BusyStat[cNum]:=BusyStat[cNum]+EventQueue^.CurrentTime-LastEvent;
  //Обновляем время последнего события
  LastEvent:=EventQueue^.CurrentTime;
end;

//Метод добавления заявки в очередь
procedure TQueue.PutRequest(Request:pRequest);

//Поиск свободного канала
function GetFreeChannel:pChannel;
var
  i,j:integer;
  channels:array of pChannel;
begin
  //Собираем указатели на свободные каналы в массиве channels
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
  //Если свободных каналов нет
  if j=-1 then exit;
  case PutType of
    ptFirstFree:
      Result:=channels[0];
    ptRandom:
      Result:=channels[random(length(channels))];
    ptMinBusiness:
      begin
        //Если канал всего один - его и выбираем
        if length(channels)=1 then
          begin
            Result:=channels[0];
            exit;
          end;
        //Иначе ищем канал с наименьшей занятостью
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
      Tracer.Add('В очередь '+Self.ObjName+' поступила заявка №'+IntToStr(Request^.ID)+'.')
    else
      Tracer.Add('Заявка №'+IntToStr(Request^.ID)+' успешно обслужена.');
  //Запоминаем время входа заявки в систему
  Request^.InTime:=EventQueue^.CurrentTime;
  //Обновляем статистику
  UpdateStatistic;
  //Увеличиваем число пришедших заявок
  inc(NumIn);
  CreateAddEvent;
  //Если очередь пуста и есть каналы обслуживания
  if (AutoOutput) and (cNum=0) and (ChannelList<>nil) then
    begin
      //Ищем свободный канал
      FreeChannel:=GetFreeChannel;
      if (FreeChannel<>nil) then
        begin
          //Есть свободный канал - отправляем заявку на обслуживание
          inc(NumOut);
          FreeChannel^.PutRequest(Request);
          exit;
        end;
    end;
  //Если есть место в очереди
  if cNum<MaxLength then
     //Cтавим заявку в очередь
     begin
       //Увеличиваем число заявок
       inc(cNum);
       //Если очередь заявок пуста
       if FirstRequest=nil then
         FirstRequest:=Request
       else
         LastRequest^.Next:=Request;
       Request^.Prev:=LastRequest;
       Request^.Next:=nil;
       LastRequest:=Request;
       Request^.Location:=Self;
       //Создаем событие на покидание заявки
       if LeaveStream<>nil then
         begin
           //Создаем новое модельное событие - уход заявки
           tmp:=new(pModelEvent);
           tmp^.EventTime:=EventQueue.CurrentTime+LeaveStream^.GetNumber;
           tmp^.EventType:=mDecS;
           tmp^.pObject:=Self;
           tmp^.pRequest:=Request;
           //Добавляем событие в очередь модельных событий
           EventQueue.AddEvent(tmp);
         end;
     end
  else
     //Мест нет - увеличиваем число отказов
     begin
       inc(NumBlock);
       if Tracer<>nil then
         if Self.ObjName<>'4' then
           Tracer.Add('В очереди '+Self.ObjName+' нет места. Заявка №'+IntToStr(Request^.ID)+' потеряна');
     end;
end;

//Метод получения заявки из очереди
function TQueue.GetRequest:pRequest;
begin
  //Обновляем статистику
  UpdateStatistic;
  AvgWait:=AvgWait*NumOut+(EventQueue^.CurrentTime-FirstRequest^.InTime);
  //Увеличиваем число ушедших на обслуживание заявок
  inc(NumOut);
  AvgWait:=AvgWait/NumOut;
  //Уменьшаем число заявок в очереди
  dec(cNum);
  //Возвращаем первую заявку из очереди
  Result:=FirstRequest;
  Result^.Location:=nil;
  //Сдвигаем указатель на первый элемент очереди
  FirstRequest:=FirstRequest^.Next;
  //Если очередь пуста, за nil'яем указатель на последний элемент, иначе - обрываем связь с ушедшей заявкой
  if FirstRequest=nil then
    LastRequest:=nil
  else
    FirstRequest^.Prev:=nil;
  //Обрываем связи в очереди
  Result^.Next:=nil;
  Result^.Prev:=nil;
end;

//Метод обработки события очереди
function TQueue.HandleEvent(ModelEvent:pModelEvent):pointer;
begin
  Result:=nil;
  if Tracer<>nil then
    begin
      Tracer.Add('');
      Tracer.Add('Модельное время: '+copy(FloatToStr(ModelEvent^.EventTime),1,pos(',',FloatToStr(ModelEvent^.EventTime))+3));
    end;
  case ModelEvent^.EventType of
    mIncS:
      begin
        //Генерируем новую заявку с произвольным ID (для отладки) и единичным весом
        Self.PutRequest(CreateRequest(random(1000),1));
      end;
    mDecS:
      begin
        //Если заявка все еще находится в данной очереди
        if ModelEvent^.pRequest^.Location=Self then
          begin
            ModelEvent^.pRequest^.Location:=nil;
            Tracer.Add('Потеря заявки №'+IntToStr(ModelEvent^.pRequest^.ID)+' в очереди '+Self.ObjName);
            if ModelEvent^.pRequest^.Prev<>nil then
              ModelEvent^.pRequest^.Prev^.Next:=ModelEvent^.pRequest^.Next
            else
              FirstRequest:=ModelEvent^.pRequest^.Next;
            if ModelEvent^.pRequest^.Next<>nil then
              ModelEvent^.pRequest^.Next^.Prev:=ModelEvent^.pRequest^.Prev
            else
              LastRequest:=ModelEvent^.pRequest^.Prev;
            //Вывод заявки из системы
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

//Конструктор класса КО
constructor TChannel.Create;
begin
  inherited;
  ServeStream:=nil;
end;

//Метод обновления статистики канала
procedure TChannel.UpdateStatistic;
begin
  //С момента последнего события (LastEvent) до текущего момента (EventQueue^.CurrentTime)
  //канал был свободен либо занят
  if Busy then
    BusyTime:=BusyTime+EventQueue^.CurrentTime-LastEvent
  else
    FreeTime:=FreeTime+EventQueue^.CurrentTime-LastEvent;
  LastEvent:=EventQueue^.CurrentTime;
end;

//Метод обнуления статистики
procedure TChannel.ResetStatistic;
begin
  //
  BusyTime:=0;
  FreeTime:=0;
end;

//Метод сброса канала
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
  //Если на входе очередь и она не пуста
  if (InObject^ is TQueue) and ((InObject^ as TQueue).CNum>0) then
    Self.PutRequest(InObject^.GetRequest);
  //Очередь на входе пуста - освобождаем канал
  if InObject^ is TChannel then
    (InObject^ as TChannel).MakeRequest;
end;

//Метод обработки события канала обслуживания
function TChannel.HandleEvent(ModelEvent:pModelEvent):pointer;
begin
  Result:=nil;
  UpdateStatistic;
  if Tracer<>nil then
    begin
      Tracer.Add('');
      Tracer.Add('Модельное время: '+copy(FloatToStr(ModelEvent^.EventTime),1,pos(',',FloatToStr(ModelEvent^.EventTime))+3));
    end;
  case ModelEvent^.EventType of
    mDecS:
      begin
        if CRequest<>nil then
          begin
            if Tracer<>nil then
              Tracer.Add('Заявка №'+IntToStr(CRequest^.ID)+' прошла обслуживание в канале '+Self.Objname);
            //Передаем заявку в очередь далее
            CRequest^.Location:=nil;
            Busy:=false;
            OutObject^.PutRequest(CRequest);
            CRequest:=nil;
            if (InObject^ is TChannel) then (InObject^ as TChannel).Busy:=False;
          end;
        //Если на входе есть объект
        if (InObject<>nil) and (AutoInput) then
          MakeRequest;
      end;
  end;
end;

//Метод добавления заявки в канал
procedure TChannel.PutRequest(Request:pRequest);
var
  tmp:pModelEvent;
begin
  CRequest:=Request;
  CRequest^.Location:=Self;
  if Tracer<>nil then
    Tracer.Add('Заявка №'+IntToStr(CRequest^.ID)+' поступила в канал '+Self.Objname);
  //Обновляем статистику
  UpdateStatistic;
  //Изменяем состояние канала
  Busy:=True;
  if (InObject^ is TChannel) then (InObject^ as TChannel).Busy:=True; 
  //Создаем новое модельное событие - освобождение канала
  tmp:=new(pModelEvent);
  tmp^.EventTime:=EventQueue.CurrentTime+ServeStream^.GetNumber;
  tmp^.EventType:=mDecS;
  tmp^.pObject:=Self;
  //Добавляем событие в очередь модельных событий
  EventQueue.AddEvent(tmp);
end;


end.
