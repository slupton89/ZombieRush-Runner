using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour {

    [SerializeField]
    float jumpForce = 100f;
    [SerializeField]
    private AudioClip sfxJump;
    [SerializeField]
    private AudioClip sfxDeath;

    private Animator anim;
    private Rigidbody rigidBody;
    private bool jump = false;
    private AudioSource audioSource;

    void Awake() {
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.instance.GameOver && GameManager.instance.GameStarted) {
            if (Input.GetMouseButtonDown(0)) {
                GameManager.instance.PlayerStartedGame();
                anim.Play("Jump");
                jump = true;
                rigidBody.useGravity = true;
            }
        }

	}

    void FixedUpdate() {

        if (jump == true) {

            jump = false;
            rigidBody.velocity = new Vector2(0, 0);
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
            audioSource.PlayOneShot(sfxJump);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "obstacle") {
            //rigidBody.useGravity = false;
            rigidBody.AddForce(new Vector3(-50, 10, -25), ForceMode.Impulse);
            rigidBody.detectCollisions = false;
            audioSource.PlayOneShot(sfxDeath);
            GameManager.instance.PlayerCollided();

        }
    }
}
