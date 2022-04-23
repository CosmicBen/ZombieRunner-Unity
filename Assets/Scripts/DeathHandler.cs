using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas = null;

    private void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;

        FindObjectOfType<WeaponSwitcher>().enabled = false;
        foreach (WeaponZoom zoom in FindObjectsOfType<WeaponZoom>())
        {
            zoom.enabled = false;
        }

        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
