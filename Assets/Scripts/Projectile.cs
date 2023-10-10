using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Target target;
    void Start()
    {
        Destroy(this.gameObject, 8);
    }

    public void OnCollisionEnter(Collision collision)
    {
        //checks if the target is tagged
        if(collision.gameObject.CompareTag("Target"))
        {
            target = collision.gameObject.GetComponent<Target>();
           target.DecreaseHealth();
           target.CheckHealth();

        }
    }
}
