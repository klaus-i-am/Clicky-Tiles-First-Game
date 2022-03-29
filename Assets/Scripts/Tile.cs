using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameManager gameManager;
    
    public int scoreCount;
    //Color startTileColor = new Color(0.1012371f, 0.7510139f, 0.8584906f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Start Tile"))
        {

            gameManager.StartGame();

            Debug.Log("Started!");

        }

        if (gameObject.GetComponent<MeshRenderer>().material.color == Color.black)
        {
            gameManager.TileSound(gameManager.coinSound);
            scoreCount++;
            gameManager.UpdateScore(scoreCount);
            Destroy(gameObject);

        }
        if (gameObject.GetComponent<MeshRenderer>().material.color == Color.white)
        {

            // wrong sound
            Debug.Log("You lose points! Minus 5 points for Gryffindor!");
            gameManager.TileSound(gameManager.wrongSound);
            scoreCount--;
            gameManager.UpdateScore(scoreCount);

            gameManager.isGameActive = false;
            gameManager.GameOver();
        }
        
    }
    
   
}
