using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowMovement : MonoBehaviour
{

    public float speed;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z < .8f)
        {
            Destroy(gameObject);
        }
    }

}
