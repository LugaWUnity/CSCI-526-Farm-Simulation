// this document demonstrates how to add/remove items in inventory
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToAccessInventory : MonoBehaviour{

	Inventory inventory;

	void Start(){
		inventory = Inventory.instance;
	}
	
	public void Foo(){
		// add one corn seed to inventory
		inventory.Add("Corn", 1, true);
		// remove one corn from inventory
		inventory.Add("Corn", -1, true);
	}
}