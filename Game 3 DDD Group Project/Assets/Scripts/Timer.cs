using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float currentTime = 100;
    private bool Paused = false;
    private void Update()
    {
        if(Paused == false)
        {
            currentTime -= Time.deltaTime;
            timerText.text = currentTime.ToString("F0");
        }
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    public void Pause()
    {
        Paused = true;
    }
}
