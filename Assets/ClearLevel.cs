using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearLevel : MonoBehaviour
{
	public GameObject trash;
	private void Awake()
	{
		trash.SetActive(false);
	}
}
