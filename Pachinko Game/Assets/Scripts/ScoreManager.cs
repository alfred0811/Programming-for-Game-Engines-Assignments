using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int score = 0;


    public void Add(int points)
    {
        score += points;
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
