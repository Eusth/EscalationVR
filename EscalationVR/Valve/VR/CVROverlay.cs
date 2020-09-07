using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Valve.VR
{
	// Token: 0x0200002B RID: 43
	public class CVROverlay
	{
		// Token: 0x0600018B RID: 395 RVA: 0x0000C416 File Offset: 0x0000A616
		internal CVROverlay(global::System.IntPtr pInterface)
		{
			this.FnTable = (global::Valve.VR.IVROverlay)global::System.Runtime.InteropServices.Marshal.PtrToStructure(pInterface, typeof(global::Valve.VR.IVROverlay));
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000C43C File Offset: 0x0000A63C
		public global::Valve.VR.EVROverlayError FindOverlay(string pchOverlayKey, ref ulong pOverlayHandle)
		{
			pOverlayHandle = 0UL;
			return this.FnTable.FindOverlay(pchOverlayKey, ref pOverlayHandle);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000C468 File Offset: 0x0000A668
		public global::Valve.VR.EVROverlayError CreateOverlay(string pchOverlayKey, string pchOverlayFriendlyName, ref ulong pOverlayHandle)
		{
			pOverlayHandle = 0UL;
			return this.FnTable.CreateOverlay(pchOverlayKey, pchOverlayFriendlyName, ref pOverlayHandle);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000C494 File Offset: 0x0000A694
		public global::Valve.VR.EVROverlayError DestroyOverlay(ulong ulOverlayHandle)
		{
			return this.FnTable.DestroyOverlay(ulOverlayHandle);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000C4BC File Offset: 0x0000A6BC
		public global::Valve.VR.EVROverlayError SetHighQualityOverlay(ulong ulOverlayHandle)
		{
			return this.FnTable.SetHighQualityOverlay(ulOverlayHandle);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000C4E4 File Offset: 0x0000A6E4
		public ulong GetHighQualityOverlay()
		{
			return this.FnTable.GetHighQualityOverlay();
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0000C508 File Offset: 0x0000A708
		public uint GetOverlayKey(ulong ulOverlayHandle, global::System.Text.StringBuilder pchValue, uint unBufferSize, ref global::Valve.VR.EVROverlayError pError)
		{
			return this.FnTable.GetOverlayKey(ulOverlayHandle, pchValue, unBufferSize, ref pError);
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000C534 File Offset: 0x0000A734
		public uint GetOverlayName(ulong ulOverlayHandle, global::System.Text.StringBuilder pchValue, uint unBufferSize, ref global::Valve.VR.EVROverlayError pError)
		{
			return this.FnTable.GetOverlayName(ulOverlayHandle, pchValue, unBufferSize, ref pError);
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000C560 File Offset: 0x0000A760
		public global::Valve.VR.EVROverlayError GetOverlayImageData(ulong ulOverlayHandle, global::System.IntPtr pvBuffer, uint unBufferSize, ref uint punWidth, ref uint punHeight)
		{
			punWidth = 0U;
			punHeight = 0U;
			return this.FnTable.GetOverlayImageData(ulOverlayHandle, pvBuffer, unBufferSize, ref punWidth, ref punHeight);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000C594 File Offset: 0x0000A794
		public string GetOverlayErrorNameFromEnum(global::Valve.VR.EVROverlayError error)
		{
			global::System.IntPtr intPtr = this.FnTable.GetOverlayErrorNameFromEnum(error);
			return (string)global::System.Runtime.InteropServices.Marshal.PtrToStructure(intPtr, typeof(string));
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0000C5D0 File Offset: 0x0000A7D0
		public global::Valve.VR.EVROverlayError SetOverlayRenderingPid(ulong ulOverlayHandle, uint unPID)
		{
			return this.FnTable.SetOverlayRenderingPid(ulOverlayHandle, unPID);
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0000C5F8 File Offset: 0x0000A7F8
		public uint GetOverlayRenderingPid(ulong ulOverlayHandle)
		{
			return this.FnTable.GetOverlayRenderingPid(ulOverlayHandle);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0000C620 File Offset: 0x0000A820
		public global::Valve.VR.EVROverlayError SetOverlayFlag(ulong ulOverlayHandle, global::Valve.VR.VROverlayFlags eOverlayFlag, bool bEnabled)
		{
			return this.FnTable.SetOverlayFlag(ulOverlayHandle, eOverlayFlag, bEnabled);
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000C648 File Offset: 0x0000A848
		public global::Valve.VR.EVROverlayError GetOverlayFlag(ulong ulOverlayHandle, global::Valve.VR.VROverlayFlags eOverlayFlag, ref bool pbEnabled)
		{
			pbEnabled = false;
			return this.FnTable.GetOverlayFlag(ulOverlayHandle, eOverlayFlag, ref pbEnabled);
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000C674 File Offset: 0x0000A874
		public global::Valve.VR.EVROverlayError SetOverlayColor(ulong ulOverlayHandle, float fRed, float fGreen, float fBlue)
		{
			return this.FnTable.SetOverlayColor(ulOverlayHandle, fRed, fGreen, fBlue);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000C6A0 File Offset: 0x0000A8A0
		public global::Valve.VR.EVROverlayError GetOverlayColor(ulong ulOverlayHandle, ref float pfRed, ref float pfGreen, ref float pfBlue)
		{
			pfRed = 0f;
			pfGreen = 0f;
			pfBlue = 0f;
			return this.FnTable.GetOverlayColor(ulOverlayHandle, ref pfRed, ref pfGreen, ref pfBlue);
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000C6E0 File Offset: 0x0000A8E0
		public global::Valve.VR.EVROverlayError SetOverlayAlpha(ulong ulOverlayHandle, float fAlpha)
		{
			return this.FnTable.SetOverlayAlpha(ulOverlayHandle, fAlpha);
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0000C708 File Offset: 0x0000A908
		public global::Valve.VR.EVROverlayError GetOverlayAlpha(ulong ulOverlayHandle, ref float pfAlpha)
		{
			pfAlpha = 0f;
			return this.FnTable.GetOverlayAlpha(ulOverlayHandle, ref pfAlpha);
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000C738 File Offset: 0x0000A938
		public global::Valve.VR.EVROverlayError SetOverlayWidthInMeters(ulong ulOverlayHandle, float fWidthInMeters)
		{
			return this.FnTable.SetOverlayWidthInMeters(ulOverlayHandle, fWidthInMeters);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0000C760 File Offset: 0x0000A960
		public global::Valve.VR.EVROverlayError GetOverlayWidthInMeters(ulong ulOverlayHandle, ref float pfWidthInMeters)
		{
			pfWidthInMeters = 0f;
			return this.FnTable.GetOverlayWidthInMeters(ulOverlayHandle, ref pfWidthInMeters);
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0000C790 File Offset: 0x0000A990
		public global::Valve.VR.EVROverlayError SetOverlayAutoCurveDistanceRangeInMeters(ulong ulOverlayHandle, float fMinDistanceInMeters, float fMaxDistanceInMeters)
		{
			return this.FnTable.SetOverlayAutoCurveDistanceRangeInMeters(ulOverlayHandle, fMinDistanceInMeters, fMaxDistanceInMeters);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0000C7B8 File Offset: 0x0000A9B8
		public global::Valve.VR.EVROverlayError GetOverlayAutoCurveDistanceRangeInMeters(ulong ulOverlayHandle, ref float pfMinDistanceInMeters, ref float pfMaxDistanceInMeters)
		{
			pfMinDistanceInMeters = 0f;
			pfMaxDistanceInMeters = 0f;
			return this.FnTable.GetOverlayAutoCurveDistanceRangeInMeters(ulOverlayHandle, ref pfMinDistanceInMeters, ref pfMaxDistanceInMeters);
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0000C7F0 File Offset: 0x0000A9F0
		public global::Valve.VR.EVROverlayError SetOverlayTextureColorSpace(ulong ulOverlayHandle, global::Valve.VR.EColorSpace eTextureColorSpace)
		{
			return this.FnTable.SetOverlayTextureColorSpace(ulOverlayHandle, eTextureColorSpace);
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0000C818 File Offset: 0x0000AA18
		public global::Valve.VR.EVROverlayError GetOverlayTextureColorSpace(ulong ulOverlayHandle, ref global::Valve.VR.EColorSpace peTextureColorSpace)
		{
			return this.FnTable.GetOverlayTextureColorSpace(ulOverlayHandle, ref peTextureColorSpace);
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000C840 File Offset: 0x0000AA40
		public global::Valve.VR.EVROverlayError SetOverlayTextureBounds(ulong ulOverlayHandle, ref global::Valve.VR.VRTextureBounds_t pOverlayTextureBounds)
		{
			return this.FnTable.SetOverlayTextureBounds(ulOverlayHandle, ref pOverlayTextureBounds);
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000C868 File Offset: 0x0000AA68
		public global::Valve.VR.EVROverlayError GetOverlayTextureBounds(ulong ulOverlayHandle, ref global::Valve.VR.VRTextureBounds_t pOverlayTextureBounds)
		{
			return this.FnTable.GetOverlayTextureBounds(ulOverlayHandle, ref pOverlayTextureBounds);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000C890 File Offset: 0x0000AA90
		public global::Valve.VR.EVROverlayError GetOverlayTransformType(ulong ulOverlayHandle, ref global::Valve.VR.VROverlayTransformType peTransformType)
		{
			return this.FnTable.GetOverlayTransformType(ulOverlayHandle, ref peTransformType);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0000C8B8 File Offset: 0x0000AAB8
		public global::Valve.VR.EVROverlayError SetOverlayTransformAbsolute(ulong ulOverlayHandle, global::Valve.VR.ETrackingUniverseOrigin eTrackingOrigin, ref global::Valve.VR.HmdMatrix34_t pmatTrackingOriginToOverlayTransform)
		{
			return this.FnTable.SetOverlayTransformAbsolute(ulOverlayHandle, eTrackingOrigin, ref pmatTrackingOriginToOverlayTransform);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0000C8E0 File Offset: 0x0000AAE0
		public global::Valve.VR.EVROverlayError GetOverlayTransformAbsolute(ulong ulOverlayHandle, ref global::Valve.VR.ETrackingUniverseOrigin peTrackingOrigin, ref global::Valve.VR.HmdMatrix34_t pmatTrackingOriginToOverlayTransform)
		{
			return this.FnTable.GetOverlayTransformAbsolute(ulOverlayHandle, ref peTrackingOrigin, ref pmatTrackingOriginToOverlayTransform);
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000C908 File Offset: 0x0000AB08
		public global::Valve.VR.EVROverlayError SetOverlayTransformTrackedDeviceRelative(ulong ulOverlayHandle, uint unTrackedDevice, ref global::Valve.VR.HmdMatrix34_t pmatTrackedDeviceToOverlayTransform)
		{
			return this.FnTable.SetOverlayTransformTrackedDeviceRelative(ulOverlayHandle, unTrackedDevice, ref pmatTrackedDeviceToOverlayTransform);
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0000C930 File Offset: 0x0000AB30
		public global::Valve.VR.EVROverlayError GetOverlayTransformTrackedDeviceRelative(ulong ulOverlayHandle, ref uint punTrackedDevice, ref global::Valve.VR.HmdMatrix34_t pmatTrackedDeviceToOverlayTransform)
		{
			punTrackedDevice = 0U;
			return this.FnTable.GetOverlayTransformTrackedDeviceRelative(ulOverlayHandle, ref punTrackedDevice, ref pmatTrackedDeviceToOverlayTransform);
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000C95C File Offset: 0x0000AB5C
		public global::Valve.VR.EVROverlayError SetOverlayTransformTrackedDeviceComponent(ulong ulOverlayHandle, uint unDeviceIndex, string pchComponentName)
		{
			return this.FnTable.SetOverlayTransformTrackedDeviceComponent(ulOverlayHandle, unDeviceIndex, pchComponentName);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000C984 File Offset: 0x0000AB84
		public global::Valve.VR.EVROverlayError GetOverlayTransformTrackedDeviceComponent(ulong ulOverlayHandle, ref uint punDeviceIndex, string pchComponentName, uint unComponentNameSize)
		{
			punDeviceIndex = 0U;
			return this.FnTable.GetOverlayTransformTrackedDeviceComponent(ulOverlayHandle, ref punDeviceIndex, pchComponentName, unComponentNameSize);
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000C9B0 File Offset: 0x0000ABB0
		public global::Valve.VR.EVROverlayError ShowOverlay(ulong ulOverlayHandle)
		{
			return this.FnTable.ShowOverlay(ulOverlayHandle);
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0000C9D8 File Offset: 0x0000ABD8
		public global::Valve.VR.EVROverlayError HideOverlay(ulong ulOverlayHandle)
		{
			return this.FnTable.HideOverlay(ulOverlayHandle);
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0000CA00 File Offset: 0x0000AC00
		public bool IsOverlayVisible(ulong ulOverlayHandle)
		{
			return this.FnTable.IsOverlayVisible(ulOverlayHandle);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000CA28 File Offset: 0x0000AC28
		public global::Valve.VR.EVROverlayError GetTransformForOverlayCoordinates(ulong ulOverlayHandle, global::Valve.VR.ETrackingUniverseOrigin eTrackingOrigin, global::Valve.VR.HmdVector2_t coordinatesInOverlay, ref global::Valve.VR.HmdMatrix34_t pmatTransform)
		{
			return this.FnTable.GetTransformForOverlayCoordinates(ulOverlayHandle, eTrackingOrigin, coordinatesInOverlay, ref pmatTransform);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000CA54 File Offset: 0x0000AC54
		public bool PollNextOverlayEvent(ulong ulOverlayHandle, ref global::Valve.VR.VREvent_t pEvent, uint uncbVREvent)
		{
			return this.FnTable.PollNextOverlayEvent(ulOverlayHandle, ref pEvent, uncbVREvent);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0000CA7C File Offset: 0x0000AC7C
		public global::Valve.VR.EVROverlayError GetOverlayInputMethod(ulong ulOverlayHandle, ref global::Valve.VR.VROverlayInputMethod peInputMethod)
		{
			return this.FnTable.GetOverlayInputMethod(ulOverlayHandle, ref peInputMethod);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000CAA4 File Offset: 0x0000ACA4
		public global::Valve.VR.EVROverlayError SetOverlayInputMethod(ulong ulOverlayHandle, global::Valve.VR.VROverlayInputMethod eInputMethod)
		{
			return this.FnTable.SetOverlayInputMethod(ulOverlayHandle, eInputMethod);
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000CACC File Offset: 0x0000ACCC
		public global::Valve.VR.EVROverlayError GetOverlayMouseScale(ulong ulOverlayHandle, ref global::Valve.VR.HmdVector2_t pvecMouseScale)
		{
			return this.FnTable.GetOverlayMouseScale(ulOverlayHandle, ref pvecMouseScale);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0000CAF4 File Offset: 0x0000ACF4
		public global::Valve.VR.EVROverlayError SetOverlayMouseScale(ulong ulOverlayHandle, ref global::Valve.VR.HmdVector2_t pvecMouseScale)
		{
			return this.FnTable.SetOverlayMouseScale(ulOverlayHandle, ref pvecMouseScale);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0000CB1C File Offset: 0x0000AD1C
		public bool ComputeOverlayIntersection(ulong ulOverlayHandle, ref global::Valve.VR.VROverlayIntersectionParams_t pParams, ref global::Valve.VR.VROverlayIntersectionResults_t pResults)
		{
			return this.FnTable.ComputeOverlayIntersection(ulOverlayHandle, ref pParams, ref pResults);
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0000CB44 File Offset: 0x0000AD44
		public bool HandleControllerOverlayInteractionAsMouse(ulong ulOverlayHandle, uint unControllerDeviceIndex)
		{
			return this.FnTable.HandleControllerOverlayInteractionAsMouse(ulOverlayHandle, unControllerDeviceIndex);
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0000CB6C File Offset: 0x0000AD6C
		public bool IsHoverTargetOverlay(ulong ulOverlayHandle)
		{
			return this.FnTable.IsHoverTargetOverlay(ulOverlayHandle);
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x0000CB94 File Offset: 0x0000AD94
		public ulong GetGamepadFocusOverlay()
		{
			return this.FnTable.GetGamepadFocusOverlay();
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0000CBB8 File Offset: 0x0000ADB8
		public global::Valve.VR.EVROverlayError SetGamepadFocusOverlay(ulong ulNewFocusOverlay)
		{
			return this.FnTable.SetGamepadFocusOverlay(ulNewFocusOverlay);
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0000CBE0 File Offset: 0x0000ADE0
		public global::Valve.VR.EVROverlayError SetOverlayNeighbor(global::Valve.VR.EOverlayDirection eDirection, ulong ulFrom, ulong ulTo)
		{
			return this.FnTable.SetOverlayNeighbor(eDirection, ulFrom, ulTo);
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0000CC08 File Offset: 0x0000AE08
		public global::Valve.VR.EVROverlayError MoveGamepadFocusToNeighbor(global::Valve.VR.EOverlayDirection eDirection, ulong ulFrom)
		{
			return this.FnTable.MoveGamepadFocusToNeighbor(eDirection, ulFrom);
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0000CC30 File Offset: 0x0000AE30
		public global::Valve.VR.EVROverlayError SetOverlayTexture(ulong ulOverlayHandle, ref global::Valve.VR.Texture_t pTexture)
		{
			return this.FnTable.SetOverlayTexture(ulOverlayHandle, ref pTexture);
		}

		// Token: 0x060001BD RID: 445 RVA: 0x0000CC58 File Offset: 0x0000AE58
		public global::Valve.VR.EVROverlayError ClearOverlayTexture(ulong ulOverlayHandle)
		{
			return this.FnTable.ClearOverlayTexture(ulOverlayHandle);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000CC80 File Offset: 0x0000AE80
		public global::Valve.VR.EVROverlayError SetOverlayRaw(ulong ulOverlayHandle, global::System.IntPtr pvBuffer, uint unWidth, uint unHeight, uint unDepth)
		{
			return this.FnTable.SetOverlayRaw(ulOverlayHandle, pvBuffer, unWidth, unHeight, unDepth);
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000CCAC File Offset: 0x0000AEAC
		public global::Valve.VR.EVROverlayError SetOverlayFromFile(ulong ulOverlayHandle, string pchFilePath)
		{
			return this.FnTable.SetOverlayFromFile(ulOverlayHandle, pchFilePath);
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0000CCD4 File Offset: 0x0000AED4
		public global::Valve.VR.EVROverlayError GetOverlayTexture(ulong ulOverlayHandle, ref global::System.IntPtr pNativeTextureHandle, global::System.IntPtr pNativeTextureRef, ref uint pWidth, ref uint pHeight, ref uint pNativeFormat, ref global::Valve.VR.EGraphicsAPIConvention pAPI, ref global::Valve.VR.EColorSpace pColorSpace)
		{
			pWidth = 0U;
			pHeight = 0U;
			pNativeFormat = 0U;
			return this.FnTable.GetOverlayTexture(ulOverlayHandle, ref pNativeTextureHandle, pNativeTextureRef, ref pWidth, ref pHeight, ref pNativeFormat, ref pAPI, ref pColorSpace);
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0000CD14 File Offset: 0x0000AF14
		public global::Valve.VR.EVROverlayError ReleaseNativeOverlayHandle(ulong ulOverlayHandle, global::System.IntPtr pNativeTextureHandle)
		{
			return this.FnTable.ReleaseNativeOverlayHandle(ulOverlayHandle, pNativeTextureHandle);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000CD3C File Offset: 0x0000AF3C
		public global::Valve.VR.EVROverlayError CreateDashboardOverlay(string pchOverlayKey, string pchOverlayFriendlyName, ref ulong pMainHandle, ref ulong pThumbnailHandle)
		{
			pMainHandle = 0UL;
			pThumbnailHandle = 0UL;
			return this.FnTable.CreateDashboardOverlay(pchOverlayKey, pchOverlayFriendlyName, ref pMainHandle, ref pThumbnailHandle);
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x0000CD70 File Offset: 0x0000AF70
		public bool IsDashboardVisible()
		{
			return this.FnTable.IsDashboardVisible();
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000CD94 File Offset: 0x0000AF94
		public bool IsActiveDashboardOverlay(ulong ulOverlayHandle)
		{
			return this.FnTable.IsActiveDashboardOverlay(ulOverlayHandle);
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000CDBC File Offset: 0x0000AFBC
		public global::Valve.VR.EVROverlayError SetDashboardOverlaySceneProcess(ulong ulOverlayHandle, uint unProcessId)
		{
			return this.FnTable.SetDashboardOverlaySceneProcess(ulOverlayHandle, unProcessId);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0000CDE4 File Offset: 0x0000AFE4
		public global::Valve.VR.EVROverlayError GetDashboardOverlaySceneProcess(ulong ulOverlayHandle, ref uint punProcessId)
		{
			punProcessId = 0U;
			return this.FnTable.GetDashboardOverlaySceneProcess(ulOverlayHandle, ref punProcessId);
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000CE0D File Offset: 0x0000B00D
		public void ShowDashboard(string pchOverlayToShow)
		{
			this.FnTable.ShowDashboard(pchOverlayToShow);
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0000CE24 File Offset: 0x0000B024
		public uint GetPrimaryDashboardDevice()
		{
			return this.FnTable.GetPrimaryDashboardDevice();
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000CE48 File Offset: 0x0000B048
		public global::Valve.VR.EVROverlayError ShowKeyboard(int eInputMode, int eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText, bool bUseMinimalMode, ulong uUserValue)
		{
			return this.FnTable.ShowKeyboard(eInputMode, eLineInputMode, pchDescription, unCharMax, pchExistingText, bUseMinimalMode, uUserValue);
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000CE78 File Offset: 0x0000B078
		public global::Valve.VR.EVROverlayError ShowKeyboardForOverlay(ulong ulOverlayHandle, int eInputMode, int eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText, bool bUseMinimalMode, ulong uUserValue)
		{
			return this.FnTable.ShowKeyboardForOverlay(ulOverlayHandle, eInputMode, eLineInputMode, pchDescription, unCharMax, pchExistingText, bUseMinimalMode, uUserValue);
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0000CEAC File Offset: 0x0000B0AC
		public uint GetKeyboardText(global::System.Text.StringBuilder pchText, uint cchText)
		{
			return this.FnTable.GetKeyboardText(pchText, cchText);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000CED2 File Offset: 0x0000B0D2
		public void HideKeyboard()
		{
			this.FnTable.HideKeyboard();
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000CEE6 File Offset: 0x0000B0E6
		public void SetKeyboardTransformAbsolute(global::Valve.VR.ETrackingUniverseOrigin eTrackingOrigin, ref global::Valve.VR.HmdMatrix34_t pmatTrackingOriginToKeyboardTransform)
		{
			this.FnTable.SetKeyboardTransformAbsolute(eTrackingOrigin, ref pmatTrackingOriginToKeyboardTransform);
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000CEFC File Offset: 0x0000B0FC
		public void SetKeyboardPositionForOverlay(ulong ulOverlayHandle, global::Valve.VR.HmdRect2_t avoidRect)
		{
			this.FnTable.SetKeyboardPositionForOverlay(ulOverlayHandle, avoidRect);
		}

		// Token: 0x040001B3 RID: 435
		private global::Valve.VR.IVROverlay FnTable;
	}
}
