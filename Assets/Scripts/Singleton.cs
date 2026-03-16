using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Play.HD.Singleton  // cria um using
{

    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;
        public virtual void Awake()
        {
            if (Instance == null) Instance = GetComponent<T>();
            else Destroy(gameObject);
        }
    }
}
