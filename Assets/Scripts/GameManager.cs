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

    // Spawn Tiles
    public void SpawnTiles()
    {
        int index = Random.Range(0, rowTiles.Count);
        string[] type = new string[] { "lava", "point" };

        // Assign random tpye
        int nameIndex = Random.Range(0, type.Length);

        Debug.Log(rowTiles[index].name = type[nameIndex]);
        Instantiate(rowTiles[index]);
    }
    // Start Game
    public void StartGame()
    {
        isGameActive = true;
        InvokeRepeating("SpawnRows", spawnTime, spawnRate);

        //SpawnRows();
    }
    
    
}
