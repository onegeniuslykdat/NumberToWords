# Tech Test: Number To Words
*v1.0.0*
--
A web page with a backend web server that converts numerical input into words and passes these words as a string output parameter onto the web page. This is a web application that converts a number (monetary value) from the user's input into the appropriate words. E.g. $157.76 to One Hundred and Fifty Seven Dollars And Seventy Six Cents. Three options for currency are also provided.

--
## Getting started
This application is built with the .NET 8 stack, leveraging C#, HTML, CSS, JavaScript and Bootstrap. It is built as a full stack application in order to speed up development. The application houses its own sample data and does not connect to an external database. Recommended additions can be found in **Further contribution**. The limit for the input number is **1,000,000,000,000,000,000, which is 1 Quintillion**. While the available currencies are: **Australian Dollar(s) (AUD)**, **Nigerian Naira (NGN)** and **United States Dollar(s) (USD)**.

The application follows a layered N-Tier architecture with the following layers:
* Presentation layer - This is the application startup project, called **App**. It is the frontend of the application built with .NET Razor pages.
* Services - The is the business logic of the application. It is a class library project called **App.Services**.
* Data - The application data layer, also found in the App.Services project. For simplicity, as stated earlier, the data is housed in the project in the AppData class.

Furthermore, the application follows the Test Driven Development (TDD) methodology. Tests for functions are first created, before the functions are then created. The tests are found in **App.Tests**.

To get started with the project, use the **git clone** command to clone the repo.

--
## Test
In the App.Tests project, unit tests are found and can be run using the **dotnet test** command.

--
## Build and run
When all tests are run and passed, use the **dotnet run** command to start the application. Alternatively, in Visual Studio, you can go to **Debug > Start Without Debugging** or **Press CTRL + F5**.

When the application is ruuning, you can enter a number as input in the textbox and see the words output.

--
## Host
The application is hosted on an Azure WebApp**** using CI/CD from GitHub. When a change is pushed to the Master branch****, the GitHub Action template is started, tests are run and the change is automatically pushed to the WebApp.

--
## Further contribution
The following recommendations are made to further extend the application:
* Connect to an external database. Move the data in the AppData class to an SQL database and then create another implementation for the IDataServices interface to connect to the database.
* Extend the limit of the input number and the number database.
* Add more currencies to the available options.
* Convert the project to an API based project in order to expose APIs to other applications.

To contribute to the repo:
* Fork the repo.
* Make changes.
* Push changes to your fork.
* Open a pull request.

