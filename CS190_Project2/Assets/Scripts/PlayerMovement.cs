using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum WALKMODES
    {
        OUTSIDE,
        INSIDE
    }
    public PlayerMovement.WALKMODES walkMode;

    private bool canMove = true;
    private int walkSoundResetInside = 35;
    private int walkSoundCDInside = 35;
    private int walkSoundResetOutside = 10;
    private int walkSoundCDOutside = 10;

    public float moveSpeed = 5f;

    // Use this for initialization
    void Start()
    {
        walkMode = WALKMODES.OUTSIDE;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
            transform.Translate(x, 0, 0);
        }
    }
    void FixedUpdate()
    {
        if (canMove)
        {
            if (walkMode == WALKMODES.OUTSIDE)
            {
                walkSoundCDOutside--;
                if (Mathf.Abs(Input.GetAxis("Horizontal")) > .8f)
                {
                    if (walkSoundCDOutside <= 0)
                    {
                        AkSoundEngine.PostEvent("StaggeredWalk", gameObject); // replace with actual walk
                        walkSoundCDOutside = walkSoundResetOutside;
                    }
                }
            }
            if (walkMode == WALKMODES.INSIDE)
            {
                walkSoundCDInside--;
                if (Mathf.Abs(Input.GetAxis("Horizontal")) > .8f)
                {
                    if (walkSoundCDInside <= 0)
                    {
                        AkSoundEngine.PostEvent("StaggeredWalk", gameObject);
                        walkSoundCDInside = walkSoundResetInside;
                    }
                }
            }
        }
    }
    public void disableMovement(float disableTime)
    {
        canMove = false;
        StartCoroutine(disablePlayer(disableTime));
    }

    IEnumerator disablePlayer(float disableTime)
    {
        yield return new WaitForSeconds(disableTime);
        canMove = true;
        walkMode = WALKMODES.INSIDE;
    }
    public void stopPlayer()
    {
        canMove = false;
    }
    public void restartPlayer()
    {
        canMove = true;
        moveSpeed = 2.5f;
    }
}


