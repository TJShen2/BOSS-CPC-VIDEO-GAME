// This is the old player controller script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public KeyCode boostKey = KeyCode.Space;
    public KeyCode slowKey = KeyCode.LeftShift;

    public float normalDrag = 0f;
    public float slowDrag = 1f;

    private bool canMove;
    private bool canBoost; 

    public bool canCollide;

    public bool CanCollide {
        get {return canCollide;}
        set {canCollide = value;}
    }

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

        if(Input.GetKey(boostKey) && canBoost)
        {
            rb2d.velocity = Vector2.zero; 
            canMove = false;
        }

        if(Input.GetKeyUp(boostKey) && canBoost)
        {
            canMove = true;
            StartCoroutine(boost());
        }

        if(Input.GetKey(slowKey))
        {
            rb2d.drag = slowDrag;
        }

        else
            rb2d.drag = normalDrag;

    }

    // Called every fixed timestep
    // Used for physics
    void FixedUpdate()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 dirNormalized = dir.normalized;

        transform.up = dirNormalized;

        if(canMove)
            rb2d.AddForce(transform.up * moveSpeed * Time.deltaTime, ForceMode2D.Force);

    }

    IEnumerator boost ()
    {
        canBoost = false; 
        rb2d.AddForce(transform.up * 10, ForceMode2D.Impulse);
        yield return new WaitForSeconds(5f);
        canBoost = true;
    }

    public void reset() {
        gameObject.SetActive(true);
        gameObject.transform.position = new Vector3(0, 4, 0);
        canMove = true;
        canBoost = true;
        gameObject.GetComponent<Collidable>().CanCollide = true;
    }
}
