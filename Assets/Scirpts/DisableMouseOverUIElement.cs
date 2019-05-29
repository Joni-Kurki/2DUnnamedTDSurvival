using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisableMouseOverUIElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private StateManagerScript _stateManager;

    // Start is called before the first frame update
    void Start()
    {
        _stateManager = GameObject.FindGameObjectWithTag(Constants.TAG_STATE_MANAGER).GetComponent<StateManagerScript>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _stateManager.ToggleBuilders(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _stateManager.ToggleBuilders(false);
    }
}
