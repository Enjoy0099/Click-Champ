using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI LivesText;
    public GameObject titleScreen;
    public GameObject pauseScreen;
    public GameObject exitButton;

    private int score;
    private float spawnRate = 1f;
    public bool isGameActive;

    public Slider volume_Slider;
    public AudioSource bg_Music;

    [HideInInspector]public int game_Lives = 3;

    [HideInInspector]public int score_Difficulty;
    public void StartGame(int difficulty)
    {
        titleScreen.SetActive(false);
        spawnRate /= difficulty;

        score = 0;
        UpdateScore(0);

        StartCoroutine(SpawnTarget());
        isGameActive = true;

        LivesText.text = "Lives: " + game_Lives.ToString("00");
        exitButton.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        yield return new WaitForSeconds(spawnRate);
        if(isGameActive)
        {
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            StartCoroutine(SpawnTarget());
        }
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += (scoreToAdd * score_Difficulty);
        scoreText.text = "Score: " + score.ToString("00");
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        bg_Music.volume = volume_Slider.value;

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
            }
                
            else
            {
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
            }
        }
    }


    public void ExitGame()
    {
        Application.Quit();
    }

}
