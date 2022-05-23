using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTriggers : MonoBehaviour
{
    public Canvas textInf;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals("Player"))
        {
            textInf.GetComponent<Canvas>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textInf.GetComponent<Canvas>().enabled = false;
    }
}
