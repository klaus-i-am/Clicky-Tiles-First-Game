using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public GameObject rowPrefab;
    public GameObject initialRow;

    private Tile tileScript;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    public bool isGameActive;
    public bool isTimerActive;

    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnTime;
    private int score;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
        isGameActive = true;

        InvokeRepeating("SpawnRows", spawnTime, spawnRate);

    }

    // Update is called once per frame
    void Update()
    {
        StopWatch();
    }

    // Spawn Rows
    void SpawnRows()
    {
        float posZ = 3.955f;
        Vector3 spawnPos = new Vector3(rowPrefab.transform.position.x, rowPrefab.transform.position.y, posZ);
        

        Instantiate(rowPrefab, spawnPos, rowPrefab.transform.rotation);
        
    }

    
    // Score 
    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.SetText("Score: " + score);
    }

    // Stop Watch
    void StopWatch()
    {
        time += Time.deltaTime;
        timeText.SetText(time.ToString("F3"));
    }

    // Game Over : 
}
