using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private SceneObjects _menuObjects;
    [SerializeField] private IternalMenuSwitcher _iternalMenuSwitcher;
    
    private void Awake()
    {
        Instantiate(_menuObjects);
        
        _iternalMenuSwitcher.CloseSelectLevelMenu();
        
        ServiceLocator.GetService<LoadingBackground>().TurnOff();
    }
}
