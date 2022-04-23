using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] private float lightDecay = 0.1f;
    [SerializeField] private float angleDecay = 1.0f;
    [SerializeField] private float minimumAngle = 40.0f;
    
    private Light myLight = null;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }

    public void AddLightIntensity(float intensityAmount)
    {
        myLight.intensity += intensityAmount;
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minimumAngle) { return; }
        myLight.spotAngle = Mathf.Max(myLight.spotAngle - angleDecay * Time.deltaTime, minimumAngle);
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity = Mathf.Max(myLight.intensity - lightDecay * Time.deltaTime, 0.0f);
    }
}
