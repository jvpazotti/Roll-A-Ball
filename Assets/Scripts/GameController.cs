using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float startTime = 30f;
    private float timeRemaining;

    void Start()
    {
        timeRemaining = startTime;
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        timerText.text = "Time Remaining: " + timeRemaining.ToString("F2");

        if (timeRemaining <= 0f)
        {
            SceneManager.LoadScene("Dead-End"); // Replace with your Dead-End scene name
        }
    }
}

