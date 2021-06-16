using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandSelectionController : XRGrabInteractable
{
    
    //Stops the object from being grabbed by 2 hands
    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        bool isAlreadyGrabbed = selectingInteractor && !interactor.Equals(selectingInteractor);
        
        return base.IsSelectableBy(interactor) && !isAlreadyGrabbed;
    }
    
    
}
