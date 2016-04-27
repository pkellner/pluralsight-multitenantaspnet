

# ASP.NET in Multi-tenant App, Examples in MVC, ExtJS, and Angular

This is the starting code for the Pluralsight Course.  If you would like the full source, head over to the Pluralsight web site and make sure you have licensed the content such that you have access to the full source.

https://app.pluralsight.com/library/courses/aspnet-multi-tenant-app-mvc-extjs-angular/table-of-contents

## Course Description

I will teach you, an ASP.NET web site developer, how to build a first class best practices web site that supports multiple domains (also known as a multiple tenants) from both a server side and client side perspective.  I will show you how to segregate both the data and theme of each unique domain (tenant) such that each tenant (unique domain) has its own private web site logic and theme. I will show you how to capture the incoming request on the server side and parse that request for the domain, and then based on that parse I will show you how to guide your code through different programming logic and display themes.  After I've shown you how to build a best practices server side multi-tenant web site, I will teach you how to build separately a 100 percent client side apps that leverage our web server code using the client side SPA (Single Page JavaScript App) libraries Angular and ExtJS.  As part of this course, I will teach you how to setup and use Node.js and Gulp as your build system for Angular apps.  I will also teach you how to use Sencha's CMD for scaffolding your ExtJS app as well as building and minifying the ExtJS app for production.  Finally I will teach you the details around deploying your application (including dns considerations) to an on premise service as well as Amazon's AWS and Microsoft Azure Clouds.  You will also learn advanced data caching patterns inclding taking advantage of Redis for distributed caching.


##Special Note:

I've found that EF is a little picky about how it wants to initialize
the Sql Server Express database which is in the directory /AppData.

It's important that you don't simply delete the database files but that you do that
through the menu choice on VS View/Sql Server objects.  Drill into databases
and then right click and remove the dbmultitenant database and make sure to click
checkbox "close connections".

This will delete those two files in the AppData directory and new files will be created
when the project is run. If you have issues, I suggest making sure to stop the asp.net 
web server (IIS Express) and let VS restart it. That might help.

