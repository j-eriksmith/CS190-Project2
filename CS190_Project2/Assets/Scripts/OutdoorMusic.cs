using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutdoorMusic : MonoBehaviour {
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        GameObject speaker1 = new GameObject();
        AkSoundEngine.RegisterGameObj(speaker1);
        AkSoundEngine.SetObjectPosition(speaker1, transform.position.x - 4f, transform.position.y, 10f, 1f, 1f, 1f,1f,1f,1f);
        AkSoundEngine.SetActiveListeners(player, 1);
        AkSoundEngine.PostEvent("WindBG", speaker1);
    }
	
	// Update is called once per frame
	void Update () {
        AkSoundEngine.SetListenerPosition(player.transform.position.x, player.transform.position.y, player.transform.position.z,
            1f, 1f, 1f,1f,1f,1f,1);
    }
}
