using System;
using UnityEngine;

namespace VRGIN.Core
{
	// Token: 0x0200009F RID: 159
	public interface IActor
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060002EE RID: 750
		bool IsValid { get; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060002EF RID: 751
		global::UnityEngine.Pose Eyes { get; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060002F0 RID: 752
		// (set) Token: 0x060002F1 RID: 753
		bool HasHead { get; set; }
	}
}
