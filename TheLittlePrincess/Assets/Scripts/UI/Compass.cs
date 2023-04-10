using UnityEngine;

public class Compass : MonoBehaviour {

    public Transform player;
    Vector3 vector;

    // Update is called once per frame
    void Update() {
        vector.z = -player.eulerAngles.y;
        transform.localEulerAngles = vector;
    }
}
