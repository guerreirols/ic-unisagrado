using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsRepository : MonoBehaviour
{
    [SerializeField]
    private GameObject[] planets;

    public GameObject[] GetPlanetsList()
    {
        return planets;
    }
}
