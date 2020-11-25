using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardX : MonoBehaviour
{
    // variable pour la vitesse
    public float speed;

    // Update is called once per frame
    void Update()
        // Deplacement des objets forward
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
