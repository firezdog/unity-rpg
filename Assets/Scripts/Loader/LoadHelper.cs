namespace UnityEngine
{
	class LoadHelper : MonoBehaviour
	{
		public static T setInstance<T>(GameObject gameObject, T that, T instance)
		{
			if (instance == null) instance = that;
			else Destroy(gameObject);
			DontDestroyOnLoad(gameObject);
			return instance;
		}
	}
}