using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaWaveManager : MonoBehaviour
{
    public GameObject katanaTrail; //Given
    public GameObject bladeTip; //Given
    public ParticleSystem bladeSystem;
    //public ParticleSystem.Particle[] bladeBuffer;//not used rn



    public int charge;
    public ParticleSystem.EmissionModule emissionModule;
    public ParticleSystem.MinMaxCurve bladeOn = new ParticleSystem.MinMaxCurve(20f);
    public ParticleSystem.MinMaxCurve bladeOff = new ParticleSystem.MinMaxCurve(0f);
    public ParticleSystemForceField forceField;
    public bool waveDrawn = false;
    public Vector3 waveStartPos;
    public Vector3 waveEndPos;
    public Vector3 waveMidPoint;
    // Start is called before the first frame update
    void Start()
    {
        emissionModule = bladeTip.GetComponent<ParticleSystem>().emission;
        bladeSystem = bladeTip.GetComponent<ParticleSystem>();
        Debug.Log("rate over time of emission module: " + emissionModule.rateOverTime.constant);
        charge = 0;
        //bladeBuffer = new ParticleSystem.Particle[bladeSystem.main.maxParticles];
        forceField = gameObject.GetComponent<ParticleSystemForceField>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        //if (collision.gameObject.name == "CubeRenderer(Clone)")
        //{
        //    charge++;
        //    ParticleSystem.MainModule particleMain = katanaTrail.GetComponent<ParticleSystem>().main;
        //    Debug.Log("Previous multiplier for particle system : " + particleMain.startSizeMultiplier);
        //    particleMain.startSizeMultiplier = particleMain.startSizeMultiplier + .1f;
        //}
    }

    // Update is called once per frame
    void Update()
    {

        if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0.2f)
        {
            waveStartPos = gameObject.transform.position;
            waveDrawn = true;
            //bladeTip.GetComponent<ParticleSystemForceField>().gravity = 0.05f;
            OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.RTouch);
            emissionModule.rateOverDistance = bladeOn;
            bladeSystem.Play();
            Debug.Log("rate over time of emission module: " + emissionModule.rateOverTime.constant);
        }
        else if(OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) <= 0.2f && waveDrawn == true)
        {
            waveEndPos = gameObject.transform.position;
            waveMidPoint = ((waveStartPos + waveEndPos)/2);
            
            //int numParticles = bladeSystem.GetParticles(bladeBuffer);
            //Vector3 particleVelocity = new Vector3(waveMidPoint.x - GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>().centerEyeAnchor.position.x, 0, 
            //    bladeBuffer[numParticles / 2].position.z - GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>().centerEyeAnchor.position.z);
            //particleVelocity = particleVelocity.normalized;
            //for (int i = 0; i < numParticles; i++)
            //{
            //    bladeBuffer[i].velocity = particleVelocity;
            //}
            
            //bladeSystem.SetParticles(bladeBuffer, numParticles);
            forceField.directionX = waveMidPoint.x - GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>().centerEyeAnchor.position.x;
            forceField.directionZ = waveMidPoint.z - GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>().centerEyeAnchor.position.z;

            OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
            emissionModule.rateOverDistance = bladeOff;
            bladeSystem.Stop();
            waveDrawn = false;
            
            Debug.Log("rate over time of emission module: " + emissionModule.rateOverTime.constant);
        }
        //if (OVRInput.GetDown(OVRInput.RawButton.A))
        //{
        //    GameObject.Find("particle spark master").GetComponent<ParticleSystem>().Emit(1);
        //}
    }
}