using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckPoint : MonoBehaviour
{
    public PlayerHealthManager theHealthMan;
    public Canvas textInf;

    private void Start()
    {
        theHealthMan = FindObjectOfType<PlayerHealthManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        textInf.GetComponent<Canvas>().enabled = true;

        if(collider.tag.Equals("Player"))
        {
            theHealthMan.SetSpawnPoint(transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textInf.GetComponent<Canvas>().enabled = false;
    }

}
