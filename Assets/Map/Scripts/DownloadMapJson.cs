using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


//[ExecuteAlways]

public class DownloadMapJson : MonoBehaviour
{
    [Range(1, 5)]  private static int? mapNumber;
    public string downloadedMapData;

    public MapDataToObj mapData;
    public LoadPregress loadFromFile; 


    public string mapDataUrl
    {
        get
        {
            return $"https://raw.githubusercontent.com/hamza-afzaal/game-levels/main/map{mapNumber}.json";
        }
    }


    private void Awake()
    {

        if (!loadFromFile.CheckTheLastSave())
        { 
            mapNumber = Random.Range(1, 5);
            if (mapNumber != null)
                StartCoroutine(GetJsonData());
        }
    }
  
   

    void printGameSpec(string mapPath)
    {
        Debug.Log("Game Spec {\n Map Url : " + mapPath + "\nMap Array : " + downloadedMapData + "\n}");
    }
    IEnumerator GetJsonData()
     {
         using (UnityWebRequest request = UnityWebRequest.Get(mapDataUrl))
         {
             yield return request.SendWebRequest();

             if (request.result != UnityWebRequest.Result.Success)
             {
                 Debug.LogError("Failed to get data: " + request.error);
             }
             else
             {
                downloadedMapData = request.downloadHandler.text;
                printGameSpec(mapDataUrl);
                mapData.CreateMap(downloadedMapData);
             }
         }
     }

}

