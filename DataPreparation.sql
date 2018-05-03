USE MyAuthentication
GO

/*
INSERT INTO UserCredentials VALUES (NEWID(), 'DonavanYap', 'Donavan Yap Sheau Meng', 'Abcd1234')
INSERT INTO UserCredentials VALUES (NEWID(), 'PeggyWong', 'Peggy Wong Pee Yee', 'Dcba4321')

INSERT INTO Applications VALUES (NEWID(), 'MyCustomApp1', 'My Custom Application One', 'http://localhost:16482/Default.aspx')

DECLARE @DonavanUserID UNIQUEIDENTIFIER
DECLARE @PeggyUserID UNIQUEIDENTIFIER
DECLARE @MyCustomerAppID UNIQUEIDENTIFIER 

SELECT @MyCustomerAppID = ApplicationId FROM Applications WITH (NOLOCK)
WHERE ApplicationName = 'My Custom Application One'
SELECT @PeggyUserID = UserGuid FROM UserCredentials WITH (NOLOCK)
WHERE UserName = 'DonavanYap'
SELECT @DonavanUserID = UserGuid FROM UserCredentials WITH (NOLOCK)
WHERE UserName = 'PeggyWong'

INSERT INTO ApplicationUsers VALUES (NEWID(), 'DonavanYap', @MyCustomerAppID)
INSERT INTO ApplicationUsers VALUES (NEWID(), 'PeggyWong', @MyCustomerAppID)
*/



SELECT * FROM Applications WITH (NOLOCK)
SELECT * FROM UserCredentials WITH (NOLOCK)
SELECT * FROM ApplicationUsers WITH (NOLOCK)