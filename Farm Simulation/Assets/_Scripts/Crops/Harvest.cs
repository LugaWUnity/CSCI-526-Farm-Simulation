﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Harvest : MonoBehaviour
{
    // Summary: Script checks for the current gameobject that is being interacted and determines whether the player can harvest a crop successfully
    // Notifications are handled in HarvestStats.cs

    private GameObject childObject;
    public Text notificationText;
    public HarvestStats hs;

    Inventory inventory;

    private Transform parentInventory;
    public AudioClip HarvestSound;

    void Start()
    {
        
        parentInventory = GameObject.Find("HarvestPlaceholder").transform;

        inventory = Inventory.instance;
    }

    public void SetObject(GameObject gameObject)
    {
        childObject = gameObject;
    }

    void HarvestSingleCrop(CropGrowing cropGrowing)
    {
        string cropName = childObject.name;
        int reward = cropGrowing.reward;
        Debug.Log("Harvesting " + cropName);
        hs.AddToInventory(cropName, reward);

        //string inventName = cropName + "Fruit";
        //Debug.Log(inventName);
        inventory.Add(cropName, Item.RandomHarvest(cropName), false);

        notificationText.text = "";
        HideCrop(cropName);

        Animator anim = childObject.GetComponent<Animator>();
        anim.Play("Harvest");
    }

    public void CollectCrop()
    {
        
        //clicked on nothing
        
        if (childObject == null || childObject.transform.parent == null)
        {
            Debug.Log("Not clicking anywhere near the fields");
            hs.ActivateFail(1);
            return;
        }
        

        //clicked on cropLand instead

        if (childObject.CompareTag("cropLand"))
        {
            //check for child just in case

            if (childObject.transform.childCount <= 0)
            {
                Debug.Log("Theres nothing on the field");
                hs.ActivateFail(2);
                return;
            }

            GameObject checkChild = childObject.transform.GetChild(0).gameObject;
            
            if (checkChild)
            {
                CropGrowing gScript= checkChild.GetComponent<CropGrowing>();
                if (gScript.grown)
                {
                    HarvestSingleCrop(gScript);
                    return;
                }

            }            
            
        } 


        //clicked on the crop itself

        CropGrowing cropGrowing = childObject.GetComponent<CropGrowing>();

        if (cropGrowing == null)
        {
            Debug.Log("Collecting right after planting");
            hs.ActivateFail(3);
            return;
        }


        if (cropGrowing.grown)
        {
            HarvestSingleCrop(cropGrowing);
        }
        else
        {
            Debug.Log("Has yet to grow");
            hs.ActivateFail(3);
            return;
        }
    }

    public void HideCrop(string cropName)
    {
        GameObject gameObject = new GameObject();
        gameObject.name = cropName;
        gameObject.transform.SetParent(parentInventory);
        gameObject.transform.position = parentInventory.position;
        gameObject.SetActive(false);
    }

}
