using TMPro;
using UnityEngine;

public class ThanksForPlayingUI : MonoBehaviour
{
    public TextMeshProUGUI thanksText;

    public void ShowThanksText()
    {
        thanksText.gameObject.SetActive(true);
    }
}
