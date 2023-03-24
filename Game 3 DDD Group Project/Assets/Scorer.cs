using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    public Slider blueScoreSlider;
    public Slider redScoreSlider;

    private void Start()
    {
        blueScoreSlider.value = 0;
        redScoreSlider.value = 0;
    }

    private void Update()
    {
        ScoreChecker();
    }

    public void IncreaseRedScore()
    {
        redScoreSlider.value += 1;
    }

    public void IncreaseBlueScore()
    {
        blueScoreSlider.value += 1;
    }

    public void ScoreChecker()
    {
        if (blueScoreSlider.value == 5)
        {
            SceneManager.LoadScene("BlueTeamWin");
        }
        else if(redScoreSlider.value == 5)
        {
            SceneManager.LoadScene("RedTeamWin");
        }
    }
}