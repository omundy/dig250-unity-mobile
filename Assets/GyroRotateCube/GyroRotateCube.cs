using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Rotate a cube in space with 1) sensor input or 2) keys/touch
/// </summary>
public class GyroRotateCube : MonoBehaviour
{
    public bool useSensor = true;

    public bool gyroEnabled;
    public Vector3 gyro = Vector3.zero;

    public Vector3 direction = Vector3.zero;
    public float speed = 100f;
    public float timer;
    public TMP_Text buttonText;


    void Update()
    {
        if (useSensor)
        {
            gyroEnabled = Input.gyro.enabled;

            if (!Input.gyro.enabled)
                Input.gyro.enabled = true;

            gyro = Input.gyro.rotationRateUnbiased;
            direction += gyro;
            transform.rotation = Quaternion.Euler(direction.x, direction.y, direction.z);
        }
        else
            UseTouchInput();

        if (useSensor)
            buttonText.text = "Using Gyro";
        else
            buttonText.text = "Using keyboard / touch";
    }


    void UseTouchInput()
    {
        if (--timer < 0)
            if (Input.anyKey || Input.touches.Length > 0)
            {
                timer = 100;
                direction = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
                speed = Random.Range(15, 200);
            }

        direction -= new Vector3(.01f, .01f, .01f);
        transform.RotateAround(transform.position, direction, speed * Time.deltaTime);
    }


    public void SwitchInput()
    {
        useSensor = !useSensor;
    }

}
