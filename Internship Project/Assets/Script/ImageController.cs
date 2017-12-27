using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour {

    public Image mainImage;
    public List<Sprite> sprites = new List<Sprite>();

    private DataController dataController;
	// Use this for initialization
	void Start () {
        dataController = FindObjectOfType<DataController>();
        mainImage.sprite = sprites[dataController.numberLevel];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
