using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileWriter  {
    private string path;

    public FileWriter(string path)
    {
        this.path = path;
    }

    public void write(string text)
    {
        //if the file does not exist, make a new one
        if (!File.Exists(path))
        {
            File.Create(path);
        }

        //writes to the file, will put each instance of write() on a new line, will not overwrite what is there
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(text);
            writer.Close();
        }
    }

    public void newPath(string path)
    {
        //changes the path to a new location, will create a new file if the filename is different
        this.path = path;
    }

    public void overwriteFile()
    {
        //call this if you want to create a fresh blank file
        File.Create(path);
    }
}
