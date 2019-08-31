using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vent : MonoBehaviour
{
    [SerializeField] private GameObject prompt;
    private GameManager gManager;
    private bool inRange;

    void Awake()
    {
        gManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (inRange == true && Input.GetButtonDown("Interact"))
        {
            BeatLevel();
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
        //Load Next Scene
        FindObjectOfType<AudioManager>().Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
