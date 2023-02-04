using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float turboSpeed;

    //Speed Turbo
    private float minSpeed;
    private float maxSpeed;

    void Start()
    {
        minSpeed = speed;
        maxSpeed = speed + turboSpeed;
    }

    void FixedUpdate()
    {
        AstronautMovement();
        AstronautTurbo();
    }

    void AstronautTurbo()
    {
        if (Input.GetAxis("RT") > 0f)
        {
            if(speed.Equals(minSpeed))
            {
                speed = maxSpeed;
            }
        }
        else
        {
            if (speed.Equals(maxSpeed))
            {
                speed = minSpeed;
            }         
        }
    }

    void AstronautMovement()
    {
        //Sides
        if (Input.GetAxis("Vertical") > 0f)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical") < 0f)
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        //Down and Up
        if(Input.GetAxis("A") > 0)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Y") > 0)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
}
