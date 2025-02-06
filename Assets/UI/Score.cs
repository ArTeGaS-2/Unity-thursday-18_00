using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score Instance;
    public int score = 0;
    public TextMeshProUGUI text;
    private void Start()
    {
        Instance = this;
        text.text = "Рахунок: 0";
    }
    public void AddScore()
    {
        score++;
        text.text = $"Рахунок: {score}";
    }
}
