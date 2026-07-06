using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    private List<KitchenObjectSO> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if(!validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            //This KitchenObjectSO is not valid for this plate
            return false;
        }
        if (kitchenObjectSOList.Contains(kitchenObjectSO)) 
        {
            //Already has this ingredient
            return false;
        }
        else
        {
            kitchenObjectSOList.Add(kitchenObjectSO);
            return true;
        }
    }
}
