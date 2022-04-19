using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateTrigger : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private string Animacion;

    bool isOpended = false;

    void OnTriggerEnter(Collider col)
    {
        if (!isOpended)
        {
            isOpended = true;
            myDoor.Play(Animacion, 0, 0.0f);
        }    
       
    }
}
