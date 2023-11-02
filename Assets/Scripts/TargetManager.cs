using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum sizes
{
    Small, Medium, Large
}


public class TargetManager : Singleton<TargetManager>
{

    public Transform[] spawnPoints;
   
    public GameObject[] targetTypes;

    public List<GameObject> targets;


    private Target Target;

    void Start()
    {
        StartCoroutine(SpawnDelay());      
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

        if(Input.GetKeyUp(KeyCode.K))
        {
            KillAllTargets();
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
    /// <summary>
    /// kills specific target
    /// </summary>
    /// <param name="target_">the target we want to kill</param>
    public void KillTarget(GameObject target_)
    {
        if (targets.Count == 0)
            return;

        Destroy(target_);
        targets.Remove(target_);
        GetTargetCount();
    }
    /// <summary>
    /// kills all targets in the scene
    /// </summary>
    void KillAllTargets()
    {
        if (targets.Count == 0)
            return;

        for (int i = targets.Count - 1; i >=0; i--)
        {
            KillTarget(targets[0]);
        }
        GetTargetCount();
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

    IEnumerator SpawnDelay()
    {
        for(int i = 0; i < spawnPoints.Length;i++) 
        {
            int rnd = Random.Range(0, targetTypes.Length);
            GameObject target = Instantiate(targetTypes[rnd], spawnPoints[i].position, spawnPoints[i].rotation);
            targets.Add(target);
            GetTargetCount();
            yield return new WaitForSeconds(2);
        
        }
    }
    /// <summary>
    /// event system
    /// </summary>
    private void OnEnable()
    {
        Target.OnTargetDie += KillTarget; 
    }

    private void OnDisable() 
    {
        Target.OnTargetDie -= KillTarget;
    }
}
