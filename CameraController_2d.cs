using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_2d: MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float pitch = 3;


    public float zoomSpeed = 4f;
    public float minZoom = 3f;
    public float MaxZoom = 15f;

    public float zoom = 10f;
    public float currZoom;

    private float yawSpeed = 100f;
    private float yawInput = 0f;
    private float UpSpeed = 2f;
    private float UpInput = 0f;

    void Update()
    {
        //check documentation brackaeys is a legend;



        currZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currZoom = Mathf.Clamp(currZoom, minZoom, MaxZoom);

        yawInput += Input.GetAxis("Mouse X") * yawSpeed * Time.deltaTime;
        UpInput += Input.GetAxis("Mouse Y") * UpSpeed * Time.deltaTime;
        offset.y= Mathf.Clamp(UpInput, -1, 0);

    }
    //called after update
    void LateUpdate()
    {
        transform.position = target.position - offset * currZoom;
        //rotates an objetct until it looks to other
        transform.LookAt(target.position + Vector3.up * pitch);

        //wtf? pq vector3.up, ah ok é pra rodar ao redor do eixo z
        transform.RotateAround(target.position, Vector3.up, yawInput);
        //transform.RotateAround(target.position, Vector3., UpInput);
    }
}