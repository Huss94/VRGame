using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class TestInteractor : MonoBehaviour
{
    // Start is called before the first frame update
    private PokeInteractor interactor;
    void Start()
    {
        interactor = GetComponent<PokeInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactor.State == InteractorState.Hover){
        }
        Debug.Log("STATE  / / :" + interactor.State);

        
    }
}
