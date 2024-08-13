using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    float speed = 1.0f;
    float rotationSpeed = 100.0f;


    Animator anim;
    Rigidbody playerRigidBody; 

    void Start()
    {
        anim = this.GetComponent<Animator>();
        playerRigidBody = this.GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {

        float translation = PlayerMovement();
        if(translation == 0)
        {
            playerRigidBody.constraints |= RigidbodyConstraints.FreezePosition;   
        }
        if (translation == 0)
        {
            playerRigidBody.constraints &= ~RigidbodyConstraints.FreezePositionX
                & ~RigidbodyConstraints.FreezePositionZ;
        }


        float rotation = PlayerRotation();
        AnimControl(translation, rotation);


    }

    float PlayerMovement()
    {

        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, 0, translation);
        return translation;
    }
    void AnimControl(float translation, float rotation)
    {
        if (rotation !=0 && translation == 0)
        {
            anim.SetBool("isWalking", true);
        }
        else if (translation > 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("direction", 1);
        }
        else if (translation < 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("direction", -1);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
    float PlayerRotation()
    {

        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
        return rotation;
    }
}
