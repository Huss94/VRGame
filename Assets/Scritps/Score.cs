using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float t;
    private int totalScore;
    private int meilleurScore;
    private int scoreMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0; 
        meilleurScore = 0;
        scoreMultiplier = 10;
    }

    public int getMeilleurScore(){
        return meilleurScore;
    }
    public int getScore(){
        return totalScore;
    }

    public void AddScore(){
        float diff = Time.time - t;
        Debug.Log(diff);

        if (diff < 6)
            totalScore += 3*scoreMultiplier;
        else if (diff < 8) 
            totalScore +=2*scoreMultiplier;
        else
            totalScore +=1*scoreMultiplier;

    }

    public void resetScore(){
        totalScore = 0;
    }

    public void endGame(){
        if (meilleurScore < totalScore){
            meilleurScore  = totalScore;
        } 
        Debug.Log("Meilleurscore = " + meilleurScore); 
        resetScore();
    }

    public void onCollision(){
        if (scoreMultiplier > 1)
            scoreMultiplier--;
        
    }
    public int get_scoreMult(){
        return scoreMultiplier;
    }
}
