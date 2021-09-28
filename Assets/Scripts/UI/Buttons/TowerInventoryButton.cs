using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInventoryButton : MonoBehaviour
{
	public Button towerInventoryButton;
	public GameObject towerInventoryPanel; 

	void Start()
	{
		Button btn = towerInventoryButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		if (towerInventoryPanel.activeSelf)
        {
			towerInventoryPanel.SetActive(false);
        }
		else if (!towerInventoryPanel.activeSelf)
		{
			towerInventoryPanel.SetActive(true);
		}
	}
}
