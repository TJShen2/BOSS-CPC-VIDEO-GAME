using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public GameObject particles;
    public GameObject scoreMenu;
    private bool canCollide = true;

    public bool CanCollide {
        get { return canCollide; }
        set { canCollide = value; }
    }

    //This method will run when the player collides with something
    void OnCollisionEnter2D(Collision2D col) {
        
        if (col.gameObject.tag == "Kill Block" && canCollide) {
            if(gameObject.tag == "Player")
                scoreMenu.GetComponent<ScoreMenu>().AddEnemyWin();
            else
                scoreMenu.GetComponent<ScoreMenu>().AddPlayerWin();

            ShowScoreMenu();

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

    void ShowScoreMenu() {
        scoreMenu.SetActive(true);
        Invoke("HideScoreMenu", 2);
    }

    void HideScoreMenu() {
        scoreMenu.SetActive(false);
    }
}
