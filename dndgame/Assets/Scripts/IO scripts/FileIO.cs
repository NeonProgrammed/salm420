using UnityEngine;
using System.Collections.Generic;
using System.IO;

/**
 * The code here has yet to be tested. No comments available at this time.
 **/

public class FileIO : MonoBehaviour {
    public static string savPath = Application.persistentDataPath + "/TestFile/ ";
    public static string fileExtension = ".lnl";
    public static string[] defualtExcludeExtentions = new string[] { ".meta" };

    public static List<string> LinesOfFile(string filePath, bool removeBlankLines = true) {

        // makes sure we add the dafault save path if desired
        filePath = AttemptCorrectFilePath(filePath);

        if (File.Exists(filePath)){
            string content = ""; // Gets raw file content(filePath)
            List<string> lines = GetLinesFromContent(content, removeBlankLines);
            return lines;
        } else{
            string errorMessage = "ERR! File " + filePath + " does not exist!";
            Debug.LogError(errorMessage);
            return new List<string>() { errorMessage };
        }

    }

    static string AttemptCorrectFilePath(string filePath) {
        filePath = filePath.Replace("[]", savPath);
        if (!filePath.Contains(".")) filePath += fileExtension;
        return filePath;
    }

    public static void SaveFileWithLines(string filePath, List<string> lines) {
        filePath = AttemptCorrectFilePath(filePath);

        TryCreateDirectoryFromPath(filePath);

        StreamWriter sw = new StreamWriter(filePath);
        int i = 0;
        for (i = 0; i < lines.Count; i++){
            sw.WriteLine(lines[i]);
        }
        sw.Close();
        print("Saved " + i.ToString() + " lines to file [" + filePath + "]");
    }

    static string GetRawFileContent(string filePath) {
        StreamReader sr = new StreamReader(filePath);
        string content = sr.ReadToEnd();
        sr.Dispose();
        return content;
    }

    public static List<string> GetLinesFromContent(string content, bool removeBlankLines = true) {
        string[] splitLines = RemoveNewLinesReadLine(content);
        List<string> trueList = ArrayToList(splitLines);
        return trueList;
    }

    static string[] RemoveNewLinesReadLine(string content) {
        string[] splitLines;
        char[] splitters = new char[] {'\n', '\r'};
        splitLines = content.Split(splitters);
        return splitLines;
    }

    static List<string> ArrayToList(string[] array, bool removeBlankLines = true) {
        List<string> list = new List<string>();
        for (int i = 0; i < array.Length; i++) {
            string s = array[i];
            if (s.Length > 0 || !removeBlankLines)  {
                list.Add(s);
            }
        }
        return list;
    }

    public static bool TryCreateDirectoryFromPath(string path) {
        string directoryPath = path;

        if (Directory.Exists(path) || File.Exists(path)) { return true; }
        if (path.Contains("."))
        {
            directoryPath = "";
            string[] parts = path.Split('/');
            foreach(string part in parts)
            {
                directoryPath += part + "/";
            }
            if (Directory.Exists(directoryPath)) { return true; }
        }
        if (directoryPath != "" && !directoryPath.Contains(".")){
            Directory.CreateDirectory(directoryPath);
            return true;
        } else{
            Debug.LogError("Directory was not valid - " + directoryPath);
            return false;
        }
    }

    public static bool DirectoryExists(string path){
        path = path.Replace("[]", savPath);
        return Directory.Exists(path);
    }

    public static bool FileExists(string path)
    {
        path = AttemptCorrectFilePath(path);
        return File.Exists(path);
    }

    public static List<string> GetAllFilesInDirectory(string directory, string[] excludeExtentions, string searchExtention = ""){
        directory = directory.Replace("[]", savPath);
        List<string> retVal = new List<string>();
        if (Directory.Exists(directory))
        {
            DirectoryInfo d = new DirectoryInfo(directory);
            FileInfo[] files = (searchExtention == "") ? d.GetFiles() : d.GetFiles((searchExtention.StartsWith("*") ? searchExtention : "*" + searchExtention));
            for (int i = 0; i < files.Length; i++){
                FileInfo file = files[i];
                
                foreach(string ext in excludeExtentions){
                    if (file.FullName.ToLower().EndsWith(ext.ToLower())){
                        continue;
                    } else {
                        retVal.Add(file.Name);
                    }
                }
            }
        }else {
            Debug.LogError("Directory does not exist! " + directory + " - could not get files");
        }
        return retVal;
    }

}

// Source material: https://www.youtube.com/watch?v=cBIoDJscFnI