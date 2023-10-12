using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using UnityEngine;


public class FiringPoint : MonoBehaviour
{
    [Header("Rigidbody projectile")]
   
    public float projectileSpeed = 1000f;

    public GameObject[] weapons;
    private int shotCount = 5;
    private bool weapon1Active = true;
    private bool weapon2Active = true;
    private bool weapon3Active = true;



    

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            weapon1Active=true;
            weapon2Active=false; weapon3Active=false;
            print("weapon 1 in use");

        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            weapon1Active = false;
            weapon2Active = true; weapon3Active = false;
            print("weapon 2 in use");
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            weapon1Active = false;
            weapon2Active = false; weapon3Active = true;
            print("weapon 3 in use");
        }

        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            weapon1Active = true;
            weapon2Active = true; 
            weapon3Active = true;
            print("All 3 in use");
        }

       

        if (Input.GetButtonDown("Fire1"))
        {
            if (weapon1Active == true)
                Weapon1();

            if (weapon2Active == true) 
                Weapon2();

            if (weapon3Active == true)
                Weapon3();
        }
    }
     
    void Weapon1()
    {
        //create a reference to hold our instaciate object
        GameObject projectileInstance1;
        //Instanciate our projectile at this objects position and rotation
        projectileInstance1 = Instantiate(weapons[0], transform.position, transform.rotation);
        //add force to the prjectile
        projectileInstance1.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
    }
    
    void Weapon2()
    {
        //create a reference to hold our instaciate object
        GameObject projectileInstance2;
        //Instanciate our projectile at this objects position and rotation
        projectileInstance2 = Instantiate(weapons[1], transform.position, transform.rotation);
        //add force to the prjectile
        projectileInstance2.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
    }
    
    void Weapon3()
    {
        //create a reference to hold our instaciate object
        GameObject projectileInstance3;
        //Instanciate our projectile at this objects position and rotation
        projectileInstance3 = Instantiate(weapons[2], transform.position, transform.rotation);
        //add force to the prjectile
        projectileInstance3.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
    }

    

}
