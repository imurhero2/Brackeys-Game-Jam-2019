using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseMovement : MonoBehaviour
{
    public bool isAttacking = true;
    public float movementSpeed = 10;
    [SerializeField] Animator gooseAnim;
    [SerializeField] GameObject boundary;
    public bool facingRight = false;
    private GooseHit gooseHit;

    void Awake()
    {
        gooseHit = FindObjectOfType<GooseHit>();
    }

    // Update is called once per frame
    void Start()
    {
        movementSpeed *= -1;
        GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, 0f);
        gooseAnim.SetBool("isAttacking", true);
        StartCoroutine(SetBoundary());
    }

    

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Stop")
        {
            Debug.Log("hit");
            isAttacking = false;
            gooseAnim.SetBool("isAttacking", false);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            StartCoroutine(Idle());
        }
    }

    IEnumerator SetBoundary()
    {
        yield return new WaitForSeconds(3);
        boundary.SetActive(true);
    }

    IEnumerator Idle()
    {

        movementSpeed *= -1;
        yield return new WaitForSeconds(3);
        if (!gooseHit.isDazed)
        {
            FlipSprite();
            isAttacking = true;
            gooseAnim.SetBool("isAttacking", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, 0f);
        }
        
    }

    public void FlipSprite()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        facingRight = !facingRight;
    }

    private void Attack()
    {

    }

}
