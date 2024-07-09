using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficcars : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 0.2f);
        Vector3 trafficpos = transform.position;
        if (trafficpos.z > 120)
        {
            trafficpos.z = -120;
            transform.position = trafficpos;
        }
    }
}
