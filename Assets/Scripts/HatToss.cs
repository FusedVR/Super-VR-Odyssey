using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HatToss : MonoBehaviour {

    public float maxFloatTime = 2f;

    public AudioSource wee;

    private Rigidbody rigid;



    private void Start() {
        rigid = GetComponent<Rigidbody>();
    }

    public void OnTossed() {
        wee.Play();
        Vector3 initalVelocity = rigid.velocity;
        transform.rotation = Quaternion.Euler(Vector3.up * transform.eulerAngles.y);
        rigid.angularVelocity = Vector3.up * initalVelocity.sqrMagnitude;
        StopAllCoroutines();
        StartCoroutine(Return(initalVelocity));
    } 

    IEnumerator Return(Vector3 initalVelocity) {
        float animateTime = .5f;
        yield return new WaitForSeconds(maxFloatTime - animateTime);

        float timeDelta = 0f;
        while (timeDelta < animateTime) {
            timeDelta += Time.deltaTime;
            rigid.velocity = Vector3.Lerp(initalVelocity, Vector3.zero, timeDelta / animateTime);
            yield return null;
        }

        timeDelta = 0f;
        while (timeDelta < animateTime) {
            timeDelta += Time.deltaTime;
            rigid.velocity = Vector3.Lerp(Vector3.zero, -initalVelocity, timeDelta / animateTime);
            yield return null;
        }

        yield return new WaitForSeconds(maxFloatTime - animateTime);
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            StopAllCoroutines();
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;

            Vector3 playerPos = transform.position;
            playerPos.y = Player.instance.transform.position.y;
            Player.instance.transform.position = playerPos;

            Destroy(other.gameObject);
            
        }
    }

}
