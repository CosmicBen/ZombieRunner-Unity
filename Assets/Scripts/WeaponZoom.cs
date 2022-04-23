using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private RigidbodyFirstPersonController fpsController = null;
    [SerializeField] private Camera fpsCamera;
    [SerializeField] private float zoomedInFov = 20.0f;
    [SerializeField] private float zoomedInSensitivity = 0.5f;
    [SerializeField] private float zoomedOutFov = 60.0f;
    [SerializeField] private float zoomedOutSensitivity = 2.0f;

    private bool zoomedInToggle = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle)
            {
                ZoomOut();
            }
            else
            {
                ZoomIn();
            }
        }
    }

    private void ZoomOut()
    {
        fpsCamera.fieldOfView = zoomedOutFov;
        zoomedInToggle = false;
        fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedInFov;
        fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
    }
}
