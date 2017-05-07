using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private bool canMove = true;

    public float moveSpeed = 5f;

    // Use this for initialization
    void Start()
    {

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
    public void disableMovement(float disableTime)
    {
        canMove = false;
        StartCoroutine(disablePlayer(disableTime));
    }

    IEnumerator disablePlayer(float disableTime)
    {
        yield return new WaitForSeconds(disableTime);
        canMove = true;
    }
    public void stopPlayer()
    {
        canMove = false;
    }
    public void restartPlayer()
    {
        canMove = true;
    }
}


