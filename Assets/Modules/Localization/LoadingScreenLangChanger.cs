using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LoadingScreenLangChanger : MonoBehaviour
{
    [SerializeField] private string _ru, _en, _tr;

    [SerializeField] private TMP_Text _text;
    
    private void OnEnable()
    {
        YG2.onSwitchLang += SwitchLanguage;
        SwitchLanguage(YG2.lang);
    }
    private void OnDisable()
    {
        YG2.onSwitchLang -= SwitchLanguage;
    }

    public void SwitchLanguage(string lang)
    {
        switch (lang)
        {
            case "ru":
                _text.text = _ru;
                break;
            case "tr":
                _text.text = _tr;
                break;
            default:
                _text.text = _en;
                break;
        }
    }
}
