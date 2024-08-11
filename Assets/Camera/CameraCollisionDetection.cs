using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collide with object");
        collision.gameObject.GetComponent<MeshRenderer>().enabled = false; 
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("exit with object");
        collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
