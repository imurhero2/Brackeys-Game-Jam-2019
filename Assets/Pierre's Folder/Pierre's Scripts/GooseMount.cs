using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GooseMount : MonoBehaviour
{
    [SerializeField] private GameObject prompt;
    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer goose;
    [SerializeField] private GameObject mountFly;
    private GameManager gManager;
    private bool inRange;
    private BoxCollider2D mountBox;
    private GooseHit hit;


    void Awake()
    {
        gManager = FindObjectOfType<GameManager>();
        hit = FindObjectOfType<GooseHit>();
        mountBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange == true && Input.GetButtonDown("Interact"))
        {
            BeatLevel();
        }

        if (hit.isDazed)
        {
            mountBox.enabled = true;
        } else
        {
            mountBox.enabled = false;
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

    private void BeatLevel()
    {
        Debug.Log("Complete");
        gManager.vent = true;
        player.SetActive(false);
        goose.enabled = false;
        mountFly.SetActive(true);
        //Load Next Scene
        FindObjectOfType<AudioManager>().Stop();
        FindObjectOfType<AudioManager>().Play("Game Win");
        StartCoroutine(EndGame());
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}