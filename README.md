# Blazor-Assembly-DemoApp

Please follow the below steps to run the application.
1.	With the help of Visual Studio 2019, please open the solution file from the root directory.
2.	Open “appsettings.json” from CashDeskDemoApp.Server project and update the connection string by providing valid connection string to SQL Server. (In the next step, we are going to create database using EF so please provide valid connection)
3.	Open Package Manager Console and to apply migration type the command “Update Database”. This will create the database in SQL Server based on the connection you have provided.
4.	Now, run the application (make sure CashDeskDemoApp.Server is your startup project).
5.	Once the app is open, click on “Register” on top right and provide valid username and password and submit it to register a new user.
6.	Once it is done, confirm your account from the next screen with link provided to activate your account.
7.	Login with the credentials and you will be having a screen with dashboard view with your location details as well as current exchange rates and top 10 trending tickers. (This view is created using 3 different external APIs to show the records).

Demo of the running application is placed at: https://www.screencast.com/t/M2MG8JKq
