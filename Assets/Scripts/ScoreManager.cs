using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject playerGoal;
    [SerializeField] private GameObject computerGoal;


    private Text playerScoreText;
    private Text compScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        playerGoal = GameObject.Find("PlayerGoal");
        computerGoal = GameObject.Find("ComputerGoal");
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerGoal")
        {
            Debug.Log("Player's Goal");
        }
    }
}
