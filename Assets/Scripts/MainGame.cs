using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class MainGame : MonoBehaviour
{
    public int Points = 0;
    public float AwkwardPoints = 0f;

    public float RotationBorderX = 1.71f;
    public float RotationBorderY = 10.8f;
    public float RotationCurrentX = 0.0f;
    public float RotationCurrentY = 0.0f;

    public GameObject EyeObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * 1.0f;
        float MouseY = Input.GetAxis("Mouse Y") * 1.0f;

        Debug.Log(MouseX);
        Debug.Log(MouseY);
        RotationCurrentX += MouseX;
        RotationCurrentY += MouseY;
        RotationCurrentX = Mathf.Clamp(RotationCurrentX, -5.5f, -4.7f);
        RotationCurrentY = Mathf.Clamp(RotationCurrentY, 1.7f, 2.35f);

        EyeObject.transform.localPosition = new Vector3(RotationCurrentX, RotationCurrentY, 0);

    }
}
