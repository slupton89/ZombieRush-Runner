using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour {

    [SerializeField]
    private float objectSpeed = 1;
    [SerializeField]
    private float resetPosition = 45f;
    [SerializeField]
    private float startPosition = -84f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        if (!GameManager.instance.GameOver) {
            transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

                    if (transform.localPosition.x >= resetPosition) {
                        Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
                        transform.position = newPos;
                    }
        }
        
	}
}
