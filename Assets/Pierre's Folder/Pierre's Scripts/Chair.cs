using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        StartCoroutine(SecondNarration());
        StartCoroutine(NextScene());
        player.GetComponent<SpriteRenderer>().enabled = false;
        gManager.KillPlayer();

        
    }

    IEnumerator StartNaration()
    {
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("Chair Death");
        FindObjectOfType<AudioManager>().Play("Chair Eat");
    }

    IEnumerator SecondNarration()
    {
        yield return new WaitForSeconds(5);
        FindObjectOfType<AudioManager>().Play("Move On");
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(9);
        //Load Next Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Debug.Log("Next");
    }
}
