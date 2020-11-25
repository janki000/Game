using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isOnGround = true;
    public float jumpForce;
    public float gravityModifier = 1;
    private Rigidbody playerRb;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip fireSound;
    private AudioSource playerAudio;

    public GameObject firePrefab;

    public float speed = 10;
    public float horizontalInput;
   



    // Start is called before the first frame update
    void Start()
    {
    
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(firePrefab, transform.position, firePrefab.transform.rotation);
            playerAudio.PlayOneShot(fireSound, 1f);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            Debug.Log("Jump");
            playerRb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            isOnGround = false;
      
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1f);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.back * speed * Time.deltaTime * horizontalInput);

       

    }
    private void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject.CompareTag(String)
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isOnGround = false;
            explosionParticle.Play();
            dirtParticle.Stop();
            gameOver = true;
           
            playerAudio.PlayOneShot(crashSound, 1f);
        }
        
    }
}

