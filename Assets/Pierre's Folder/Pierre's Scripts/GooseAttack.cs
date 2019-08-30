using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseAttack : MonoBehaviour
{
    [SerializeField] GameManager gManager;
    [SerializeField] Rigidbody2D gooseBody;
    [SerializeField] Animator gooseAnim;
    [SerializeField] GameObject goose;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject boundary;
    [SerializeField] GameObject daze;
    private GooseMovement movement;

    void Awake()
    {
        gManager = FindObjectOfType<GameManager>();
        movement = FindObjectOfType<GooseMovement>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Kill Player");
            daze.SetActive(false);
            gManager.KillPlayer();
            gooseBody.velocity = new Vector2(0f, 0f);
            //gooseAnim.setBool("kill", true);
            StartCoroutine(SpawnGoose());
        }
    }

    IEnumerator SpawnGoose()
    {
        yield return new WaitForSeconds(gManager.spawnTimer);
        Respawn();
    }

    private void Respawn()
    {
        boundary.SetActive(false);
        daze.SetActive(true);
        //gooseAnim.setBool("kill", false);
        //gooseAnim.setBool("isAttacking", true);
        if (movement.facingRight)
        {
            movement.FlipSprite();
        }
        if(Mathf.Sign(movement.movementSpeed) == 1)
        {
            movement.movementSpeed *= -1;
        }
        goose.transform.position = spawnPoint.transform.position;
        gooseAnim.SetBool("isAttacking", true);
        gooseBody.velocity = new Vector2(movement.movementSpeed, 0f);
        StartCoroutine(SetBoundary());
    }

    IEnumerator SetBoundary()
    {
        yield return new WaitForSeconds(3);
        boundary.SetActive(true);
    }
}
