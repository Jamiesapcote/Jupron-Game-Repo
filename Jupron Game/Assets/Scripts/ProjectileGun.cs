using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileGun : MonoBehaviour
{
    //bullet
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardsForce;

    //gun stats 
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsshot;

    //bools
    bool shooting, readyToShoot, reloading;

    //refrences
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics 
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    public bool allowInvoke = true;

    //bug fixing 
    private void Awake()
    {
        // make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        //set ammo display, if it exists 
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletPerTap + " / " + magazineSize / bulletPerTap);
    }
    private void MyInput()
    {
        //check if allowed to hold down button and take corresponding input 
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //reloading 
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        //reload automatically when trying to shoot without ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0) Reload();


        //shooting 
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //set bullets shot to 0 
            bulletsshot = 0;

            Shoot();
        }
    }

        private void Shoot()
        {
            readyToShoot = false;

            //find the exact hit position using a raycast
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));//just a ray through the middle of your screen
            RaycastHit hit;

            //check if ray hits something
            Vector3 targetPoint;
            if (Physics.Raycast(ray, out hit))
                targetPoint = hit.point;
            else
                targetPoint = ray.GetPoint(75);//just a point far awsy from the player 

            //calculate direction from attack 
            Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

            //calculate spread
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            //calculate new direction with spread
            Vector3 directionWithtSpread = directionWithoutSpread + new Vector3(x, y, 0); // just add spread to las direction

            //instantiate bullet/ projectile
            GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
            //rotate bullet to shoot direction 
            currentBullet.transform.forward = directionWithtSpread.normalized;

            //add force to bullet
            currentBullet.GetComponent<Rigidbody>().AddForce(directionWithtSpread.normalized * shootForce, ForceMode.Impulse);
            currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardsForce, ForceMode.Impulse);

            //instantiate muzzle flash, if you have one 
            if (muzzleFlash != null)
                Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

            bulletsLeft--;
            bulletsshot++;

            //invoke reset function  (if not already invoked)
            if (allowInvoke)
            {
                Invoke("ResetShot", timeBetweenShooting);
                allowInvoke = false;
            }
            //if more than  one bulletsPerTap make sure to repeat shoot function 
            if (bulletsshot < bulletPerTap && bulletsLeft > 0)
                Invoke("Shoot", timeBetweenShots);

        }

        private void ResetShot()
        {
            readyToShoot = true;
            allowInvoke = true;
        }
        private void Reload()
        {
            reloading = true;
            Invoke("ReloadFinished", reloadTime);
        }
        private void ReloadFinished()
        {
            bulletsLeft = magazineSize;
            reloading = false;
        }




    
}
