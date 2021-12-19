using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{

    public GameObject basicTowerObject;
    public GameObject dummyPlacement;
    public ShopManager shopManager;

    private GameObject currentTowerPlacing;
    
    public Camera cam;

    public GameObject hoverTile;

    public LayerMask mask;
    public LayerMask towerMask;

    public bool isBuilding;

    public void Start(){
    }

    public Vector2 GetMousePosition(){
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void GetCurrentHoverTile(){

        Vector2 mousePosition = GetMousePosition();

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(0,0), 0.1f, mask, -100, 100);


        if(hit.collider != null){
            //checking if the detected object is mapTile
            if( MapGenerator.mapTiles.Contains(hit.collider.gameObject)){
                // checking if the mapTile detected is not a pathTile
                if(!MapGenerator.pathTiles.Contains(hit.collider.gameObject)){
                    hoverTile = hit.collider.gameObject;
                }
            }
        }
    }

    public bool CheckForTower(){
        Vector2 mousePosition = GetMousePosition();
        bool towerOnSlot = false;

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(0,0), 0.1f, towerMask);

        if(hit.collider != null){
            towerOnSlot = true;
        }

        return towerOnSlot;
    }

    public void PlaceBuilding(){

        if(hoverTile != null){

            if(CheckForTower() == false){

                if(shopManager.CanBuyTower(currentTowerPlacing) == true){

                    GameObject newTowerObject = Instantiate(currentTowerPlacing);
                    newTowerObject.layer = LayerMask.NameToLayer("Tower");
                    newTowerObject.transform.position = hoverTile.transform.position;

                    EndBuilding();
                    shopManager.BuyTower(currentTowerPlacing);
                }

            }else{
                Debug.Log("Not enough money! Can't buy this tower yet");
            }
        }

    }



    public void StartBuilding(GameObject towerToBuild){

        isBuilding = true;

        currentTowerPlacing = towerToBuild;

        dummyPlacement = Instantiate(currentTowerPlacing);

        if(dummyPlacement.GetComponent<Tower>() != null){
            Destroy(dummyPlacement.GetComponent<Tower>());
        }

        if(dummyPlacement.GetComponent<BarrelRotation>() != null){
            Destroy(dummyPlacement.GetComponent<BarrelRotation>());
        }


    }

    public void EndBuilding(){

        isBuilding = false;

        if(dummyPlacement != null){
            Destroy(dummyPlacement);
        }
    }

    public void Update(){

        if(isBuilding == true){

            if(dummyPlacement != null){

                GetCurrentHoverTile();

                if(hoverTile != null){
                    dummyPlacement.transform.position = hoverTile.transform.position;
                }
            }

            if(Input.GetButtonDown("Fire1")){
                PlaceBuilding();
            }
        }
    }
}
