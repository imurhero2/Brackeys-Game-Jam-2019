using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseHit : MonoBehaviour
{
    [SerializeField] int dazedLength = 4;
    [SerializeField] float bounceForce = 900f;
    [SerializeField] Animator gooseAnim;
    [SerializeField] Rigidbody2D gooseBody;
    [SerializeField] Rigidbody2D player;
    [SerializeField] GameObject gooseAttack;
    [SerializeField] GameObject goose;
    private GooseMovement movement;
    public bool isDazed = false;

    void Awake()
    {
        movement = FindObjectOfType<GooseMovement>();
    }

    void Update()
    {
        if (isDazed)
        {
            gooseBody.velocity = new Vector2(0f, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            gooseAnim.SetBool("gooseHit", true);
            gooseBody.velocity = new Vector2(0f, 0f);
            isDazed = true;
            player.AddForce(new Vector2(0, bounceForce));
            GetComponent<BoxCollider2D>().enabled = false;
            gooseAttack.SetActive(false);
            FindObjectOfType<AudioManager>().Play("Goose Dazed");
            StartCoroutine(Dazed());
        }
    }

    IEnumerator Dazed()
    {
        yield return new WaitForSeconds(dazedLength);
        gooseAnim.SetBool("gooseHit", false);
        gooseAnim.SetBool("isAttacking", true);
        if (movement.isAttacking == false)
        {
            Vector3 theScale = goose.transform.localScale;
            theScale.x *= -1;
            goose.transform.localScale = theScale;
            movement.isAttacking = true;
        }
        gooseBody.velocity = new Vector2(movement.movementSpeed, 0f);
        GetComponent<BoxCollider2D>().enabled = true;
        gooseAttack.SetActive(true);
        isDazed = false;
    }
}
