using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationManager3 : MonoBehaviour
{
    private GameManager gManager;
    [SerializeField] GameObject chair;

    void Awake()
    {
        gManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gManager.noDrinks)
        {
            FindObjectOfType<AudioManager>().Play("No Drinks");
            StartCoroutine(NoDrinks());
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("1-3 Intro");
            StartCoroutine(SpawnChair());
        }
    }

    IEnumerator NoDrinks()
    {
        yield return new WaitForSeconds(10);
        FindObjectOfType<AudioManager>().Play("1-3 Intro");
        StartCoroutine(SpawnChair());
    }

    IEnumerator SpawnChair()
    {
        yield return new WaitForSeconds(4);
        chair.SetActive(true);
    }
}
