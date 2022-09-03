# ASP.NET-Core-Web-App
ASP.NET Core Web Apps with EF Core. ASP.NET Core and EF Core are a perfect match to accelerate our web app development. Using EntityFrameworkCore with ASP.NET Core's Dependency Injection container.

## Required NuGet packages
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.SqlServer

# Using an existing Database and create entity model code
## Scaffold-DbContext command link
  1. Pass the connection string (can be found in the notes)
  2. Pass the name of the provider (what package you are working with)
  3. Optionally pass the output directories for the DbContext and the Models classes
 
Visual Studio Package manager console
```Javascript
Scaffold-DbContext "Connection String Here;" Microsoft.EntityFrameworkCore.SqlServer -ContextDir Data -OutputDir Models/Generated -ContextNamespace <NamespaceName>.Data -Namespace <NamespaceName>.Models
```

## Get connection information from cofiguration
  1. Delete the OnCofiguring method from the DatabaseContext class
  2. In the Program.cs add this line of code instead
```Javascript
  builder.Services.AddDbContext<DbNameContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("<dbName>")));
```
> This method registrates `DbNameContext` with ASP.NET Core's dependency injection container.
> Passing the method a Lambda expression that configures EF code to use the SQL Server database provider using a connection string retrieved from the configuration

#### .NET Secret manger
This feature gives us a mechanism to seprate our secrets from our code. Using the .NET Secret manager to store that connection string.
At run time ASP.NET Core will look for the configuration in-app settings.json and other locations. Secrets.json is one of the locations it checks.
>Right click on our project --> select **Manage User Secrets** opening the *Secrets.json*
#### Using .NET CLI Secret manager
  1. First initialize the secret store  `dotnet user-secrets init`
  2. Then add your secrets  `dotnet user-secrets set "ConnectionStrings;"
  
## Creating our database table's page
#### Visual Studio
  1. Create a folder inside the pages folder, Name it the entity in numerous.
  2. Add **New Scaffold Item** to the folder.
  3. Select **Razor Pages Using Entity Framework (CRUD)**.
  4. Select the required Entity as the *Model class* and `DbNameContext` as *Data Context class*
  5. Click add.

#### .NET CLI
  1. Install the .NET ASPNET code genrator tool as global tool 
  ```python
  dotnet tool install -g dotnet-aspnet-codegenerator
  ```
  2. Use the .NET ASPNET code generator command to scaffold the pages 
  ```python
 dotnet aspnet-codegenerator razorpage --model <Entity> --datacontext DbNameContext --relativeFolderPath Pages/<EntityNumerous> --ReferenceScriptLibraries
 ```
 
## Scaffold page Creation
  - Create
  - Delete
  - Details
  - Edit
  - Index
  
 *In order to see the table in our webapp edit the URL to navigate directly to the Table Index page by adding `/<EntityNumerous>`*

## Edit the HTML page so you can navigate with links to a required table in our database
```python
@page
@model IndexModel
@{
    ViewData["Title"] = "Home page";
}

<div class="text-center">
    <h1 class="display-4">Welcome To the Final Project</h1>
    <ul style="text-align:left; font-size:30px;">
        <li><a id="Countries"           href="javascript:CopyURLtoClipBoard('Countries')">Countries list</a></li>
        <li><a id="Cities"              href="javascript:CopyURLtoClipBoard('Cities')">Cities list</a></li>
        <li><a id="Neighborhoods"       href="javascript:CopyURLtoClipBoard('Neighborhoods')">Neighborhoods list</a></li>
        <li><a id="Houses"              href="javascript:CopyURLtoClipBoard('Houses')">Houses list</a></li>
        <li><a id="Salemen"             href="javascript:CopyURLtoClipBoard('Salemen')">Salemen list</a></li>
        <li><a id="Sales"               href="javascript:CopyURLtoClipBoard('Sales')">Sales list</a></li>
        <li><a id="Specializations"     href="javascript:CopyURLtoClipBoard('Specializations')">Specializations list</a></li>
        <li><a id="Customers"           href="javascript:CopyURLtoClipBoard('Customers')">Customers list</a></li>
        <li><a id="HouseTypes"          href="javascript:CopyURLtoClipBoard('HouseTypes')">House-Types list</a></li>
        <li><a id="Comapanies"          href="javascript:CopyURLtoClipBoard('Comapanies')">Comapanies list</a></li>
        <li><a id="ExperienceLevels"    href="javascript:CopyURLtoClipBoard('ExperienceLevels')">ExperienceLevels list</a></li>
    </ul>
</div>
<script>
    function CopyURLtoClipBoard(obj) { 
        window.open(window.location.href + obj, '_blank').focus();
    }
</script>
```
<div align="left">
<p3> This page demonstrates the home page and a list for our database table's</p3>
<p>
  <img height="350" src="https://user-images.githubusercontent.com/23366804/188271544-c92e1a93-cb0c-42f4-a203-6ec7dba4a5d3.png">
</p>
</div>
<div align="left">
<p3> Table of all the Countries in our database</p3>
<p>
  <img height="600" src="https://user-images.githubusercontent.com/23366804/188271599-00b27609-9935-4cb2-b332-b41b2fdec02d.png">
</p> </div>

# Two patterns for loading Entities
  1. Eager loading - Include method signals to the EF Core that the related order should be loaded on the same database query as the <EntityNumerous>
  2. Lazy loading - To enable lazy loading first install package `Microsoft.EntityFrameworkCore.Proxies`
