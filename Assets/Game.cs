using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<GameObject> Cubes;
    
    private System.Random rnd = new System.Random();
    
    private bool showingPhase = true;// Si on est en showing phase, l'utilisateur ne joue pas, le jeu montre les couleurs de l'étape suivante 
    private bool creating = false;
    private bool playingPhase = false;
    private int level = 3;
    private Queue<int> order = new Queue<int>();

    void Start()
    {

    }

    void Update()
    {
        if (showingPhase){
            if (!creating)
                StartCoroutine(CreateOrder(level));

        }

        else if (playingPhase){ // Lorqu'on joue
            foreach (var i in order){
                print(i);
            }
            playingPhase = false;
        }
    }
    

    IEnumerator CreateOrder(int n){
        creating = true;
        for (int i = 0; i  < n ; i++){
            int randomNum = rnd.Next(3);
            order.Enqueue(randomNum);
            Cubes[randomNum].GetComponent<CubeProperties>().CubePlay();
            yield return new WaitForSeconds(1);
            Cubes[randomNum].GetComponent<MeshRenderer>().material.color = Color.white;
            yield return new WaitForSeconds(1);

        }

        creating = false;
        showingPhase = false;
        playingPhase = true;
    }  
        

    bool isACubePlaying(){
        foreach(GameObject c in Cubes){
            if (c.GetComponent<CubeProperties>().isSoundPlaying()){
                return true;
            }
        }
        return false;

    }
    
}
