using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapOffsetManager : MonoBehaviour
{
    // Start is called before the first frame update

    OVRGrabbable currentHand;
    void Start()
    {
        gameObject.GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHand = gameObject.GetComponent<OVRGrabbable>();
        {
            if (currentHand.grabbedBy.name == "AvatarGrabberLeft")
            {
              //  gameObject.GetComponent<OVRGrabbable>().snapOffset = //read only, figure out how to write to snapOffset...
            }
        }
    }

    private OVRGrabbable NewMethod()
    {
        return gameObject.GetComponent<OVRGrabbable>();
    }
}
