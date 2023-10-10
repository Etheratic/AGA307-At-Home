using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 3;
    

   
    public void CheckHealth()
    {
        if (health <= 0)

            Destroy(this.gameObject);
    }

    public void DecreaseHealth()
    {
        health = health -1;
    }

   


}
