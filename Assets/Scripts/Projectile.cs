using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : GameBehaviour
{
    private Target target;
    public int damage = 1;

    public static event Action<GameObject> OnEnemyHit = null;

    void Start()
    {
        Destroy(this.gameObject, 8);
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    //checks if the target is tagged
    //    if(collision.gameObject.CompareTag("Target"))
    //    {
    //        //change the colour of the target
    //        collision.gameObject.GetComponent<Renderer>().material.color = Color.green;
    //        //destroy target after 1 second
    //        Destroy(collision.gameObject, 1);
    //        //destroy this object
    //        Destroy(this.gameObject);


    //    }
    //}
}
