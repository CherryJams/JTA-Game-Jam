using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private int currentChildIndex;
    private int childCount;

    private GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        currentChildIndex = 0;
        childCount = menu.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && childCount - 1 == currentChildIndex)
        {
            SceneManager.LoadScene(1);
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            currentChildIndex++;
            menu.transform.GetChild(currentChildIndex).gameObject.SetActive(true);
        }
    }
}