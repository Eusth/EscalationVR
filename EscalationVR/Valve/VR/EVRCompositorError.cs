using System;

namespace Valve.VR
{
	// Token: 0x0200004D RID: 77
	public enum EVRCompositorError
	{
		// Token: 0x0400035F RID: 863
		None,
		// Token: 0x04000360 RID: 864
		IncompatibleVersion = 100,
		// Token: 0x04000361 RID: 865
		DoNotHaveFocus,
		// Token: 0x04000362 RID: 866
		InvalidTexture,
		// Token: 0x04000363 RID: 867
		IsNotSceneApplication,
		// Token: 0x04000364 RID: 868
		TextureIsOnWrongDevice,
		// Token: 0x04000365 RID: 869
		TextureUsesUnsupportedFormat,
		// Token: 0x04000366 RID: 870
		SharedTexturesNotSupported,
		// Token: 0x04000367 RID: 871
		IndexOutOfRange
	}
}
