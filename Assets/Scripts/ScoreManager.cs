using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    int score = 0;

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
        score += 10;
        scoreText.text = score.ToString();
    }
}
