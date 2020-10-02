using UnityEngine;

public class ItemObject : MonoBehaviour
{

    [SerializeField] Item item;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = item.ItemImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameManager.instance.AddItem(item);
        Destroy(gameObject);
    }
}
