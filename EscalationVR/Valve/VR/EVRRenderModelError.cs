using System;

namespace Valve.VR
{
	// Token: 0x02000054 RID: 84
	public enum EVRRenderModelError
	{
		// Token: 0x04000389 RID: 905
		None,
		// Token: 0x0400038A RID: 906
		Loading = 100,
		// Token: 0x0400038B RID: 907
		NotSupported = 200,
		// Token: 0x0400038C RID: 908
		InvalidArg = 300,
		// Token: 0x0400038D RID: 909
		InvalidModel,
		// Token: 0x0400038E RID: 910
		NoShapes,
		// Token: 0x0400038F RID: 911
		MultipleShapes,
		// Token: 0x04000390 RID: 912
		TooManyIndices,
		// Token: 0x04000391 RID: 913
		MultipleTextures,
		// Token: 0x04000392 RID: 914
		InvalidTexture = 400
	}
}
