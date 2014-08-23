﻿using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;

	public static T Instance
	{
		get{
			if (_instance == null)
			{
				GameObject singleton = new GameObject();
				_instance = singleton.AddComponent<T>();
				singleton.name = "(singleton) "+ typeof(T).ToString();
				DontDestroyOnLoad(singleton);
			}
			return _instance;
		}
	}
}