using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameManager gameManager;
    

    public int TileNumber;
    public int scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //KeyboardControls();
    }

    private void OnMouseDown()
    {
        scoreCount++;
        gameManager.UpdateScore(scoreCount);
        Destroy(gameObject);
    }

    void KeyboardControls()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Q = Tile 1
            Destroy(GameObject.FindGameObjectWithTag("Lava"));
        }
    }

    // Colliders
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Lava") && other.gameObject.CompareTag("Start Bar"))
        {
            Debug.Log("You touched: " + gameObject.tag);
        }
    }

    // Tile Random Color also
    void RandomColor()
    {
       
    }
}
