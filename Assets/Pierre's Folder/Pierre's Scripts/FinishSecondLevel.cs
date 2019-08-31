using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishSecondLevel : MonoBehaviour
{
    [SerializeField] private GameObject prompt;
    private bool inRange;

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
        //Load Next Scene
        FindObjectOfType<AudioManager>().Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
