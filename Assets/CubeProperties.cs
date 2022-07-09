using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class CubeProperties : MonoBehaviour
{
    public Color32 color;
    public Game gameref;
    public int idcube;


    public void CubePlay(){ 
        GetComponent<MeshRenderer>().material.color = color;
        GetComponent<AudioSource>().Play();
    }

    public bool isSoundPlaying(){ 
        return GetComponent<AudioSource>().isPlaying;
    }


    public void PlayerChoice(){
        // Si on est dans la showing phase, on interdit le joueur de jouer;
        if (gameref.get_showingPhase())
            return; 

        if (gameref.getCurrentId() == idcube){
            CubePlay();
            gameref.win();
        }
        else{
            StartCoroutine(lostanimation());
            gameref.lost();
        }

    }

    public void resetCube(){
        GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public IEnumerator lostanimation(){
        // Lost sound
        gameref.GetComponent<AudioSource>().Play(); 

        GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        resetCube();
        yield return new WaitForSeconds(0.1f);
        GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        resetCube();

    }

}
