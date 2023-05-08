using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Update()
    {
        if(!PlanetTransition.inTransition)
        {
            transform.Rotate(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
        }
        else
        {
         
        }
    }
}
