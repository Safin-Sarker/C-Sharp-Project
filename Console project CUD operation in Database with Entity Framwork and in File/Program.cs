// See https://aka.ms/new-console-template for more information

using Assignment3;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


Console.WriteLine("Please select data storage:");
Console.WriteLine("1. Database");
Console.WriteLine("2. File");
Console.WriteLine("3. Exit");

int storageOption = int.Parse(Console.ReadLine());

if (storageOption == 1)
{
    Console.WriteLine("Using database for storage.");
}
else if (storageOption == 2)
{
    Console.WriteLine("Using file for storage.");
}
else if (storageOption == 3)
{
    Environment.Exit(0);
}
else
{
    Console.WriteLine("Invalid option selected.");
    Environment.Exit(0);
}

Console.WriteLine("\nPlease select task:");
Console.WriteLine("1. Create file");
Console.WriteLine("2. Edit file");
Console.WriteLine("3. Delete file");
Console.WriteLine("4. Exit");

int taskOption = int.Parse(Console.ReadLine());

string folderName = "UserFiles";
string pathString = Path.Combine(Environment.CurrentDirectory, folderName);

if (taskOption == 1)
{
    Console.WriteLine("\nEnter Filename:");
    //string name= Console.ReadLine();

    if(storageOption==1)
    {

        string name = Console.ReadLine();
        string text = Console.ReadLine();

        Filelist filetype = new Filelist();
        filetype.FileName = name;
        filetype.FileText = text;
       


        ApplicationDbContext context = new ApplicationDbContext();

        
        if (context.Files.Any(x => x.FileName == name))
        {
            Console.WriteLine("A file with the same name already exists.");
            Environment.Exit(0);
        }
        else
        {
            context.Files.Add(filetype);
            context.SaveChanges();

            Console.WriteLine("row added succesfully");

        }



    }
    else if (storageOption == 2)
    {
        /*
        
        string currentDirectoryPath= Directory.GetCurrentDirectory();
        DirectoryInfo currentDirectory= new DirectoryInfo(currentDirectoryPath);
        string path = Path.Combine(currentDirectory.Parent.Parent.Parent.FullName,"UserFiles");

        Directory.CreateDirectory(path);

        if(Directory.Exists(path)) 
        {
            Console.WriteLine("Folder  created succesfully");
        }

        string filepath= Path.Combine(path, name);
        */
        //string folderName = "UserFiles";
        //string pathString = Path.Combine(Environment.CurrentDirectory, folderName);
        if (!Directory.Exists(pathString))
        {
            Directory.CreateDirectory(pathString);
        }

        // Get the file name from the user
        Console.WriteLine("Enter a file name:");
        string fileName = Console.ReadLine();

        // Check if the file already exists
        string filePath = Path.Combine(pathString, fileName);
        if (File.Exists(filePath))
        {
            Console.WriteLine("A file with that name already exists.");
        }
        else
        {
            // Create the file
            Console.WriteLine("Enter the file data:");
            string fileData = Console.ReadLine();
            File.WriteAllText($"UserFiles/{fileName}", fileData);
            Console.WriteLine($"File '{fileName}' has been created successfully");
        }



}
}
 else if(taskOption== 2) 
{ 
    if (storageOption == 1) 
    {

        string name = Console.ReadLine();
        string text = Console.ReadLine();

        Filelist filetype = new Filelist();
        filetype.FileName = name;
        filetype.FileText = text;

        ApplicationDbContext context = new ApplicationDbContext();
        if (context.Files.Any(x => x.FileName == name))
        {

            Filelist updateFileName = context.Files.Where(x => x.FileName == name).FirstOrDefault();
            updateFileName.FileText = text;
            context.SaveChanges();
        }
        else 
        {
            Console.WriteLine("Please input existing file name");
        }
    }
    else if(storageOption== 2) 
    {
        Console.WriteLine("Enter a file name:");
        
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(pathString, fileName);

        if (File.Exists(filePath))
        {
            Console.WriteLine("Enter the file data:");
            string fileData = Console.ReadLine();
            File.WriteAllText($"UserFiles/{fileName}", fileData);
            Console.WriteLine($"File '{fileName}' has been edited successfully");
        }
        else
        {
            Console.WriteLine("file does not exist");
            
            
        }



    }
}
else if(taskOption== 3)
{
    if(storageOption==1)
    {
        string name = Console.ReadLine();
       

        Filelist filetype = new Filelist();
        filetype.FileName = name;

        ApplicationDbContext context = new ApplicationDbContext();
        if (context.Files.Any(x => x.FileName == name))
        {

            Filelist updateFileName = context.Files.Where(x => x.FileName == name).FirstOrDefault();
            context.Files.Remove(updateFileName);
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Please input existing file name");
        }

    }
    else if (storageOption == 2)
    {
        Console.WriteLine("Enter a file name:");

        string fileName = Console.ReadLine();
        string filePath = Path.Combine(pathString, fileName);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Console.WriteLine($"File '{fileName}' has been edited successfully");
        }
        else
        {
            Console.WriteLine("file does not exist");


        }

    }
}
else if (taskOption == 4)
{
    Environment.Exit(0);

}
    