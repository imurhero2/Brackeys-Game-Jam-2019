using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private GameObject prompt;
    [SerializeField] private NarrationManager1 nManager;
    private bool inRange;
    
    void Update()
    {
        if (inRange == true && Input.GetButtonDown("Interact"))
        {
            KillPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        inRange = true;
        prompt.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        inRange = false;
        prompt.SetActive(false);
    }

    private void KillPlayer()
    {
        Debug.Log("DED");
        FindObjectOfType<AudioManager>().Stop();
        FindObjectOfType<AudioManager>().Play("1-1 Door Death");
        //Play Animation
        manager.KillPlayer();
        if (!nManager.spikeDeath)
        {
            StartCoroutine(WaitForNarration());
        }
    }

    IEnumerator WaitForNarration()
    {
        yield return new WaitForSeconds(15);
        FindObjectOfType<AudioManager>().Play("1-1 Spike Reminder");
    }
}
