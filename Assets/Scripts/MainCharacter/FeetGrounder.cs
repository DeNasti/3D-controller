using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetGrounder : MonoBehaviour
{

    private Vector3 rightFootPosition, leftFootPosition, rightFootIKPosition, leftFootIKPosition;
    private Quaternion rightFootIKRotation, leftFootIKRotation;
    private float lastPelvisYPosition, lastRightFootPositionY, lastLeftFootPositionY;

    [Header("foot")]
    public bool enableFeetIk = true;
    [Range(0, 2)] [SerializeField] private float heigtFromGroundRaycast = 1.4f;
    [Range(0, 2)] [SerializeField] private float raycastDownDistance = 1.4f;
    [SerializeField] private LayerMask evnironmentLater;
    [SerializeField] private float pelvisOffset = 0f;
    [Range(0, 1)] [SerializeField] private float pelvisUpAndDownSpeed = 0.28f;
    [Range(0, 1)] [SerializeField] private float feetToIkPositionSpeed = 0.28f;

    public string leftFootAnimVariableName = "LeftFootCurve";
    public string rightFootAnimVariableName = "RightFootCurve";

    public bool useProIK = true;

    private void FixedUpdate()
    {
        if (!enableFeetIk)
        { return; }

        //if no animator return

    }

    private void OnAnimatorIK(int layerIndex)
    {
        
    }

    #region methods
    private void MoveFeetToIKPoint(AvatarIKGoal foot, Vector3 positionIkHolder, Quaternion rotationIkHolder, ref float lastFootPositionY)
    {

    }

    private void MovePelvisHeight()
    { 

    }

    void FeetPositionSolver(Vector3 fromSkyPosition, ref Vector3 feetIkPosition, ref Quaternion feetIkRotation)
    {

    }
    private void AdjustFeetTarget(ref Vector3 feetPosition, HumanBodyBones foot)
    {

    }
    #endregion
}
