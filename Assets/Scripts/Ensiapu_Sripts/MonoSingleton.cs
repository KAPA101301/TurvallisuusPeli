using UnityEngine;

    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T s_instance;

        public static T Instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = FindInstance();
                    if (s_instance == null)
                    {
                        s_instance = new GameObject(nameof(T), typeof(T)) as T;
                        DontDestroyOnLoad(s_instance);
                    }
                }

                return s_instance;
            }
        }

        protected virtual void Awake()
        {
            Debug.Log($"{typeof(MonoSingleton<T>)}");
            if (s_instance == null)
            {
                s_instance = GetComponent<T>();
                DontDestroyOnLoad(s_instance);
            }
            else
            {
                Debug.LogWarning($"Multiple instances of {typeof(MonoSingleton<T>)} in the scene. Destroying this one: {name}.");
                Destroy(gameObject);
            }
        }

        private static T FindInstance()
        {
            T[] instances = FindObjectsOfType<T>();
            if (instances.Length == 0)
            {
                return null;
            }

            return instances[0];
        }
    }

