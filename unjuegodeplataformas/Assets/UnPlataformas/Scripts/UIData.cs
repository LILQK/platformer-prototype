using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIData : MonoBehaviour
{
    [SerializeField] private TMP_Text coins;
    [SerializeField] private TMP_Text time;
    [SerializeField] private TMP_Text points;

    private float elapsedTime;
    private int totalCoins = 0;
    private int totalPoints = 0;
    private bool timeGoing = true;
    public static UIData Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        elapsedTime = 0f;
    }

    void Update()
    {
        if (!timeGoing) return;
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
        coins.text = "Coins: " + totalCoins.ToString();
    }

    public void AddPoints(int p) {
        totalPoints += p;
        points.text = "Points:\n " + totalPoints.ToString("D6");
    }

    public void StopTimer() {
        timeGoing = false;
    }
}