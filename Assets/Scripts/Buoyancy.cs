using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rho = 999.97f;
        Vector3 gravity = Physics.gravity;
        float diameter = 0.047f;
        float height = 0.6477f;

        float volume = Mathf.PI * Mathf.Pow(diameter,2) / 4 * height;
        Vector3 buoyancy = - rho * gravity * volume;
        //Debug.Log(buoyancy.y);
        rb.AddForce(buoyancy);
    }
}
