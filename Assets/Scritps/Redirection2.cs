using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Input;
using Oculus.Interaction;

public class Redirection2 : MonoBehaviour
{
    public Hand hand;
    public VRGame gameref;
    public GameObject offset;
    public GameObject warpOrigin;
    public GameObject realHand;
    public GameObject planeOnHand;
    public GameObject Sphere; 

    
    // On enrigistre la pose réel pour garder la trace de la vrai main (et peut etre l'afficher pour un rendu visuel de la redirection);
    private Pose realPose;

    private Vector3 realCubePosition;
    private Vector3 virtualCubePosition;
    private Vector3 T; // Distance entre le cube reel et le cube virtuel 
    private Vector3 wO;
    private Vector3 w; // offset
    private Pose poseH;


    void Start()
    {
        realCubePosition = gameref.Cubes[4].transform.position;
        wO = warpOrigin.transform.position;

        // Au départ on veut que le warping soit nul 
        virtualCubePosition = realCubePosition;
        T = virtualCubePosition - realCubePosition;
    }

    void FixedUpdate()
    {
        Azman();
        followVirtualHand();
    }


    private void Azman(){

        // Debug.Log(HandPose.position.z - eyePose.position.z );


            hand.GetRootPose(out poseH);

            Vector3 pH = poseH.position;
            Vector3 wT = realCubePosition; // Cette position est immobile.

            float a = Mathf.Max(0, Mathf.Min(1, (Vector3.Dot((wT - wO), (pH - wO))) / Vector3.Dot(wT - wO, wT - wO)));
            w = a*T;


            offset.transform.position = w;
            // On modifie aussi la position de ce gameObject (redirection2) pour l'utiliser comme origine pokeInteractor : 

            realHand.transform.position  = pH;


    }
    private void followVirtualHand(){
        Pose jointPose;
        Pose middleFingerPose;
        hand.GetJointPose(HandJointId.HandMiddle2, out jointPose);
        hand.GetJointPose(HandJointId.HandMiddle1, out middleFingerPose);
        planeOnHand.transform.position = jointPose.position + w + new Vector3(0,0.05f,0);
        planeOnHand.transform.rotation = poseH.rotation;

        realHand.transform.position = jointPose.position ;
        transform.position = middleFingerPose.position + w; 
    }



    // Lorsqu'on a touché le warpOrigin on  déclanche cette méthode qui permet de dire au jeu de choisir un nouveau cube.
    // En meme temps, elle update la redirection
    public void whenWarpPointTouched(){

        // Dans le cas ou on a deja touché le warpOrigin, on ne fait rien.
        if (!gameref.warpOriginTouched){

            gameref.warpOriginTouched = true;
            gameref.CubeTouched = false;

            gameref.NewCube();
            virtualCubePosition = gameref.GetCurrentCubePosition();

            // Dans le cas d'un recalibrage, il est important de mettre a jour la valeur de realCubePosition
            realCubePosition = gameref.Cubes[4].transform.position;
            T = virtualCubePosition - realCubePosition;

            warpOrigin.GetComponent<MeshRenderer>().material.color = Color.white;
            if (!gameref.gameStarted)
                gameref.gameStart();

            // On lance un timer a chaque fois qu'oon touche warp origin
            gameref.score.t  = Time.time;


            Sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Sphere.transform.position = planeOnHand.transform.position + new Vector3(0,0.006f, 0);


        }
    }


}
