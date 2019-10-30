using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{


    public bool hasBeenHit;
    // Start is called before the first frame update
    void Start()
    {
        hasBeenHit = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        hasBeenHit = true;
        Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<CapsuleCollider>());
        Rigidbody arrowBody = gameObject.GetComponent<Rigidbody>();
        arrowBody.velocity = new Vector3(0, 0, 0);
        //arrowBody.useGravity = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (hasBeenHit)
        {
            gameObject.GetComponent<AudioSource>().Play();
            //gameObject.transform.Rotate(1080 * Time.deltaTime, 0, 0); //rotates 50 degrees per second around x axis
        }
        else
        {
            gameObject.transform.LookAt(GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>().centerEyeAnchor.position);
        }
    }
}
