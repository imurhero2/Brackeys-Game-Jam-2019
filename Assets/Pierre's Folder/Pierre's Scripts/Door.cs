using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private GameObject prompt;
    [SerializeField] private NarrationManager1 nManager;
    [SerializeField] private GameObject explosion;
    [SerializeField] private SpriteRenderer player;
    private bool inRange;
    public bool inSpikes = false;
    
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
        explosion.SetActive(true);
        StartCoroutine(RemoveExplosion());
        player.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        FindObjectOfType<AudioManager>().Stop();
        FindObjectOfType<AudioManager>().Play("Explode");
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
        if (!inSpikes)
        {
            FindObjectOfType<AudioManager>().Play("1-1 Spike Reminder");
        }
    }

    IEnumerator RemoveExplosion()
    {
        yield return new WaitForSeconds(1);
        explosion.SetActive(false);
    }
}
