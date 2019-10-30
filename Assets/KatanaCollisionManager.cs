using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaCollisionManager : MonoBehaviour
{
    public GameObject katanaTrail;
    public GameObject bladeTip;
    public int charge;
    public ParticleSystem.EmissionModule emissionModule;
    public ParticleSystem.MinMaxCurve bladeOn = new ParticleSystem.MinMaxCurve(200f);
    public ParticleSystem.MinMaxCurve bladeOff = new ParticleSystem.MinMaxCurve(0f);
    // Start is called before the first frame update
    void Start()
    {
        emissionModule = katanaTrail.GetComponent<ParticleSystem>().emission;
        Debug.Log("rate over time of emission module: " + emissionModule.rateOverTime.constant);
        charge = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "CubeRenderer(Clone)")
        {
            charge++;
            ParticleSystem.MainModule particleMain = katanaTrail.GetComponent<ParticleSystem>().main;
            Debug.Log("Previous multiplier for particle system : " + particleMain.startSizeMultiplier);
            particleMain.startSizeMultiplier = particleMain.startSizeMultiplier + .1f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0.2f)
        {
            bladeTip.GetComponent<ParticleSystemForceField>().gravity = 0.05f;
            OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.RTouch);
            emissionModule.rateOverTime = bladeOn;
            Debug.Log("rate over time of emission module: " + emissionModule.rateOverTime.constant);
        } else
        {
            bladeTip.GetComponent<ParticleSystemForceField>().gravity = 0f;
            OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
            emissionModule.rateOverTime = bladeOff;
            Debug.Log("rate over time of emission module: " + emissionModule.rateOverTime.constant);
        }
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            GameObject.Find("particle spark master").GetComponent<ParticleSystem>().Emit(1);
        }
    }
}
