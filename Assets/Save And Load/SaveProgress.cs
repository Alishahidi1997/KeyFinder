using System.IO;  // Required for file operations
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
    private string fileName = "SavedData.txt";
    public MapDataToObj mapData;

    void Start()
    {
      
    }
    public void SaveCheckPoint()
    {
        // Create the file path
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        // The content you want to write to the file
   

        // Write the content to the file
        WriteTextToFile(filePath, mapData.mapObject.Map);

        Debug.Log("File written to: " + filePath);
    }

    void WriteTextToFile(string path, string content)
    {
        // Open or create the file at the specified path
        using (StreamWriter writer = new StreamWriter(path, false))  // 'false' to overwrite the file, 'true' to append
        {
            writer.Write(content);
        }
    }
}