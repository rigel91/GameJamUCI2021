using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    [System.NonSerialized]
    public int score = 0;

    public int pointReward = 10;
    public int pointPenalty = 10;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();

    }

    private void Awake()
    {
        instance = this;
        //Use ScoreManager.instance.(functionName()) for access all across scripts.
    }

    public void AddPoint()
    {
        score += pointReward;
        updateScoreDisplay();

        //Audio
        AudioManager.instance.Play("ScoreIncrease");
    }

    public void DeductPoints()
    {
        score -= pointPenalty;
        updateScoreDisplay();

        //Audio
        AudioManager.instance.Play("Fail");

    }

    private void updateScoreDisplay()
    {
        scoreText.text = score.ToString();
    }
}
