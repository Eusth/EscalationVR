using System;

namespace Valve.VR
{
	// Token: 0x02000049 RID: 73
	public enum EVRApplicationTransitionState
	{
		// Token: 0x0400034A RID: 842
		VRApplicationTransition_None,
		// Token: 0x0400034B RID: 843
		VRApplicationTransition_OldAppQuitSent = 10,
		// Token: 0x0400034C RID: 844
		VRApplicationTransition_WaitingForExternalLaunch,
		// Token: 0x0400034D RID: 845
		VRApplicationTransition_NewAppLaunched = 20
	}
}
