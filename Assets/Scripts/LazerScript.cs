using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour
{
    public Transform bulletSpawn;

    public GameObject lazer;

    public float speed;

    public Camera cam;

    public int gravityType = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //Find the exact hit position using a raycast
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); //A ray through the middle of your screen
        RaycastHit hit;

        //Checks if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = ray.GetPoint(75); //Just a point far away from the player
        }
        else
        {
            targetPoint = ray.GetPoint(75); //Just a point far away from the player
        }

        //Calculate direction from attackPoint to targetPoint
        Vector3 direction = targetPoint - bulletSpawn.position;

        //Instantiate bullet
        GameObject currentBullet = Instantiate(lazer, bulletSpawn.position, Quaternion.identity);
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = direction.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * speed, ForceMode.Impulse);

        currentBullet.GetComponent<BulletScript>().bulletType = gravityType;
    }
}
