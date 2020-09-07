using System;

namespace Valve.VR
{
	// Token: 0x02000042 RID: 66
	public enum EVROverlayError
	{
		// Token: 0x040002C5 RID: 709
		None,
		// Token: 0x040002C6 RID: 710
		UnknownOverlay = 10,
		// Token: 0x040002C7 RID: 711
		InvalidHandle,
		// Token: 0x040002C8 RID: 712
		PermissionDenied,
		// Token: 0x040002C9 RID: 713
		OverlayLimitExceeded,
		// Token: 0x040002CA RID: 714
		WrongVisibilityType,
		// Token: 0x040002CB RID: 715
		KeyTooLong,
		// Token: 0x040002CC RID: 716
		NameTooLong,
		// Token: 0x040002CD RID: 717
		KeyInUse,
		// Token: 0x040002CE RID: 718
		WrongTransformType,
		// Token: 0x040002CF RID: 719
		InvalidTrackedDevice,
		// Token: 0x040002D0 RID: 720
		InvalidParameter,
		// Token: 0x040002D1 RID: 721
		ThumbnailCantBeDestroyed,
		// Token: 0x040002D2 RID: 722
		ArrayTooSmall,
		// Token: 0x040002D3 RID: 723
		RequestFailed,
		// Token: 0x040002D4 RID: 724
		InvalidTexture,
		// Token: 0x040002D5 RID: 725
		UnableToLoadFile,
		// Token: 0x040002D6 RID: 726
		VROVerlayError_KeyboardAlreadyInUse,
		// Token: 0x040002D7 RID: 727
		NoNeighbor
	}
}
