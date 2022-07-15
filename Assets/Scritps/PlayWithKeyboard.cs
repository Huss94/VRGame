using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWithKeyboard : MonoBehaviour
{
    public Redirection2 rightRedirection;
    public List<GameObject> Cubes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w")){
            rightRedirection.whenWarpPointTouched();
        } 

        if(Input.GetKeyDown("1")){
            Cubes[1].GetComponent<TheCube>().whenCubeTouched();
        } 
        if(Input.GetKeyDown("2")){
            Cubes[2].GetComponent<TheCube>().whenCubeTouched();

        } 

        if(Input.GetKeyDown("3")){
            Cubes[3].GetComponent<TheCube>().whenCubeTouched();

        } 

        if(Input.GetKeyDown("4")){
            Cubes[4].GetComponent<TheCube>().whenCubeTouched();

        } 
        if(Input.GetKeyDown("5")){
            Cubes[5].GetComponent<TheCube>().whenCubeTouched();

        } 
        if(Input.GetKeyDown("6")){
            Cubes[6].GetComponent<TheCube>().whenCubeTouched();

        } 
        if(Input.GetKeyDown("7")){
            Cubes[7].GetComponent<TheCube>().whenCubeTouched();

        } 
        if(Input.GetKeyDown("8")){
            Cubes[8].GetComponent<TheCube>().whenCubeTouched();

        } 
        if(Input.GetKeyDown("0")){
            Cubes[0].GetComponent<TheCube>().whenCubeTouched();

        } 

    }
}
