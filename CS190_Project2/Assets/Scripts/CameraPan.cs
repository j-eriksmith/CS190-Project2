using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

    public bool scrolling = false;

    private GameObject mainCamera;

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        if (scrolling)
        {
            if (mainCamera.transform.position.x < 37f)
            {
                mainCamera.transform.position= new Vector3(mainCamera.transform.position.x + (20f * Time.deltaTime), 0, -10f);
            }
            else if (mainCamera.transform.position.x > 37f)
            {
                mainCamera.transform.position = new Vector3(37f, 0, -10f);
                scrolling = false;
                this.gameObject.SetActive(false);
            }
        }
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().disableMovement(2f);
            scrolling = true;
        }
    }
}
