using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : Ball
{
    public Transform player;
    public float attackRadius;
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

        if(rb2d.velocity.sqrMagnitude >= 50)
        {
            rb2d.drag = slowDrag;
        }
        
        else
            rb2d.drag = normalDrag;

        if(dir.sqrMagnitude <= attackRadius && canBoost)
        {
            StartCoroutine(boost());
        }

        else if(canMove)
            rb2d.AddForce(transform.up * moveSpeed * Time.deltaTime, ForceMode2D.Force);
        
    }

    public override void reset()
    {
        base.reset();
        transform.position = new Vector3(0, -4, 0);
    }
}
