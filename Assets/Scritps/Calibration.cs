using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Input;

public class Calibration : MonoBehaviour
{
    public Controller leftController; 
    public GameObject Table;
    public GameObject pivotPoint;
    public GameObject CameraRig;

    private Pose controllerPose;
    private Transform TDesk;
    private Pose pointerPose;
    // Start is called before the first frame update
    void Start()
    {
        TDesk = Table.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown("c"))
        {
            if (!leftController.TryGetPose(out controllerPose))
                Debug.Log("Return");

           
            pivotPoint.GetComponent<Transform>().position = controllerPose.position;
            pivotPoint.GetComponent<Transform>().rotation = Quaternion.Euler(0, controllerPose.rotation.eulerAngles.y, 0);
            Debug.Log("Controller" + controllerPose.position);
            Debug.Log("Pivot" + pivotPoint.transform.position);
        }

    }

//    void OldCalib()
//    {
//        if (leftController.TryGetPose(out controllerPose))
//            leftController.TryGetPointerPose(out pointerPose);
//        TDesk.rotation = Quaternion.Euler(0, pointerPose.rotation.eulerAngles.y, 0);


//        if (OVRInput.GetDown(OVRInput.Button.One))
//        {
//            Debug.Log("Entr�e ici");
//            if (leftController.isActiveAndEnabled)
//            {


//                if (!leftController.TryGetPose(out controllerPose))
//                    return;
//                if (!leftController.TryGetPointerPose(out pointerPose))
//                    return;
//                float teta = controllerPose.rotation.eulerAngles.y;
//                TDesk.rotation = Quaternion.Euler(0.0f, teta, 0.0f);



//                float c = Mathf.Cos(Mathf.Deg2Rad * teta);
//                float s = Mathf.Sin(Mathf.Deg2Rad * teta);

//                float x = TDesk.localScale.x / 2;
//                float z = TDesk.localScale.z / 2;

//                TDesk.position = controllerPose.position + new Vector3(c * x - s * z, 0, s * x + c * z);
//                Debug.Log("Controller position" + controllerPose.position);
//            }

//        }
//        if (Input.GetKeyDown("m"))
//        {
//            if (!leftController.TryGetPointerPose(out pointerPose))
//                return;
//            if (!leftController.TryGetPose(out controllerPose))
//                return;

//            //Debug.Log("Pointer rotation" + pointerPose.rotation.eulerAngles);
//            Debug.Log("Pointer position" + pointerPose.position);
//            //Debug.Log("controller position" + controllerPose.position);
//        }

    
//}
}
