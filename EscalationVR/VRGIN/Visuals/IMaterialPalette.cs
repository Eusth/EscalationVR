using System;
using UnityEngine;

namespace VRGIN.Visuals
{
	// Token: 0x0200008C RID: 140
	public interface IMaterialPalette
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600023B RID: 571
		global::UnityEngine.Material Sprite { get; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600023C RID: 572
		global::UnityEngine.Material Unlit { get; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600023D RID: 573
		global::UnityEngine.Material UnlitTransparent { get; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600023E RID: 574
		global::UnityEngine.Material UnlitTransparentCombined { get; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600023F RID: 575
		global::UnityEngine.Shader StandardShader { get; }
	}
}
