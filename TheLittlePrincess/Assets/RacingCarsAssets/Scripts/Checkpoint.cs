using UnityEngine.Events;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public UnityEvent<GameObject, Checkpoint> onCheckpointEnter;

    void OnTriggerEnter(Collider collider)
    {
        // if entering object is tagged as the Player
        /*if (collider.gameObject.tag == "Player")
        {
            // fire an event giving the entering gameObject and this checkpoint
            onCheckpointEnter.Invoke(collider.gameObject, this);
        }*/

        // Or can be done by getting a component that means this is a car, like CarController
        CarIdentity car = collider.gameObject.GetComponent<CarIdentity>();
<<<<<<< Updated upstream
        if (car != null && (car.identityName.Equals("Red") || car.identityName.Equals("Green")))
=======
        if (car != null && car.identityName.Equals("Car"))
>>>>>>> Stashed changes
        {
            onCheckpointEnter.Invoke(collider.gameObject, this);
        }
    }
}