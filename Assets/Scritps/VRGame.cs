using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGame : MonoBehaviour
{
    public List<GameObject> Cubes;
    public GameObject warpOrigin;
    public Score score;
    public int TempsPartie = 60;


    public bool gameStarted = false;
    private GameObject currentCube;
    Vector3 virtualCUbePosition;
    private float timer;

    public bool CubeTouched;
    public bool warpOriginTouched;
    // Start is called before the first frame update
    void Start()
    {
        resetAll();
    }
    // Update is called once per frame
    void Update()
    {
        // une partie dure 60 secondes;
        if (gameStarted && outOfTime()) {
            resetAll();
            gameStarted = false;
        }
    }

    // Un nouveau cube est choisi (on entre dans cette méthode lorsque le joueur appui sur le warp origin)
    public void NewCube(){
        System.Random rand = new System.Random(); 
        int randomNnumber = rand.Next(Cubes.Count - 1);
        currentCube = Cubes[randomNnumber];
        currentCube.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    // Si on rentre dans cette fonction c'est que on a touché le cube
    public void resetCube(){
        currentCube.GetComponent<MeshRenderer>().material.color = Color.white;
        warpOrigin.GetComponent<MeshRenderer>().material.color = Color.blue;

    }
    public void resetAll(){
        foreach (var c in Cubes){
            c.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        CubeTouched = false;
        warpOriginTouched = false;
        warpOrigin.GetComponent<MeshRenderer>().material.color = Color.blue;

        score.endGame();
    }

    public Vector3 GetCurrentCubePosition(){
        return currentCube.transform.position;
    }
    public GameObject GetCurrentCube(){
        return currentCube;
    }
    
    public void gameStart(){
        gameStarted = true;
        timer = Time.time;
    }
    public bool outOfTime(){

        if (Time.time - timer > TempsPartie) 
            return true; 
        else 
            return false;

    }

    public float getTimeLeft(){
        float timeLeft = TempsPartie - (Time.time -timer);
        return timeLeft;
    }

}
