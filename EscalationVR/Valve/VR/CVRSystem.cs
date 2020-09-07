using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Valve.VR
{
	// Token: 0x02000025 RID: 37
	public class CVRSystem
	{
		// Token: 0x06000105 RID: 261 RVA: 0x0000B0C0 File Offset: 0x000092C0
		internal CVRSystem(global::System.IntPtr pInterface)
		{
			this.FnTable = (global::Valve.VR.IVRSystem)global::System.Runtime.InteropServices.Marshal.PtrToStructure(pInterface, typeof(global::Valve.VR.IVRSystem));
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000B0E5 File Offset: 0x000092E5
		public void GetRecommendedRenderTargetSize(ref uint pnWidth, ref uint pnHeight)
		{
			pnWidth = 0U;
			pnHeight = 0U;
			this.FnTable.GetRecommendedRenderTargetSize(ref pnWidth, ref pnHeight);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0000B104 File Offset: 0x00009304
		public global::Valve.VR.HmdMatrix44_t GetProjectionMatrix(global::Valve.VR.EVREye eEye, float fNearZ, float fFarZ, global::Valve.VR.EGraphicsAPIConvention eProjType)
		{
			return this.FnTable.GetProjectionMatrix(eEye, fNearZ, fFarZ, eProjType);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0000B12D File Offset: 0x0000932D
		public void GetProjectionRaw(global::Valve.VR.EVREye eEye, ref float pfLeft, ref float pfRight, ref float pfTop, ref float pfBottom)
		{
			pfLeft = 0f;
			pfRight = 0f;
			pfTop = 0f;
			pfBottom = 0f;
			this.FnTable.GetProjectionRaw(eEye, ref pfLeft, ref pfRight, ref pfTop, ref pfBottom);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000B168 File Offset: 0x00009368
		public global::Valve.VR.DistortionCoordinates_t ComputeDistortion(global::Valve.VR.EVREye eEye, float fU, float fV)
		{
			return this.FnTable.ComputeDistortion(eEye, fU, fV);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0000B190 File Offset: 0x00009390
		public global::Valve.VR.HmdMatrix34_t GetEyeToHeadTransform(global::Valve.VR.EVREye eEye)
		{
			return this.FnTable.GetEyeToHeadTransform(eEye);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000B1B8 File Offset: 0x000093B8
		public bool GetTimeSinceLastVsync(ref float pfSecondsSinceLastVsync, ref ulong pulFrameCounter)
		{
			pfSecondsSinceLastVsync = 0f;
			pulFrameCounter = 0UL;
			return this.FnTable.GetTimeSinceLastVsync(ref pfSecondsSinceLastVsync, ref pulFrameCounter);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000B1EC File Offset: 0x000093EC
		public int GetD3D9AdapterIndex()
		{
			return this.FnTable.GetD3D9AdapterIndex();
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000B210 File Offset: 0x00009410
		public void GetDXGIOutputInfo(ref int pnAdapterIndex)
		{
			pnAdapterIndex = 0;
			this.FnTable.GetDXGIOutputInfo(ref pnAdapterIndex);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0000B228 File Offset: 0x00009428
		public bool IsDisplayOnDesktop()
		{
			return this.FnTable.IsDisplayOnDesktop();
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000B24C File Offset: 0x0000944C
		public bool SetDisplayVisibility(bool bIsVisibleOnDesktop)
		{
			return this.FnTable.SetDisplayVisibility(bIsVisibleOnDesktop);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000B271 File Offset: 0x00009471
		public void GetDeviceToAbsoluteTrackingPose(global::Valve.VR.ETrackingUniverseOrigin eOrigin, float fPredictedSecondsToPhotonsFromNow, global::Valve.VR.TrackedDevicePose_t[] pTrackedDevicePoseArray)
		{
			this.FnTable.GetDeviceToAbsoluteTrackingPose(eOrigin, fPredictedSecondsToPhotonsFromNow, pTrackedDevicePoseArray, (uint)pTrackedDevicePoseArray.Length);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000B28B File Offset: 0x0000948B
		public void ResetSeatedZeroPose()
		{
			this.FnTable.ResetSeatedZeroPose();
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000B2A0 File Offset: 0x000094A0
		public global::Valve.VR.HmdMatrix34_t GetSeatedZeroPoseToStandingAbsoluteTrackingPose()
		{
			return this.FnTable.GetSeatedZeroPoseToStandingAbsoluteTrackingPose();
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000B2C4 File Offset: 0x000094C4
		public global::Valve.VR.HmdMatrix34_t GetRawZeroPoseToStandingAbsoluteTrackingPose()
		{
			return this.FnTable.GetRawZeroPoseToStandingAbsoluteTrackingPose();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000B2E8 File Offset: 0x000094E8
		public uint GetSortedTrackedDeviceIndicesOfClass(global::Valve.VR.ETrackedDeviceClass eTrackedDeviceClass, uint[] punTrackedDeviceIndexArray, uint unRelativeToTrackedDeviceIndex)
		{
			return this.FnTable.GetSortedTrackedDeviceIndicesOfClass(eTrackedDeviceClass, punTrackedDeviceIndexArray, (uint)punTrackedDeviceIndexArray.Length, unRelativeToTrackedDeviceIndex);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000B314 File Offset: 0x00009514
		public global::Valve.VR.EDeviceActivityLevel GetTrackedDeviceActivityLevel(uint unDeviceId)
		{
			return this.FnTable.GetTrackedDeviceActivityLevel(unDeviceId);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000B339 File Offset: 0x00009539
		public void ApplyTransform(ref global::Valve.VR.TrackedDevicePose_t pOutputPose, ref global::Valve.VR.TrackedDevicePose_t pTrackedDevicePose, ref global::Valve.VR.HmdMatrix34_t pTransform)
		{
			this.FnTable.ApplyTransform(ref pOutputPose, ref pTrackedDevicePose, ref pTransform);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000B350 File Offset: 0x00009550
		public uint GetTrackedDeviceIndexForControllerRole(global::Valve.VR.ETrackedControllerRole unDeviceType)
		{
			return this.FnTable.GetTrackedDeviceIndexForControllerRole(unDeviceType);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000B378 File Offset: 0x00009578
		public global::Valve.VR.ETrackedControllerRole GetControllerRoleForTrackedDeviceIndex(uint unDeviceIndex)
		{
			return this.FnTable.GetControllerRoleForTrackedDeviceIndex(unDeviceIndex);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000B3A0 File Offset: 0x000095A0
		public global::Valve.VR.ETrackedDeviceClass GetTrackedDeviceClass(uint unDeviceIndex)
		{
			return this.FnTable.GetTrackedDeviceClass(unDeviceIndex);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000B3C8 File Offset: 0x000095C8
		public bool IsTrackedDeviceConnected(uint unDeviceIndex)
		{
			return this.FnTable.IsTrackedDeviceConnected(unDeviceIndex);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000B3F0 File Offset: 0x000095F0
		public bool GetBoolTrackedDeviceProperty(uint unDeviceIndex, global::Valve.VR.ETrackedDeviceProperty prop, ref global::Valve.VR.ETrackedPropertyError pError)
		{
			return this.FnTable.GetBoolTrackedDeviceProperty(unDeviceIndex, prop, ref pError);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000B418 File Offset: 0x00009618
		public float GetFloatTrackedDeviceProperty(uint unDeviceIndex, global::Valve.VR.ETrackedDeviceProperty prop, ref global::Valve.VR.ETrackedPropertyError pError)
		{
			return this.FnTable.GetFloatTrackedDeviceProperty(unDeviceIndex, prop, ref pError);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000B440 File Offset: 0x00009640
		public int GetInt32TrackedDeviceProperty(uint unDeviceIndex, global::Valve.VR.ETrackedDeviceProperty prop, ref global::Valve.VR.ETrackedPropertyError pError)
		{
			return this.FnTable.GetInt32TrackedDeviceProperty(unDeviceIndex, prop, ref pError);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000B468 File Offset: 0x00009668
		public ulong GetUint64TrackedDeviceProperty(uint unDeviceIndex, global::Valve.VR.ETrackedDeviceProperty prop, ref global::Valve.VR.ETrackedPropertyError pError)
		{
			return this.FnTable.GetUint64TrackedDeviceProperty(unDeviceIndex, prop, ref pError);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000B490 File Offset: 0x00009690
		public global::Valve.VR.HmdMatrix34_t GetMatrix34TrackedDeviceProperty(uint unDeviceIndex, global::Valve.VR.ETrackedDeviceProperty prop, ref global::Valve.VR.ETrackedPropertyError pError)
		{
			return this.FnTable.GetMatrix34TrackedDeviceProperty(unDeviceIndex, prop, ref pError);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000B4B8 File Offset: 0x000096B8
		public uint GetStringTrackedDeviceProperty(uint unDeviceIndex, global::Valve.VR.ETrackedDeviceProperty prop, global::System.Text.StringBuilder pchValue, uint unBufferSize, ref global::Valve.VR.ETrackedPropertyError pError)
		{
			return this.FnTable.GetStringTrackedDeviceProperty(unDeviceIndex, prop, pchValue, unBufferSize, ref pError);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000B4E4 File Offset: 0x000096E4
		public string GetPropErrorNameFromEnum(global::Valve.VR.ETrackedPropertyError error)
		{
			global::System.IntPtr intPtr = this.FnTable.GetPropErrorNameFromEnum(error);
			return (string)global::System.Runtime.InteropServices.Marshal.PtrToStructure(intPtr, typeof(string));
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000B520 File Offset: 0x00009720
		public bool PollNextEvent(ref global::Valve.VR.VREvent_t pEvent, uint uncbVREvent)
		{
			return this.FnTable.PollNextEvent(ref pEvent, uncbVREvent);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000B548 File Offset: 0x00009748
		public bool PollNextEventWithPose(global::Valve.VR.ETrackingUniverseOrigin eOrigin, ref global::Valve.VR.VREvent_t pEvent, uint uncbVREvent, ref global::Valve.VR.TrackedDevicePose_t pTrackedDevicePose)
		{
			return this.FnTable.PollNextEventWithPose(eOrigin, ref pEvent, uncbVREvent, ref pTrackedDevicePose);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000B574 File Offset: 0x00009774
		public string GetEventTypeNameFromEnum(global::Valve.VR.EVREventType eType)
		{
			global::System.IntPtr intPtr = this.FnTable.GetEventTypeNameFromEnum(eType);
			return (string)global::System.Runtime.InteropServices.Marshal.PtrToStructure(intPtr, typeof(string));
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0000B5B0 File Offset: 0x000097B0
		public global::Valve.VR.HiddenAreaMesh_t GetHiddenAreaMesh(global::Valve.VR.EVREye eEye)
		{
			return this.FnTable.GetHiddenAreaMesh(eEye);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000B5D8 File Offset: 0x000097D8
		public bool GetControllerState(uint unControllerDeviceIndex, ref global::Valve.VR.VRControllerState_t pControllerState)
		{
			return this.FnTable.GetControllerState(unControllerDeviceIndex, ref pControllerState);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000B600 File Offset: 0x00009800
		public bool GetControllerStateWithPose(global::Valve.VR.ETrackingUniverseOrigin eOrigin, uint unControllerDeviceIndex, ref global::Valve.VR.VRControllerState_t pControllerState, ref global::Valve.VR.TrackedDevicePose_t pTrackedDevicePose)
		{
			return this.FnTable.GetControllerStateWithPose(eOrigin, unControllerDeviceIndex, ref pControllerState, ref pTrackedDevicePose);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000B629 File Offset: 0x00009829
		public void TriggerHapticPulse(uint unControllerDeviceIndex, uint unAxisId, char usDurationMicroSec)
		{
			this.FnTable.TriggerHapticPulse(unControllerDeviceIndex, unAxisId, usDurationMicroSec);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000B640 File Offset: 0x00009840
		public string GetButtonIdNameFromEnum(global::Valve.VR.EVRButtonId eButtonId)
		{
			global::System.IntPtr intPtr = this.FnTable.GetButtonIdNameFromEnum(eButtonId);
			return (string)global::System.Runtime.InteropServices.Marshal.PtrToStructure(intPtr, typeof(string));
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000B67C File Offset: 0x0000987C
		public string GetControllerAxisTypeNameFromEnum(global::Valve.VR.EVRControllerAxisType eAxisType)
		{
			global::System.IntPtr intPtr = this.FnTable.GetControllerAxisTypeNameFromEnum(eAxisType);
			return (string)global::System.Runtime.InteropServices.Marshal.PtrToStructure(intPtr, typeof(string));
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000B6B8 File Offset: 0x000098B8
		public bool CaptureInputFocus()
		{
			return this.FnTable.CaptureInputFocus();
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0000B6DC File Offset: 0x000098DC
		public void ReleaseInputFocus()
		{
			this.FnTable.ReleaseInputFocus();
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000B6F0 File Offset: 0x000098F0
		public bool IsInputFocusCapturedByAnotherProcess()
		{
			return this.FnTable.IsInputFocusCapturedByAnotherProcess();
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0000B714 File Offset: 0x00009914
		public uint DriverDebugRequest(uint unDeviceIndex, string pchRequest, string pchResponseBuffer, uint unResponseBufferSize)
		{
			return this.FnTable.DriverDebugRequest(unDeviceIndex, pchRequest, pchResponseBuffer, unResponseBufferSize);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x0000B740 File Offset: 0x00009940
		public global::Valve.VR.EVRFirmwareError PerformFirmwareUpdate(uint unDeviceIndex)
		{
			return this.FnTable.PerformFirmwareUpdate(unDeviceIndex);
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0000B765 File Offset: 0x00009965
		public void AcknowledgeQuit_Exiting()
		{
			this.FnTable.AcknowledgeQuit_Exiting();
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000B779 File Offset: 0x00009979
		public void AcknowledgeQuit_UserPrompt()
		{
			this.FnTable.AcknowledgeQuit_UserPrompt();
		}

		// Token: 0x040001AD RID: 429
		private global::Valve.VR.IVRSystem FnTable;
	}
}
