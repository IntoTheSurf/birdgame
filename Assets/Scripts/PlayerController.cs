using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject explosion;
    Rigidbody rg;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rg.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Enemy") {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die() {
        Instantiate(explosion, transform.position, Quaternion.identity);
        this.gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
