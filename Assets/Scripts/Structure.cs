using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 view = Camera.main.WorldToViewportPoint(transform.position);
        if (view.y <= 0 || view.x >= 1 || view.x <= 0)
        {
            Destroy(gameObject);
        }
    }
}
