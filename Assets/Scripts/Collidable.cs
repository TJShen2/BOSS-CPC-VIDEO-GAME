using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public GameObject particles;
    public GameObject scoreMenu;
<<<<<<< Updated upstream
    public bool canCollide;

    //This method will run when the player collides with something
    void OnCollisionEnter2D(Collision2D col) {
        
        if (col.gameObject.tag == "Kill Block") {
=======
    public Enemy enemy;
    public GameObject projectile;

    private bool canCollide = true;
    public bool CanCollide{
        get{return canCollide;}
        set{canCollide = value;}
    }

    void Start()
    {
        canCollide = true;
    }

    //This method will run when the player collides with something
    void OnCollisionEnter2D(Collision2D col) {
        if(gameObject.tag == "Enemy" && col.gameObject.layer == 6){
            return;
        }
        else if(col.gameObject.tag == "Kill Block" && canCollide){

            if (gameObject.tag == "Player"){
                scoreMenu.GetComponent<ScoreMenu>().AddEnemyWin();
            } else {
                scoreMenu.GetComponent<ScoreMenu>().AddPlayerWin();
            }
            ShowScoreMenu();
>>>>>>> Stashed changes

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

<<<<<<< Updated upstream
=======
    void ShowScoreMenu(){
        scoreMenu.SetActive(true);
        enemy.CanMove = false;
        Invoke("HideScoreMenu",2);
    }
    
>>>>>>> Stashed changes
    void HideScoreMenu() {
        scoreMenu.SetActive(false);
    }
}
