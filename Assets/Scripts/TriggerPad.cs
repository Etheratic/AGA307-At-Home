using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class TriggerPad : GameBehaviour
{
    public GameObject triggeredObject;


    private void OnTriggerEnter(Collider other)
    {
        triggeredObject.GetComponent<Renderer>().material.color = Color.black;
    }

    private void OnTriggerStay(Collider other)
    {
        triggeredObject.transform.localScale += Vector3.one * 0.4f;
        triggeredObject.transform.position += Vector3.one * 0.01f;
    }

    private void OnTriggerExit(Collider other)
    {
        triggeredObject.GetComponent<Renderer>().material.color = Color.white;
        triggeredObject.transform.localScale = Vector3.one;
        triggeredObject.transform.position = new Vector3(-70, 5, -70);
    }
}
