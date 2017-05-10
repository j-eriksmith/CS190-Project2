using System.Collections;
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
        END
    }
    public PHASES currentPhase;

    private bool ready = true;
    private float sanity = 100f;

    public GameObject revolver;
    private GameObject sanityText;
    private GameObject sanityBar;
    private SpriteRenderer mySpriteRenderer;


    // Use this for initialization
    void Start () {
        currentPhase = PHASES.FIRSTCOCK;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        sanityText = GameObject.Find("SanityText");
        sanityBar = GameObject.Find("SanityBar");
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
                        currentPhase = PHASES.LOADANDROLL;
                        break;
                    }
                case PHASES.LOADANDROLL:
                    {
                        StartCoroutine(LoadAndRoll());
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
        //play sound
        byte alpha = 0;
        while (alpha < 254)
        {
            yield return new WaitForSeconds(.008f);
            sanityText.GetComponent<Text>().color = new Color32(50, 50, 50, alpha);
            sanityBar.GetComponent<Image>().color = new Color32(255, 255, 255, alpha);
            alpha++;
        }
        revolver.SetActive(true);
        yield return new WaitForSeconds (/*however long the prime takes)*/2f);
        ready = true;
        mySpriteRenderer.enabled = true;
    }
    IEnumerator LoadAndRoll()
    {
        mySpriteRenderer.enabled = false;
        ready = false;
        //play sound event
        yield return new WaitForSeconds(/*however long the event takes)*/2f);
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
        ready = false;
        //play sound event
        yield return new WaitForSeconds(/*however long the event takes)*/2f);
        ready = true;
        mySpriteRenderer.enabled = true;
    }
}
