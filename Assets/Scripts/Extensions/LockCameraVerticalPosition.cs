using UnityEngine;
using Cinemachine;

[ExecuteInEditMode] [SaveDuringPlay]
public class LockCameraVerticalPosition : CinemachineExtension
{
    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vCamera,
        CinemachineCore.Stage stage, ref CameraState state, float time)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.z = 0;
            state.RawPosition = pos;
        }
    }
}