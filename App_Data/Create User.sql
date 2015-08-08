insert into aspnet_Users values('3B301772-930C-40D9-ADF0-F1C699AF519F', 
'8B060347-8F3D-4DE6-939F-BC9494FF0D27','111200028', '111200028', null , 0, '20 Feb 2012')

insert into aspnet_Membership values('3B301772-930C-40D9-ADF0-F1C699AF519F', '8B060347-8F3D-4DE6-939F-BC9494FF0D27',
123456, 0, '7M1PkmUYgfYdd2or+uGHjw==', null, 0, 0, 'a','a',1,0,'20 Feb 2012', '20 Feb 2012', '20 Feb 2012', '20 Feb 2012', 0,
'1754-01-01 00:00:00.000', 0,'1754-01-01 00:00:00.000', null)


select * from HR_Employee Where EmployeeID ='45472D2A-2E34-4078-81EA-EAF213C70392'

select * from aspnet_Users where UserId ='45472D2A-2E34-4078-81EA-EAF213C70392'
select * from aspnet_Users where UserName='111200035'
select * from aspnet_Membership where UserId ='9BF6C77D-6F92-4E36-A79F-C63A41F549FD'

select * from aspnet_UsersInRoles where UserId ='9BF6C77D-6F92-4E36-A79F-C63A41F549FD'
delete from aspnet_UsersInRoles where UserId='9BF6C77D-6F92-4E36-A79F-C63A41F549FD'
delete from aspnet_Membership where UserId ='9BF6C77D-6F92-4E36-A79F-C63A41F549FD'
delete from aspnet_Users where UserName='111200035'

select * from aspnet_Roles where RoleId ='45472D2A-2E34-4078-81EA-EAF213C70392'

insert into aspnet_Users values('3B301772-930C-40D9-ADF0-F1C699AF519F', 
'45472D2A-2E34-4078-81EA-EAF213C70392','111200035', '111200035', null , 0, '19 Feb 2012')

select * from aspnet_Membership where UserId = '45472D2A-2E34-4078-81EA-EAF213C70392'

insert into aspnet_Membership values('3B301772-930C-40D9-ADF0-F1C699AF519F', '45472D2A-2E34-4078-81EA-EAF213C70392',
123456, 0, '7M1PkmUYgfYdd2or+uGHjw==', null, 0, 0, 'a','a',1,0,'20 Feb 2012', '20 Feb 2012', '20 Feb 2012', '20 Feb 2012', 0,
'1754-01-01 00:00:00.000', 0,'1754-01-01 00:00:00.000', null)


select * from aspnet_UsersInRoles where UserId = '45472D2A-2E34-4078-81EA-EAF213C70392'

select * from aspnet_Profile where UserId = '45472D2A-2E34-4078-81EA-EAF213C70392'

select * from aspnet_PersonalizationPerUser