using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    GameManager gameManager_Script;

    public int difficulty;

    private void Start()
    {
        button = GetComponent<Button>();
        gameManager_Script = FindObjectOfType<GameManager>();

        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        gameManager_Script.score_Difficulty = difficulty;
        gameManager_Script.StartGame(difficulty);
    }
}
