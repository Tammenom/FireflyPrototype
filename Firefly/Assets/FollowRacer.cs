using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRacer : MonoBehaviour {

    public Transform racer;
    public Vector3 offset;


    // Update is called once per frame
    void Update()
    {
        transform.position = racer.position + offset;
        transform.rotation = Quaternion.EulerRotation(0, racer.transform.rotation.y -90,0);
    }
}


