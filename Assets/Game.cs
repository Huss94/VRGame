using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<GameObject> Cubes;
    
    
    private System.Random rnd = new System.Random();

    
    private bool showingPhase; // Si on est en showing phase, l'utilisateur ne joue pas, le jeu montre les couleurs de l'étape suivante 
    private bool creating = false;
    private bool playingPhase = false;
    private int level = 3;
    private Queue<int> order = new Queue<int>();
    private int currentCube ;

    // Variable qui gere si on passe a l'état suivant
    private bool passed {get; set;}
    private float waiting = 0;



    void Start()
    {
        passed = true;  
        showingPhase = true;
    }

    void Update()
    {
        StartCoroutine(gameStart());
    }

    IEnumerator gameStart(){
        if (Input.GetKeyDown("i"))
        {
            print(currentCube);
            print("Count : " + order.Count);
        }
        if(waiting > 0)
            yield return new WaitForSeconds(waiting);
            waiting =  0;

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
                    currentCube = order.Dequeue();

                    passed = false;
                }

            }

            else if (passed){
                // order.Clear(); // Inutile vu que la queue est vide
                playingPhase = false;
                showingPhase = true;
                level ++ ;
                Debug.Log("NIVEAU " + level);
                waiting = 2;


            }

        }
    }

    public int getCurrentId(){
        return Cubes[currentCube].GetComponent<CubeProperties>().idcube;
    }

    public bool get_showingPhase(){
        return showingPhase;
    }

    public void win(){
        passed = true;
    }

    public void lost(){
        level = 3;
        playingPhase = false;
        showingPhase = true;
        creating = false;
        passed = true;
        order.Clear();
        waiting = 4;




    }

    public IEnumerator wait(float s){
        yield return new WaitForSeconds(s); 
    }

    // Create order permet de créer une queue (pile fifo) contenant l'ordre des cubes a retenir
    IEnumerator CreateOrder(int n){
        creating = true;
        for (int i = 0; i  < n ; i++){
            int randomNum = rnd.Next(3);
            order.Enqueue(randomNum);
            Cubes[randomNum].GetComponent<CubeProperties>().CubePlay();
            yield return new WaitForSeconds(0.5f);
            Cubes[randomNum].GetComponent<MeshRenderer>().material.color = Color.white;
            yield return new WaitForSeconds(0.5f);

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
