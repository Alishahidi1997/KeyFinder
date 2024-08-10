using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadMapJson : MonoBehaviour
{
    [Range(1, 5)]  private static int? mapNumber;
    public string downloadedMapData;

    public MapDataToObj mapData;

    public string mapDataUrl
    {
        get
        {
            return $"https://raw.githubusercontent.com/hamza-afzaal/game-levels/main/map{mapNumber}.json";
        }
    }


    private void Awake()
    {
        mapNumber = Random.Range(1, 5);
        if(mapNumber != null)
            StartCoroutine(GetJsonData());
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

                Debug.Log("Game Spec {\n Map Url : " + mapDataUrl + "\nMap Array : " + downloadedMapData + "\n}");
                mapData.CreateMap(downloadedMapData);
             }
         }
     }

}

