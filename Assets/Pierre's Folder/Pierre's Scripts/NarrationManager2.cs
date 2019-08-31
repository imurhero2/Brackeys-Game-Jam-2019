using System.Collections;
using UnityEngine;

public class NarrationManager2 : MonoBehaviour
{
    public int numDrank = 0;
    public bool dead;
    [SerializeField] Transform player;
    [SerializeField] Transform ventSpawn;

    private GameManager gManager;

    void Awake()
    {
        gManager = FindObjectOfType<GameManager>();
        gManager.ResetPlayer();
        if (gManager.vent)
        {
            player.position = ventSpawn.position;
        }
    }

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("1-2 Intro");
    }

    void Update()
    {
        if (dead)
        {
            dead = false;
            StartCoroutine(RespawnNarration());
        }
    }

    IEnumerator RespawnNarration()
    {
        yield return new WaitForSeconds(10);
        if(numDrank == 1)
        {
            FindObjectOfType<AudioManager>().Play("First Death");
        } 
        else if (numDrank == 2)
        {
            FindObjectOfType<AudioManager>().Play("Second Death 2");
        }
        else if (numDrank == 3)
        {
            FindObjectOfType<AudioManager>().Play("All Drank");
        }
    }
}
