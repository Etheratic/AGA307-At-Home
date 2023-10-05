using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    [Header("Rigidbody projectile")]
    public GameObject projectileBullet;
    public float projectileSpeed = 1000f;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
            FireRigidBody();
    }
     
    void FireRigidBody()
    {
        //create a reference to hold our instaciate object
        GameObject projectileInstance;
        //Instanciate our projectile at this objects position and rotation
        projectileInstance = Instantiate(projectileBullet, transform.position, transform.rotation);
        //add force to the prjectile
        projectileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
    }

}
