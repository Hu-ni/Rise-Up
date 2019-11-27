using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float camSpeed = 0.04f;

    void Awake()
    {
        Screen.SetResolution(540,960, FullScreenMode.Windowed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(Camera.main.transform.position.x,
            Camera.main.transform.position.y + camSpeed, Camera.main.transform.position.z);
    }
}
