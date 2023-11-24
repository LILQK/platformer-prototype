using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIData : MonoBehaviour
{
    [SerializeField] private TMP_Text coins;
    [SerializeField] private TMP_Text time;

    private float elapsedTime;
    private int totalCoins = 0;
    void Start()
    {
        elapsedTime = 0f;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimeDisplay();
    }

    void UpdateTimeDisplay()
    {
        int minutes = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime % 60);
        int milliseconds = (int)((elapsedTime * 1000) % 1000);

        time.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    public void AddCoin() {
        totalCoins++;
        coins.text = totalCoins.ToString();
    }
}