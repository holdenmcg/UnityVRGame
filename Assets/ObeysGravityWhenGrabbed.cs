using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeysGravityWhenGrabbed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<OVRGrabbable>().isGrabbed)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
