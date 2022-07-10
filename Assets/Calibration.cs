using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Input;

public class Calibration : MonoBehaviour
{
    public Controller leftController; 
    public GameObject Desk;
    public GameObject CameraRig;

    private Pose controllerPose;
    private Vector3 sizeofDesk;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 sizeofDesk = Desk.GetComponentInChildren<BoxCollider>().size;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c")){
            if (leftController.isActiveAndEnabled){
                if (!leftController.TryGetPose(out controllerPose))
                    return;

            Debug.Log("CALIBRATION");

            Vector3 offset = new Vector3(sizeofDesk.x/2, 0, -0.10f);
            CameraRig.transform.position = controllerPose.position + offset;

            Vector3 newRotation = leftController.transform.rotation.eulerAngles - CameraRig.transform.rotation.eulerAngles;
            CameraRig.transform.rotation  = Quaternion.Euler(newRotation);


            }
            
        }
    }
}
