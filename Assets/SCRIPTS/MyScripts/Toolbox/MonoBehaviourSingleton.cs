using UnityEngine;

namespace Toolbox
{
    public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviourSingleton<T>
    {
        [SerializeField] private bool dontDestroyOnLoad;

        private static T instance;
        private static bool wasDestroyed;

        public static T Instance
        {
            get
            {
                if (!instance)
                {
                    instance = FindObjectOfType<T>();

                    if (!instance && !wasDestroyed)
                        instance = new GameObject(typeof(T).Name).AddComponent<T>();
                }

                return instance;
            }
        }


        private void Awake()
        {
            if (Instance == this)
            {
                if (dontDestroyOnLoad)
                    DontDestroyOnLoad(gameObject);

                OnAwaken();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                wasDestroyed = true;
                instance = null;

                OnDestroyed();
            }
        }


        protected virtual void OnAwaken() { }
        protected virtual void OnDestroyed() { }
    }
}