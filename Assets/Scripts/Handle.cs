using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 offset;
    private bool clicked = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
#if(UNITY_ANDROID||UNITY_IPHONE)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            
            if (touch.phase == TouchPhase.Began)
            {
                offset = (Vector2) transform.position - touchPos;
            }
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                Vector2 newPos = new Vector2(touchPos.x + offset.x, touchPos.y + offset.y);
                rb.MovePosition(newPos);
            }
        }
        else
        {
            rb.MovePosition(transform.position + new Vector3(0, Camera.main.GetComponent<CameraMovement>().camSpeed, 0));
        }
#else
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!clicked)
            {
                offset = (Vector2)transform.position - mousePos;
                clicked = true;
            }

            Vector2 newPos = new Vector2(mousePos.x + offset.x, mousePos.y + offset.y);
            rb.MovePosition(newPos);
        }
        else
        {
            rb.MovePosition(transform.position + new Vector3(0, Camera.main.GetComponent<CameraMovement>().camSpeed, 0));
            clicked = false;
        }
#endif

    }
}
