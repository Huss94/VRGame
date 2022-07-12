using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Input;
public class FollowHand : MonoBehaviour
{
    public Hand h; 
    private Pose pose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h.GetRootPose(out pose); 
        GetComponent<Transform>().position = pose.position;

        
    }
}
