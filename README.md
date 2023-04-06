# c-sharp-projects
Here  Entity Framework used for database operations.

After running the program, it shows following options:

Please select data storage:
1.Database
2.File
3.Exit

After user select 1 or 2, another set of options will be shown:

Please select task:
1.Create file
2.Edit file
3.Delete file
4.Exit

If the user selects an option to create a file, then the user needs to provide a file name, then the user needs to provide file text. If the user is using a database for storage, then a row is added to the table with the data. If the user selects a file as storage then a file is created with the data. Create a folder named UserFiles in the project so that all created files are stored inside it. Users can’t create files with duplicate names.

If the user selects Edit file, then file name has to be provided and then the new text needs to be provided and the program will update the file data either in database or in file storage depending on the option user selected. 

If a user wants to delete a file, the user provides the filename and if the file exists then the file is deleted.

