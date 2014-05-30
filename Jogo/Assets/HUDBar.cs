using UnityEngine;
using System.Collections;

public class HUDBar : MonoBehaviour 
{
	public HUDItemBar BarbarianBar;
	public HUDItemBar PaladinBar;
	public HUDItemBar ThiefBar;
	public HUDItemBar WarriorBar;

	void Start () 
	{	
	}	

	void Update () 
	{	
	}

	public void UpdateBar(CharClass charClass, float percentual)
	{
		switch(charClass)
		{
			case CharClass.Warrior:
				WarriorBar.Percentual = percentual;
				break;

			case CharClass.Barbarian:
				BarbarianBar.Percentual = percentual;
				break;

			case CharClass.Paladin:
				PaladinBar.Percentual = percentual;
				break;

			case CharClass.Thief:
				ThiefBar.Percentual = percentual;
				break;
		}
	}
}
