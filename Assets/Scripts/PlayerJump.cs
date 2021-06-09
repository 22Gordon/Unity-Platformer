using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
 
    //variables 
    Rigidbody player; 
    private float jumpForce = 5f; //force to jump; controll here!
    private bool onGround; 
 
 
    
    void Start () {
        player = GetComponent<Rigidbody> ();
        onGround = true;
    }
 

    void Update () {
        if (Input.GetButton("Jump") && onGround == true) {
            //adds force to player on the jump, change velocity in jumps here!
            player.velocity = new Vector3( 0f, jumpForce, 0f);
            onGround = false;
        }
    }
 
    void OnCollisionEnter(Collision other) {
        //Tag the plane object as "Ground" to work with colliders
        if(other.gameObject.CompareTag("Ground")){
            onGround = true;
        }
    }
}