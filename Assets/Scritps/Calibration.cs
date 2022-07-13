using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Input;

public class Calibration : MonoBehaviour
{
    public Controller leftController; 
    public GameObject pivotPoint;

    private Pose controllerPose;
    

    void Update()
    {
        Calibrate();
    }

    void Calibrate(){
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            if (!leftController.TryGetPose(out controllerPose)){
                return;
            }
            pivotPoint.GetComponent<Transform>().position = controllerPose.position - new Vector3(0,0.05f,0);
            pivotPoint.GetComponent<Transform>().rotation = Quaternion.Euler(0, controllerPose.rotation.eulerAngles.y, 0);
        }


    }

}
