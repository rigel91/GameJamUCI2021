using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int pointsToPass;

    public TextMeshProUGUI score;
    public TextMeshProUGUI phrase;
    public TextMeshProUGUI buttonLevel;

    public GameObject menu;

    public timer theTimer;
    public BoxCollector boxCollector;
    public gameManager manager;
    public ScoreManager scoreManager;

    [System.NonSerialized]
    public bool stop;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        //theTimer = GetComponent<timer>();
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (theTimer.ringTimer())
        {
            //make the player stop moving
            stop = true;
            phrase.text = "Times up!";
            buttonLevel.text = "Retry Level";
            score.text = scoreManager.score.ToString();
            menu.SetActive(true);
        }
        if (boxCollector.boxCount == manager.totalBoxSpawns)
        {
            //stop the clock count for the scene
            //make the player stop moving
            stop = true;

            if (scoreManager.score >= pointsToPass)
            {
                score.text = scoreManager.score.ToString();
                phrase.text = "You have collected all the boxes and have earned enough points for the next level!";
                buttonLevel.text = "Next Level";
            }
            else
            {
                score.text = scoreManager.score.ToString();
                phrase.text = "You have not earned enough points to move on.";
                buttonLevel.text = "Retry Level";
            }
            menu.SetActive(true);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void NextLevel()
    {
        if (scoreManager.score >= pointsToPass || !theTimer.ringTimer())
        {
            Debug.Log("Next Level");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void MainMenu()
    {
        Debug.Log("Main menu");
    }
}
