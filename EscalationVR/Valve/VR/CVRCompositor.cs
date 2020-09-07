using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x0200002A RID: 42
	public class CVRCompositor
	{
		// Token: 0x0600016D RID: 365 RVA: 0x0000C09A File Offset: 0x0000A29A
		internal CVRCompositor(global::System.IntPtr pInterface)
		{
			this.FnTable = (global::Valve.VR.IVRCompositor)global::System.Runtime.InteropServices.Marshal.PtrToStructure(pInterface, typeof(global::Valve.VR.IVRCompositor));
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000C0BF File Offset: 0x0000A2BF
		public void SetTrackingSpace(global::Valve.VR.ETrackingUniverseOrigin eOrigin)
		{
			this.FnTable.SetTrackingSpace(eOrigin);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000C0D4 File Offset: 0x0000A2D4
		public global::Valve.VR.ETrackingUniverseOrigin GetTrackingSpace()
		{
			return this.FnTable.GetTrackingSpace();
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000C0F8 File Offset: 0x0000A2F8
		public global::Valve.VR.EVRCompositorError WaitGetPoses(global::Valve.VR.TrackedDevicePose_t[] pRenderPoseArray, global::Valve.VR.TrackedDevicePose_t[] pGamePoseArray)
		{
			return this.FnTable.WaitGetPoses(pRenderPoseArray, (uint)pRenderPoseArray.Length, pGamePoseArray, (uint)pGamePoseArray.Length);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000C124 File Offset: 0x0000A324
		public global::Valve.VR.EVRCompositorError GetLastPoses(global::Valve.VR.TrackedDevicePose_t[] pRenderPoseArray, global::Valve.VR.TrackedDevicePose_t[] pGamePoseArray)
		{
			return this.FnTable.GetLastPoses(pRenderPoseArray, (uint)pRenderPoseArray.Length, pGamePoseArray, (uint)pGamePoseArray.Length);
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000C150 File Offset: 0x0000A350
		public global::Valve.VR.EVRCompositorError GetLastPoseForTrackedDeviceIndex(uint unDeviceIndex, ref global::Valve.VR.TrackedDevicePose_t pOutputPose, ref global::Valve.VR.TrackedDevicePose_t pOutputGamePose)
		{
			return this.FnTable.GetLastPoseForTrackedDeviceIndex(unDeviceIndex, ref pOutputPose, ref pOutputGamePose);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000C178 File Offset: 0x0000A378
		public global::Valve.VR.EVRCompositorError Submit(global::Valve.VR.EVREye eEye, ref global::Valve.VR.Texture_t pTexture, ref global::Valve.VR.VRTextureBounds_t pBounds, global::Valve.VR.EVRSubmitFlags nSubmitFlags)
		{
			return this.FnTable.Submit(eEye, ref pTexture, ref pBounds, nSubmitFlags);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000C1A1 File Offset: 0x0000A3A1
		public void ClearLastSubmittedFrame()
		{
			this.FnTable.ClearLastSubmittedFrame();
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000C1B5 File Offset: 0x0000A3B5
		public void PostPresentHandoff()
		{
			this.FnTable.PostPresentHandoff();
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000C1CC File Offset: 0x0000A3CC
		public bool GetFrameTiming(ref global::Valve.VR.Compositor_FrameTiming pTiming, uint unFramesAgo)
		{
			return this.FnTable.GetFrameTiming(ref pTiming, unFramesAgo);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000C1F4 File Offset: 0x0000A3F4
		public float GetFrameTimeRemaining()
		{
			return this.FnTable.GetFrameTimeRemaining();
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000C218 File Offset: 0x0000A418
		public void FadeToColor(float fSeconds, float fRed, float fGreen, float fBlue, float fAlpha, bool bBackground)
		{
			this.FnTable.FadeToColor(fSeconds, fRed, fGreen, fBlue, fAlpha, bBackground);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000C235 File Offset: 0x0000A435
		public void FadeGrid(float fSeconds, bool bFadeIn)
		{
			this.FnTable.FadeGrid(fSeconds, bFadeIn);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000C24C File Offset: 0x0000A44C
		public global::Valve.VR.EVRCompositorError SetSkyboxOverride(global::Valve.VR.Texture_t[] pTextures)
		{
			return this.FnTable.SetSkyboxOverride(pTextures, (uint)pTextures.Length);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000C274 File Offset: 0x0000A474
		public void ClearSkyboxOverride()
		{
			this.FnTable.ClearSkyboxOverride();
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000C288 File Offset: 0x0000A488
		public void CompositorBringToFront()
		{
			this.FnTable.CompositorBringToFront();
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000C29C File Offset: 0x0000A49C
		public void CompositorGoToBack()
		{
			this.FnTable.CompositorGoToBack();
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000C2B0 File Offset: 0x0000A4B0
		public void CompositorQuit()
		{
			this.FnTable.CompositorQuit();
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000C2C4 File Offset: 0x0000A4C4
		public bool IsFullscreen()
		{
			return this.FnTable.IsFullscreen();
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000C2E8 File Offset: 0x0000A4E8
		public uint GetCurrentSceneFocusProcess()
		{
			return this.FnTable.GetCurrentSceneFocusProcess();
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000C30C File Offset: 0x0000A50C
		public uint GetLastFrameRenderer()
		{
			return this.FnTable.GetLastFrameRenderer();
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000C330 File Offset: 0x0000A530
		public bool CanRenderScene()
		{
			return this.FnTable.CanRenderScene();
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000C354 File Offset: 0x0000A554
		public void ShowMirrorWindow()
		{
			this.FnTable.ShowMirrorWindow();
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000C368 File Offset: 0x0000A568
		public void HideMirrorWindow()
		{
			this.FnTable.HideMirrorWindow();
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000C37C File Offset: 0x0000A57C
		public bool IsMirrorWindowVisible()
		{
			return this.FnTable.IsMirrorWindowVisible();
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000C3A0 File Offset: 0x0000A5A0
		public void CompositorDumpImages()
		{
			this.FnTable.CompositorDumpImages();
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000C3B4 File Offset: 0x0000A5B4
		public bool ShouldAppRenderWithLowResources()
		{
			return this.FnTable.ShouldAppRenderWithLowResources();
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000C3D8 File Offset: 0x0000A5D8
		public void ForceInterleavedReprojectionOn(bool bOverride)
		{
			this.FnTable.ForceInterleavedReprojectionOn(bOverride);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000C3ED File Offset: 0x0000A5ED
		public void ForceReconnectProcess()
		{
			this.FnTable.ForceReconnectProcess();
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000C401 File Offset: 0x0000A601
		public void SuspendRendering(bool bSuspend)
		{
			this.FnTable.SuspendRendering(bSuspend);
		}

		// Token: 0x040001B2 RID: 434
		private global::Valve.VR.IVRCompositor FnTable;
	}
}
