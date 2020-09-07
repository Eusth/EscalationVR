using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace EscalationVR
{
	// Token: 0x020000F1 RID: 241
	[global::System.CodeDom.Compiler.GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[global::System.Diagnostics.DebuggerNonUserCode]
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	internal class Resource
	{
		// Token: 0x06000626 RID: 1574 RVA: 0x0001D8C6 File Offset: 0x0001BAC6
		internal Resource()
		{
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000627 RID: 1575 RVA: 0x0001D8D0 File Offset: 0x0001BAD0
		[global::System.ComponentModel.EditorBrowsable(2)]
		internal static global::System.Resources.ResourceManager ResourceManager
		{
			get
			{
				bool flag = global::EscalationVR.Resource.resourceMan == null;
				if (flag)
				{
					global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager("EscalationVR.Resource", typeof(global::EscalationVR.Resource).Assembly);
					global::EscalationVR.Resource.resourceMan = resourceManager;
				}
				return global::EscalationVR.Resource.resourceMan;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000628 RID: 1576 RVA: 0x0001D918 File Offset: 0x0001BB18
		// (set) Token: 0x06000629 RID: 1577 RVA: 0x0001D92F File Offset: 0x0001BB2F
		[global::System.ComponentModel.EditorBrowsable(2)]
		internal static global::System.Globalization.CultureInfo Culture
		{
			get
			{
				return global::EscalationVR.Resource.resourceCulture;
			}
			set
			{
				global::EscalationVR.Resource.resourceCulture = value;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x0600062A RID: 1578 RVA: 0x0001D938 File Offset: 0x0001BB38
		internal static byte[] vrgin_2019_2
		{
			get
			{
				object @object = global::EscalationVR.Resource.ResourceManager.GetObject("vrgin_2019_2", global::EscalationVR.Resource.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x0400069B RID: 1691
		private static global::System.Resources.ResourceManager resourceMan;

		// Token: 0x0400069C RID: 1692
		private static global::System.Globalization.CultureInfo resourceCulture;
	}
}
