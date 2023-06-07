using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField]
    private float speedOnFloating;

    [SerializeField]
    private float speedOnLanding;

    [SerializeField]
    private Transform spaceship;

    private Transform planet;

    private bool inTransition = false;

    private bool onLanding = false;


    private void Start()
    {
        if(Leaving.leftPlanet)
        {
            switch (Random.Range(1, 3))
            {
                case 1:
                    spaceship.Rotate(0f, 0f, 300f);
                    break;
                case 2:
                    spaceship.Rotate(0f, 100f, 300f);
                    break;
            }          
        }
    }

    void FixedUpdate()
    {
        if (!inTransition && !onLanding)
        {
            spaceship.Rotate(speedOnFloating * Time.deltaTime, speedOnFloating * Time.deltaTime, speedOnFloating * Time.deltaTime);
        }
        else
        {
            if(planet != null)
            {
                Vector3 direction = planet.position - spaceship.position;
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
                spaceship.rotation = Quaternion.Lerp(spaceship.rotation, rotation, 1 * Time.deltaTime);

                if (onLanding)
                {
                    spaceship.Translate(transform.forward * speedOnLanding * Time.deltaTime);
                    spaceship.Rotate(0, 0, 300 * Time.deltaTime);
                }
            }       
        }
    }

    public void OnWentToThePlanet(bool inTransition, GameObject planetObject)
    {
        if(planetObject != null)
        {
            planet = planetObject.transform;
        }
        
        this.inTransition = inTransition;
    }

    public void OnSaidToLand(bool onLanding, GameObject planet)
    {
        if (this.planet == null)
        {
            this.planet = planet.transform;
        }

        this.onLanding = onLanding;
    }
}
