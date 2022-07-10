using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCalib : MonoBehaviour
{
    public GameObject o1;
    public GameObject o2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
            process();
    }

    public void process(){
        Quaternion a = o1.transform.rotation;
        Quaternion b = o2.transform.rotation;
        Debug.Log(a.eulerAngles - b.eulerAngles);
    }
}
