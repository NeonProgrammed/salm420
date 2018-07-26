using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_FileReader : MonoBehaviour {

    public string datFile = "[]dta.txt";
    public List<string> data = new List<string>();

    public List<string> files = new List<string>();

    public string[] excludeExtentions = new string[] { ".meta" };

    public string searchExtentions = ".txt";

    public bool search = false;


	// Use this for initialization
	void Start () {
		if (!FileIO.FileExists(datFile))
        {
            FileIO.SaveFileWithLines(datFile, new List<string>() { "line1", "line2", "line3" });
        }

        data = FileIO.LinesOfFile(datFile);

        search = true;
	}

    void Update(){
        if (search)
        {
            search = false;
            Search();
        }
    }

    void Search() {
        files = FileIO.GetAllFilesInDirectory("[]file/", excludeExtentions, searchExtentions);
    }

}
