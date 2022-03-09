# CountriesIso

For run the web api

1) Create a SQL SERVER database called CountryISODB
2) In the file "appsettings.json" modify the connection string with the credentials to use in your instance of sql server
3) In Visual Studio 2019 open the web api solution and with the tool "package manager console"
   execute the command "update-database", this will create the database with test records.

4) Execute the solution in Visual studio with F5, this will open in the default browser the swager web page with the documentation of the web api


For run the Xamarin app

1) Open the solution in visual studio 2019 and restore the Nuget packages
2) in the App.xaml.cs file of the Xamarin Forms project, Modify the URL of the Api web (I use a proxy with a program called sharproxy https://github.com/jocull/SharpProxy)
3) with F5 run the application in some android emulator (I use genymotion)
4) Register an new user (Email and Password) and following, login with this new user

Voila
