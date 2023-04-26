using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public KeyCode boostKey = KeyCode.Space;
    public KeyCode slowKey = KeyCode.LeftShift;

    public Transform player;

    public float attackRadius;

    private bool canMove;
    private bool canBoost; 

    public bool canCollide;

    private Rigidbody2D rb2d;   
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        canBoost = true;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Called every fixed timestep
    // Used for physics
    void FixedUpdate()
    {
        Vector2 dir = player.position - transform.position;
        Vector2 dirNormalized = dir.normalized;

        transform.up = dirNormalized;

        if(dir.sqrMagnitude <= attackRadius && canBoost)
        {
            StartCoroutine(boost());
        }

        else if(canMove)
            rb2d.AddForce(transform.up * moveSpeed * Time.deltaTime, ForceMode2D.Force);
        
    }

    IEnumerator boost ()
    {
        canBoost = false; 
        rb2d.AddForce(transform.up * 10, ForceMode2D.Impulse);
        yield return new WaitForSeconds(5f);
        canBoost = true;
    }
}
