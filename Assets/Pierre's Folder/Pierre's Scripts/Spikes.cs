﻿using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private CircleCollider2D playerCollider;
    [SerializeField] private BoxCollider2D playerBoxCollider;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private NarrationManager1 nManager;
    [SerializeField] private GameObject ladder;

    private Door door;

    void Awake()
    {
        door = FindObjectOfType<Door>();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            //Play Spike Enter Voice Over
            door.inSpikes = true;
            FindObjectOfType<AudioManager>().Stop();
            FindObjectOfType<AudioManager>().Play("Spikes Fine");
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            manager.KillPlayer();
            playerAnimator.SetBool("diced", true);
            playerAnimator.SetBool("isDead", true);
            collider.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            ladder.SetActive(true);
            FindObjectOfType<AudioManager>().Stop();
            FindObjectOfType<AudioManager>().Play("1-1 Spike Death");
            FindObjectOfType<AudioManager>().Play("Spikes");
            nManager.spikeDeath = true;
        }
    }
}
