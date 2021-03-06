﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpacebarManager : MonoBehaviour {

    public enum PHASES
    {
        FIRSTCOCK,
        LOADANDROLL,
        PRIME1,
        SHOT1,
        PRIME2,
        SHOT2,
        PRIME3,
        SHOT3, //starts crying
        PRIME4,
        SHOT4,
        PRIME5, //starts heavy breathing again
        SHOT5,
        PRIME6,
        SHOT6, //summons the angels
        END, //drops the gun
        FINISH //no more

    }
    public PHASES currentPhase;

    private bool ready = true;
    private float sanity = 100f;

    public GameObject revolver;
    public GameObject exit1;
    public GameObject exit2;

    private GameObject sanityText;
    private GameObject sanityBar;
    private GameObject heavenBG;
    private GameObject insideBG;
    private SpriteRenderer mySpriteRenderer;


    // Use this for initialization
    void Start () {
        currentPhase = PHASES.FIRSTCOCK;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        sanityText = GameObject.Find("SanityText");
        sanityBar = GameObject.Find("SanityBar");
        heavenBG = GameObject.Find("heaven_bg");
        insideBG = GameObject.Find("indoor_bg");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && ready)
        {
            switch (currentPhase)
            {
                case PHASES.FIRSTCOCK:
                    {
                        StartCoroutine(FirstCock());
                        currentPhase = PHASES.PRIME1;
                        break;
                    }
                case PHASES.PRIME1:
                    {
                        StartCoroutine(Prime1());
                        currentPhase = PHASES.SHOT1;
                        break;
                    }
                case PHASES.SHOT1:
                    {
                        StartCoroutine(Shot1());
                        currentPhase = PHASES.PRIME2;
                        break;
                    }
                case PHASES.PRIME2:
                    {
                        StartCoroutine(Prime2());
                        currentPhase = PHASES.SHOT2;
                        break;
                    }
                case PHASES.SHOT2:
                    {
                        StartCoroutine(Shot2());
                        currentPhase = PHASES.PRIME3;
                        break;
                    }
                case PHASES.PRIME3:
                    {
                        StartCoroutine(Prime3());
                        currentPhase = PHASES.SHOT3;
                        break;
                    }
                case PHASES.SHOT3:
                    {
                        StartCoroutine(Shot3());
                        currentPhase = PHASES.PRIME4;
                        break;
                    }
                case PHASES.PRIME4:
                    {
                        StartCoroutine(Prime4());
                        currentPhase = PHASES.SHOT4;
                        break;
                    }
                case PHASES.SHOT4:
                    {
                        StartCoroutine(Shot4());
                        currentPhase = PHASES.PRIME5;
                        break;
                    }
                case PHASES.PRIME5:
                    {
                        StartCoroutine(Prime5());
                        currentPhase = PHASES.SHOT5;
                        break;
                    }
                case PHASES.SHOT5:
                    {
                        StartCoroutine(Shot5());
                        currentPhase = PHASES.PRIME6;
                        break;
                    }
                case PHASES.PRIME6:
                    {
                        StartCoroutine(Prime6());
                        currentPhase = PHASES.SHOT6;
                        break;
                    }
                case PHASES.SHOT6:
                    {
                        StartCoroutine(Shot6());
                        currentPhase = PHASES.END;
                        break;
                    }
                case PHASES.END:
                    {
                        break;
                    }
                
            }
        }
    }
    void shotEffect()
    {
        float newX = sanityBar.GetComponent<RectTransform>().localScale.x - .2f;
        sanityBar.GetComponent<RectTransform>().localScale = new Vector3(newX, 1f, 1f);

        float newRevolverSize = revolver.transform.localScale.x + .5f;
        revolver.transform.localScale = new Vector3(newRevolverSize, newRevolverSize, newRevolverSize);
    }
    IEnumerator FirstCock()
    {
        mySpriteRenderer.enabled = false;
        ready = false;
        AkSoundEngine.PostEvent("GunLoad", gameObject);
        byte alpha = 0;
        while (alpha < 254)
        {
            yield return new WaitForSeconds(.016f);
            sanityText.GetComponent<Text>().color = new Color32(50, 50, 50, alpha);
            sanityBar.GetComponent<Image>().color = new Color32(255, 255, 255, alpha);
            alpha++;
        }
        yield return new WaitForSeconds (2f);
        revolver.SetActive(true);
        ready = true;
        mySpriteRenderer.enabled = true;
    }
    IEnumerator Prime1()
    {
        mySpriteRenderer.enabled = false;
        ready = false;
        //play sound event
        yield return new WaitForSeconds(/*however long the event takes)*/2f);
        ready = true;
        mySpriteRenderer.enabled = true;
    }
    IEnumerator Shot1()
    {
        mySpriteRenderer.enabled = false;
        ready = false;
        //play sound event
        shotEffect();
        yield return new WaitForSeconds(/*however long the event takes)*/2f);
        ready = true;
        mySpriteRenderer.enabled = true;
    }
    IEnumerator Prime2()
    {
        mySpriteRenderer.enabled = false;
        ready = false;
        //play sound event
        yield return new WaitForSeconds(/*however long the event takes)*/2f);
        ready = true;
        mySpriteRenderer.enabled = true;
    }
    IEnumerator Shot2()
    {
        mySpriteRenderer.enabled = false;
        ready = false;
        //play sound event
        shotEffect();
        yield return new WaitForSeconds(/*however long the event takes)*/2f);
        ready = true;
        mySpriteRenderer.enabled = true;
    }
    IEnumerator Prime3()
    {
        mySpriteRenderer.enabled = false;
        ready = false;
        //play sound event
        yield return new WaitForSeconds(/*however long the event takes)*/2f);
        ready = true;
        mySpriteRenderer.enabled = true;
    }
    IEnumerator Shot3()
    {
        mySpriteRenderer.enabled = false;
        ready = false;
        //play sound event
        shotEffect();
        yield return new WaitForSeconds(/*however long the event takes)*/2f);
        ready = true;
        mySpriteRenderer.enabled = true;
    }
    IEnumerator Prime4()
    {
        mySpriteRenderer.enabled = false;
        ready = false;
        //play sound event
        yield return new WaitForSeconds(/*however long the event takes)*/2f);
        ready = true;
        mySpriteRenderer.enabled = true;
    }
    IEnumerator Shot4()
    {
        mySpriteRenderer.enabled = false;
        ready = false;
        //play sound event
        shotEffect();
        yield return new WaitForSeconds(/*however long the event takes)*/2f);
        ready = true;
        mySpriteRenderer.enabled = true;
    }
    IEnumerator Prime5()
    {
        mySpriteRenderer.enabled = false;
        ready = false;
        //play sound event
        yield return new WaitForSeconds(/*however long the event takes)*/2f);
        ready = true;
        mySpriteRenderer.enabled = true;
    }
    IEnumerator Shot5()
    {
        mySpriteRenderer.enabled = false;
        ready = false;
        //play sound event
        shotEffect();
        yield return new WaitForSeconds(/*however long the event takes)*/2f);
        ready = true;
        mySpriteRenderer.enabled = true;
    }
    IEnumerator Prime6()
    {
        mySpriteRenderer.enabled = false;
        ready = false;
        //play sound event
        yield return new WaitForSeconds(/*however long the event takes)*/2f);
        ready = true;
        mySpriteRenderer.enabled = true;
    }
    IEnumerator Shot6() //this is the angels. its a big one.
    {
        mySpriteRenderer.enabled = false;
        sanityText.GetComponent<Text>().enabled = false;
        sanityBar.GetComponent<Image>().enabled = false;
        ready = false;
        AkSoundEngine.PostEvent("Angel", heavenBG);
        byte alpha = 0;
        while (alpha < 195)
        {
            yield return new WaitForSeconds(.065f);
            heavenBG.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, alpha);
            alpha++;
        }
        yield return new WaitForSeconds(/*however long the gregorian chant takes)*/10.5f);
        alpha = 195;
        byte color = 95;
        while (alpha > 0)
        {
            yield return new WaitForSeconds(.035f);
            heavenBG.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, alpha);
            alpha--;
        }
        while (color < 254)
        {
            yield return new WaitForSeconds(.024f);
            insideBG.GetComponent<SpriteRenderer>().color = new Color32(color, color, color, 255);
            color++;
        }
        revolver.SetActive(false);
        AkSoundEngine.PostEvent("GunDrop", heavenBG);
        yield return new WaitForSeconds(/*however long the gun drop event takes)*/1.8f);

        exit1.SetActive(true);
        exit2.SetActive(true);
        this.GetComponentInParent<PlayerMovement>().restartPlayer();
    }
}
