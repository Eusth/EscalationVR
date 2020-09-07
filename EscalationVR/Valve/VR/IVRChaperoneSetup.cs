using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Valve.VR
{
	// Token: 0x0200001F RID: 31
	public struct IVRChaperoneSetup
	{
		// Token: 0x0400011C RID: 284
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._CommitWorkingCopy CommitWorkingCopy;

		// Token: 0x0400011D RID: 285
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._RevertWorkingCopy RevertWorkingCopy;

		// Token: 0x0400011E RID: 286
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._GetWorkingPlayAreaSize GetWorkingPlayAreaSize;

		// Token: 0x0400011F RID: 287
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._GetWorkingPlayAreaRect GetWorkingPlayAreaRect;

		// Token: 0x04000120 RID: 288
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._GetWorkingCollisionBoundsInfo GetWorkingCollisionBoundsInfo;

		// Token: 0x04000121 RID: 289
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._GetLiveCollisionBoundsInfo GetLiveCollisionBoundsInfo;

		// Token: 0x04000122 RID: 290
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._GetWorkingSeatedZeroPoseToRawTrackingPose GetWorkingSeatedZeroPoseToRawTrackingPose;

		// Token: 0x04000123 RID: 291
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._GetWorkingStandingZeroPoseToRawTrackingPose GetWorkingStandingZeroPoseToRawTrackingPose;

		// Token: 0x04000124 RID: 292
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._SetWorkingPlayAreaSize SetWorkingPlayAreaSize;

		// Token: 0x04000125 RID: 293
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._SetWorkingCollisionBoundsInfo SetWorkingCollisionBoundsInfo;

		// Token: 0x04000126 RID: 294
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._SetWorkingSeatedZeroPoseToRawTrackingPose SetWorkingSeatedZeroPoseToRawTrackingPose;

		// Token: 0x04000127 RID: 295
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._SetWorkingStandingZeroPoseToRawTrackingPose SetWorkingStandingZeroPoseToRawTrackingPose;

		// Token: 0x04000128 RID: 296
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._ReloadFromDisk ReloadFromDisk;

		// Token: 0x04000129 RID: 297
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._GetLiveSeatedZeroPoseToRawTrackingPose GetLiveSeatedZeroPoseToRawTrackingPose;

		// Token: 0x0400012A RID: 298
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._SetWorkingCollisionBoundsTagsInfo SetWorkingCollisionBoundsTagsInfo;

		// Token: 0x0400012B RID: 299
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._GetLiveCollisionBoundsTagsInfo GetLiveCollisionBoundsTagsInfo;

		// Token: 0x0400012C RID: 300
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._SetWorkingPhysicalBoundsInfo SetWorkingPhysicalBoundsInfo;

		// Token: 0x0400012D RID: 301
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._GetLivePhysicalBoundsInfo GetLivePhysicalBoundsInfo;

		// Token: 0x0400012E RID: 302
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._ExportLiveToBuffer ExportLiveToBuffer;

		// Token: 0x0400012F RID: 303
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRChaperoneSetup._ImportFromBufferToWorking ImportFromBufferToWorking;

		// Token: 0x02000158 RID: 344
		// (Invoke) Token: 0x060007E3 RID: 2019
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _CommitWorkingCopy(global::Valve.VR.EChaperoneConfigFile configFile);

		// Token: 0x02000159 RID: 345
		// (Invoke) Token: 0x060007E7 RID: 2023
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _RevertWorkingCopy();

		// Token: 0x0200015A RID: 346
		// (Invoke) Token: 0x060007EB RID: 2027
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetWorkingPlayAreaSize(ref float pSizeX, ref float pSizeZ);

		// Token: 0x0200015B RID: 347
		// (Invoke) Token: 0x060007EF RID: 2031
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetWorkingPlayAreaRect(ref global::Valve.VR.HmdQuad_t rect);

		// Token: 0x0200015C RID: 348
		// (Invoke) Token: 0x060007F3 RID: 2035
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetWorkingCollisionBoundsInfo([global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.Out] global::Valve.VR.HmdQuad_t[] pQuadsBuffer, ref uint punQuadsCount);

		// Token: 0x0200015D RID: 349
		// (Invoke) Token: 0x060007F7 RID: 2039
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetLiveCollisionBoundsInfo([global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.Out] global::Valve.VR.HmdQuad_t[] pQuadsBuffer, ref uint punQuadsCount);

		// Token: 0x0200015E RID: 350
		// (Invoke) Token: 0x060007FB RID: 2043
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetWorkingSeatedZeroPoseToRawTrackingPose(ref global::Valve.VR.HmdMatrix34_t pmatSeatedZeroPoseToRawTrackingPose);

		// Token: 0x0200015F RID: 351
		// (Invoke) Token: 0x060007FF RID: 2047
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetWorkingStandingZeroPoseToRawTrackingPose(ref global::Valve.VR.HmdMatrix34_t pmatStandingZeroPoseToRawTrackingPose);

		// Token: 0x02000160 RID: 352
		// (Invoke) Token: 0x06000803 RID: 2051
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _SetWorkingPlayAreaSize(float sizeX, float sizeZ);

		// Token: 0x02000161 RID: 353
		// (Invoke) Token: 0x06000807 RID: 2055
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _SetWorkingCollisionBoundsInfo([global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.Out] global::Valve.VR.HmdQuad_t[] pQuadsBuffer, uint unQuadsCount);

		// Token: 0x02000162 RID: 354
		// (Invoke) Token: 0x0600080B RID: 2059
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _SetWorkingSeatedZeroPoseToRawTrackingPose(ref global::Valve.VR.HmdMatrix34_t pMatSeatedZeroPoseToRawTrackingPose);

		// Token: 0x02000163 RID: 355
		// (Invoke) Token: 0x0600080F RID: 2063
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _SetWorkingStandingZeroPoseToRawTrackingPose(ref global::Valve.VR.HmdMatrix34_t pMatStandingZeroPoseToRawTrackingPose);

		// Token: 0x02000164 RID: 356
		// (Invoke) Token: 0x06000813 RID: 2067
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _ReloadFromDisk(global::Valve.VR.EChaperoneConfigFile configFile);

		// Token: 0x02000165 RID: 357
		// (Invoke) Token: 0x06000817 RID: 2071
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetLiveSeatedZeroPoseToRawTrackingPose(ref global::Valve.VR.HmdMatrix34_t pmatSeatedZeroPoseToRawTrackingPose);

		// Token: 0x02000166 RID: 358
		// (Invoke) Token: 0x0600081B RID: 2075
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _SetWorkingCollisionBoundsTagsInfo([global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.Out] byte[] pTagsBuffer, uint unTagCount);

		// Token: 0x02000167 RID: 359
		// (Invoke) Token: 0x0600081F RID: 2079
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetLiveCollisionBoundsTagsInfo([global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.Out] byte[] pTagsBuffer, ref uint punTagCount);

		// Token: 0x02000168 RID: 360
		// (Invoke) Token: 0x06000823 RID: 2083
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _SetWorkingPhysicalBoundsInfo([global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.Out] global::Valve.VR.HmdQuad_t[] pQuadsBuffer, uint unQuadsCount);

		// Token: 0x02000169 RID: 361
		// (Invoke) Token: 0x06000827 RID: 2087
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetLivePhysicalBoundsInfo([global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.Out] global::Valve.VR.HmdQuad_t[] pQuadsBuffer, ref uint punQuadsCount);

		// Token: 0x0200016A RID: 362
		// (Invoke) Token: 0x0600082B RID: 2091
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _ExportLiveToBuffer(global::System.Text.StringBuilder pBuffer, ref uint pnBufferLength);

		// Token: 0x0200016B RID: 363
		// (Invoke) Token: 0x0600082F RID: 2095
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _ImportFromBufferToWorking(string pBuffer, uint nImportFlags);
	}
}
