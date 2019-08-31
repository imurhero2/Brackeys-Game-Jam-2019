using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationManager4 : MonoBehaviour
{
    public int throws = 5;
    public int thrown = 0;
    public bool floppyThrown = false;
    public float projectileSpeed = 10f;
    private int spawnCoin = 0;
    public bool throwing = false;
    public bool floppyDeath = false;
    public bool hit = false;
    [SerializeField] GameObject floppyPrefab;
    [SerializeField] GameObject goose;
    [SerializeField] GameObject spawnPointHi;
    [SerializeField] GameObject spawnPointHi2;
    [SerializeField] GameObject spawnPointLow;

    private GameManager gManager;

    void Awake()
    {
        FindObjectOfType<AudioManager>().StopMusic("music");
        FindObjectOfType<AudioManager>().Play("Broken Music");
        gManager = FindObjectOfType<GameManager>();
        gManager.ResetPlayer();
    }

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("1-4 Intro");
        StartCoroutine(WaitForNarration());
    }

    void Update()
    {
        if (throwing)
        {
            ThrowFloppies();
        }
    }

    void ThrowFloppies()
    {
        if (!floppyThrown && thrown < throws)
        {
            spawnCoin = Random.Range(1, 3);
            Debug.Log(spawnCoin);
            if(spawnCoin == 1)
            {
                GameObject floppy = Instantiate(floppyPrefab, spawnPointHi.transform) as GameObject;
                floppy.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0);
                GameObject floppy2 = Instantiate(floppyPrefab, spawnPointHi2.transform) as GameObject;
                floppy2.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0);
                FindObjectOfType<AudioManager>().Play("Jump");
                thrown++;
                floppyThrown = true;
            } else if (spawnCoin == 2)
            {
                GameObject floppy = Instantiate(floppyPrefab, spawnPointLow.transform) as GameObject;
                floppy.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0);
                FindObjectOfType<AudioManager>().Play("Duck");
                thrown++;
                floppyThrown = true;
            }
        }
        else if (!floppyThrown && thrown < throws + 2)
        {
            GameObject floppy = Instantiate(floppyPrefab, spawnPointLow.transform) as GameObject;
            floppy.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0);
            FindObjectOfType<AudioManager>().Play("Duck");
            thrown++;
            floppyThrown = true;
        }
        else if (!floppyThrown && thrown >= throws + 2)
        {
            throwing = false;
            FindObjectOfType<AudioManager>().StopMusic("Broken Music");
            FindObjectOfType<AudioManager>().Play("Boss Music");
            FindObjectOfType<AudioManager>().Play("Goose");
            FindObjectOfType<AudioManager>().Play("Banjo");
            StartCoroutine(SpawnGoose());
        }
    }

    IEnumerator WaitForNarration()
    {
        yield return new WaitForSeconds(19);
        throwing = true;
    }

    IEnumerator SpawnGoose()
    {
        yield return new WaitForSeconds(1);
        goose.SetActive(true);
    }
}
