set serveroutput on
declare
pi constant number:=3.14;
radius number:=&radius;
area number;
begin
area:= pi*radius*radius;
dbms_output.put_line('Area is: '||area);
end;
/