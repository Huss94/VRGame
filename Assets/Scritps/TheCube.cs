using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCube : MonoBehaviour
{
    public int id; 
    public VRGame gameref;

    public void whenCubeTouched(){
        if (gameref.CubeTouched || !gameref.gameStarted) return;

        GameObject currentCube = gameref.GetCurrentCube();
        if (currentCube.GetComponent<TheCube>().id == id){
            gameref.resetCube();

            gameref.CubeTouched = true;
            gameref.warpOriginTouched = false;
            
            gameref.score.AddScore();
        }
    }
}
