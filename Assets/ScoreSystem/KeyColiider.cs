using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyColiider : MonoBehaviour
{
    public ScoreHandler scoreClass; 
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Key")
        {
            scoreClass.updateScore();
            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame

}
