using System;
using System.Linq;
using System.Xml.Serialization;
using VRGIN.Helpers;

namespace VRGIN.Core
{
	// Token: 0x020000B7 RID: 183
	public class XmlKeyStroke
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000400 RID: 1024 RVA: 0x00014447 File Offset: 0x00012647
		// (set) Token: 0x06000401 RID: 1025 RVA: 0x0001444F File Offset: 0x0001264F
		[global::System.Xml.Serialization.XmlAttribute("on")]
		public global::VRGIN.Helpers.KeyMode CheckMode { get; private set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x00014458 File Offset: 0x00012658
		// (set) Token: 0x06000403 RID: 1027 RVA: 0x00014460 File Offset: 0x00012660
		[global::System.Xml.Serialization.XmlText]
		public string Keys { get; private set; }

		// Token: 0x06000404 RID: 1028 RVA: 0x00014469 File Offset: 0x00012669
		public XmlKeyStroke()
		{
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00014473 File Offset: 0x00012673
		public XmlKeyStroke(string strokeString, global::VRGIN.Helpers.KeyMode mode = global::VRGIN.Helpers.KeyMode.PressUp)
		{
			this.CheckMode = mode;
			this.Keys = strokeString;
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00014490 File Offset: 0x00012690
		public global::VRGIN.Helpers.KeyStroke[] GetKeyStrokes()
		{
			return global::System.Linq.Enumerable.ToArray<global::VRGIN.Helpers.KeyStroke>(global::System.Linq.Enumerable.Select<string, global::VRGIN.Helpers.KeyStroke>(this.Keys.Split(new char[]
			{
				',',
				'|'
			}), (string part) => new global::VRGIN.Helpers.KeyStroke(part.Trim())));
		}
	}
}
