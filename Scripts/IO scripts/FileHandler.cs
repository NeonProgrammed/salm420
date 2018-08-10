using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/**
 * NOTES FOR USE_____
 * When using any paths returned from Application.dataPath
 * you cannot make the variable as a global variable. It must be initialized in
 * Start() or update()
 * 
 * FILE STRUCTURE ______
 * void CreateNewFile(string dir, string fileName, string ext)
 * void DeleteFile(string dir, string fileName, string ext)
 * void WriteToFile(string dir, string fileName, string ext, List<string> data)
 * List<string> ReadFromFile(string dir, string fileName, string ext)
 * 
 * CreateLNL(string dir, string fileName, string charName, string campain = "" SUC sucFile, Image[] maps, NPC npcs, Item items)
 * LNL files will point to a dir with a campain to it. By default this will have a blank string just in case
 **/

public class FileHandler : MonoBehaviour {


	public static void CreateNewfile(string dir, string fileName, string ext){ // Creates a new blank file with the name and extention

        string path = dir + "/" + fileName + "." + ext; // Makes the path include the file name and extention
        if (!File.Exists(path)){ // Checks to see if the file is already there
            File.Create(path); // Creates the file at the specified path
        } else {
            Debug.LogError("File already exists! - " + path); // Returns an error if the file exists
        }

    }


    public static void DeleteFile(string dir, string fileName, string ext){ // Deletes a file in the specified path

        string path = dir + "/" + fileName + "." + ext; ; // Makes path include the file name and extention

        if (File.Exists(path)) {
            File.Delete(path);
        } else {
            Debug.LogError("File Does not exist - " + path);
        }
    }


    public static void WriteToFile(string dir, string fileName, string ext, List<string> data){ // Writes to a file

        string path = dir + "/" + fileName + "." + ext; // Makes path include the file name and extention

        // This block of code allows for each element of data to write to the file
        StreamWriter sw = new StreamWriter(path);
        int counter = 0; // Adds a counter for debugging
        foreach (string line in data){ // Iterates through data and gives the value to line
            counter++; // Increases counter every iteration
            sw.WriteLine(line); // Casts the line to a string and writes to the file
        }
        sw.Close(); // Closes the file
        print("Save " + counter.ToString() + " lines to " + path); // Prints debug information
    }


    public static List<string> ReadFromFile(string dir, string fileName, string ext){ // Reads a file that already exists

        string path = dir + "/" + fileName + "." + ext; // Makes path include the file name and extention
        List<string> fileData = new List<string>(); // allows for a List of what was read to be put in a variable

        // This WHOLE block of code reads the data from a file and sets the content to a list for fileData
        StreamReader sr = new StreamReader(path);
        string content = sr.ReadToEnd(); // creates a string for the file to go to
        sr.Close(); // Closes the file
        sr.Dispose(); // gets rid of all resources using stream reader

        char[] splitters = new char[] { '\n', '\r' }; // Gives a list of characters that are meant to split the string
        string[] splitLines = content.Split(splitters); // Removes the characters and everything inbetween became an element to the array

        int counter = 0; // counter for debugging
        foreach(string line in splitLines){ // Iterates through the splitLines array
            counter++;
            fileData.Add(line); // Adds each line from the array to the string to fileData
        }
        print(counter + " lines read from " + path); // Prints debugging information

        return fileData; // returns the file's content in a List
    }



    // Here are the pre-set functions that will be used in creating LNL files and SUC files
    public static void CreateLnL(string dir, string fileName){ // When we go about making the classes I will include them in the function

    }

    public static void CreateSUC(string dir, string fileName, string charName, string campain = ""){

    }

}
