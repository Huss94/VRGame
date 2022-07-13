using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeleScore : MonoBehaviour
{
    public TextMeshProUGUI MscoreText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimeLeftText;
    public VRGame gameref;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MscoreText.text = "Meilleur Score : " + gameref.score.getMeilleurScore();
        ScoreText.text = "Score : " + gameref.score.getScore();
        if (gameref.gameStarted)
            TimeLeftText.text = "Time Left: " + (int)gameref.getTimeLeft() + "s"; 
        else 
            TimeLeftText.text = "Time Left: 60s";
    }
}
