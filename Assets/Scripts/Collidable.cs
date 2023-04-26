using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public GameObject particles;
    public GameObject scoreMenu;
    public bool canCollide;

    //This method will run when the player collides with something
    void OnCollisionEnter2D(Collision2D col) {
        
        if (col.gameObject.tag == "Kill Block") {

            //Spawn the kill particles at the collision site
            GameObject deathParticles = Instantiate(particles) as GameObject;
            deathParticles.transform.position = col.GetContact(0).point;

            //Set the colour of the particles to the player's colour
            ParticleSystem dpSystem = deathParticles.GetComponent<ParticleSystem>();
            ParticleSystem.MainModule dpMain = dpSystem.main;
            dpMain.startColor = gameObject.GetComponent<SpriteRenderer>().color;

            gameObject.SetActive(false);

            //Destroy the particles after 2 seconds
            Destroy(deathParticles, 2);
        }
    }

    void HideScoreMenu() {
        scoreMenu.SetActive(false);
    }
}
