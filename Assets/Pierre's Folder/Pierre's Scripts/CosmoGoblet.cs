using System.Collections;
using UnityEngine;

public class CosmoGoblet : MonoBehaviour
{
    [SerializeField] private SpriteRenderer player;
    [SerializeField] private GameObject deathAnim;
    [SerializeField] private GameObject prompt;
    private Player_Movement movement;
    private GameManager gManager;
    private NarrationManager2 nManager;
    private bool inRange;

    void Awake()
    {
        gManager = FindObjectOfType<GameManager>();
        nManager = FindObjectOfType<NarrationManager2>();
        movement = FindObjectOfType<Player_Movement>();
    }

    void Update()
    {
        if (inRange == true && Input.GetButtonDown("Interact"))
        {
            Interaction();
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

    private void Interaction()
    {
        Debug.Log("Gulp");
        nManager.numDrank += 1;
        FindObjectOfType<AudioManager>().Stop();
        FindObjectOfType<AudioManager>().Play("Drink Gulp");
        
        //Play Cosmo Animation
        deathAnim.SetActive(true);
        player.enabled = false;
        gManager.noDrinks = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        movement.enabled = false;
        StartCoroutine(KillPlayer());
        nManager.dead = true;
        StartCoroutine(StartNarration());
        StartCoroutine(RemoveAnimation());
    }

    IEnumerator KillPlayer()
    {
        yield return new WaitForSeconds(3);
        gManager.KillPlayer();
        FindObjectOfType<AudioManager>().Play("Singularity");
    }

    IEnumerator RemoveAnimation()
    {
        yield return new WaitForSeconds(13);
        deathAnim.SetActive(false);
    }

    IEnumerator StartNarration()
    {
        yield return new WaitForSeconds(7);
        FindObjectOfType<AudioManager>().Play("Singularity Death");
        FindObjectOfType<AudioManager>().Play("Cosmo Drink");
    }
}
