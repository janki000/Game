using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // creation des variables utiliées
    Rigidbody enemyRb;
    GameObject player;
    public float speed;
    public float pst = -80;
    // Start is called before the first frame update
    void Start()
    {
        // aller chercher le Rigidbody et le GameObjects
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(direction * speed);

        if (transform.position.x < pst)
        {
            Destroy(gameObject);
        }
    }
     
}
