using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    private bool gameisOver;
    private float gameSpeed = 5f;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    private float score = 0;

    [SerializeField]
    private float speedIncrease = 0.15f;

    [SerializeField]
    private GameObject scoreTxt_obj;
    [SerializeField]
    private GameObject gameStartTxt_obj;

    [SerializeField]
    private GameObject gameOverTxt_obj;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public float getGameSpeed()
    {
        return gameSpeed;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameSpeed();
        if (gameisOver != true)
        {
            UpdateScore();
            handleStartgame();
        }

    }

    private void UpdateGameSpeed()
    {
        gameSpeed += Time.deltaTime * speedIncrease;
    }

    private void UpdateScore()
    {
        score += Time.deltaTime * 10;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }

    private void StartGame()
    {
        Time.timeScale = 0;
        scoreTxt_obj.SetActive(false);
        gameStartTxt_obj.SetActive(true);
        gameOverTxt_obj.SetActive(false);
    }

    private void handleStartgame()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            scoreTxt_obj.SetActive(true);
            gameStartTxt_obj.SetActive(false);

        }
    }

    public void gameOver()
    {
        gameisOver = true;

        gameOverTxt_obj.SetActive(true);
        Time.timeScale = 0;

        StartCoroutine(reloadScene());
    }

    private IEnumerator reloadScene()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
