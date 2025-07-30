using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;

    private Player playerReference;
    private ScoreManager scoreManagerReference;

    private void Awake()
    {
        playerReference = FindAnyObjectByType<Player>();
        scoreManagerReference = FindAnyObjectByType<ScoreManager>();
    }

    private void Start()
    {
        playerReference.health.OnHealthChange += UpdateHealthText;
        scoreManagerReference.OnScoreChange += UpdateScoreText;
    }
    private void UpdateHealthText(int updatedHealthValue)
    {
        healthText.text = updatedHealthValue.ToString() + "%";
    }
    private void UpdateScoreText(int updatedScoreValue)
    {
        scoreText.text = updatedScoreValue.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        //This is bad
        //healthText.text = playerReference.health.GetHealth().ToString();
    }
}
