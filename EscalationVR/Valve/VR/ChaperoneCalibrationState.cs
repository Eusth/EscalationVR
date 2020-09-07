using System;

namespace Valve.VR
{
	// Token: 0x0200004A RID: 74
	public enum ChaperoneCalibrationState
	{
		// Token: 0x0400034F RID: 847
		OK = 1,
		// Token: 0x04000350 RID: 848
		Warning = 100,
		// Token: 0x04000351 RID: 849
		Warning_BaseStationMayHaveMoved,
		// Token: 0x04000352 RID: 850
		Warning_BaseStationRemoved,
		// Token: 0x04000353 RID: 851
		Warning_SeatedBoundsInvalid,
		// Token: 0x04000354 RID: 852
		Error = 200,
		// Token: 0x04000355 RID: 853
		Error_BaseStationUninitalized,
		// Token: 0x04000356 RID: 854
		Error_BaseStationConflict,
		// Token: 0x04000357 RID: 855
		Error_PlayAreaInvalid,
		// Token: 0x04000358 RID: 856
		Error_CollisionBoundsInvalid
	}
}
