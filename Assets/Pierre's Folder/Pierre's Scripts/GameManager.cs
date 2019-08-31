using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int deathCount = 0;
    public bool noDrinks = true;
    private Player_Movement movement;
    private GameObject player;
    private GameObject playerAnimator;
    private GameObject spawnPoint;
    public int spawnTimer = 10;
    private CircleCollider2D playerCollider;
    private BoxCollider2D playerBoxCollider;
    private Rigidbody2D playerRB;


    public static GameManager instance;
    
        

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            player = GameObject.FindWithTag("Player");
            spawnPoint = GameObject.FindWithTag("Spawn");
            playerAnimator = GameObject.FindWithTag("PlayerAnimator");
            playerCollider = player.GetComponent<CircleCollider2D>();
            playerBoxCollider = player.GetComponent<BoxCollider2D>();
            playerRB = player.GetComponent<Rigidbody2D>();
            movement = player.GetComponent<Player_Movement>();
        }

    public void KillPlayer()
    {
        //Turn off Player_Movement
        movement.enabled = false;
        playerRB.velocity = new Vector3(0, playerRB.velocity.y, 0);
        playerBoxCollider.enabled = false;
        
        deathCount += 1;
        //Check death count and Spawn new Player based on damage
        StartCoroutine(WaitForRespawn());
        //set Player_Movement and Player_Controller to new player
    }


    IEnumerator WaitForRespawn()
    {
        yield return new WaitForSeconds(spawnTimer);
        Respawn();
    }

    private void Respawn()
    {
        playerAnimator.GetComponent<SpriteRenderer>().enabled = true;
        movement.enabled = true;
        playerCollider.enabled = true;
        playerBoxCollider.enabled = true;
        playerRB.bodyType = RigidbodyType2D.Dynamic;
        playerAnimator.GetComponent<Animator>().SetBool("isDead", false);
        playerAnimator.GetComponent<Animator>().SetBool("diced", false);
        player.transform.position = spawnPoint.transform.position;
    }
}
