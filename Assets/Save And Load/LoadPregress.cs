using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
public class LoadPregress : MonoBehaviour
{
    private string fileName = "SavedData.txt";
    public MapDataToObj mapData;
    public ScoreHandler scoreBoard; 

    void printGameSpec(string mapPath, string content)
    {
        Debug.Log("Game Spec {\n Map Url : " + mapPath + "\nMap Array : " + content + "\n}");
    }
    public bool CheckTheLastSave()
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(filePath))
        {

            string fileContent = File.ReadAllText(filePath);
            int keyCount = NumOfKeyYetToBeFound(fileContent);
            if (keyCount < 3)
            {
                mapData.CreateMap(fileContent);
                scoreBoard.Score = scoreBoard.NumberOfKeys - keyCount;
                scoreBoard.SetScoreToScoreBoard();
                printGameSpec(filePath, fileContent);
                return true;
            }
        }
        else
            Debug.Log("File not found: " + filePath);
        return false;

    }

    int NumOfKeyYetToBeFound(string map)
    {
        char targetChar = '3';
        int numOfKeyYetToBeFound = map.Count(c => c == targetChar);
        return numOfKeyYetToBeFound; 
    }
}
