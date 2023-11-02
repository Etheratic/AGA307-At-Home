using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : GameBehaviour
{
    public static event Action<GameObject> OnTargetHit = null;
    public static event Action<GameObject> OnTargetDie = null;

    public sizes sizes;

    public int myHealth;
    private int baseHealth = 100;
    public float speed = 10f;

  
    public float scalefactor = 1;
    public int myScore;
    
   
    public TargetManager _TM;


    public Transform moveToPos;




    private void Start()
    {
        switch (sizes)
        {
            case sizes.Small:
                myHealth = 1;
                gameObject.transform.localScale = Vector3.one * scalefactor * .5f;
                speed = speed * 2;
                myScore = 1;
                break;
            case sizes.Medium:
                gameObject.transform.localScale = Vector3.one * scalefactor * 1f;
                myHealth = 3;
                myScore = 2;
                
                break;
            case sizes.Large:
                myHealth = 5;
                speed = speed / 2;
                gameObject.transform.localScale = Vector3.one * scalefactor * 3;
                myScore = 3;
                break;
        }
        _TM = FindObjectOfType<TargetManager>();
        SetUp();
    }

    public void Die()
    {
        OnTargetDie?.Invoke(this.gameObject);

        StopAllCoroutines();
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            //ChangeSize();
        }
    }
    public void SetUp()
    {
      

        StartCoroutine(Move());
    }

  
    IEnumerator Move()
    {
        moveToPos = _TM.GetRandomSpawnpoint();
        
        while(Vector3.Distance(transform.position,moveToPos.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToPos.position, Time.deltaTime * speed);
            yield return null;
        }

        yield return new WaitForSeconds(3);
        StartCoroutine(Move());
    }

    public void Hit(int _damage)
    {
        myHealth -= _damage;

        _GM.AddScore(myScore);
        _TI.IncrementTimer(5.00f);
        if (myHealth <= 0)
        {
            Die();
        }
        else
        {
            OnTargetHit?.Invoke(this.gameObject);
        }
    }
    public void CheckHealth()
    {
        if (myHealth <= 0)
            _TM.DestroyTarget(this.gameObject);
      
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Projectile"))
        {
            Hit(collision.gameObject.GetComponent<Projectile>().damage);
        }
    }






}
