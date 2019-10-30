using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrowLauncher : MonoBehaviour
{
    public GameObject bulletPrefab;
    // public GameObject explosionPrefab;
    private DateTime lastLaunch;
    // Start is called before the first frame update
    void Start()
    {
        lastLaunch = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        if (DateTime.Now.Subtract(lastLaunch).TotalMilliseconds > 5000)
        {
            lastLaunch = DateTime.Now;
            Vector3 playerPos = GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>().centerEyeAnchor.position;
            Vector3 rawBulletVelocity = playerPos - gameObject.transform.position;
            // Rigidbody bulletBody = new Rigidbody();
            GameObject spawnedBullet = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.LookRotation(rawBulletVelocity));
            Debug.Log("bulletinstantiated ");
            // GameObject spawnedExplosion = Instantiate(explosionPrefab, spawnedBullet.transform);
            //  spawnedExplosion.GetComponent<ParticleSystem>().Stop();
            //  spawnedExplosion.AddComponent<particleAttractorSpherical>();
            //spawnedBullet.GetComponentInChildren<ParticleSystem>().Stop();
            //Debug.Log("Name of avatar object = " + GameObject.Find("CenterEyeAnchor").name);

            // Debug.Log("spawned cube bullet prefab!");
            
            //Debug.Log("player position(eye anchor): " + playerPos.ToString());
            
            //spawnedBullet.transform.rotation = Quaternion.LookRotation(rawBulletVelocity);
            // Debug.Log("raw bullet velocity = " + rawBulletVelocity.ToString());
            Vector3 bulletVelocity = rawBulletVelocity.normalized * 2;
            // Debug.Log("bullet velocity = " + bulletVelocity.ToString());
            // Debug.Log("spawned bullet's name " + spawnedBullet.name);
            ///////spawnedBullet.AddComponent<Rigidbody>();
            //spawnedBullet.AddComponent<CubeCollisionManager>();
            //ParticleSystem ps = Instantiate(GameObject.Find("Cube Explosion Effect").GetComponent<ParticleSystem>());
            Rigidbody bulletBody = spawnedBullet.GetComponent<Rigidbody>();
            bulletBody.useGravity = false;
            // Debug.Log("rigid body on bullet spawn: " + spawnedBullet.GetComponent<Rigidbody>());
            bulletBody.velocity = bulletVelocity;
            Debug.Log("name of spawned bullet: " + spawnedBullet.name);
        }
    }
}

