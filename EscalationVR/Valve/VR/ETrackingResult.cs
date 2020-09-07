using System;

namespace Valve.VR
{
	// Token: 0x02000033 RID: 51
	public enum ETrackingResult
	{
		// Token: 0x040001C2 RID: 450
		Uninitialized = 1,
		// Token: 0x040001C3 RID: 451
		Calibrating_InProgress = 100,
		// Token: 0x040001C4 RID: 452
		Calibrating_OutOfRange,
		// Token: 0x040001C5 RID: 453
		Running_OK = 200,
		// Token: 0x040001C6 RID: 454
		Running_OutOfRange
	}
}
