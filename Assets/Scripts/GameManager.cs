using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject SpawnRowPrefab;
    public GameObject InitialRowPrefab;

    public bool isGameActive;

  // Start is called before the first frame update
  void Start()
  {
        isGameActive = true;
        InitialRows();
  }

  // Update is called once per frame
  void Update()
  {
        if (isGameActive)
        {
            // keep spawning tiles
            SpawnRows();
        }
  }

    // Initial Rows
    void InitialRows()
    {
        Vector3 initialSpawnPos = new Vector3(0,0, 3.45f);
        
         // Create rows
         Instantiate(SpawnRowPrefab, initialSpawnPos, transform.rotation);
 
    }

    // Spawn Rows after initial Rows
    void SpawnRows()
    {
       if (InitialRowPrefab.transform.position.z < 2.1)
        {
            Debug.Log("Yee");
        }
    }

    // Random Tile Types: Lava or Safe
    void RandomTiles()
    {
        // Comment
    }
}
