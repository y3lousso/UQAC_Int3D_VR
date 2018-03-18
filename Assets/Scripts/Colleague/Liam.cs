using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liam : MonoBehaviour {

    public Animator animator;
    public Transform start;
    public Transform end;

    public float currentTime = 0f;

    [Range(0.1f, 20f)]
    public float deplacementTime = 5f;

    public void Update()
    {
        
    }

    public void StartCardiacArrest(){
        StartCoroutine("Walking");
	}

	IEnumerator Walking(){
		animator.SetBool ("StartWalking", true);
        while (currentTime<=deplacementTime)
        {
            transform.position = Vector3.Lerp(start.position, end.position, currentTime / deplacementTime);
            transform.rotation = Quaternion.Slerp(start.rotation, end.rotation, currentTime / deplacementTime);
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;
        }
        Die();
	}

	public void Die(){
        animator.SetBool("StartDying", true);
        StartCoroutine ("Dying");
	}

	IEnumerator Dying(){
		yield return new WaitForSeconds (5.5f);
		Scenario.NextStep ();
	}

}
