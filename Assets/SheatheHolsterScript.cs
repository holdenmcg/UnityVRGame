using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheatheHolsterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>().centerEyeAnchor.position - new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>().transform.position - new Vector3(0, 0.2f, 0);
        gameObject.transform.rotation = GameObject.Find("Katana").transform.rotation;
    }
}
