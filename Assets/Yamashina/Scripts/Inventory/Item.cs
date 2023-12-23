using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Item :MonoBehaviour
{ 
    
        public enum Category
        {
            Sozai,
            Water,
            food,
        }
        public Category enCategory;
        public string sName;
        public Sprite image;
        public string description;
        //public string description = "Description";


    
}
