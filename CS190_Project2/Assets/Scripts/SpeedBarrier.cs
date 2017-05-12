using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBarrier : MonoBehaviour {

    private GameObject player;

    public enum Speeds
    {
        SLOW1,
        SLOW2,
        STOP,
        RESTART,
        END
    }
    public Speeds barrier; 

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
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
                AkSoundEngine.PostEvent("StaggeredBreathing", GameObject.Find("indoor_bg"));

            }
            else if (barrier == Speeds.SLOW2)
            {
                other.gameObject.GetComponent<PlayerMovement>().moveSpeed = 1.25f;
                AkSoundEngine.PostEvent("Viola", GameObject.Find("indoor_bg"));
                this.gameObject.SetActive(false);
            }
            else if (barrier == Speeds.STOP)
            {
                other.gameObject.GetComponent<PlayerMovement>().stopPlayer();
                AkSoundEngine.PostEvent("StopViola", GameObject.Find("indoor_bg"));
                StartCoroutine(FadeOutBG());
            }
            else if (barrier == Speeds.RESTART)
            {
                other.gameObject.GetComponent<PlayerMovement>().restartPlayer();
                this.gameObject.SetActive(false);
            }
            else if (barrier == Speeds.END)
            {
                StartCoroutine(EndGame());
            }

        }
    }
    IEnumerator FadeOutBG()
    {
        GameObject background = GameObject.Find("indoor_bg");
        byte color = 255;
        while (color > 95)
        {
            yield return new WaitForSeconds(.04f);
            background.GetComponent<SpriteRenderer>().color = new Color32(color, color, color, 255);
            color--;
        }
        player.transform.GetChild(0).gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    IEnumerator EndGame()
    {
        GameObject blackSquare = GameObject.Find("BlackSquare");
        AkSoundEngine.StopAll();
        player.GetComponent<PlayerMovement>().stopPlayer();
        byte alpha = 0;
        while (alpha < 254)
        {
            yield return new WaitForSeconds(.024f);
            blackSquare.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, alpha);
            alpha++;
        }
        yield return new WaitForSeconds(3f);
        Application.Quit();
    
    }
}
