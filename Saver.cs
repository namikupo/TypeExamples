using System;

public class Saver
{
    public string savePath;

    public Saver()
    {
        this.savePath = "";
    }

    public Saver(string savePath)
    {
        this.savePath = savePath;
    }

    public virtual void saveFile(string content)
    {
        File.WriteAllText(savePath, content);
    }
}