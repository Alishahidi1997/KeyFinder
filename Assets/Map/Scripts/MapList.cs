using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

//[ExecuteAlways]
public class MapList
{
    private Vector3 userPosition;
    private string map;
    private static List<List<int>> mapArray = new List<List<int>>();

    public List<List<int>> MapArray
    {
        get { return mapArray; }
    }

    public string Map
    {
        get { return map; }
        set { map = value; }
    }

    public MapList(string downloadedMapData)
    {
        map = downloadedMapData;
        if (map != null)
            ConvertStringTo2DArray();
    }

    void ConvertStringTo2DArray()
    {
        List<int> row = new List<int>();
        for (int i = 0; i < map.Length - 2; i++)
        {
            if (map[i] == ']')
            {
                mapArray.Add(row);
                row = new List<int>();
            }
            else if (System.Char.IsNumber(map[i]))
                row.Add((int)char.GetNumericValue(map[i]));
        }
    }

    public void ChangeMapElement(int xPosition, int yPosition, int newObj)
    {
        mapArray[xPosition][yPosition] = newObj;
        PlayerPositionCheckpoint(xPosition, yPosition, newObj);
    }

    void PlayerPositionCheckpoint(int xPosition, int yPosition, int newObj)
    {
        if (newObj == 2)
        {
            updatePlayerPosition();
            userPosition.x = xPosition;
            userPosition.y = yPosition;
        }
        Convert2DListToString();
    }
    public void updatePlayerPosition()
    {
        if(userPosition != null)
            mapArray[(int)userPosition.x][(int)userPosition.y] = 0;
    }

    public void Convert2DListToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("[");
        foreach (List<int> row in MapArray)
        {
            stringBuilder.Append("[");
            for (int i = 0; i < row.Count; i++)
            {
                stringBuilder.Append(row[i]);

                // Add a comma between elements, but not after the last one
                if (i < row.Count - 1)
                {
                    stringBuilder.Append(", ");
                }
            }
            stringBuilder.Append("]");
            stringBuilder.AppendLine();
        }
        stringBuilder.Append("]");
        map = stringBuilder.ToString();
    }

public void Print2DList()
    {
        for (int i = 0; i < mapArray.Count; i++)
        {
            string rowString = string.Join(", ", mapArray[i]);
            Debug.Log("Row " + i + ": " + rowString);
        }
    }
}
