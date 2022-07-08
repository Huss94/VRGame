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
    private int currentCube ;

    // Variable qui gere si on passe a l'état suivant
    private bool passed {get; set;}



    void Start()
    {
        passed = true;  
    }

    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            print(currentCube);
            print("Count : " + order.Count);
        }
        // On montre l'ordre à retenir à l'utilisateur
        if (showingPhase){
            if (!creating)
                StartCoroutine(CreateOrder(level));

        }

        // L'utilisateur doit se rappeler de l'ordre et jouer 
        else if (playingPhase){ 
            if (order.Count > 0){
                if (passed)
                {
                    Debug.Log("On Dequeue");
                    currentCube = order.Dequeue();

                    passed = false;
                }

            }

            else{
                order.Clear();
                playingPhase = false;
                showingPhase = true;
                level ++ ;
            }

        }
    }

    public int getCurrentId(){
        return Cubes[currentCube].GetComponent<CubeProperties>().idcube;
    }

    public void win(){
        Cubes[currentCube].GetComponent<CubeProperties>().CubePlay();
        passed = true;
    }

    public void lost(){
        print("Vous avez perdu");
        level = 3;
        playingPhase = false;
        showingPhase = true;
        creating = false;
        passed = true;
        order.Clear();
    }

    // Create order permet de créer une queue (pile fifo) contenant l'ordre des cubes a retenir
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
