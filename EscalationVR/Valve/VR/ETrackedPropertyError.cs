using System;

namespace Valve.VR
{
	// Token: 0x02000038 RID: 56
	public enum ETrackedPropertyError
	{
		// Token: 0x0400022A RID: 554
		TrackedProp_Success,
		// Token: 0x0400022B RID: 555
		TrackedProp_WrongDataType,
		// Token: 0x0400022C RID: 556
		TrackedProp_WrongDeviceClass,
		// Token: 0x0400022D RID: 557
		TrackedProp_BufferTooSmall,
		// Token: 0x0400022E RID: 558
		TrackedProp_UnknownProperty,
		// Token: 0x0400022F RID: 559
		TrackedProp_InvalidDevice,
		// Token: 0x04000230 RID: 560
		TrackedProp_CouldNotContactServer,
		// Token: 0x04000231 RID: 561
		TrackedProp_ValueNotProvidedByDevice,
		// Token: 0x04000232 RID: 562
		TrackedProp_StringExceedsMaximumLength,
		// Token: 0x04000233 RID: 563
		TrackedProp_NotYetAvailable
	}
}
