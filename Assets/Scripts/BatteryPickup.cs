using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] private float restoreAngle = 60.0f;
    [SerializeField] private float addIntensity = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FlashLightSystem flashLight = other.GetComponentInChildren<FlashLightSystem>();
            flashLight.RestoreLightAngle(restoreAngle);
            flashLight.AddLightIntensity(addIntensity);
            Destroy(gameObject);
        }
    }
}
