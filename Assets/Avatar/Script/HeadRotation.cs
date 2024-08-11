using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotation : MonoBehaviour
{
    public GameObject neckRig;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        neckRig.transform.rotation = Camera.main.transform.rotation;
    }
}
