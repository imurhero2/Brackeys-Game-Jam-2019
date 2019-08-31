using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    [SerializeField] private GameObject prompt;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator chairAnim;
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
            chairAnim.SetBool("eat", true);
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
        StartCoroutine(StartNaration());
        player.GetComponent<SpriteRenderer>().enabled = false;
        gManager.KillPlayer();

        //Load Next Scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator StartNaration()
    {
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("Chair Death");
    }
}
