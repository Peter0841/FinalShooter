using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public int currentMag = 30;
    public float bulletSpeed = 40f;

    public Transform cameraPos;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    private HudController hudController;

    void Start()
    {
        hudController = GameObject.Find("Canvas").GetComponent<HudController>();
    }

    void Update()
    {

        if(currentMag <= 0)
        {
            hudController.ShowWarning();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            hudController.HideWarning();
            hudController.ammo = 30;
            hudController.UseAmmo(0);
            currentMag = 30;
        }

        if(Input.GetMouseButtonDown(0) && currentMag > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = bulletSpawn.forward * bulletSpeed;
            }
            currentMag -= 1;
            hudController.UseAmmo(1);
            Debug.Log(currentMag);
            if(bullet != null)
            {
                Destroy(bullet, 2f);
            }         
        }
    }
}
