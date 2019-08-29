using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
//    [SerializeField] private Game_Manager manager;
    [SerializeField] private Animator playerAnimator;

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //Game_Manager.KillPlayer();
            playerAnimator.SetBool("diced", true);
        }
    }
}
