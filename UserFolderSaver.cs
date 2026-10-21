using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic.FileIO;

public class UserFolderSaver : Saver
{
    string fileName = "typedemo_03.txt";

    public UserFolderSaver()
        : base()
    {}

    public override void saveFile(string content)
    {
        File.WriteAllText(SpecialDirectories.MyDocuments + Path.DirectorySeparatorChar + fileName, content);
    }
}