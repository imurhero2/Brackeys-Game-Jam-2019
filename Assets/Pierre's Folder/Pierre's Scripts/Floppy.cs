using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floppy : MonoBehaviour
{
    private NarrationManager4 nManager;
    private GameManager gManager;
    private int waitSeconds = 0;
    

    void Awake()
    {
        gManager = FindObjectOfType<GameManager>();
        nManager = FindObjectOfType<NarrationManager4>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player" && nManager.hit == false)
        {
            nManager.hit = true;
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        Debug.Log("Kill Player");
        gManager.KillPlayer();
        nManager.throwing = false;
        
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
}
