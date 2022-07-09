using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IWantDebug : MonoBehaviour
{
    public GameObject hand;
    public GameObject offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("OkOKOkOkoK");
        Debug.Log("Hand" + hand.transform.position);
        Debug.Log("offset" + offset.transform.position);
    }
}
