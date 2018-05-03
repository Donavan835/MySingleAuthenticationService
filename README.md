# Technical Exercise (Single Sign On)
A basic technical exercise on Single-Sign-On concept

### Pre-requisite : 
1. MSSQL Server 2012 and above
2. Microsoft Internet Information Services (IIS)
3. Microsoft Visual Studio 2015 and above (To debug or enhance)

### Setup : 
1. Download the entire sub-branch.
2. Take the MyAuthentication.bak file and restore as a database in MSSQL Server 2012. I am using "MyAuthentication" as the Database name. (If you decided to change this make sure you change your web.config later on.)
3. In IIS, create a new Web application named "MyAuthenticationService" with application-pool ".Net v4.5" and physical-path of "[Your drive and directory]\MyAuthenticationService\MyAuthenticationService"
4. In IIS, create a new Web application named "MySampleApplication" with application-pool ".Net v4.5" and physical-path of "[Your drive and directory]\MyAuthenticationService\MySampleApplication"
5. Check your "[Your drive and directory]\MyAuthenticationService\MyAuthenticationService\web.config" file for the correct connection-string to the database that you've setup earlier.
6. Check your "[Your drive and directory]\MyAuthenticationService\MySampleApplication\web.config" file for the correct connection-string to the database that you've setup earlier.

### Testing : 

Use the following username & password for both the Master web application & Client web application #1 : 

UserName | Password |
1. DonavanYap | Abcd1234
2. PeggyWong | Dcba4321

* Master web application url : 
http://localhost/MyAuthenticationService/login

* Client web application #1 url :
http://localhost/MySampleApplication/login

#### Testing steps (From Master to client) : 
1. Login using username "DonavanYap" and password "Abcd1234" in http://localhost/MyAuthenticationService/login . You will be greeted in the "My Main Application" page with "Donavan Yap Sheau Meng" as the full name.

2. Click on "My Custom Application One" hyperlink to go to http://localhost/MySampleApplication/ClientMainPage without needing to login to the http://localhost/MySampleApplication/ environment.

3. Click on the "Logout" button.

4. Copy paste "http://localhost/MySampleApplication/ClientMainPage?SSOAuth=1" to your browser url-bar and click enter. You shall be redirected back to http://localhost/MySampleApplication/login

#### Technical terminology : 
1. MyAuthenticationService.SingleAuthenticator - Webservice providing SSO logics and basic user to application business rules as well as invoking caching when necessary. 

2. UserCredentialCache.UserCache - Library that mimicking caching to the user credentials using Collections.Generic.Dictionary approach. Basic user details are queried once during login and stored as dictionary entries to minimise data retrieval. 

3. MyAuthentication.dbml - Linq.DataContext that provides data-structure in accordance of the tables (Applications, UserCredentials, ApplicationUsers) within the database

#### Database terminology : 
1. Applications - Table to store basic information of the client web-applications and their respective url.
2. UserCredentials - Table to store basic user information. Username, password, Fullname. 
3. ApplicationUsers - Table to store basic information of relations of users and the client applications they can access.

Coding reference : https://www.codeproject.com/Articles/429166/Basics-of-Single-Sign-on-SSO