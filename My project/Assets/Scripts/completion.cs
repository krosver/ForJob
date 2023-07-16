using TMPro;
using UnityEngine;

public class completion : MonoBehaviour
{
    [SerializeField] GameObject numberPrefab;
    [SerializeField] int MaxNumber;
    void Start()
    {
        for (int i = 0; i < MaxNumber; i++)
        {
            var text = Instantiate(numberPrefab,transform).GetComponent<TMP_Text>();
            text.text = "";
            if (i<10)
                text.text = "0";
            text.text += i.ToString();
            text.gameObject.name = text.text;
        }
    }
}
