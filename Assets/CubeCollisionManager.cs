using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollisionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CubeExplosionEffect;
    
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       // //  OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);//vibration on right controller on cube hit
       // //gameObject.GetComponent<AudioSource>().Play();
       // //KatanaTrailPower = KatanaTrailPower + 0.1f;
        GameObject explosionEffect = Instantiate(CubeExplosionEffect, this.gameObject.transform.position, Quaternion.identity) as GameObject;
        explosionEffect.GetComponent<ParticleSystem>().Play();
        Destroy(explosionEffect, 2); //asyncrhoniosueas?
        Destroy(gameObject);
        
     //   }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
