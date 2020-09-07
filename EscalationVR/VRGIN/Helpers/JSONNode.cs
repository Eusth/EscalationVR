using System;
using System.Collections.Generic;
using System.IO;

namespace VRGIN.Helpers
{
	// Token: 0x020000CC RID: 204
	public abstract class JSONNode
	{
		// Token: 0x060004C3 RID: 1219 RVA: 0x00018B0F File Offset: 0x00016D0F
		public virtual void Add(string aKey, global::VRGIN.Helpers.JSONNode aItem)
		{
		}

		// Token: 0x170000D4 RID: 212
		public virtual global::VRGIN.Helpers.JSONNode this[int aIndex]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x170000D5 RID: 213
		public virtual global::VRGIN.Helpers.JSONNode this[string aKey]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x00018B44 File Offset: 0x00016D44
		// (set) Token: 0x060004C9 RID: 1225 RVA: 0x00018B5B File Offset: 0x00016D5B
		public virtual string Value
		{
			get
			{
				return "";
			}
			set
			{
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x00018B60 File Offset: 0x00016D60
		public virtual int Count
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x00018B73 File Offset: 0x00016D73
		public virtual void Add(global::VRGIN.Helpers.JSONNode aItem)
		{
			this.Add("", aItem);
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x00018B84 File Offset: 0x00016D84
		public virtual global::VRGIN.Helpers.JSONNode Remove(string aKey)
		{
			return null;
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x00018B98 File Offset: 0x00016D98
		public virtual global::VRGIN.Helpers.JSONNode Remove(int aIndex)
		{
			return null;
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x00018BAC File Offset: 0x00016DAC
		public virtual global::VRGIN.Helpers.JSONNode Remove(global::VRGIN.Helpers.JSONNode aNode)
		{
			return aNode;
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x00018BC0 File Offset: 0x00016DC0
		public virtual global::System.Collections.Generic.IEnumerable<global::VRGIN.Helpers.JSONNode> Children
		{
			get
			{
				yield break;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x00018BE0 File Offset: 0x00016DE0
		public global::System.Collections.Generic.IEnumerable<global::VRGIN.Helpers.JSONNode> DeepChildren
		{
			get
			{
				foreach (global::VRGIN.Helpers.JSONNode C in this.Children)
				{
					foreach (global::VRGIN.Helpers.JSONNode D in C.DeepChildren)
					{
						yield return D;
						D = null;
					}
					global::System.Collections.Generic.IEnumerator<global::VRGIN.Helpers.JSONNode> enumerator2 = null;
					C = null;
				}
				global::System.Collections.Generic.IEnumerator<global::VRGIN.Helpers.JSONNode> enumerator = null;
				yield break;
				yield break;
			}
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00018C00 File Offset: 0x00016E00
		public override string ToString()
		{
			return "JSONNode";
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00018C18 File Offset: 0x00016E18
		public virtual string ToString(string aPrefix)
		{
			return "JSONNode";
		}

		// Token: 0x060004D3 RID: 1235
		public abstract string ToJSON(int prefix);

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x00018C2F File Offset: 0x00016E2F
		// (set) Token: 0x060004D5 RID: 1237 RVA: 0x00018C37 File Offset: 0x00016E37
		public virtual global::VRGIN.Helpers.JSONBinaryTag Tag { get; set; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x00018C40 File Offset: 0x00016E40
		// (set) Token: 0x060004D7 RID: 1239 RVA: 0x00018C6A File Offset: 0x00016E6A
		public virtual int AsInt
		{
			get
			{
				int num = 0;
				bool flag = int.TryParse(this.Value, ref num);
				int result;
				if (flag)
				{
					result = num;
				}
				else
				{
					result = 0;
				}
				return result;
			}
			set
			{
				this.Value = value.ToString();
				this.Tag = global::VRGIN.Helpers.JSONBinaryTag.IntValue;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x00018C84 File Offset: 0x00016E84
		// (set) Token: 0x060004D9 RID: 1241 RVA: 0x00018CB6 File Offset: 0x00016EB6
		public virtual float AsFloat
		{
			get
			{
				float num = 0f;
				bool flag = float.TryParse(this.Value, ref num);
				float result;
				if (flag)
				{
					result = num;
				}
				else
				{
					result = 0f;
				}
				return result;
			}
			set
			{
				this.Value = value.ToString();
				this.Tag = global::VRGIN.Helpers.JSONBinaryTag.FloatValue;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060004DA RID: 1242 RVA: 0x00018CD0 File Offset: 0x00016ED0
		// (set) Token: 0x060004DB RID: 1243 RVA: 0x00018D0A File Offset: 0x00016F0A
		public virtual double AsDouble
		{
			get
			{
				double num = 0.0;
				bool flag = double.TryParse(this.Value, ref num);
				double result;
				if (flag)
				{
					result = num;
				}
				else
				{
					result = 0.0;
				}
				return result;
			}
			set
			{
				this.Value = value.ToString();
				this.Tag = global::VRGIN.Helpers.JSONBinaryTag.DoubleValue;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060004DC RID: 1244 RVA: 0x00018D24 File Offset: 0x00016F24
		// (set) Token: 0x060004DD RID: 1245 RVA: 0x00018D5B File Offset: 0x00016F5B
		public virtual bool AsBool
		{
			get
			{
				bool flag = false;
				bool flag2 = bool.TryParse(this.Value, ref flag);
				bool result;
				if (flag2)
				{
					result = flag;
				}
				else
				{
					result = !string.IsNullOrEmpty(this.Value);
				}
				return result;
			}
			set
			{
				this.Value = (value ? "true" : "false");
				this.Tag = global::VRGIN.Helpers.JSONBinaryTag.BoolValue;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060004DE RID: 1246 RVA: 0x00018D7C File Offset: 0x00016F7C
		public virtual global::VRGIN.Helpers.JSONArray AsArray
		{
			get
			{
				return this as global::VRGIN.Helpers.JSONArray;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060004DF RID: 1247 RVA: 0x00018D94 File Offset: 0x00016F94
		public virtual global::VRGIN.Helpers.JSONClass AsObject
		{
			get
			{
				return this as global::VRGIN.Helpers.JSONClass;
			}
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00018DAC File Offset: 0x00016FAC
		public static implicit operator global::VRGIN.Helpers.JSONNode(string s)
		{
			return new global::VRGIN.Helpers.JSONData(s);
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00018DC4 File Offset: 0x00016FC4
		public static implicit operator string(global::VRGIN.Helpers.JSONNode d)
		{
			return (d == null) ? null : d.Value;
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00018DE8 File Offset: 0x00016FE8
		public static bool operator ==(global::VRGIN.Helpers.JSONNode a, object b)
		{
			bool flag = b == null && a is global::VRGIN.Helpers.JSONLazyCreator;
			return flag || a == b;
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00018E18 File Offset: 0x00017018
		public static bool operator !=(global::VRGIN.Helpers.JSONNode a, object b)
		{
			return !(a == b);
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00018E34 File Offset: 0x00017034
		public override bool Equals(object obj)
		{
			return this == obj;
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00018E4C File Offset: 0x0001704C
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x00018E64 File Offset: 0x00017064
		internal static string Escape(string aText)
		{
			string text = "";
			int i = 0;
			while (i < aText.Length)
			{
				char c = aText.get_Chars(i);
				char c2 = c;
				char c3 = c2;
				switch (c3)
				{
				case '\b':
					text += "\\b";
					break;
				case '\t':
					text += "\\t";
					break;
				case '\n':
					text += "\\n";
					break;
				case '\v':
					goto IL_B6;
				case '\f':
					text += "\\f";
					break;
				case '\r':
					text += "\\r";
					break;
				default:
					if (c3 != '"')
					{
						if (c3 != '\\')
						{
							goto IL_B6;
						}
						text += "\\\\";
					}
					else
					{
						text += "\\\"";
					}
					break;
				}
				IL_C6:
				i++;
				continue;
				IL_B6:
				text += c.ToString();
				goto IL_C6;
			}
			return text;
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x00018F50 File Offset: 0x00017150
		private static global::VRGIN.Helpers.JSONData Numberize(string token)
		{
			bool aData = false;
			int aData2 = 0;
			double aData3 = 0.0;
			bool flag = int.TryParse(token, ref aData2);
			global::VRGIN.Helpers.JSONData result;
			if (flag)
			{
				result = new global::VRGIN.Helpers.JSONData(aData2);
			}
			else
			{
				bool flag2 = double.TryParse(token, ref aData3);
				if (flag2)
				{
					result = new global::VRGIN.Helpers.JSONData(aData3);
				}
				else
				{
					bool flag3 = bool.TryParse(token, ref aData);
					if (!flag3)
					{
						throw new global::System.NotImplementedException(token);
					}
					result = new global::VRGIN.Helpers.JSONData(aData);
				}
			}
			return result;
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x00018FC0 File Offset: 0x000171C0
		private static void AddElement(global::VRGIN.Helpers.JSONNode ctx, string token, string tokenName, bool tokenIsString)
		{
			if (tokenIsString)
			{
				bool flag = ctx is global::VRGIN.Helpers.JSONArray;
				if (flag)
				{
					ctx.Add(token);
				}
				else
				{
					ctx.Add(tokenName, token);
				}
			}
			else
			{
				global::VRGIN.Helpers.JSONData aItem = global::VRGIN.Helpers.JSONNode.Numberize(token);
				bool flag2 = ctx is global::VRGIN.Helpers.JSONArray;
				if (flag2)
				{
					ctx.Add(aItem);
				}
				else
				{
					ctx.Add(tokenName, aItem);
				}
			}
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0001902C File Offset: 0x0001722C
		public static global::VRGIN.Helpers.JSONNode Parse(string aJSON)
		{
			global::System.Collections.Generic.Stack<global::VRGIN.Helpers.JSONNode> stack = new global::System.Collections.Generic.Stack<global::VRGIN.Helpers.JSONNode>();
			global::VRGIN.Helpers.JSONNode jsonnode = null;
			int i = 0;
			string text = "";
			string text2 = "";
			bool flag = false;
			bool flag2 = false;
			while (i < aJSON.Length)
			{
				char c = aJSON.get_Chars(i);
				char c2 = c;
				if (c2 <= ',')
				{
					if (c2 <= ' ')
					{
						switch (c2)
						{
						case '\t':
							break;
						case '\n':
						case '\r':
							goto IL_473;
						case '\v':
						case '\f':
							goto IL_45A;
						default:
							if (c2 != ' ')
							{
								goto IL_45A;
							}
							break;
						}
						bool flag3 = flag;
						if (flag3)
						{
							text += aJSON.get_Chars(i).ToString();
						}
					}
					else if (c2 != '"')
					{
						if (c2 != ',')
						{
							goto IL_45A;
						}
						bool flag4 = flag;
						if (flag4)
						{
							text += aJSON.get_Chars(i).ToString();
						}
						else
						{
							bool flag5 = text != "";
							if (flag5)
							{
								global::VRGIN.Helpers.JSONNode.AddElement(jsonnode, text, text2, flag2);
							}
							text2 = "";
							text = "";
							flag2 = false;
						}
					}
					else
					{
						flag = !flag;
						flag2 = (flag || flag2);
					}
				}
				else
				{
					if (c2 <= ']')
					{
						if (c2 != ':')
						{
							switch (c2)
							{
							case '[':
							{
								bool flag6 = flag;
								if (flag6)
								{
									text += aJSON.get_Chars(i).ToString();
									goto IL_473;
								}
								stack.Push(new global::VRGIN.Helpers.JSONArray());
								bool flag7 = jsonnode != null;
								if (flag7)
								{
									text2 = text2.Trim();
									bool flag8 = jsonnode is global::VRGIN.Helpers.JSONArray;
									if (flag8)
									{
										jsonnode.Add(stack.Peek());
									}
									else
									{
										bool flag9 = text2 != "";
										if (flag9)
										{
											jsonnode.Add(text2, stack.Peek());
										}
									}
								}
								text2 = "";
								text = "";
								jsonnode = stack.Peek();
								goto IL_473;
							}
							case '\\':
							{
								i++;
								bool flag10 = flag;
								if (flag10)
								{
									char c3 = aJSON.get_Chars(i);
									char c4 = c3;
									char c5 = c4;
									if (c5 <= 'f')
									{
										if (c5 != 'b')
										{
											if (c5 != 'f')
											{
												goto IL_447;
											}
											text += "\f";
										}
										else
										{
											text += "\b";
										}
									}
									else if (c5 != 'n')
									{
										switch (c5)
										{
										case 'r':
											text += "\r";
											break;
										case 's':
											goto IL_447;
										case 't':
											text += "\t";
											break;
										case 'u':
										{
											string text3 = aJSON.Substring(i + 1, 4);
											text += ((char)int.Parse(text3, 512)).ToString();
											i += 4;
											break;
										}
										default:
											goto IL_447;
										}
									}
									else
									{
										text += "\n";
									}
									goto IL_458;
									IL_447:
									text += c3.ToString();
								}
								IL_458:
								goto IL_473;
							}
							case ']':
								break;
							default:
								goto IL_45A;
							}
						}
						else
						{
							bool flag11 = flag;
							if (flag11)
							{
								text += aJSON.get_Chars(i).ToString();
								goto IL_473;
							}
							text2 = text;
							text = "";
							flag2 = false;
							goto IL_473;
						}
					}
					else if (c2 != '{')
					{
						if (c2 != '}')
						{
							goto IL_45A;
						}
					}
					else
					{
						bool flag12 = flag;
						if (flag12)
						{
							text += aJSON.get_Chars(i).ToString();
							goto IL_473;
						}
						stack.Push(new global::VRGIN.Helpers.JSONClass());
						bool flag13 = jsonnode != null;
						if (flag13)
						{
							text2 = text2.Trim();
							bool flag14 = jsonnode is global::VRGIN.Helpers.JSONArray;
							if (flag14)
							{
								jsonnode.Add(stack.Peek());
							}
							else
							{
								bool flag15 = text2 != "";
								if (flag15)
								{
									jsonnode.Add(text2, stack.Peek());
								}
							}
						}
						text2 = "";
						text = "";
						jsonnode = stack.Peek();
						goto IL_473;
					}
					bool flag16 = flag;
					if (flag16)
					{
						text += aJSON.get_Chars(i).ToString();
					}
					else
					{
						bool flag17 = stack.Count == 0;
						if (flag17)
						{
							throw new global::System.Exception("JSON Parse: Too many closing brackets");
						}
						stack.Pop();
						bool flag18 = text != "";
						if (flag18)
						{
							text2 = text2.Trim();
							global::VRGIN.Helpers.JSONNode.AddElement(jsonnode, text, text2, flag2);
							flag2 = false;
						}
						text2 = "";
						text = "";
						bool flag19 = stack.Count > 0;
						if (flag19)
						{
							jsonnode = stack.Peek();
						}
					}
				}
				IL_473:
				i++;
				continue;
				IL_45A:
				text += aJSON.get_Chars(i).ToString();
				goto IL_473;
			}
			bool flag20 = flag;
			if (flag20)
			{
				throw new global::System.Exception("JSON Parse: Quotation marks seems to be messed up.");
			}
			return jsonnode;
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x000194DE File Offset: 0x000176DE
		public virtual void Serialize(global::System.IO.BinaryWriter aWriter)
		{
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x000194E4 File Offset: 0x000176E4
		public void SaveToStream(global::System.IO.Stream aData)
		{
			global::System.IO.BinaryWriter aWriter = new global::System.IO.BinaryWriter(aData);
			this.Serialize(aWriter);
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00019501 File Offset: 0x00017701
		public void SaveToCompressedStream(global::System.IO.Stream aData)
		{
			throw new global::System.Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0001950E File Offset: 0x0001770E
		public void SaveToCompressedFile(string aFileName)
		{
			throw new global::System.Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x0001951B File Offset: 0x0001771B
		public string SaveToCompressedBase64()
		{
			throw new global::System.Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x00019528 File Offset: 0x00017728
		public void SaveToFile(string aFileName)
		{
			throw new global::System.Exception("Can't use File IO stuff in webplayer");
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x00019538 File Offset: 0x00017738
		public string SaveToBase64()
		{
			string result;
			using (global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream())
			{
				this.SaveToStream(memoryStream);
				memoryStream.Position = 0L;
				result = global::System.Convert.ToBase64String(memoryStream.ToArray());
			}
			return result;
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x00019588 File Offset: 0x00017788
		public static global::VRGIN.Helpers.JSONNode Deserialize(global::System.IO.BinaryReader aReader)
		{
			global::VRGIN.Helpers.JSONBinaryTag jsonbinaryTag = (global::VRGIN.Helpers.JSONBinaryTag)aReader.ReadByte();
			global::VRGIN.Helpers.JSONNode result;
			switch (jsonbinaryTag)
			{
			case global::VRGIN.Helpers.JSONBinaryTag.Array:
			{
				int num = aReader.ReadInt32();
				global::VRGIN.Helpers.JSONArray jsonarray = new global::VRGIN.Helpers.JSONArray();
				for (int i = 0; i < num; i++)
				{
					jsonarray.Add(global::VRGIN.Helpers.JSONNode.Deserialize(aReader));
				}
				result = jsonarray;
				break;
			}
			case global::VRGIN.Helpers.JSONBinaryTag.Class:
			{
				int num2 = aReader.ReadInt32();
				global::VRGIN.Helpers.JSONClass jsonclass = new global::VRGIN.Helpers.JSONClass();
				for (int j = 0; j < num2; j++)
				{
					string aKey = aReader.ReadString();
					global::VRGIN.Helpers.JSONNode aItem = global::VRGIN.Helpers.JSONNode.Deserialize(aReader);
					jsonclass.Add(aKey, aItem);
				}
				result = jsonclass;
				break;
			}
			case global::VRGIN.Helpers.JSONBinaryTag.Value:
				result = new global::VRGIN.Helpers.JSONData(aReader.ReadString());
				break;
			case global::VRGIN.Helpers.JSONBinaryTag.IntValue:
				result = new global::VRGIN.Helpers.JSONData(aReader.ReadInt32());
				break;
			case global::VRGIN.Helpers.JSONBinaryTag.DoubleValue:
				result = new global::VRGIN.Helpers.JSONData(aReader.ReadDouble());
				break;
			case global::VRGIN.Helpers.JSONBinaryTag.BoolValue:
				result = new global::VRGIN.Helpers.JSONData(aReader.ReadBoolean());
				break;
			case global::VRGIN.Helpers.JSONBinaryTag.FloatValue:
				result = new global::VRGIN.Helpers.JSONData(aReader.ReadSingle());
				break;
			default:
				throw new global::System.Exception("Error deserializing JSON. Unknown tag: " + jsonbinaryTag.ToString());
			}
			return result;
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x000196C1 File Offset: 0x000178C1
		public static global::VRGIN.Helpers.JSONNode LoadFromCompressedFile(string aFileName)
		{
			throw new global::System.Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x000196CE File Offset: 0x000178CE
		public static global::VRGIN.Helpers.JSONNode LoadFromCompressedStream(global::System.IO.Stream aData)
		{
			throw new global::System.Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x000196DB File Offset: 0x000178DB
		public static global::VRGIN.Helpers.JSONNode LoadFromCompressedBase64(string aBase64)
		{
			throw new global::System.Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x000196E8 File Offset: 0x000178E8
		public static global::VRGIN.Helpers.JSONNode LoadFromStream(global::System.IO.Stream aData)
		{
			global::VRGIN.Helpers.JSONNode result;
			using (global::System.IO.BinaryReader binaryReader = new global::System.IO.BinaryReader(aData))
			{
				result = global::VRGIN.Helpers.JSONNode.Deserialize(binaryReader);
			}
			return result;
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00019724 File Offset: 0x00017924
		public static global::VRGIN.Helpers.JSONNode LoadFromFile(string aFileName)
		{
			throw new global::System.Exception("Can't use File IO stuff in webplayer");
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00019734 File Offset: 0x00017934
		public static global::VRGIN.Helpers.JSONNode LoadFromBase64(string aBase64)
		{
			byte[] array = global::System.Convert.FromBase64String(aBase64);
			return global::VRGIN.Helpers.JSONNode.LoadFromStream(new global::System.IO.MemoryStream(array)
			{
				Position = 0L
			});
		}
	}
}
