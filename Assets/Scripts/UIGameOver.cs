using UnityEngine;
using TMPro;
public class UIGameOver : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highestScoreText;
    void Start()
    {
        GameManager.Instance.OnGameEnd += DisplayGameOverScreen;
    }


    private void DisplayGameOverScreen()
    {
        container.SetActive(true);

        currentScoreText.text = 
            "Current Score: " + GameManager.Instance.GetScoreManager().GetCurrentScore();


        highestScoreText.text = 
            "Highest Score: " + GameManager.Instance.GetScoreManager().GetHighestScore();
    }
}
