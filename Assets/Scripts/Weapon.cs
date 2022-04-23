using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera fpCamera = null;
    [SerializeField] private float range = 100.0f;
    [SerializeField] private float damage = 30.0f;
    [SerializeField] private float timeBetweenShots = 0.5f;

    [SerializeField] private ParticleSystem muzzleFlashVfx = null;
    [SerializeField] private ParticleSystem hitVfx = null;
    [SerializeField] private Ammo ammoSlot = null;
    [SerializeField] private AmmoType ammoType = AmmoType.Bullets;
    [SerializeField] private TextMeshProUGUI ammoText = null;

    private bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
        DisplayAmmo();
    }

    private void Update()
    {
        DisplayAmmo();

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    private IEnumerator Shoot()
    {
        canShoot = false;

        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            ProcessRaycast();
            PlayMuzzleFlash();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlashVfx.Play();
    }

    private void ProcessRaycast()
    {
        if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out RaycastHit hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        ParticleSystem impact = Instantiate(hitVfx, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact.gameObject, 1.0f);
    }
}
