using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class interactMYOwn : MonoBehaviour {
	public Transform targetHandR;
	public Transform Onreleaseparent;
	public Transform target;
	public float speed=10f;
	Rigidbody rigidbody;
	private InteractionBehaviour _intObj;
	private bool gripIsReleased;

	// Use this for initialization
	void Start () {
        
        gripIsReleased = true;
		rigidbody = GetComponent<Rigidbody> ();
		_intObj = GetComponent<InteractionBehaviour> ();
		/*
		_intObj.OnHoverBegin += OnHoverBegin;
		_intObj.OnHoverEnd += OnHoverEnd;
		*/
		_intObj.OnGraspBegin += OnGraspBegin;
		_intObj.OnGraspEnd += OnGraspEnd;
	}
	
	// Update is called once per frame
	void Update () {
		if(gripIsReleased){
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		} 
	}
	/*
	private void OnHoverBegin(){
		gripIsReleased = false;
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ|
			RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionY | 
			RigidbodyConstraints.FreezePositionZ| RigidbodyConstraints.FreezePositionX;
	}

	private void OnHoverEnd(){
		gripIsReleased = true;
		rigidbody.constraints = RigidbodyConstraints.None;
	}
  */


    // Target hand is sent horizontally for the turning point after catching the handdle of the parachute
	private void OnGraspBegin(){
		gripIsReleased = false;

		this.transform.parent = targetHandR.transform;
	}

    // Target hand is realesed to the original point afer realising the handle
	private void OnGraspEnd(){
		gripIsReleased = true;
		this.transform.parent = Onreleaseparent.transform;
	}
}
