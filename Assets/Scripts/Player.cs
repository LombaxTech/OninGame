using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public float jumpAmount;

    private float screenWidth;
    private float screenHeight;


    SpawnScript spawnScript;


    // Start is called before the first frame update
    void Start()
    {

        spawnScript = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<SpawnScript>();        
        spriteRenderer = GetComponent<SpriteRenderer>();

        // spriteRenderer.color = colors[Random.Range(0, colors.Length)];

        rb = GetComponent<Rigidbody2D>();

        Vector2 randomForce = new Vector2(Random.Range(-0.25f, 0.25f),     
        // Random.Range(0.0f, 1.0f)
            2.0f
        ) * jumpAmount;

        // rb.AddForce(transform.up, ForceMode2D.Impulse);
        // rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        rb.AddForce(randomForce, ForceMode2D.Impulse);

        Camera camera = Camera.main;
        screenHeight = camera.orthographicSize;
        screenWidth = screenHeight * camera.aspect;

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {   
            
            Vector2 randomForce = new Vector2(Random.Range(-1.0f, 1.0f), 
            
            // Random.Range(0.0f, 1.0f)
            2.0f
            ) * jumpAmount;

            // rb.AddForce(transform.up, ForceMode2D.Impulse);
            // rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            rb.AddForce(randomForce, ForceMode2D.Impulse);

                // GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }

        if (transform.position.x < -screenWidth || transform.position.x > screenWidth ||
            transform.position.y < -screenHeight || transform.position.y > screenHeight)
        {
            // The object is outside the screen bounds
            // Debug.Log("Object went off screen!");

            spawnScript.removeSquareFromList(gameObject);
            Destroy(gameObject);
            spawnScript.decrementLife();
            
        }
    }
}   
