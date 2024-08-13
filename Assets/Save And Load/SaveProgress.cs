using System.IO;  // Required for file operations
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
    private string fileName = "SavedData.txt";
    public MapDataToObj mapData;

    public void SaveCheckPoint()
    {

        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        WriteTextToFile(filePath, mapData.mapObject.Map);

        Debug.Log("File written to: " + filePath);
    }

    void WriteTextToFile(string path, string content)
    {
        using (StreamWriter writer = new StreamWriter(path, false))  
        {
            writer.Write(content);
        }
    }
}