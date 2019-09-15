using UnityEngine;
using UnityRPG;

public class StatsPanel : MonoBehaviour, IMenuPanel
{
    public void Activate()
	{
		gameObject.SetActive(true);
	}

	public void Blur()
	{
		gameObject.SetActive(false);
	}
}
