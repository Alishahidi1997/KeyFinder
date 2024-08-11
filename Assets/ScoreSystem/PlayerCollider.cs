using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public ScoreHandler scoreClass;
    public MapDataToObj mapData;
    public SaveProgress saveCall; 
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Key")
        {
            KeyColliderHandler(collision); 
           
            Destroy(collision.gameObject);
        }
        else if (collision.transform.tag == "Door")
        {
            scoreClass.AreAllKeysFound();
        }
    }

    private void KeyColliderHandler(Collision collision)
    {
        scoreClass.updateScore();
        mapData.UpdateMap(collision.transform.position, 2);
        saveCall.SaveCheckPoint();
    }
    // Update is called once per frame

}
