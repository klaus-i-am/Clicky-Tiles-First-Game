using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float rowSpeed;

    public GameObject rowPrefab;

    public List<GameObject> rowTiles;

    public GameObject initialRow;
    public GameObject startBar;
    public GameObject startButton;
    public GameObject restartButton;

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
    public float spawnRate;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
        tileClick = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            StopWatch();
        } else
        {
            return;
        }
        
    }

    // Spawn Rows
    void SpawnRows()
    {
        if (isGameActive)
        {
            Vector3 spawnPos = new Vector3(rowPrefab.transform.position.x, rowPrefab.transform.position.y, posZ);
            Instantiate(rowPrefab, spawnPos, Quaternion.identity);

        }

    }
    // Start Game
    public void StartGame()
    {
        isGameActive = true;

        score = 0;
        UpdateScore(0);

        gameOverText.gameObject.SetActive(false);
        startText.gameObject.SetActive(false);
        startButton.SetActive(false);
        rowSpeed = 0.5f;

        InvokeRepeating("SpawnRows", spawnTime, spawnRate);

    }

    // Restart Game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Game Over
    public void GameOver()
    {
        isGameActive = false;

        rowSpeed = 0f;
        restartButton.SetActive(true);
        startText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);

        

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
        //Instantiate(rowTiles[index]);

    }

}
