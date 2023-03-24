using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float currentTime = 90;
    private Scorer scorer;

    private void Awake()
    {
        scorer = GameObject.FindObjectOfType<Scorer>();
    }
    private void Update()
    {
        ProgressTime();

        if(currentTime <= 0)
        {
            WinScreenDisplayer();
        }
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    public void ProgressTime()
    {
        currentTime -= Time.deltaTime;
        timerText.text = currentTime.ToString("F0");
    }
    public void WinScreenDisplayer()
    {
        int blueScore = scorer.ReturnBlueScore();
        int redScore = scorer.ReturnRedScore();

        if (blueScore > redScore)
        {
            SceneManager.LoadScene("BlueTeamWin");
        }
        else if(blueScore < redScore)
        {
            SceneManager.LoadScene("RedTeamWin");
        }
        else if(blueScore == redScore)
        {
            SceneManager.LoadScene("Draw");
        }

    }

}
