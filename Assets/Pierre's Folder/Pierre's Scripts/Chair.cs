using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    [SerializeField] private GameObject prompt;
    private bool inRange;
    private GameManager gManager;

    void Awake()
    {
        gManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (inRange == true && Input.GetButtonDown("Interact"))
        {
            ChairEat();
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

    private void ChairEat()
    {
        FindObjectOfType<AudioManager>().Stop();
        FindObjectOfType<AudioManager>().Play("Chair Death");
        gManager.KillPlayer();

        //Load Next Scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
