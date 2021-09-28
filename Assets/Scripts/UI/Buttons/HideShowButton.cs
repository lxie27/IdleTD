using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideShowButton : MonoBehaviour
{
	public Button hideShowButton;
	public GameObject hidableButtons;

	void Start()
	{
		Button btn = hideShowButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

		if (hidableButtons.activeSelf)
        {
			hideShowButton.GetComponentInChildren<Text>().text = "Hide Buttons";
		}
        else
        {
			hideShowButton.GetComponentInChildren<Text>().text = "Show Buttons";
		}
	}

	void TaskOnClick()
	{
		if (hidableButtons.activeSelf)
		{
			hidableButtons.SetActive(false);
			hideShowButton.GetComponentInChildren<Text>().text = "Show Buttons";
		}
		else if (!hidableButtons.activeSelf)
		{
			hidableButtons.SetActive(true);
			hideShowButton.GetComponentInChildren<Text>().text = "Hide Buttons";
		}
	}
}
