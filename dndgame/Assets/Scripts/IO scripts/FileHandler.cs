using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/**
 * FILE STRUCTURE ______
 * void CreateNewFile(string dir, string fileName, string ext)
 * void DeleteFile(string dir, string fileName, string ext)
 * void WriteToFile(string dir, string fileName, string ext, List<string> data)
 * List<string> ReadFromFile(string dir, string fileName, string ext)
 **/

public class FileHandler : MonoBehaviour {


	static void CreateNewfile(string dir, string fileName, string ext){ // Creates a new blank file with the name and extention
        string path = dir + "/" + fileName + "." + ext; // Makes the path include the file name and extention
        if (!File.Exists(path)){ // Checks to see if the file is already there
            File.Create(path); // Creates the file at the specified path
        } else {
            Debug.LogError("File already exists! - " + path); // Returns an error if the file exists
        }

    }


    static void DeleteFile(string dir, string fileName, string ext){ // Deletes a file in the specified path
        string path = dir + "/" + fileName + "." + ext; // Makes path include the file name and extention
        File.Delete(path);
    }


    static void WriteToFile(string dir, string fileName, string ext, List<string> data){ // Writes to a file
        string path = dir + "/" + fileName + "." + ext; // Makes path include the file name and extention

        // This block of code allows for each element of data to write to the file
        StreamWriter sw = new StreamWriter(path);
        int counter = 0; // Adds a counter for debugging
        foreach (string line in data){ // Iterates through data and gives the value to line
            counter++; // Increases counter every iteration
            sw.WriteLine((string)line); // Casts the line to a string and writes to the file
        }
        sw.Close(); // Closes the file
        print("Save " + counter.ToString() + " lines to " + path); // Prints debug information
    }


    static List<string> ReadFromFile(string dir, string fileName, string ext){ // Reads a file that already exists
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

}
