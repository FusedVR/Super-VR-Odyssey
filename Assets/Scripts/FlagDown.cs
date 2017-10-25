using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagDown : MonoBehaviour {

    public AudioSource tada;
    public Animator flag;

    private bool done = false;

    void OnTriggerEnter(Collider other) {
        if (!done && other.tag == "Player") {
            tada.Play();
            flag.SetTrigger("down");
            done = true;
        }
    }

}
