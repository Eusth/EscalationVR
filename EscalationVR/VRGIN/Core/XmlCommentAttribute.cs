using System;

namespace VRGIN.Core
{
	// Token: 0x020000B8 RID: 184
	[global::System.AttributeUsage(128, AllowMultiple = false)]
	public class XmlCommentAttribute : global::System.Attribute
	{
		// Token: 0x06000407 RID: 1031 RVA: 0x000144E6 File Offset: 0x000126E6
		public XmlCommentAttribute(string value)
		{
			this.Value = value;
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x000144F8 File Offset: 0x000126F8
		// (set) Token: 0x06000409 RID: 1033 RVA: 0x00014500 File Offset: 0x00012700
		public string Value { get; set; }
	}
}
