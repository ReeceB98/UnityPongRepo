using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Score values
    [SerializeField] private float playerScore;
    [SerializeField] private float compScore;

    // Scores texts
    [SerializeField] private Text playerScoreText;
    [SerializeField] private Text compScoreText;

    // Set the score for the player
    public void SetPlayerScore(int score)
    {
        playerScore += score;
        playerScoreText.text = playerScore.ToString();
    }
    
    // Set the score for the computer
    public void SetComputerScore(int score)
    {
        compScore += score;
        compScoreText.text = compScore.ToString();
    }
}
