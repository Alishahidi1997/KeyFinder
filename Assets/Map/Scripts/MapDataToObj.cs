using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteAlways]
public class MapDataToObj : MonoBehaviour
{
    public MapList mapObject; 

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
        AssignThePoolToEachObject();
        AddFloorTileToTheWorld();
    }

    void AssignThePoolToEachObject()
    {
        ground = GameObject.FindWithTag("Ground");
        wallPool = GameObject.FindWithTag("Wall");
        obstaclePool = GameObject.FindWithTag("Obstacle");
        Keys = GameObject.FindWithTag("KeyPool");
        player = GameObject.FindWithTag("Player");
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
                mapObject.ChangeMapElement(row, col, 0);
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

    void AddFloorAndRoof(float i, float y, float j, string floorType)
    {
        floorInstance = Instantiate(floorTile, new Vector3(j, y, i), Quaternion.identity, ground.transform);
        floorInstance.transform.name = $"{floorType}({j},{i})";

    }
    void AddFloorTileToTheWorld()
    {
        for(int i = 0; i < mapObject.MapArray.Count; i++ )
            for(int j = 0; j < mapObject.MapArray[i].Count; j++)
            {
                AddFloorAndRoof(i, 0, j, "Floor");
                AddFloorAndRoof(i, 1.39f, j, "Roof");
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

    public void UpdateMap(Vector3 position, int newObj)
    {
        mapObject.ChangeMapElement((int)position.z, (int)position.x, newObj);
    }

}
