using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace VRGIN.Helpers
{
	// Token: 0x020000CD RID: 205
	public class JSONArray : global::VRGIN.Helpers.JSONNode, global::System.Collections.IEnumerable
	{
		// Token: 0x170000E1 RID: 225
		public override global::VRGIN.Helpers.JSONNode this[int aIndex]
		{
			get
			{
				bool flag = aIndex < 0 || aIndex >= this.m_List.Count;
				global::VRGIN.Helpers.JSONNode result;
				if (flag)
				{
					result = new global::VRGIN.Helpers.JSONLazyCreator(this);
				}
				else
				{
					result = this.m_List[aIndex];
				}
				return result;
			}
			set
			{
				bool flag = aIndex < 0 || aIndex >= this.m_List.Count;
				if (flag)
				{
					this.m_List.Add(value);
				}
				else
				{
					this.m_List[aIndex] = value;
				}
			}
		}

		// Token: 0x170000E2 RID: 226
		public override global::VRGIN.Helpers.JSONNode this[string aKey]
		{
			get
			{
				return new global::VRGIN.Helpers.JSONLazyCreator(this);
			}
			set
			{
				this.m_List.Add(value);
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x00019820 File Offset: 0x00017A20
		public override int Count
		{
			get
			{
				return this.m_List.Count;
			}
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x0001983D File Offset: 0x00017A3D
		public override void Add(string aKey, global::VRGIN.Helpers.JSONNode aItem)
		{
			this.m_List.Add(aItem);
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00019850 File Offset: 0x00017A50
		public override global::VRGIN.Helpers.JSONNode Remove(int aIndex)
		{
			bool flag = aIndex < 0 || aIndex >= this.m_List.Count;
			global::VRGIN.Helpers.JSONNode result;
			if (flag)
			{
				result = null;
			}
			else
			{
				global::VRGIN.Helpers.JSONNode jsonnode = this.m_List[aIndex];
				this.m_List.RemoveAt(aIndex);
				result = jsonnode;
			}
			return result;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x000198A0 File Offset: 0x00017AA0
		public override global::VRGIN.Helpers.JSONNode Remove(global::VRGIN.Helpers.JSONNode aNode)
		{
			this.m_List.Remove(aNode);
			return aNode;
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000501 RID: 1281 RVA: 0x000198C0 File Offset: 0x00017AC0
		public override global::System.Collections.Generic.IEnumerable<global::VRGIN.Helpers.JSONNode> Children
		{
			get
			{
				foreach (global::VRGIN.Helpers.JSONNode N in this.m_List)
				{
					yield return N;
					N = null;
				}
				global::System.Collections.Generic.List<global::VRGIN.Helpers.JSONNode>.Enumerator enumerator = default(global::System.Collections.Generic.List<global::VRGIN.Helpers.JSONNode>.Enumerator);
				yield break;
				yield break;
			}
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x000198DF File Offset: 0x00017ADF
		public global::System.Collections.IEnumerator GetEnumerator()
		{
			foreach (global::VRGIN.Helpers.JSONNode N in this.m_List)
			{
				yield return N;
				N = null;
			}
			global::System.Collections.Generic.List<global::VRGIN.Helpers.JSONNode>.Enumerator enumerator = default(global::System.Collections.Generic.List<global::VRGIN.Helpers.JSONNode>.Enumerator);
			yield break;
			yield break;
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x000198F0 File Offset: 0x00017AF0
		public override string ToString()
		{
			string text = "[ ";
			foreach (global::VRGIN.Helpers.JSONNode jsonnode in this.m_List)
			{
				bool flag = text.Length > 2;
				if (flag)
				{
					text += ", ";
				}
				text += jsonnode.ToString();
			}
			text += " ]";
			return text;
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x00019980 File Offset: 0x00017B80
		public override string ToString(string aPrefix)
		{
			string text = "[ ";
			foreach (global::VRGIN.Helpers.JSONNode jsonnode in this.m_List)
			{
				bool flag = text.Length > 3;
				if (flag)
				{
					text += ", ";
				}
				text = text + "\n" + aPrefix + "   ";
				text += jsonnode.ToString(aPrefix + "   ");
			}
			text = text + "\n" + aPrefix + "]";
			return text;
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00019A34 File Offset: 0x00017C34
		public override string ToJSON(int prefix)
		{
			string text = new string(' ', (prefix + 1) * 2);
			string text2 = "[ ";
			foreach (global::VRGIN.Helpers.JSONNode jsonnode in this.m_List)
			{
				bool flag = text2.Length > 3;
				if (flag)
				{
					text2 += ", ";
				}
				text2 = text2 + "\n" + text;
				text2 += jsonnode.ToJSON(prefix + 1);
			}
			text2 = text2 + "\n" + text + "]";
			return text2;
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00019AEC File Offset: 0x00017CEC
		public override void Serialize(global::System.IO.BinaryWriter aWriter)
		{
			aWriter.Write(1);
			aWriter.Write(this.m_List.Count);
			for (int i = 0; i < this.m_List.Count; i++)
			{
				this.m_List[i].Serialize(aWriter);
			}
		}

		// Token: 0x04000656 RID: 1622
		private global::System.Collections.Generic.List<global::VRGIN.Helpers.JSONNode> m_List = new global::System.Collections.Generic.List<global::VRGIN.Helpers.JSONNode>();
	}
}
