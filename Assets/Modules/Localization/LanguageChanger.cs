using UnityEngine;
using UnityEngine.UI;
using YG;

public class LanguageChanger : MonoBehaviour
{
    [SerializeField] private Image _ruIcon;
    [SerializeField] private Image _enIcon;
    [SerializeField] private Image _trIcon;

    private string _ruLanguage = "ru";
    private string _enLanguage = "en";
    private string _trLanguage = "tr";
    
    private void Awake()
    {
        if (YG2.lang == _ruLanguage)
        {
            _enIcon.gameObject.SetActive(false);
            _trIcon.gameObject.SetActive(false);
        }
        else if (YG2.lang == _enLanguage)
        {
            _ruIcon.gameObject.SetActive(false);
            _trIcon.gameObject.SetActive(false);
        }
        else if (YG2.lang == _trLanguage)
        {
            _ruIcon.gameObject.SetActive(false);
            _enIcon.gameObject.SetActive(false);
        }
    }

    public void ChangeLanguage()
    {
        if (_ruIcon.isActiveAndEnabled == true)
        {
            YG2.SwitchLanguage(_enLanguage);
            
            _enIcon.gameObject.SetActive(true);
            _ruIcon.gameObject.SetActive(false);
        }
        else if (_enIcon.isActiveAndEnabled == true)
        {
            YG2.SwitchLanguage(_trLanguage);
            
            _trIcon.gameObject.SetActive(true);
            _enIcon.gameObject.SetActive(false);
        }
        else if (_trIcon.isActiveAndEnabled == true)
        {
            YG2.SwitchLanguage(_ruLanguage);
            
            _ruIcon.gameObject.SetActive(true);
            _trIcon.gameObject.SetActive(false);
        }
    }
}
