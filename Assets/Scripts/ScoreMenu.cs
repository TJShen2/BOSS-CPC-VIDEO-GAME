using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreMenu : MonoBehaviour
{
    //Fields
    private int playerWins;
    private int enemyWins;

    public void AddPlayerWin() {
        playerWins++;
    }

    public void AddEnemyWin() {
        enemyWins++;
    }

    public Color playerColor;
    public Color enemyColor;

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI enemyScoreText;
    public TextMeshProUGUI winText;

    public GameObject winScreen;

    public UnityEvent deactivateCollision;
    public UnityEvent resetPlayers;

    void OnEnable() {
        playerScoreText.SetText(playerWins.ToString());
        enemyScoreText.SetText(enemyWins.ToString());

        deactivateCollision.Invoke();
    }

    void OnDisable() {

        //Check if anyone won
        if (playerWins == 5) {
            showWinScreen(true);
        } else if (enemyWins == 5) {
            showWinScreen(false);
            
        } else
            resetPlayers.Invoke();
    }

    //true = player won, false = enemy won
    void showWinScreen(bool playerWon) {
        winScreen.SetActive(true);

        if (playerWon) {
            winText.SetText("You win!");
        } else {
            winText.SetText("You lose!");
        }

        Invoke("hideWinScreen", 2);
    }

    void hideWinScreen() {
        playerWins = 0;
        enemyWins = 0;

        winScreen.SetActive(false);

        resetPlayers.Invoke();
    }
    
}
