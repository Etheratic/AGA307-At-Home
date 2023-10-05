using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 3;
    private Projectile Projectile;

   
    void Start()
    {
        
    }

    public void DecreaseHealth()
    {
        health -= 1;
    }

    private void DestroyTarget()
    {
        if (health <= 0)
            Debug.Log("working");
            //Destroy(this.gameObject);
    }


}
