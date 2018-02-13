using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


/* Code format: 
    FileCreation .lnl
    FileCreation .suc
    File Read

    If you are editing this file than please heavily comment.
    This is a team effort and if we are always going to each other for
    explanation of code and code structure than we wont get anywhere. thanks :) -GB
     */

public class FileIO : MonoBehaviour {
    
	//I don't know how data manipulation works in a class for unity.
	//I'm assuming we can just set it to a public variable.
	//Will work out a system for making the file names changeable later. -GB

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Creates lnl files from data in a file. Will refine to work during runtime
    public static void Createlnl() {

		BinaryFormatter bf = new BinaryFormatter(); //Create new instance of binary formatter

		FileStream stream = new FileStream (Application.persistentDataPath + "filename", FileMode.Create); //Creates new lnl file and fileStream

		//Here is where we would take in data to put into the file, for now I'm just going to create
		//a dummy lnl file for testing purposes but later on we will make it do the actual thing
		//using the structure I am laying out here. -GB
		string[] data = new string[10];

		//writing the string data line per line into the binary file using bf.serialize
		for (int i = 0; i < data.Length; i++) {
			data [i] = data [i] + "/n"; //Adds a new line for every line that we put into the string
			bf.Serialize(stream, data[i]); //Stream is the file we are writing to and data is the string we are writing
		}

		stream.Close (); //closing the file to avoid future issues

    }

    //Creates suc file during runtime to save campain/game data ... will refine
    public static void Createsuc() {
		//We are essentially doing the same thing as when we create a .lnl file except a little different
		BinaryFormatter bf = new BinaryFormatter ();

		FileStream stream = new FileStream (Application.persistentDataPath + "filename", FileMode.Create);

		int[] data = new int[10]; //we are making this an int array because ultimately we are just writing ints into the file
		// creating an array size of ten for testing purposes

		for(int i = 0; i < data.Length; i++) {
			bf.Serialize (stream, data[i]); //The reason we dont need to do anything fancy here like + "/n" is because we are working with ints. Will refine later
		}
			
		stream.Close (); //Close that bad boy up

    }

    //Detects the file type and deserializes it to derive a string value.
    //Will read data into memory for future use.
    public static void LoadFile(){
		//We need to work out a way to tell if the file we are reading is a .suc or .lnl
    }

}
