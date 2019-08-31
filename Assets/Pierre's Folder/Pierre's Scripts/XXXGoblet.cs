using System.Collections;
using UnityEngine;

public class XXXGoblet : MonoBehaviour
{
    [SerializeField] private GameObject prompt;
    [SerializeField] private SpriteRenderer player;
    [SerializeField] private GameObject deathAnim;
    private GameManager gManager;
    private NarrationManager2 nManager;
    private bool inRange;

    void Awake()
    {
        gManager = FindObjectOfType<GameManager>();
        nManager = FindObjectOfType<NarrationManager2>();
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
        FindObjectOfType<AudioManager>().Play("Drink Gulp");
        nManager.numDrank += 1;
        //Play XXX Animation
        deathAnim.SetActive(true);
        player.enabled = false;
        gManager.noDrinks = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        gManager.KillPlayer();
        nManager.dead = true;
        StartCoroutine(StartNarration());
        StartCoroutine(RemoveAnimation());
    }

    IEnumerator RemoveAnimation()
    {
        yield return new WaitForSeconds(10);
        deathAnim.SetActive(false);
    }

    IEnumerator StartNarration()
    {
        yield return new WaitForSeconds(4);
        FindObjectOfType<AudioManager>().Stop();
        FindObjectOfType<AudioManager>().Play("XXX Drink");
        FindObjectOfType<AudioManager>().Play("Acid Death");
    }
}
