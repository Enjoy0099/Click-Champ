using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;

    private int score;
    private float spawnRate = 1f;
    public bool isGameActive;

    [HideInInspector]public int score_Difficulty;
    public void StartGame(int difficulty)
    {
        titleScreen.SetActive(false);
        spawnRate /= difficulty;

        score = 0;
        UpdateScore(0);

        StartCoroutine(SpawnTarget());
        isGameActive = true;
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

}
