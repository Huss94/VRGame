using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Input;
using Oculus.Interaction;

public class HMDtest : MonoBehaviour
{
    public Hand h;
    public Game gameref;
    public GameObject virtualHand;
    public GameObject offset;

    
    // On enrigistre la pose réel pour garder la trace de la vrai main (et peut etre l'afficher pour un rendu visuel de la redirection);
    private Pose realPose;

    private bool RedirectionOn;
    private Vector3 realCubePose;
    private Vector3 virtualCubePose;
    private Vector3 T; // Distance entre le cube reel et le cube virtuel 
    private Vector3 wO;
    // Start is called before the first frame update
    void Start()
    {
        RedirectionOn = false;        

        UpdateRedirection();
    // Le cube au mileu est toujours le cube réel;
        realCubePose = gameref.Cubes[1].GetComponent<Transform>().position;

    }

    // Update is called once per frame
    void Update()
    {
        // if (gameref.get_showingPhase()) return;
        Azman();

    }


    void Azman(){

        // Debug.Log(HandPose.position.z - eyePose.position.z );


            Pose poseH;  
            Pose eyePose;

            h.GetRootPose(out poseH);
            h.GetCenterEyePose(out eyePose);
            Debug.Log("Distance " +Vector3.Distance(poseH.position, eyePose.position));

            if (Vector3.Distance(poseH.position, eyePose.position) < 0.3){
                UpdateRedirection();
                setNewHandPose(poseH.position);
            }


            wO = new Vector3(0.2f, 1 , 0.08f);

            Vector3 pH = poseH.position;
            Vector3 wT = realCubePose;

            float a = Mathf.Max(0, Mathf.Min(1, (Vector3.Dot((wT - wO), (pH - wO))) / Vector3.Dot(wT - wO, wT - wO)));

            Vector3 w = a*T;
            

            offset.transform.position = w;
            setNewHandPose(pH + w);



            if (Input.GetKeyDown("m")){
                Debug.Log("a  = " + a);
        }


    }

    bool setNewHandPose(Vector3 position){ 
        if (h.isActiveAndEnabled){
            virtualHand.transform.position = position;
            return true;
        }
        
        return false;
    }


    /// <summary>
    /// C'est ici que le liens entre les cube virtuel et les cubes réel se fait, 
    /// et que le warp Origin est défini 
    /// </summary>
    /// <param name="warpOr"></param>
    void UpdateRedirection(){

        Pose HandPose;
        // Pose eyePose;
        h.GetRootPose(out HandPose);
        // h.GetCenterEyePose(out eyePose);

        // if (HandPose.position.z > eyePose.position.z + 0.1){
        //     Debug.Log("Main trop loin pour le warpOrigin, veuillez reculer la main");
        // }
            virtualCubePose = gameref.getCurrentCubePose();
            wO = HandPose.position;
            T = virtualCubePose - realCubePose;
            RedirectionOn = true;
            // Debug.Log("WO = " + wO);
            

    }

}
