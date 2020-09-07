using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x0200001E RID: 30
	public struct IVRChaperone
	{
		// Token: 0x04000114 RID: 276
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperone._GetCalibrationState GetCalibrationState;

		// Token: 0x04000115 RID: 277
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperone._GetPlayAreaSize GetPlayAreaSize;

		// Token: 0x04000116 RID: 278
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperone._GetPlayAreaRect GetPlayAreaRect;

		// Token: 0x04000117 RID: 279
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperone._ReloadInfo ReloadInfo;

		// Token: 0x04000118 RID: 280
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperone._SetSceneColor SetSceneColor;

		// Token: 0x04000119 RID: 281
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperone._GetBoundsColor GetBoundsColor;

		// Token: 0x0400011A RID: 282
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperone._AreBoundsVisible AreBoundsVisible;

		// Token: 0x0400011B RID: 283
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperone._ForceBoundsVisible ForceBoundsVisible;

		// Token: 0x02000150 RID: 336
		// (Invoke) Token: 0x060007C3 RID: 1987
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.ChaperoneCalibrationState _GetCalibrationState();

		// Token: 0x02000151 RID: 337
		// (Invoke) Token: 0x060007C7 RID: 1991
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetPlayAreaSize(ref float pSizeX, ref float pSizeZ);

		// Token: 0x02000152 RID: 338
		// (Invoke) Token: 0x060007CB RID: 1995
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetPlayAreaRect(ref global::Valve.VR.HmdQuad_t rect);

		// Token: 0x02000153 RID: 339
		// (Invoke) Token: 0x060007CF RID: 1999
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _ReloadInfo();

		// Token: 0x02000154 RID: 340
		// (Invoke) Token: 0x060007D3 RID: 2003
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _SetSceneColor(global::Valve.VR.HmdColor_t color);

		// Token: 0x02000155 RID: 341
		// (Invoke) Token: 0x060007D7 RID: 2007
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _GetBoundsColor(ref global::Valve.VR.HmdColor_t pOutputColorArray, int nNumOutputColors, float flCollisionBoundsFadeDistance, ref global::Valve.VR.HmdColor_t pOutputCameraColor);

		// Token: 0x02000156 RID: 342
		// (Invoke) Token: 0x060007DB RID: 2011
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _AreBoundsVisible();

		// Token: 0x02000157 RID: 343
		// (Invoke) Token: 0x060007DF RID: 2015
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _ForceBoundsVisible(bool bForce);
	}
}
