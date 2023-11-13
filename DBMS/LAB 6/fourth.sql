create or replace trigger triginst
after insert or update or delete on instructor
begin
	if inserting then
		insert into tbl_audit
			values('instructor','insert',sysdate);
	end if;
	if updating then
		insert into tbl_audit
			values('instructor','update',sysdate);
	end if;
	if deleting then
		insert into tbl_audit
			values('instructor','update',sysdate);
	end if;
end;
/