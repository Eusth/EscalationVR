using System;

namespace Valve.VR
{
	// Token: 0x0200007C RID: 124
	public struct Compositor_FrameTiming
	{
		// Token: 0x04000442 RID: 1090
		public uint m_nSize;

		// Token: 0x04000443 RID: 1091
		public uint m_nFrameIndex;

		// Token: 0x04000444 RID: 1092
		public uint m_nNumFramePresents;

		// Token: 0x04000445 RID: 1093
		public uint m_nNumDroppedFrames;

		// Token: 0x04000446 RID: 1094
		public double m_flSystemTimeInSeconds;

		// Token: 0x04000447 RID: 1095
		public float m_flSceneRenderGpuMs;

		// Token: 0x04000448 RID: 1096
		public float m_flTotalRenderGpuMs;

		// Token: 0x04000449 RID: 1097
		public float m_flCompositorRenderGpuMs;

		// Token: 0x0400044A RID: 1098
		public float m_flCompositorRenderCpuMs;

		// Token: 0x0400044B RID: 1099
		public float m_flCompositorIdleCpuMs;

		// Token: 0x0400044C RID: 1100
		public float m_flClientFrameIntervalMs;

		// Token: 0x0400044D RID: 1101
		public float m_flPresentCallCpuMs;

		// Token: 0x0400044E RID: 1102
		public float m_flWaitForPresentCpuMs;

		// Token: 0x0400044F RID: 1103
		public float m_flSubmitFrameMs;

		// Token: 0x04000450 RID: 1104
		public float m_flWaitGetPosesCalledMs;

		// Token: 0x04000451 RID: 1105
		public float m_flNewPosesReadyMs;

		// Token: 0x04000452 RID: 1106
		public float m_flNewFrameReadyMs;

		// Token: 0x04000453 RID: 1107
		public float m_flCompositorUpdateStartMs;

		// Token: 0x04000454 RID: 1108
		public float m_flCompositorUpdateEndMs;

		// Token: 0x04000455 RID: 1109
		public float m_flCompositorRenderStartMs;

		// Token: 0x04000456 RID: 1110
		public global::Valve.VR.TrackedDevicePose_t m_HmdPose;

		// Token: 0x04000457 RID: 1111
		public int m_nFidelityLevel;

		// Token: 0x04000458 RID: 1112
		public uint m_nReprojectionFlags;
	}
}
