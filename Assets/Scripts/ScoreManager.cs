using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject playerGoal;
    [SerializeField] private GameObject computerGoal;

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
}
