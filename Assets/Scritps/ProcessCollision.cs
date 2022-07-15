using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessCollision : MonoBehaviour
{
    public VRGame gameref;

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "wall") {
        Debug.LogError(other.gameObject.tag);
            gameref.score.onCollision();  
        }

        int scoreMult = gameref.score.get_scoreMult(); 
        if (scoreMult > 7) 
            GetComponent<MeshRenderer>().material.color = Color.blue;
        else if (scoreMult > 4)
            GetComponent<MeshRenderer>().material.color = Color.green;
        else if (scoreMult > 2)
            GetComponent<MeshRenderer>().material.color = Color.red;
        else 
            GetComponent<MeshRenderer>().material.color = Color.white;
    }

    

}
