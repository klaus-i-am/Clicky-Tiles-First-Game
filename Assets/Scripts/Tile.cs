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
        
        //TileType();

    }

    private void OnMouseDown()
    {
        if (gameObject.name == "Tile")
        {
            gameManager.TileSound();
            scoreCount++;
            gameManager.UpdateScore(scoreCount);
            Destroy(gameObject);
        }
        
    }

    

    // Colliders
    private void OnTriggerEnter(Collider other)
    {
      
    }
   
}
