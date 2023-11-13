create or replace function deptcnt
return integer is 
	dcnt integer;
begin
	select count(*) into dcnt
	from instructor
	where instructor.deptname='&deptname';

return dcnt;
end;
/