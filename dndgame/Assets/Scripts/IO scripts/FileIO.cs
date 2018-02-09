using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//Learning file io that unity uses. Will refactor for our uses

public class FileIO : MonoBehaviour {

    string readpath;
    string writepath;

    public List<string> stringList = new List<string>();
    public List<string> writeList = new List<string>();

	// Use this for initialization
	void Start () {
        readpath = Application.dataPath + "/ReadFile.txt";
        writepath = Application.dataPath + "/WriteFile.txt";

        ReadFile(readpath);
        WriteFile(writepath);
        AppendFile(writepath);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Read the file
    void ReadFile(string filePath)
    {
        StreamReader sReader = new StreamReader(filePath);

        //While we are still reading from the file
        while (!sReader.EndOfStream)
        {
            string line = sReader.ReadLine();
            //string line = sReader.ReadLine();
            stringList.Add(line);
        }

        sReader.Close(); //Closes the file
    }

    //Write to a file
    void WriteFile(string filePath)
    {
        StreamWriter sWriter;

        if (!File.Exists(filePath))
        {
            sWriter = File.CreateText(Application.dataPath + "WriteFile.txt");
        } else
        {
            sWriter = new StreamWriter(filePath);
        }

        for (int i = 0; i < writeList.Count; i++)
        {
            sWriter.WriteLine(writeList[i]);
        }

        sWriter.Close();
    }

    void AppendFile(string filePath)
    {
        StreamWriter sWriter;

        if (!File.Exists(filePath))
        {
            sWriter = File.CreateText(Application.dataPath + "WriteFile.txt");
        } else
        {
            sWriter = new StreamWriter(filePath, append: true);
        }

        for (int i = 0; i < writeList.Count; i++)
        {
            sWriter.WriteLine(writeList[i]);
        }

        sWriter.Close();
    }

}
