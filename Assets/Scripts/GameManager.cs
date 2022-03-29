using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class GameManager : MonoBehaviour
{
    public RowMovement rowSpeed;

    public GameObject rowPrefab;
    public GameObject rowPrefab2;

    public List<GameObject> rowTiles;

    public GameObject initialRow;
    public GameObject startBar;

    private AudioSource tileClick;
    public AudioClip coinSound;
    public AudioClip wrongSound;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    public TextMeshProUGUI startText;
    public TextMeshProUGUI gameOverText;


    public bool isGameActive;
    private int score;
    private float time;

    [SerializeField] private float posZ;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        tileClick = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        StopWatch();
    }

    // Spawn Rows
    void SpawnRows()
    {

        // Instantiate Row 1
        Vector3 spawnPos = new Vector3(rowPrefab.transform.position.x, rowPrefab.transform.position.y, posZ);
        Instantiate(rowPrefab, spawnPos, Quaternion.identity);
       
    }

    // Sound 
    public void TileSound(AudioClip sound)
    {
        tileClick.PlayOneShot(sound, .5f);
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
        timeText.SetText(time.ToString("F2"));
    }

    // Spawn Tiles
    public void SpawnTiles()
    {

        int index = Random.Range(0, rowTiles.Count);
        string[] type = new string[] { "lava", "point" };

        // Assign random tpye
        int nameIndex = Random.Range(0, type.Length);

        Debug.Log(rowTiles[index].name = type[nameIndex]);

        // Instantiate Tile
        Instantiate(rowTiles[index]);

    }
    
    // Start Game
    public void StartGame()
    {
        isGameActive = true;
        rowSpeed = GetComponent<RowMovement>();
        rowSpeed.speed = .5f;

        
        score = 0;
        UpdateScore(0);

        gameOverText.gameObject.SetActive(false);
        startText.gameObject.SetActive(false);

        InvokeRepeating("SpawnRows", spawnTime, spawnRate);
        
    }

    // Restart Game
    public void RestartGame()
    {
        // Maybe?
    }

    // Game Over
    public void GameOver()
    {
        isGameActive = false;

        startText.SetText("Restart");
        gameOverText.gameObject.SetActive(true);
    }

   

}
