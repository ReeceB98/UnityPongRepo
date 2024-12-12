using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject playerGoal;
    [SerializeField] private GameObject computerGoal;

    [SerializeField] private float playerScore;
    [SerializeField] private float compScore;

    [SerializeField] private Text playerScoreText;
    [SerializeField] private Text compScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        playerGoal = GameObject.Find("PlayerGoal");
        computerGoal = GameObject.Find("ComputerGoal");

        //playerScoreText.text = playerScore.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        //playerScoreText.text = playerScore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerGoal")
        {
            Debug.Log("Player's Goal");
        }
    }

    public void SetPlayerScore(int score)
    {
        playerScore += score;
        playerScoreText.text = playerScore.ToString();
    }
    
    public void SetComputerScore(int score)
    {
        compScore += score;
        compScoreText.text = compScore.ToString();
    }
}
