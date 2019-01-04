using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {

    Vector3 dir = Vector3.right;

	// Use this for initialization
	void Start () {
        StartCoroutine(MovementTick());
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void FixedUpdate() {
        ChangeDir();
    }

    void ConstantMovement() {
        transform.position += dir;
    }

    void ChangeDir() {
        if (Input.GetAxisRaw("Vertical") == 1 && dir != Vector3.back)
            StartCoroutine(directionCoroutine(Vector3.forward));
        else if (Input.GetAxisRaw("Vertical") == -1 && dir != Vector3.forward)
            StartCoroutine(directionCoroutine(Vector3.back));
        else if (Input.GetAxisRaw("Horizontal") == -1 && dir != Vector3.right)
            StartCoroutine(directionCoroutine(Vector3.left));
        else if (Input.GetAxisRaw("Horizontal") == 1 && dir != Vector3.left)
            StartCoroutine(directionCoroutine(Vector3.right));
    }

    IEnumerator MovementTick() {
        while (true) {
            yield return new WaitForSeconds(0.3f);
            ConstantMovement();
        }
    }

    IEnumerator directionCoroutine(Vector3 direction) {
        dir = direction;
        yield return new WaitForSeconds(0.3f);
    }
}
