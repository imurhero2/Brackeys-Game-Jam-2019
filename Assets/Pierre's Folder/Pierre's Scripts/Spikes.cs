using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private CircleCollider2D playerCollider;
    [SerializeField] private BoxCollider2D playerBoxCollider;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            //Play Spike Enter Voice Over
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            manager.KillPlayer();
            playerAnimator.SetBool("diced", true);
            playerCollider.enabled = false;
            playerBoxCollider.enabled = true;
            //Enable Ladder
            //Play Spike Death Voice Over
        }
    }
}
