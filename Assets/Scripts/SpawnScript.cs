using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SpawnScript : MonoBehaviour
{   

    public GameObject square;

    public int score;
    public int lives;
    int livesToStartWith;
    private float screenWidth;
    private float screenHeight;
    

    public List <GameObject> squaresList = new List<GameObject>();
    public List <GameObject> redSquaresList = new List<GameObject>();
    public List <GameObject> blueSqauresList = new List<GameObject>();
    public List <GameObject> greenSquaresList = new List<GameObject>();


    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText; 
    public TextMeshProUGUI highScoreText;

    public UnityEngine.UI.Button StartButton;
    public UnityEngine.UI.Button ResetHighScoreButton;
    
    public GameObject ColorButtonGroup;


    // Start is called before the first frame update
    void Start()
    {   
        livesToStartWith = lives;
        livesText.text = $"Lives Left: {lives}";

        // TODO: Set high score...
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
        scoreText.text = $"Score: {score}";
        

        // StartCoroutine(MyCoroutine());
        // Debug.Log($"Score is: {score}");

         // Get the screen size in world units
        Camera camera = Camera.main;
        screenHeight = camera.orthographicSize;
        screenWidth = screenHeight * camera.aspect;

        // Debug.Log(screenHeight);
        // Debug.Log(screenWidth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (squaresList.Count > 0)
            {   
                List<GameObject> greenSquares = squaresList.FindAll(square => square.GetComponent<SpriteRenderer>().color == Color.green);
                if (greenSquares.Count > 0)
                {
                    GameObject greenSquareToRemove = greenSquares[0]; // get the first green object
                    squaresList.Remove(greenSquareToRemove); // remove it from the list
                    Destroy(greenSquareToRemove);
                    incrementScore(); 
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (squaresList.Count > 0)
            {   
                List<GameObject> greenSquares = squaresList.FindAll(square => square.GetComponent<SpriteRenderer>().color == Color.blue);
                if (greenSquares.Count > 0)
                {
                    GameObject greenSquareToRemove = greenSquares[0]; // get the first green object
                    squaresList.Remove(greenSquareToRemove); // remove it from the list
                    Destroy(greenSquareToRemove); 
                    incrementScore(); 
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (squaresList.Count > 0)
            {   
                List<GameObject> greenSquares = squaresList.FindAll(square => square.GetComponent<SpriteRenderer>().color == Color.red);
                if (greenSquares.Count > 0)
                {
                    GameObject greenSquareToRemove = greenSquares[0]; // get the first green object
                    squaresList.Remove(greenSquareToRemove); // remove it from the list
                    Destroy(greenSquareToRemove); 
                    incrementScore(); 
                }
            }
        }

        
        
    }

    public void PressGreenButton() 
    {
        if (squaresList.Count > 0)
        {   
            List<GameObject> greenSquares = squaresList.FindAll(square => square.GetComponent<SpriteRenderer>().color == Color.green);

            if (greenSquares.Count == 0) 
            {
                decrementLife();
            }

            if (greenSquares.Count > 0)
            {
                GameObject greenSquareToRemove = greenSquares[0]; // get the first green object
                squaresList.Remove(greenSquareToRemove); // remove it from the list
                Destroy(greenSquareToRemove);
                incrementScore(); 
            }
        }
        else
        {
            decrementLife();
        }
    }

    public void PressBlueButton() 
    {
        if (squaresList.Count > 0)
        {   
            List<GameObject> blueSquares = squaresList.FindAll(square => square.GetComponent<SpriteRenderer>().color == Color.blue);
            
            if (blueSquares.Count == 0) 
            {
                decrementLife();
            }
            
            if (blueSquares.Count > 0)
            {
                GameObject blueSquareToRemove = blueSquares[0]; // get the first green object
                squaresList.Remove(blueSquareToRemove); // remove it from the list
                Destroy(blueSquareToRemove);
                incrementScore(); 
            }
        }
        else
        {
            decrementLife();
        }
        
    }
    public void PressRedButton() 
    {
        if (squaresList.Count > 0)
        {   
            List<GameObject> redSquares = squaresList.FindAll(square => square.GetComponent<SpriteRenderer>().color == Color.red);
            
            if (redSquares.Count == 0) 
            {
                decrementLife();
            }
            
            if (redSquares.Count > 0)
            {
                GameObject redSquareToRemove = redSquares[0]; // get the first green object
                squaresList.Remove(redSquareToRemove); // remove it from the list
                Destroy(redSquareToRemove);
                incrementScore(); 
            }
        }
        else
        {
            decrementLife();
        }
    }


    Coroutine co;

    IEnumerator MyCoroutine()
    {
        while(true){
            yield return new WaitForSeconds(1.5f);
            // Debug.Log("instantiating new square");
            GameObject newSquare = Instantiate(square, transform.position, Quaternion.identity);
            SpriteRenderer spriteRenderer = newSquare.GetComponent<SpriteRenderer>();
            Color[] colors = new Color[3];  
            colors[0] = Color.blue;
            colors[1] = Color.red;
            colors[2] = Color.green;
            spriteRenderer.color = colors[Random.Range(0, colors.Length)];
            // squaresList.Add(newSquare);
            addSquareToList(newSquare);

        }
    }

    public void addSquareToList(GameObject squareToAdd)
    {
        squaresList.Add(squareToAdd);
        // listToAddTo.Add(squareToAdd);
    }

    public void removeSquareFromList(GameObject squareToRemove) 
    {
        squaresList.Remove(squareToRemove);
        // listToRemoveFrom.Remove(squareToRemove);
    }

    public void sayHello() {
        Debug.Log("Hello!");
    }

    public void decrementScore()
    {
        score = score - 1;
    }

    public void incrementScore()
    {
        score = score + 1;
        scoreText.text = $"Score: {score}";
    }

    public void decrementLife()
    {
        lives--;
        livesText.text = $"Lives: {lives}";              
        if (lives == 0)
        {
            EndGame();
        }
     
    }

    public void StartGame()
    {
        co = StartCoroutine(MyCoroutine());
        score = 0;
        // lives = 25;
        scoreText.text = $"Score: {score}";
        livesText.text = $"Lives Left: {lives}";
        StartButton.gameObject.SetActive(false);
        ResetHighScoreButton.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
        ColorButtonGroup.SetActive(true);
    }

    public void EndGame()
    {   
        lives = livesToStartWith;
        livesText.text = $"Lives Left: {lives}";
        highScoreText.gameObject.SetActive(true);
        ColorButtonGroup.SetActive(false);
        int prevHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > prevHighScore)
        {
            SetHighScore(score);
            highScoreText.text = $"High Score: {score}";
        }

        ResetHighScoreButton.gameObject.SetActive(true);
        StartButton.gameObject.SetActive(true);
        foreach (GameObject s in squaresList)
        {
            Destroy(s);
        }
        squaresList.Clear();
        StopCoroutine(co);
    }

    public void SetHighScore(int score) {
        PlayerPrefs.SetInt("HighScore", score);
    }

    public void ResetHighScore() {
        PlayerPrefs.DeleteKey("HighScore");
        highScoreText.text = "High Score: 0";
    }

}   
