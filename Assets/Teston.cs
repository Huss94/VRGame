using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teston : MonoBehaviour
{
    public GameObject Hand;
    public GameObject VirtualCube;
    public GameObject RealCube;


    private Vector3 incr = new Vector3(0,0,0.01f);
    private Vector3 T;
    private Vector3 pH;
    private Vector3 w0;
    private Vector3 wT;
    private Vector3 pos;
    private Vector3 w;
    // Start is called before the first frame update
    void Start()
    {
        T = VirtualCube.transform.position  - RealCube.transform.position;
        wT = RealCube.transform.position;



    }

    // Update is called once per frame
    void Update()
    {

        float a = Mathf.Max(0, Mathf.Min(1, (Vector3.Dot((wT - w0), (pH - w0))) / Vector3.Dot(wT - w0, wT - w0)));
        w = T * a;

        Debug.Log("POSITION CHANGEE" + pos);
    }
}
