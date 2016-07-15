# Assessment

Steps to create and initialize the database

- Unzip the CSharpAssignment file.
- Open DbScripts Folder
- Open CriminalDbScript.sql file and run it in your local or any other instance you want to.
- The database will be created along with the tables and respective data.

Prepare source code, build and run the application.


- Open the Assessment folder from the folder CSharpAssignment
- Open the solution(.sln) file.
- Change the connection string in CSharpAssignment Web.config (name - DefaultConnection) and CSharpAssignment.Services App.Config (name - EntityModel)
- Update the service reference in the CSharpAssignment project.
- Build the application
- Set the CSharpAssignment project as the Start Up project. Ignore if already set.
- Run the application.

Assumptions in the requirements:

- I used MVC 4 in the application.
- Added WCF service as a service reference
- Used entity data model to get the entities from the database and for the datacontext.
- Used angular js for front end code.
- Created a unused gmail account to send mails.
- used basic SMTP client to send mails.
- used ITextSharp for pdf generator.
- Used the available home controller for $http calls as there will be only one method to be called.
- Provided a alert as there are no results retrieved if there are no result from the search.
