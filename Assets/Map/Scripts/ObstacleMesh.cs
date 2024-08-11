using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMesh : MonoBehaviour
{
    public Mesh[] obstacleMeshes; 
    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>(); 

        Mesh meshComponent = GetComponent<MeshFilter>().sharedMesh;
        Mesh randomObstacleMesh = Instantiate(obstacleMeshes[Random.Range(0, obstacleMeshes.Length)]);
        meshFilter.sharedMesh = randomObstacleMesh;
        GetComponent<MeshCollider>().sharedMesh = randomObstacleMesh;
        if (meshFilter.sharedMesh.name == "Metal_Barrier_1(Clone)")
            this.transform.localScale = new Vector3(0.5677026f, 0.392f, 0.2719817f);
    }

}
