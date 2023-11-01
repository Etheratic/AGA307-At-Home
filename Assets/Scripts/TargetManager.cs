using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum sizes
{
    Small, Medium, Large
}


public class TargetManager : Singleton<TargetManager>
{

    public Transform[] spawnPoints;
    public List<GameObject> targets;
  

    private Target Target;

    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            SpawnAtRandom();
           
            
        }
        GetTargetCount();
        
    }

    public Transform GetRandomSpawnpoint() 
    { 
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    
    }
    
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.I))
        {
            SpawnAtRandom();
           
        }


    }

    public void DestroyTarget(GameObject _target)
    {
        Destroy(_target);
        GetTargetCount() ;
    }

    public void GetTargetCount()
    {
        _UI.UpdateTarget(targets.Count);

    }
 
    private void SpawnAtRandom()
    {
        if (targets.Count == 0)
            return;

        //randomise the target type and the spawn points
        int rndTarget = Random.Range(0, targets.Count - 1);
        int rndSpawnPoint = Random.Range(0, spawnPoints.Length - 1);

      //spawn in the enemies
        GameObject target = Instantiate(targets[rndTarget], spawnPoints[rndSpawnPoint].position, spawnPoints[rndSpawnPoint].rotation);
        targets.Add(target);
        GetTargetCount();
    }

}
