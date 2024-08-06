using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotate : MonoBehaviour
{
    UnityEngine.InputSystem.Gyroscope gyroscope;
    public Vector3 gyroData = Vector3.zero;

    public float speed = 100f;
    public Vector3 direction = Vector3.zero;
    public int timer;


    private void Start()
    {
        gyroscope = UnityEngine.InputSystem.Gyroscope.current;
    }

    void Update()
    {
        // enable gyroscope
        if (gyroscope != null && !gyroscope.enabled)
        {
            InputSystem.EnableDevice(gyroscope);
            Debug.Log("Gyroscope enabled");
        }
        gyroData = gyroscope.angularVelocity.ReadValue();


        if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
            Touch();

        if (timer < 0) timer = 1000;

        //if (timer > 50)
        direction -= new Vector3(.001f, .001f, .001f);

        transform.RotateAround(transform.position, direction, speed * Time.deltaTime);
    }

    void Touch()
    {
        if (timer > 0)
            direction = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        speed = Random.Range(5, 200);
    }


    Vector3 GetGyro()
    {
        Vector3 val = Vector3.zero;
        return val;
    }


}
