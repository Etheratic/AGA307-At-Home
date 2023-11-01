using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : GameBehaviour
{

    public int health = 3;
    public float speed = 10f;
  
    public float scalefactor = 1;
    public sizes sizes;
    public TargetManager _TM;

    public Transform moveToPos;




    private void Start()
    {
        _TM = FindObjectOfType<TargetManager>();
        SetUp();
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            ChangeSize();
        }
    }
    public void SetUp()
    {
        switch(sizes)
        {
            case sizes.Small:
                health = 1;
                gameObject.transform.localScale = Vector3.one * scalefactor * .5f;
                speed = speed * 2;
            break;
            case sizes.Medium:
                gameObject.transform.localScale = Vector3.one * scalefactor * 1f;
                health = 3;
               ;
            break;
            case sizes.Large:
                health = 5;
                speed = speed / 2;
                gameObject.transform.localScale = Vector3.one * scalefactor * 3;
                
                break;
        }

        StartCoroutine(Move());
    }

    private void ChangeSize()
    {
        
        gameObject.transform.localScale = Vector3.one * scalefactor * Random.Range(.5f, 10);
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

    public void CheckHealth()
    {
        if (health <= 0)
            _TM.DestroyTarget(this.gameObject);
      
        
    }

    public void DecreaseHealth()
    {
        health = health -1;
    }


   

}
