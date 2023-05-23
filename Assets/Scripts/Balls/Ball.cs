using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Collidable
{
    public float moveSpeed;

    public float normalDrag = 0f;
    public float slowDrag = 1f;

    protected bool canBoost;
    protected bool canMove;

    protected Rigidbody2D rb2d;

    public virtual IEnumerator boost ()
    {
        canBoost = false; 
        rb2d.AddForce(transform.up * 10, ForceMode2D.Impulse);
        yield return new WaitForSeconds(5f);
        canBoost = true;
    }

    public virtual void reset() {
        gameObject.SetActive(true);
        rb2d.velocity = Vector2.zero;
        canMove = true;
        canBoost = true;
        gameObject.GetComponent<Collidable>().CanCollide = true;
    }

}
