using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckPoint : MonoBehaviour
{
    public PlayerHealthManager theHealthMan;

    private void Start()
    {
        theHealthMan = FindObjectOfType<PlayerHealthManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag.Equals("Player"))
        {
            theHealthMan.SetSpawnPoint(transform.position);
        }
    }
    
}
