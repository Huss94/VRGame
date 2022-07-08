using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeProperties : MonoBehaviour
{
    public Color32 color;

    public void CubePlay(){ 
        GetComponent<MeshRenderer>().material.color = color;
        GetComponent<AudioSource>().Play();
    }

    public bool isSoundPlaying(){ 
        return GetComponent<AudioSource>().isPlaying;
    }
}
