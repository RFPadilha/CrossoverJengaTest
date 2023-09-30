using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public StacksCreator stacksCreator;
    public GameObject focusedStack;
    public float speed = 2f;
    Vector3 offset;

    Vector3 Origin;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(1, 1, -10);
        FocusOnStack(stacksCreator.stack2);
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        MoveCamera();
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            FocusOnStack(focusedStack);
        }
    }
    public void FocusOnStack(GameObject stack)
    {
        Vector3 offset = new Vector3(1, 1, -10);
        transform.position = stack.transform.position + offset;
        focusedStack = stack;
    }
    void RotateCamera()
    {
        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(focusedStack.transform.position,
                                            transform.up,
                                            -Input.GetAxis("Mouse X") * speed);

            transform.RotateAround(focusedStack.transform.position,
                                            transform.right,
                                            -Input.GetAxis("Mouse Y") * speed);
            transform.localRotation = Quaternion.Euler(transform.rotation.x, 0f, 0f);
            transform.LookAt(focusedStack.transform.position);
        }

    }
    void MoveCamera()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Origin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(2)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - Origin);
        Vector3 move = new Vector3(0, pos.y * speed, 0);

        transform.Translate(move, Space.World);
    }
}
