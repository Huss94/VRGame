using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Input;

public class HMDtest : MonoBehaviour
{
    public Hand h;
    public Game gameref;
    
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

        // Le cube au mileu est toujours le cube réel;
        realCubePose = gameref.Cubes[1].GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameref.get_showingPhase()) return;
        test();
        // Azman();


    }

    void test(){
        if (Input.anyKeyDown){
            setNewHandPose(new Vector3(0,0.8f,2f));
            Debug.Log("POSE MODIfiée");

        }
    }
    void Azman(){
        if (!RedirectionOn)
            TurnRedirectionON();
        
        else{
            Pose poseH;  
            h.GetRootPose(out poseH);

            Vector3 pH = poseH.position;
            Vector3 wT = realCubePose;

            float a = Mathf.Max(0, Mathf.Min(1, (Vector3.Dot((wT - wO), (pH - wO))) / Vector3.Dot(wT - wO, wT - wO)));

            Vector3 w = a*T;

            setNewHandPose(pH + w);
        }


    }

    bool setNewHandPose(Vector3 position){ 
        if (h.isActiveAndEnabled){
            var rotation = h.GetData().Root.rotation;

            h.GetData().Root = new Pose(position, rotation); 

            h.GetData().RootPoseOrigin = PoseOrigin.FilteredTrackedPose;

            return true;
        }
        
        return false;
    }


    /// <summary>
    /// C'est ici que le liens entre les cube virtuel et les cubes réel se fait, 
    /// et que le warp Origin est défini 
    /// </summary>
    /// <param name="warpOr"></param>
    void TurnRedirectionON(){

        Pose HandPose;
        Pose eyePose;
        h.GetRootPose(out HandPose);
        h.GetCenterEyePose(out eyePose);

        if (HandPose.position.z > eyePose.position.z + 0.4){
            Debug.Log("Main trop loin pour le warpOrigin, veuillez reculer la main");
        }
        else{
            virtualCubePose = gameref.getCurrentCubePose();
            wO = HandPose.position;
            T = virtualCubePose - realCubePose;
            RedirectionOn = true;
            
        }

    }

}
