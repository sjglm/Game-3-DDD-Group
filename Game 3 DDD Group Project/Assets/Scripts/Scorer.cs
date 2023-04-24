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
        if (blueScoreSlider.value == 3)
        {
            SceneManager.LoadScene("BlueTeamWin");
        }
        else if(redScoreSlider.value == 3)
        {
            SceneManager.LoadScene("RedTeamWin");
        }
    }

    public int ReturnBlueScore()
    {
        return (int)blueScoreSlider.value;
    }
    public int ReturnRedScore()
    {
        return (int)redScoreSlider.value;
    }
}
