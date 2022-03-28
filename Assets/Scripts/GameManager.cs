using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public GameObject rowPrefab;
    public List<GameObject> rowTiles;

    public GameObject initialRow;
    public GameObject startBar;

    private AudioSource tileClick;
    public AudioClip coinSound;

    private Tile tileScript;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    public bool isGameActive;
    public bool isTimerActive;
    [SerializeField] private float posZ;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnTime;
    private int score;
    private float time;


    // Start is called before the first frame update
    void Start()
    {
        tileClick = GetComponent<AudioSource>();

        score = 0;
        UpdateScore(0);
        

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        StopWatch();
    }

    // Spawn Rows
    void SpawnRows()
    {
        
        Vector3 spawnPos = new Vector3(rowPrefab.transform.position.x, rowPrefab.transform.position.y, posZ);
        

        Instantiate(rowPrefab, spawnPos, Quaternion.identity);
        
    }
    // Initial Spawn Rows
    void InitialSpawnTiles()
    {
        // For loop -> index 6 (rows)
    }
    // Spawn Tiles
    void SpawnTiles()
    {

        int index = Random.Range(0, rowTiles.Count);
        Instantiate(rowTiles[index]);
    }

    // Sound 
    public void TileSound()
    {
        tileClick.PlayOneShot(coinSound, .5f);
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

    // Start Game
    public void StartGame()
    {
        isGameActive = true;
        InvokeRepeating("SpawnRows", spawnTime, spawnRate);
        //SpawnTiles();
    }
    
    
}
