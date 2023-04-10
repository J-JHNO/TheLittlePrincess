using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet3_camera : MonoBehaviour
{
    public Transform player;  // Référence au transform du personnage
    public float minHeight = 2f;  // Hauteur minimale de la caméra
    public float maxHeight = 5f;  // Hauteur maximale de la caméra
    public float heightOffset = 2f;  // Distance verticale entre la caméra et le personnage

    void Update()
    {
        // Calcul de la nouvelle hauteur de la caméra en fonction de la hauteur du personnage
        float newHeight = Mathf.Clamp(player.position.y + heightOffset, minHeight, maxHeight);

        // Déplacement de la caméra à la nouvelle position

        transform.position = new Vector3(player.position.x, newHeight, player.position.z);


    }

    /* public Transform player;  // Référence au transform du personnage
     public float rotationSpeed = f;  // Vitesse de rotation de la caméra

     private Vector3 offset;  // Distance entre la caméra et le personnage

     void Start()
     {
         // Calcul de la distance entre la caméra et le personnage
         offset = transform.position - player.position;
     }

     void LateUpdate()
     {
         // Calcul de l'angle de rotation de la caméra en fonction de l'angle de rotation du personnage
         float desiredAngle = player.eulerAngles.y;
         Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);

         transform.position = new Vector3(player.position.x, player.position.y+3f, player.position.z);
         // Déplacement de la caméra à la nouvelle position et rotation
         transform.position = player.position + offset;
         transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
     }*/
}
