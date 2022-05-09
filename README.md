# SqaureExercise
<h1>Square exercise</h1>
  <h2>How to set up</h2>
    <li>Install Visual Studio Community IDE and modules ASP.NET and .NET https://visualstudio.microsoft.com/downloads/</li>
    <li>Download MS SQL Express https://www.microsoft.com/en-us/sql-server/sql-server-downloads</li>
    <li>Download Management studio (optional) https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15</li>
    <li>Download EntityFrameworkCore from NuGet</li>
    <li>Open the Package manager console and paste these commands:
    <br><b><li>dotnet tool install --global dotnet-ef</b><br><b> <li>dotnet ef database update -c PointsDbContext</b></li>
    <li>Run the project without debugging</li>
    <h2>Test</h2>
    <li>Use the swagger for the testing</li>
    <h2>Notes</h2>
     <li>I considered that users can add a point or import a point list at any time. The list should not be created before adding a new point.</li>
     <li>API get-squares returns a list of all square drawing possibilities. The count could be accessed by list.count</li>
     <li>Unit-test is not included in this project, though I would definitely add it</li>
     <li>I used DataAccess for interactions with the database</li>
     <li>I used Models for data mapping</li>
     <li>I used Services for API logic implementation (created repository pattern)</li>
     <li>This exercise did not took longer than 8 hours</li>
