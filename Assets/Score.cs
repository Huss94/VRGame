using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float t;
    private int totalScore;
    private int meilleurScore;
    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0; 
        meilleurScore = 0;
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

        if (diff < 5)
            totalScore += 3;
        else if (diff < 7) 
            totalScore +=2;
        else if (diff < 10)
            totalScore +=1;
        else 
            return;

        Debug.Log("Score : " + totalScore);
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
}
