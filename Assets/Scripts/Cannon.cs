using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public Transform shotPos;
    public Rigidbody BulletPrefab;

	// Use this for initialization
	IEnumerator Start () {
		while (true) {
            //transform.rotation = Quaternion.Euler(Vector3.up * Random.Range(0, 360));
            Rigidbody b =Instantiate(BulletPrefab);
            b.transform.position = shotPos.position;
            b.transform.rotation = shotPos.rotation * Quaternion.Euler(Vector3.right * 90f);
            b.velocity = b.transform.up * 2f;

            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
	}

    void Update() {
        transform.Rotate(Vector3.up * Time.deltaTime * Random.Range(50f, 80f));
    }

}
