using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairWin : MonoBehaviour
{
    private bool inRange;

    void Update()
    {
        if (inRange == true && Input.GetButtonDown("Crouch"))
        {
            BeatLevel();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        inRange = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        inRange = false;
    }

    private void BeatLevel()
    {
        Debug.Log("Complete");
        FindObjectOfType<AudioManager>().Stop();
        FindObjectOfType<AudioManager>().Play("Chair Win");
        //Load Next Scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
