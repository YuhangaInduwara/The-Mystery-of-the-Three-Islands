using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassManager : MonoBehaviour
{
    public Transform player;
    Vector3 vector;

    void Start()
    {
        vector = Vector3.zero;  // Ensure the vector is initialized
    }

    void Update()
    {
        vector.z = player.eulerAngles.y;
        transform.localEulerAngles = vector;
    }
}
