using System.IO;
using UnityEngine;
public class FileRemover : MonoBehaviour
{
    void Start()
    {
        string filePath = Application.persistentDataPath + "/SavedData.txt";

        DeleteFile(filePath);
    }

    void DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("File deleted successfully.");
        }
        else
        {
            Debug.LogWarning("File not found.");
        }
    }
}