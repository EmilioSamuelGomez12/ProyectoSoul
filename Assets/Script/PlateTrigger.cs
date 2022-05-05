using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] DoorsOrPlatforms;
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private string Animacion;
    [SerializeField] private int DoorType;

    bool isOpended = false;

    void OnTriggerEnter(Collider col)
    {
        if (!isOpended)
        {
            switch (DoorType) 
            {
                case 1:
                    isOpended = true;
                    myDoor.Play(Animacion, 0, 0.0f);
                    break;
                case 2:
                    for(int n=0; n < DoorsOrPlatforms.Length; n++)
                    {
                        DoorsOrPlatforms[n].gameObject.GetComponent<Movement>().MovableCondition(true);
                    }
                    break;
            }
        }    
       
    }
}
