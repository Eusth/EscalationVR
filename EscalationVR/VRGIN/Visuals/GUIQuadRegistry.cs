using System;
using System.Collections.Generic;

namespace VRGIN.Visuals
{
	// Token: 0x0200008A RID: 138
	public static class GUIQuadRegistry
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600022E RID: 558 RVA: 0x0000DF5C File Offset: 0x0000C15C
		public static global::System.Collections.Generic.IEnumerable<global::VRGIN.Visuals.GUIQuad> Quads
		{
			get
			{
				return global::VRGIN.Visuals.GUIQuadRegistry._Quads;
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000DF73 File Offset: 0x0000C173
		internal static void Register(global::VRGIN.Visuals.GUIQuad quad)
		{
			global::VRGIN.Visuals.GUIQuadRegistry._Quads.Add(quad);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000DF82 File Offset: 0x0000C182
		internal static void Unregister(global::VRGIN.Visuals.GUIQuad quad)
		{
			global::VRGIN.Visuals.GUIQuadRegistry._Quads.Remove(quad);
		}

		// Token: 0x04000512 RID: 1298
		private static global::System.Collections.Generic.HashSet<global::VRGIN.Visuals.GUIQuad> _Quads = new global::System.Collections.Generic.HashSet<global::VRGIN.Visuals.GUIQuad>();
	}
}
