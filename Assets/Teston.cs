using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teston : MonoBehaviour
{
    // Show where the hand should be in the scene if it were not redirected.
    public bool ShowRealHand;
    public GameObject VirtualCube;
    public GameObject RealCube;
    public GameObject offset;

    public OVRHand hand;

    // On va enregistrer le Warp orgigin au point ou la main est tracké pour la premiere fois  (ceci est un test)
    private bool first_time_tracked; 




    private Vector3 T;
    private Vector3 pH;
    private Vector3 w0;
    private Vector3 wT;
    private Vector3 w;

    void Start()
    {
        T = VirtualCube.transform.position  - RealCube.transform.position;
        w = new Vector3(0,0,0);



    }

    void Update()
    {
        if(first_time_tracked){

        

            wT = RealCube.transform.position;
            pH = hand.PointerPose.position - w;
            float a = Mathf.Max(0, Mathf.Min(1, (Vector3.Dot((wT - w0), (pH - w0))) / Vector3.Dot(wT - w0, wT - w0)));
            w = T * a;
            hand.PointerPose.position += pH + w;
            // hand.PointerPose.position += pH + w;
            // offset.transform.position += pH + w;

        }
        else{
            if (hand.IsTracked){
                w0 = hand.PointerPose.position;
                first_time_tracked = true;
            }

        }
    }
}
