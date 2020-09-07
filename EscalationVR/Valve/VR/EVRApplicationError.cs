using System;

namespace Valve.VR
{
	// Token: 0x02000047 RID: 71
	public enum EVRApplicationError
	{
		// Token: 0x04000326 RID: 806
		None,
		// Token: 0x04000327 RID: 807
		AppKeyAlreadyExists = 100,
		// Token: 0x04000328 RID: 808
		NoManifest,
		// Token: 0x04000329 RID: 809
		NoApplication,
		// Token: 0x0400032A RID: 810
		InvalidIndex,
		// Token: 0x0400032B RID: 811
		UnknownApplication,
		// Token: 0x0400032C RID: 812
		IPCFailed,
		// Token: 0x0400032D RID: 813
		ApplicationAlreadyRunning,
		// Token: 0x0400032E RID: 814
		InvalidManifest,
		// Token: 0x0400032F RID: 815
		InvalidApplication,
		// Token: 0x04000330 RID: 816
		LaunchFailed,
		// Token: 0x04000331 RID: 817
		ApplicationAlreadyStarting,
		// Token: 0x04000332 RID: 818
		LaunchInProgress,
		// Token: 0x04000333 RID: 819
		OldApplicationQuitting,
		// Token: 0x04000334 RID: 820
		TransitionAborted,
		// Token: 0x04000335 RID: 821
		IsTemplate,
		// Token: 0x04000336 RID: 822
		BufferTooSmall = 200,
		// Token: 0x04000337 RID: 823
		PropertyNotSet,
		// Token: 0x04000338 RID: 824
		UnknownProperty,
		// Token: 0x04000339 RID: 825
		InvalidParameter
	}
}
