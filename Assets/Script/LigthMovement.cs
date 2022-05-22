using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigthMovement : MonoBehaviour
{
    public GameObject target;

    public float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        transform.TransformDirection(target.transform.position);
    }
}
