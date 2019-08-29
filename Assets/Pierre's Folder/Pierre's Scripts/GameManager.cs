using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int deathCount = 0;
    public Player_Movement movement;

    public Rigidbody2D playerRigidBody;
    

    public void KillPlayer()
    {
        //Turn off Player_Movement
        movement.moveSpeed = 0;
        movement.enabled = false;
        playerRigidBody.velocity = new Vector3(0, playerRigidBody.velocity.y, 0);
        deathCount += 1;
        //Check death count and Spawn new Player based on damage
        //set Player_Movement and Player_Controller to new player
    }
}
