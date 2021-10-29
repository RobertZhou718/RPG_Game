using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController4 : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        Button BT = button.GetComponent<Button>();
        BT.onClick.AddListener(Swapscene);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Swapscene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
