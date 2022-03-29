using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameManager gameManager;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();

        button.onClick.AddListener(StartButton);
    }
    void StartButton() {

        gameManager.StartGame();
        
    }
}
