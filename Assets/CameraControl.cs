using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public StacksCreator stacksCreator;
    public GameObject focusedStack;
    public GameObject cameraCenter;
    public float speed = 2f;
    Vector3 offset;

    Vector3 Origin;

    void Start()
    {
        offset = new Vector3(1,0,0);
        FocusOnStack(stacksCreator.stack2);
    }


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
        cameraCenter.transform.position = stack.transform.position + offset;
        focusedStack = stack;
    }
    void RotateCamera()
    {

        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(cameraCenter.transform.position,
                                            transform.up,
                                            -Input.GetAxis("Mouse X") * speed);

            transform.RotateAround(cameraCenter.transform.position,
                                            transform.right,
                                            -Input.GetAxis("Mouse Y") * speed);
            transform.localRotation = Quaternion.Euler(transform.rotation.x, 0f, 0f);
            transform.LookAt(cameraCenter.transform.position);
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

        cameraCenter.transform.Translate(move, Space.World);
    }
}
