using UnityEngine;
using UnityRPG;

public class ItemsPanel : MonoBehaviour, IMenuPanel
{
  public void Activate()
  {
    gameObject.SetActive(true);
  }

  public void Blur()
  {
    gameObject.SetActive(false);
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
