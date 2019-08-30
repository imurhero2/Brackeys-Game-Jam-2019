using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private CircleCollider2D playerCollider;
    [SerializeField] private BoxCollider2D playerBoxCollider;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private NarrationManager1 nManager;
    [SerializeField] private GameObject ladder;


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
            playerAnimator.SetBool("isDead", true);

            ladder.SetActive(true);
            FindObjectOfType<AudioManager>().Stop();
            FindObjectOfType<AudioManager>().Play("1-1 Spike Death");
            nManager.spikeDeath = true;
        }
    }
}
