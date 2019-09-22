using UnityEngine;
using UnityRPG;

public class ItemsPanel : MonoBehaviour, IMenuPanel
{
  public void Activate()
  {
    print("Opening Items");
  }

  public void Blur()
  {
    print("Closing Items");
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
