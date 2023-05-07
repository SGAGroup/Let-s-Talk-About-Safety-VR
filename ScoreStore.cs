using TMPro;
using UnityEngine;

public class ScoreStore : MonoBehaviour
{
    private static ScoreStore instance;

    [SerializeField]
    private int scoreValue = 0;

    [SerializeField]
    private TextMeshProUGUI scoreUI;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject); 
        }
    }

    public void AddScore(int value)
    {
        scoreValue += value;
        UpdateUI();
    }

    static public ScoreStore Instance()
    { 
        return instance;
    }

    private void UpdateUI()
    {
        scoreUI.text = scoreValue.ToString();
    }
}
