using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VRGIN.Helpers
{
	// Token: 0x020000CE RID: 206
	public class JSONClass : global::VRGIN.Helpers.JSONNode, global::System.Collections.IEnumerable
	{
		// Token: 0x170000E5 RID: 229
		public override global::VRGIN.Helpers.JSONNode this[string aKey]
		{
			get
			{
				bool flag = this.m_Dict.ContainsKey(aKey);
				global::VRGIN.Helpers.JSONNode result;
				if (flag)
				{
					result = this.m_Dict[aKey];
				}
				else
				{
					result = new global::VRGIN.Helpers.JSONLazyCreator(this, aKey);
				}
				return result;
			}
			set
			{
				bool flag = this.m_Dict.ContainsKey(aKey);
				if (flag)
				{
					this.m_Dict[aKey] = value;
				}
				else
				{
					this.m_Dict.Add(aKey, value);
				}
			}
		}

		// Token: 0x170000E6 RID: 230
		public override global::VRGIN.Helpers.JSONNode this[int aIndex]
		{
			get
			{
				bool flag = aIndex < 0 || aIndex >= this.m_Dict.Count;
				global::VRGIN.Helpers.JSONNode result;
				if (flag)
				{
					result = null;
				}
				else
				{
					result = global::System.Linq.Enumerable.ElementAt<global::System.Collections.Generic.KeyValuePair<string, global::VRGIN.Helpers.JSONNode>>(this.m_Dict, aIndex).Value;
				}
				return result;
			}
			set
			{
				bool flag = aIndex < 0 || aIndex >= this.m_Dict.Count;
				if (!flag)
				{
					string key = global::System.Linq.Enumerable.ElementAt<global::System.Collections.Generic.KeyValuePair<string, global::VRGIN.Helpers.JSONNode>>(this.m_Dict, aIndex).Key;
					this.m_Dict[key] = value;
				}
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x00019C64 File Offset: 0x00017E64
		public override int Count
		{
			get
			{
				return this.m_Dict.Count;
			}
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x00019C84 File Offset: 0x00017E84
		public override void Add(string aKey, global::VRGIN.Helpers.JSONNode aItem)
		{
			bool flag = !string.IsNullOrEmpty(aKey);
			if (flag)
			{
				bool flag2 = this.m_Dict.ContainsKey(aKey);
				if (flag2)
				{
					this.m_Dict[aKey] = aItem;
				}
				else
				{
					this.m_Dict.Add(aKey, aItem);
				}
			}
			else
			{
				this.m_Dict.Add(global::System.Guid.NewGuid().ToString(), aItem);
			}
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x00019CF4 File Offset: 0x00017EF4
		public override global::VRGIN.Helpers.JSONNode Remove(string aKey)
		{
			bool flag = !this.m_Dict.ContainsKey(aKey);
			global::VRGIN.Helpers.JSONNode result;
			if (flag)
			{
				result = null;
			}
			else
			{
				global::VRGIN.Helpers.JSONNode jsonnode = this.m_Dict[aKey];
				this.m_Dict.Remove(aKey);
				result = jsonnode;
			}
			return result;
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00019D38 File Offset: 0x00017F38
		public override global::VRGIN.Helpers.JSONNode Remove(int aIndex)
		{
			bool flag = aIndex < 0 || aIndex >= this.m_Dict.Count;
			global::VRGIN.Helpers.JSONNode result;
			if (flag)
			{
				result = null;
			}
			else
			{
				global::System.Collections.Generic.KeyValuePair<string, global::VRGIN.Helpers.JSONNode> keyValuePair = global::System.Linq.Enumerable.ElementAt<global::System.Collections.Generic.KeyValuePair<string, global::VRGIN.Helpers.JSONNode>>(this.m_Dict, aIndex);
				this.m_Dict.Remove(keyValuePair.Key);
				result = keyValuePair.Value;
			}
			return result;
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x00019D94 File Offset: 0x00017F94
		public override global::VRGIN.Helpers.JSONNode Remove(global::VRGIN.Helpers.JSONNode aNode)
		{
			global::VRGIN.Helpers.JSONNode result;
			try
			{
				global::System.Collections.Generic.KeyValuePair<string, global::VRGIN.Helpers.JSONNode> keyValuePair = global::System.Linq.Enumerable.First<global::System.Collections.Generic.KeyValuePair<string, global::VRGIN.Helpers.JSONNode>>(global::System.Linq.Enumerable.Where<global::System.Collections.Generic.KeyValuePair<string, global::VRGIN.Helpers.JSONNode>>(this.m_Dict, (global::System.Collections.Generic.KeyValuePair<string, global::VRGIN.Helpers.JSONNode> k) => k.Value == aNode));
				this.m_Dict.Remove(keyValuePair.Key);
				result = aNode;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000511 RID: 1297 RVA: 0x00019E00 File Offset: 0x00018000
		public override global::System.Collections.Generic.IEnumerable<global::VRGIN.Helpers.JSONNode> Children
		{
			get
			{
				foreach (global::System.Collections.Generic.KeyValuePair<string, global::VRGIN.Helpers.JSONNode> N in this.m_Dict)
				{
					yield return N.Value;
					N = default(global::System.Collections.Generic.KeyValuePair<string, global::VRGIN.Helpers.JSONNode>);
				}
				global::System.Collections.Generic.Dictionary<string, global::VRGIN.Helpers.JSONNode>.Enumerator enumerator = default(global::System.Collections.Generic.Dictionary<string, global::VRGIN.Helpers.JSONNode>.Enumerator);
				yield break;
				yield break;
			}
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x00019E1F File Offset: 0x0001801F
		public global::System.Collections.IEnumerator GetEnumerator()
		{
			foreach (global::System.Collections.Generic.KeyValuePair<string, global::VRGIN.Helpers.JSONNode> N in this.m_Dict)
			{
				yield return N;
				N = default(global::System.Collections.Generic.KeyValuePair<string, global::VRGIN.Helpers.JSONNode>);
			}
			global::System.Collections.Generic.Dictionary<string, global::VRGIN.Helpers.JSONNode>.Enumerator enumerator = default(global::System.Collections.Generic.Dictionary<string, global::VRGIN.Helpers.JSONNode>.Enumerator);
			yield break;
			yield break;
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x00019E30 File Offset: 0x00018030
		public override string ToString()
		{
			string text = "{";
			foreach (global::System.Collections.Generic.KeyValuePair<string, global::VRGIN.Helpers.JSONNode> keyValuePair in this.m_Dict)
			{
				bool flag = text.Length > 2;
				if (flag)
				{
					text += ", ";
				}
				text = string.Concat(new string[]
				{
					text,
					"\"",
					global::VRGIN.Helpers.JSONNode.Escape(keyValuePair.Key),
					"\":",
					keyValuePair.Value.ToString()
				});
			}
			text += "}";
			return text;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00019EF4 File Offset: 0x000180F4
		public override string ToString(string aPrefix)
		{
			string text = "{ ";
			foreach (global::System.Collections.Generic.KeyValuePair<string, global::VRGIN.Helpers.JSONNode> keyValuePair in this.m_Dict)
			{
				bool flag = text.Length > 3;
				if (flag)
				{
					text += ", ";
				}
				text = text + "\n" + aPrefix + "   ";
				text = string.Concat(new string[]
				{
					text,
					"\"",
					global::VRGIN.Helpers.JSONNode.Escape(keyValuePair.Key),
					"\" : ",
					keyValuePair.Value.ToString(aPrefix + "   ")
				});
			}
			text = text + "\n" + aPrefix + "}";
			return text;
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x00019FDC File Offset: 0x000181DC
		public override string ToJSON(int prefix)
		{
			string text = new string(' ', (prefix + 1) * 2);
			string text2 = "{ ";
			foreach (global::System.Collections.Generic.KeyValuePair<string, global::VRGIN.Helpers.JSONNode> keyValuePair in this.m_Dict)
			{
				bool flag = text2.Length > 3;
				if (flag)
				{
					text2 += ", ";
				}
				text2 = text2 + "\n" + text;
				text2 += string.Format("\"{0}\": {1}", keyValuePair.Key, keyValuePair.Value.ToJSON(prefix + 1));
			}
			text2 = text2 + "\n" + text + "}";
			return text2;
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0001A0A8 File Offset: 0x000182A8
		public override void Serialize(global::System.IO.BinaryWriter aWriter)
		{
			aWriter.Write(2);
			aWriter.Write(this.m_Dict.Count);
			foreach (string text in this.m_Dict.Keys)
			{
				aWriter.Write(text);
				this.m_Dict[text].Serialize(aWriter);
			}
		}

		// Token: 0x04000657 RID: 1623
		private global::System.Collections.Generic.Dictionary<string, global::VRGIN.Helpers.JSONNode> m_Dict = new global::System.Collections.Generic.Dictionary<string, global::VRGIN.Helpers.JSONNode>();
	}
}
