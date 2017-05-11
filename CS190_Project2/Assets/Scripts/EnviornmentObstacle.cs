using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviornmentObstacle : MonoBehaviour {

    private GameObject player;

    public float disableTime;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().disableMovement(5f);
            StartCoroutine(waitToRotateDaddy(2.2f)); // time BEFORE door opens
        }

    }
    IEnumerator waitToRotateDaddy(float beforeSwing)
    {
        yield return new WaitForSeconds(beforeSwing);
        StartCoroutine(rotateDaddy(1.8f));
    }

    IEnumerator rotateDaddy(float timeToSwing)
    {
        this.transform.parent.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, -.545f,0);
        yield return new WaitForSeconds(timeToSwing); // delay before door stops swinging
        this.transform.parent.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        this.gameObject.SetActive(false);
        player.GetComponent<PlayerMovement>().moveSpeed = 3.5f;
    }
}
