using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKey : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private string Animacion;
    [SerializeField] GameObject Key;
    

    bool isOpended = false;

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag(Key.tag))
        {
            if (!isOpended)
            { 
                isOpended = true;
                myDoor.Play(Animacion, 0, 0.0f);
                Key.SetActive(false);
            }
        }
    }
}
