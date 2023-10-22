using UnityEngine;
using TMPro;

public class GunManager : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    //bools
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatisEnemy;

    //Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;
    public CameraShake cameraShake;
    public float camShakeDuration, camShakeMagnitude;
    public TextMeshProUGUI text;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        //Set text to bullets left
        text.SetText(bulletsLeft + " / " + magazineSize);
    }

    private void MyInput()
    {
        //Check if allowed to hold down button and take the corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        //Shoot
        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //Set bulletsShot to bulletsPerTap
            bulletsShot = bulletsPerTap;

            Shoot();
        }
    }


    private void Shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate direction with spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, range, whatisEnemy))
        {
            if (rayHit.collider.CompareTag("Enemy"))
                rayHit.collider.GetComponent<EnemyAIScript>().TakeDamage(damage);
        }

        //Shake camera
        StartCoroutine(cameraShake.Shake(camShakeDuration, camShakeMagnitude));

        //Graphics
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0) 
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }    
    
    private void ResetShot()
    {
        //Allow shooting again
        readyToShoot = true;
    }

    private void Reload()
    {
        //Enable reloading state
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        //Fill magazine
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
