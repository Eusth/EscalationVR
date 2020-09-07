using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x02000020 RID: 32
	public struct IVRCompositor
	{
		// Token: 0x04000130 RID: 304
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._SetTrackingSpace SetTrackingSpace;

		// Token: 0x04000131 RID: 305
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._GetTrackingSpace GetTrackingSpace;

		// Token: 0x04000132 RID: 306
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._WaitGetPoses WaitGetPoses;

		// Token: 0x04000133 RID: 307
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._GetLastPoses GetLastPoses;

		// Token: 0x04000134 RID: 308
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._GetLastPoseForTrackedDeviceIndex GetLastPoseForTrackedDeviceIndex;

		// Token: 0x04000135 RID: 309
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._Submit Submit;

		// Token: 0x04000136 RID: 310
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._ClearLastSubmittedFrame ClearLastSubmittedFrame;

		// Token: 0x04000137 RID: 311
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._PostPresentHandoff PostPresentHandoff;

		// Token: 0x04000138 RID: 312
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._GetFrameTiming GetFrameTiming;

		// Token: 0x04000139 RID: 313
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._GetFrameTimeRemaining GetFrameTimeRemaining;

		// Token: 0x0400013A RID: 314
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._FadeToColor FadeToColor;

		// Token: 0x0400013B RID: 315
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._FadeGrid FadeGrid;

		// Token: 0x0400013C RID: 316
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._SetSkyboxOverride SetSkyboxOverride;

		// Token: 0x0400013D RID: 317
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._ClearSkyboxOverride ClearSkyboxOverride;

		// Token: 0x0400013E RID: 318
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._CompositorBringToFront CompositorBringToFront;

		// Token: 0x0400013F RID: 319
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._CompositorGoToBack CompositorGoToBack;

		// Token: 0x04000140 RID: 320
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._CompositorQuit CompositorQuit;

		// Token: 0x04000141 RID: 321
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._IsFullscreen IsFullscreen;

		// Token: 0x04000142 RID: 322
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._GetCurrentSceneFocusProcess GetCurrentSceneFocusProcess;

		// Token: 0x04000143 RID: 323
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._GetLastFrameRenderer GetLastFrameRenderer;

		// Token: 0x04000144 RID: 324
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._CanRenderScene CanRenderScene;

		// Token: 0x04000145 RID: 325
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._ShowMirrorWindow ShowMirrorWindow;

		// Token: 0x04000146 RID: 326
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._HideMirrorWindow HideMirrorWindow;

		// Token: 0x04000147 RID: 327
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._IsMirrorWindowVisible IsMirrorWindowVisible;

		// Token: 0x04000148 RID: 328
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._CompositorDumpImages CompositorDumpImages;

		// Token: 0x04000149 RID: 329
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._ShouldAppRenderWithLowResources ShouldAppRenderWithLowResources;

		// Token: 0x0400014A RID: 330
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._ForceInterleavedReprojectionOn ForceInterleavedReprojectionOn;

		// Token: 0x0400014B RID: 331
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._ForceReconnectProcess ForceReconnectProcess;

		// Token: 0x0400014C RID: 332
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRCompositor._SuspendRendering SuspendRendering;

		// Token: 0x0200016C RID: 364
		// (Invoke) Token: 0x06000833 RID: 2099
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _SetTrackingSpace(global::Valve.VR.ETrackingUniverseOrigin eOrigin);

		// Token: 0x0200016D RID: 365
		// (Invoke) Token: 0x06000837 RID: 2103
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.ETrackingUniverseOrigin _GetTrackingSpace();

		// Token: 0x0200016E RID: 366
		// (Invoke) Token: 0x0600083B RID: 2107
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRCompositorError _WaitGetPoses([global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.Out] global::Valve.VR.TrackedDevicePose_t[] pRenderPoseArray, uint unRenderPoseArrayCount, [global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.Out] global::Valve.VR.TrackedDevicePose_t[] pGamePoseArray, uint unGamePoseArrayCount);

		// Token: 0x0200016F RID: 367
		// (Invoke) Token: 0x0600083F RID: 2111
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRCompositorError _GetLastPoses([global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.Out] global::Valve.VR.TrackedDevicePose_t[] pRenderPoseArray, uint unRenderPoseArrayCount, [global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.Out] global::Valve.VR.TrackedDevicePose_t[] pGamePoseArray, uint unGamePoseArrayCount);

		// Token: 0x02000170 RID: 368
		// (Invoke) Token: 0x06000843 RID: 2115
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRCompositorError _GetLastPoseForTrackedDeviceIndex(uint unDeviceIndex, ref global::Valve.VR.TrackedDevicePose_t pOutputPose, ref global::Valve.VR.TrackedDevicePose_t pOutputGamePose);

		// Token: 0x02000171 RID: 369
		// (Invoke) Token: 0x06000847 RID: 2119
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRCompositorError _Submit(global::Valve.VR.EVREye eEye, ref global::Valve.VR.Texture_t pTexture, ref global::Valve.VR.VRTextureBounds_t pBounds, global::Valve.VR.EVRSubmitFlags nSubmitFlags);

		// Token: 0x02000172 RID: 370
		// (Invoke) Token: 0x0600084B RID: 2123
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _ClearLastSubmittedFrame();

		// Token: 0x02000173 RID: 371
		// (Invoke) Token: 0x0600084F RID: 2127
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _PostPresentHandoff();

		// Token: 0x02000174 RID: 372
		// (Invoke) Token: 0x06000853 RID: 2131
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetFrameTiming(ref global::Valve.VR.Compositor_FrameTiming pTiming, uint unFramesAgo);

		// Token: 0x02000175 RID: 373
		// (Invoke) Token: 0x06000857 RID: 2135
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate float _GetFrameTimeRemaining();

		// Token: 0x02000176 RID: 374
		// (Invoke) Token: 0x0600085B RID: 2139
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _FadeToColor(float fSeconds, float fRed, float fGreen, float fBlue, float fAlpha, bool bBackground);

		// Token: 0x02000177 RID: 375
		// (Invoke) Token: 0x0600085F RID: 2143
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _FadeGrid(float fSeconds, bool bFadeIn);

		// Token: 0x02000178 RID: 376
		// (Invoke) Token: 0x06000863 RID: 2147
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRCompositorError _SetSkyboxOverride([global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.Out] global::Valve.VR.Texture_t[] pTextures, uint unTextureCount);

		// Token: 0x02000179 RID: 377
		// (Invoke) Token: 0x06000867 RID: 2151
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _ClearSkyboxOverride();

		// Token: 0x0200017A RID: 378
		// (Invoke) Token: 0x0600086B RID: 2155
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _CompositorBringToFront();

		// Token: 0x0200017B RID: 379
		// (Invoke) Token: 0x0600086F RID: 2159
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _CompositorGoToBack();

		// Token: 0x0200017C RID: 380
		// (Invoke) Token: 0x06000873 RID: 2163
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _CompositorQuit();

		// Token: 0x0200017D RID: 381
		// (Invoke) Token: 0x06000877 RID: 2167
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _IsFullscreen();

		// Token: 0x0200017E RID: 382
		// (Invoke) Token: 0x0600087B RID: 2171
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetCurrentSceneFocusProcess();

		// Token: 0x0200017F RID: 383
		// (Invoke) Token: 0x0600087F RID: 2175
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetLastFrameRenderer();

		// Token: 0x02000180 RID: 384
		// (Invoke) Token: 0x06000883 RID: 2179
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _CanRenderScene();

		// Token: 0x02000181 RID: 385
		// (Invoke) Token: 0x06000887 RID: 2183
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _ShowMirrorWindow();

		// Token: 0x02000182 RID: 386
		// (Invoke) Token: 0x0600088B RID: 2187
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _HideMirrorWindow();

		// Token: 0x02000183 RID: 387
		// (Invoke) Token: 0x0600088F RID: 2191
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _IsMirrorWindowVisible();

		// Token: 0x02000184 RID: 388
		// (Invoke) Token: 0x06000893 RID: 2195
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _CompositorDumpImages();

		// Token: 0x02000185 RID: 389
		// (Invoke) Token: 0x06000897 RID: 2199
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _ShouldAppRenderWithLowResources();

		// Token: 0x02000186 RID: 390
		// (Invoke) Token: 0x0600089B RID: 2203
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _ForceInterleavedReprojectionOn(bool bOverride);

		// Token: 0x02000187 RID: 391
		// (Invoke) Token: 0x0600089F RID: 2207
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _ForceReconnectProcess();

		// Token: 0x02000188 RID: 392
		// (Invoke) Token: 0x060008A3 RID: 2211
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _SuspendRendering(bool bSuspend);
	}
}
