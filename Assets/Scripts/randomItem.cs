using UnityEngine;

public class randomItem : MonoBehaviour
{
    [SerializeField]string[] items = new string[10];

    void Start()
    {
        items[0] = "Auto";
        items[1] = "Sleutel";
        items[2] = "Appel";
        items[3] = "Fiets";
        items[4] = "Limoen";
        items[5] = "Hand";
        items[6] = "Eend";
        items[7] = "Deeg";
        items[8] = "Tomaat";
        items[9] = "Kauwgom";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) PrintRandomItem();
        if (Input.GetKeyDown(KeyCode.Escape)) PrintAllItems();
    }
    private void PrintRandomItem()
    {
        Debug.Log(items[Random.Range(0, 9)]);
    }
    private void PrintAllItems()
    {
        foreach (var it in items)
        {
            Debug.Log(it);
        }
    }
}
