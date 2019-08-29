using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject prompt;
    [SerializeField] private GameManager manager;
    private bool inRange;
    
    void Update()
    {
        if (inRange == true && Input.GetButtonDown("Interact"))
        {
            KillPlayer();
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

    private void KillPlayer()
    {
        Debug.Log("DED");
        //Play VO
        //Play Animation
        manager.KillPlayer();
    }
}
