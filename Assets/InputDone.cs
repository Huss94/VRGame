using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDone : MonoBehaviour
{
    public CubeProperties reff1;
    public CubeProperties reff2;
    public CubeProperties reff3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a")){
            reff1.gameProcess();
            Debug.Log("Carré 1");
        }

        if (Input.GetKeyDown("z")){
            reff2.gameProcess();
            Debug.Log("Carré 2");
        }

        if (Input.GetKeyDown("e")){
            reff3.gameProcess();
            Debug.Log("Carré 3");
        }
    }
}
