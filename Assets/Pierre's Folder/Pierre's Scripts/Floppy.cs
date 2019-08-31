using System.Collections;
using UnityEngine;

public class Floppy : MonoBehaviour
{
    private NarrationManager4 nManager;
    private GameManager gManager;
    private int waitSeconds = 0;
    private SpriteRenderer player;
    private SpriteRenderer split;
    

    void Awake()
    {
        gManager = FindObjectOfType<GameManager>();
        nManager = FindObjectOfType<NarrationManager4>();
        split = GameObject.FindGameObjectWithTag("Slice").GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("PlayerAnimator").GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player" && nManager.hit == false)
        {
            nManager.hit = true;
            FindObjectOfType<AudioManager>().Play("Floppy Slice");
            FindObjectOfType<AudioManager>().Play("Generic Death");
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        Debug.Log("Kill Player");
        gManager.KillPlayer();
        nManager.throwing = false;
        player.enabled = false;
        split.enabled =true;
        StartCoroutine(RemoveDeath());
        
        nManager.thrown = 0;
        if (!nManager.floppyDeath)
        {
            FindObjectOfType<AudioManager>().Play("Disk Death");
            waitSeconds = 13;
            StartCoroutine(StartThrowing());
            nManager.floppyDeath = true;
        }
        else if (nManager.floppyDeath)
        {
            FindObjectOfType<AudioManager>().Play("Disk Death 2");
            waitSeconds = 12;
            StartCoroutine(StartThrowing());
        }
    }

    IEnumerator StartThrowing()
    {
        yield return new WaitForSeconds(waitSeconds);
        nManager.throwing = true;
        nManager.hit = false;
    }

    IEnumerator RemoveDeath()
    {
        yield return new WaitForSeconds(10);
        split.enabled = false;
    }
}
