using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
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
            reff1.PlayerChoice();
        }

        if (Input.GetKeyDown("z")){
            reff2.PlayerChoice();
        }

        if (Input.GetKeyDown("e")){
            reff3.PlayerChoice();
        }


        if (Input.GetKeyUp("a")){
            reff1.resetCube();
        }
        if (Input.GetKeyUp("z")){
            reff2.resetCube();
        }
        if (Input.GetKeyUp("e")){
            reff3.resetCube();
        }

    }
}
