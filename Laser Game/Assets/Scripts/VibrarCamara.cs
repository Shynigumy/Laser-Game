using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrarCamara : MonoBehaviour
{
	public float power = 0.005f;
	public float duration = 1.0f;
	public Transform cam;
	public float slowDownAmount = 0.0f;
	public bool shouldShake;

	Vector3 startPosition;
	float initialDuration;

	// Use this for initialization
	void Start()
	{
		cam = Camera.main.transform;
		startPosition = cam.localPosition;
		initialDuration = duration;
	}

	// Update is called once per frame
	void Update()
	{
		if (shouldShake)
		{
			if (duration > 0)
			{
				cam.localPosition = startPosition + Random.insideUnitSphere * power;
				duration -= Time.deltaTime * slowDownAmount;
			}
			else
			{
				shouldShake = false;
				duration = initialDuration;
				cam.localPosition = startPosition;
			}
		}
	}
}