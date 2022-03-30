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

    private void Update()
    {
        DeathBar();
    }
    // When the player clicks tile
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            if (gameObject.GetComponent<MeshRenderer>().material.color == Color.black)
            {
                gameManager.TileSound(gameManager.coinSound);
                IncreaseSpeed(.5f, 5.96f, 1.35f, 1f);
                scoreCount++;
                gameManager.UpdateScore(scoreCount);
                Destroy(gameObject);

            }
            if (gameObject.GetComponent<MeshRenderer>().material.color == Color.white)
            {

                // wrong sound
                gameManager.TileSound(gameManager.wrongSound);
                scoreCount--;
                gameManager.UpdateScore(scoreCount);

                gameManager.isGameActive = false;
                gameManager.GameOver();
            }

        }


    }

    // Increase Speed of Tiles
    void IncreaseSpeed(float Speed, float Rate, float Time, float Multiplier)
    {
        gameManager.rowSpeed = Speed;
        
        gameManager.spawnRate = Rate;
        
        gameManager.spawnTime = Time;
    }

    // Black tile off screen -> game over
    void DeathBar()
    {
        if (gameObject.GetComponent<MeshRenderer>().material.color == Color.black && gameObject.transform.position.z < .98f)
        {
            gameManager.GameOver();
        }
    }
}
