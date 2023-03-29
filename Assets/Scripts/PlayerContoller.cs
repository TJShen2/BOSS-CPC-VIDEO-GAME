using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rb2d;   
    // Start is called before the first frame update
    void Start()
    {
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
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 dirNormalized = dir.normalized;

        transform.up = dirNormalized;

        rb2d.AddForce(dirNormalized * moveSpeed * Time.deltaTime, ForceMode2D.Force);

    }
}
