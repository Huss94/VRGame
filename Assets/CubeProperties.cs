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


    public void gameProcess(){
        print("idcube = " + idcube);
        print("idcurr = " + gameref.getCurrentId());
        if (gameref.getCurrentId() == idcube){
            gameref.win();
        }
        else{
            gameref.lost();
        }

    }


}
