using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    private Rigidbody2D rb2d;
    Vector2 thrustDirection = new Vector2(1, 0);
    private const float ThrustForce = 4;
    private int RotateDegreesPerSecond = 90;

    private float shipCollRad;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        shipCollRad = GetComponent<CircleCollider2D>().radius;
        
    }

    // Update is called once per frame
    void Update()
    {
        OnBecameInvisible();

        float rotationInput = Input.GetAxis("Rotate");

        // Calculate rotation amount
        float rotationAmount = RotateDegreesPerSecond * Time.deltaTime * rotationInput;
        transform.Rotate(Vector3.forward, rotationAmount);

        // Update thrust direction based on the ship's current orientation
        float zRotationRadians = transform.eulerAngles.z * Mathf.Deg2Rad;
        thrustDirection.x = Mathf.Cos(zRotationRadians);
        thrustDirection.y = Mathf.Sin(zRotationRadians);
    }

    // FixedUpdate is called at a fixed interval and is recommended for applying physics-related changes
    void FixedUpdate()
    {

        // Check if the Up Arrow key is held down
        if (Input.GetKey(KeyCode.Space))
        {
            // Apply a force to move the ship upwards using the ThrustForce constant
            rb2d.AddForce(thrustDirection.normalized * ThrustForce);
        }

    }

    void OnBecameInvisible()
    {
        Vector2 newPosition = transform.position;

        if (transform.position.x < ScreenUtils.ScreenLeft)
        {
            newPosition.x = ScreenUtils.ScreenLeft + shipCollRad;
        }
        else if (transform.position.x > ScreenUtils.ScreenRight)
        {
            newPosition.x = ScreenUtils.ScreenRight - shipCollRad;
        }

        if (transform.position.y < ScreenUtils.ScreenBottom)
        {
            newPosition.y = ScreenUtils.ScreenBottom + shipCollRad;
        }
        else if (transform.position.y > ScreenUtils.ScreenTop)
        {
            newPosition.y = ScreenUtils.ScreenTop - shipCollRad;
        }

        transform.position = newPosition;
    }
}