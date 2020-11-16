using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    Text MoveCounter;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        MoveCounter = this.GetComponent<Text>();
        score = 5;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeText();
    }

    void ChangeText()
    {
        MoveCounter.text = "Moves Left : " + score.ToString();
    }
}
