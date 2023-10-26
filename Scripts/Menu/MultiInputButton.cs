﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// An extension of Unity's base Button class, to support input from both mouse and keyboard/joypad
/// </summary>
[AddComponentMenu("UOP1/UI/MultiInputButton")]
public class MultiInputButton : Button
{
	private MenuSelectionHandler _menuSelectionHandler;
	public bool IsSelected;
	private new void Awake()
	{
		_menuSelectionHandler = transform.root.gameObject.GetComponentInChildren<MenuSelectionHandler>();
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		_menuSelectionHandler.HandleMouseEnter(gameObject);
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		_menuSelectionHandler.HandleMouseExit(gameObject);
	}

	public override void OnSelect(BaseEventData eventData)
	{
		Debug.Log("Onselect ");
		IsSelected = true;
		_menuSelectionHandler.UpdateSelection(gameObject);
		base.OnSelect(eventData);
	}

	public void UpdateSelected()
	{
		if (_menuSelectionHandler == null)
			_menuSelectionHandler = transform.root.gameObject.GetComponentInChildren<MenuSelectionHandler>();
		Debug.Log("UpdateSelected");
		_menuSelectionHandler.UpdateSelection(gameObject);

	}

	public override void OnSubmit(BaseEventData eventData)
	{
		if (_menuSelectionHandler.AllowsSubmit())
			base.OnSubmit(eventData);
	}

}
