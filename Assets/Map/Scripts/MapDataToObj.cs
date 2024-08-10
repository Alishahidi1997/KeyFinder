using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataToObj : MonoBehaviour
{
    private MapList mapObject; 

    public GameObject floorTile;
    public GameObject wall;
    public GameObject obstacle;
    public GameObject key;
    public GameObject door;
    public GameObject player;

    private GameObject ground;
    private GameObject wallPool;
    private GameObject obstaclePool;
    private GameObject Keys;

    private GameObject floorInstance;


    public void CreateMap(string downloadedMap)
    {
        mapObject = new MapList(downloadedMap);
        ground = GameObject.FindWithTag("Ground");
        wallPool = GameObject.FindWithTag("Wall");
        obstaclePool = GameObject.FindWithTag("Obstacle");
        Keys = GameObject.FindWithTag("Key");
        player = GameObject.FindWithTag("Player"); 
        mapObject.Print2DList();
        AddFloorTileToTheWorld(); 
    }
    void AddMaterialToTheMap(int num, int row, int col)
    {

        switch (num)
        {
            case 0:
                break;
            case 1:
                InstantiateObject(wall, wallPool, row, 0.557f, col);
                break;
            case 2:
                player.transform.position = new Vector3(col, 0.047f, row);
                break;
            case 3:
                InstantiateObject(key, Keys, row, 0.0657f, col);
                break;
            case 4:
                InstantiateObject(obstacle, obstaclePool, row, 0, col);
                break;
            case 5:
                InstantiateObject(door, this.gameObject, (row + 0.48f), 0, col);
                break;
            default:
                break;
        }
    }

    void AddFloorTileToTheWorld()
    {
        for(int i = 0; i < mapObject.MapArray.Count; i++ )
            for(int j = 0; j < mapObject.MapArray[i].Count; j++)
            {
                floorInstance = Instantiate(floorTile, new Vector3(j, 0, i), Quaternion.identity, ground.transform);
                floorInstance.transform.name = $"Floor({j},{i})";
                
                AddMaterialToTheMap(mapObject.MapArray[i][j], i, j);
            }
    }

    void InstantiateObject(GameObject prefab, GameObject parent, float zPosition, float yPosition, float xPosition)
    {
        GameObject temp;
        if (parent)
        {
            temp = Instantiate(prefab, new Vector3(xPosition, yPosition, zPosition), Quaternion.identity, parent.transform);
            temp.transform.name = prefab.transform.name + $"({xPosition}, {zPosition})";
        }
        else
            temp = Instantiate(prefab, new Vector3(xPosition, yPosition, zPosition), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
