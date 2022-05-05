using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour

{

    public GameObject Player;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == Player)
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == Player)
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
