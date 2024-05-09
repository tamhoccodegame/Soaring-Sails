using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruct : MonoBehaviour
{
	private void Awake()
	{
		Destroy(gameObject, 10f);
	}
}
