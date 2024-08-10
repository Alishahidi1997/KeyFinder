using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapList
{
    private string map;
    private static List<List<int>> mapArray = new List<List<int>>();

    public List<List<int>> MapArray
    {
        get { return mapArray; }
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
        for (int i = 0; i < map.Length - 1; i++)
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


    public void Print2DList()
    {
        for (int i = 0; i < mapArray.Count; i++)
        {
            string rowString = string.Join(", ", mapArray[i]);
            Debug.Log("Row " + i + ": " + rowString);
        }
    }
}
