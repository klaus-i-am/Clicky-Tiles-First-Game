using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameManager gameManager;
    
    public int scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    private void OnMouseDown()
    {

        Color startTileColor = new Color(0.1012371f, 0.7510139f, 0.8584906f, 1f);
        if (gameObject.GetComponent<MeshRenderer>().material.color == Color.black)
        {
            gameManager.TileSound();
            scoreCount++;
            gameManager.UpdateScore(scoreCount);
            Destroy(gameObject);

        } else if (gameManager.gameObject.GetComponent<MeshRenderer>().material.color == startTileColor) {

            gameManager.StartGame();

            Debug.Log("Started!");

        } else
        {

            // wrong sound
            Debug.Log("You lose points! Minus 5 points for Gryffindor!");

            scoreCount--;
            gameManager.UpdateScore(scoreCount);

            gameManager.isGameActive = false;
            gameManager.GameOver();
        }
        
    }
    
   
}
