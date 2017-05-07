using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBarrier : MonoBehaviour {

    public enum Speeds
    {
        SLOW1,
        SLOW2,
        STOP,
        RESTART
    }
    public Speeds barrier; 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (barrier == Speeds.SLOW1)
            {
                other.gameObject.GetComponent<PlayerMovement>().moveSpeed = 2.5f;
            }
            else if (barrier == Speeds.SLOW2)
            {
                other.gameObject.GetComponent<PlayerMovement>().moveSpeed = 1.25f;
                this.gameObject.SetActive(false);
            }
            else if (barrier == Speeds.STOP)
            {
                other.gameObject.GetComponent<PlayerMovement>().stopPlayer();
                StartCoroutine(FadeOutBG());
            }
            else if (barrier == Speeds.RESTART)
            {
                other.gameObject.GetComponent<PlayerMovement>().restartPlayer();
                this.gameObject.SetActive(false);
            }

        }
    }
    IEnumerator FadeOutBG()
    {
        GameObject background = GameObject.Find("indoor_bg");
        byte color = 255;
        while (color > 95)
        {
            yield return new WaitForSeconds(.002f);
            background.GetComponent<SpriteRenderer>().color = new Color32(color, color, color, 255);
            color--;
            print(color);
        }
        this.gameObject.SetActive(false);
    }
}
