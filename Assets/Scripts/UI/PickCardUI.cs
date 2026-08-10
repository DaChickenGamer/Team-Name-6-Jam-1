using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickCardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI shellName;
    [SerializeField] private TextMeshProUGUI shellDescription;
    [SerializeField] private Image shellImage;
    
    [SerializeField] private Button pickButton;

    public void ChangeShell(ShellSO shell, ObtainShellUI shellUI, int index)
    {
        shellName.text = shell.name;
        shellDescription.text = shell.description;
        shellImage.sprite = shell.shellIcon;
        
        pickButton.onClick.RemoveAllListeners();
        pickButton.onClick.AddListener((() =>
        {
           shellUI.PickShell(index); 
        }));
    }
    
}
