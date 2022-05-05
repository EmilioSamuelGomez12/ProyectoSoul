using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public PlayerHealthManager theHealthMan;

    private void Start()
    {
        theHealthMan = FindObjectOfType<PlayerHealthManager>();
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag.Equals("Player") && Player_Movement.shadowState==false)
        {
            theHealthMan.Die();;
        }
    }
}
