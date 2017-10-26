using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//模型基础表配置数据类
public class ModelBaseElement
{
	public int ModelID;          	//ID	ID
	public string Res;           	//模型资源	模型资源
	public float Height;         	//身高	身高
	public int ModelR;           	//模型半径	模型半径/单位：cm
	public string BanShen;       	//半身像	半身像资源
	public string QuanShen;      	//全身像	全身像
	public string Blood;         	//血条	血条
	public string Progress;      	//吟唱&引导&被控	吟唱&引导&被控
	public string Damage;        	//伤害数字	伤害数字
	public string Exp;           	//经验	经验
	public string Tips;          	//增益&减益	增益&减益
	public string Nickname;      	//昵称	昵称
	public int NicknameSize;     	//昵称字号、掉落道具字号	昵称字号、掉落道具字号
	public string Title;         	//称号	称号
	public int TitleSize;        	//称号字号	称号字号
	public string CityNickname;  	//主城昵称	主城昵称
	public int CityNicknameSize; 	//主城昵称字号	主城昵称字号

	public bool IsValidate = false;
	public ModelBaseElement()
	{
		ModelID = -1;
	}
};

//模型基础表配置封装类
public class ModelBaseTable
{

	private ModelBaseTable()
	{
		m_mapElements = new Dictionary<int, ModelBaseElement>();
		m_emptyItem = new ModelBaseElement();
		m_vecAllElements = new List<ModelBaseElement>();
	}
	private Dictionary<int, ModelBaseElement> m_mapElements = null;
	private List<ModelBaseElement>	m_vecAllElements = null;
	private ModelBaseElement m_emptyItem = null;
	private static ModelBaseTable sInstance = null;

	public static ModelBaseTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new ModelBaseTable();
			return sInstance;
		}
	}

	public ModelBaseElement GetElement(int key)
	{
		if( m_mapElements.ContainsKey(key) )
			return m_mapElements[key];
		return null;
	}

	public int GetElementCount()
	{
		return m_mapElements.Count;
	}
	public bool HasElement(int key)
	{
		return m_mapElements.ContainsKey(key);
	}

  public List<ModelBaseElement> GetAllElement(Predicate<ModelBaseElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("ModelBase.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("ModelBase.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[ModelBase.bin]未找到");
			return false;
		}
		return LoadBin(binTableContent);
	}


	public bool LoadBin(byte[] binContent)
	{
		m_mapElements.Clear();
		m_vecAllElements.Clear();
		int nCol, nRow;
		int readPos = 0;
		readPos += GameAssist.ReadInt32Variant( binContent, readPos, out nCol );
		readPos += GameAssist.ReadInt32Variant( binContent, readPos, out nRow );
		List<string> vecLine = new List<string>(nCol);
		List<int> vecHeadType = new List<int>(nCol);
        string tmpStr;
        int tmpInt;
		for( int i=0; i<nCol; i++ )
		{
            readPos += GameAssist.ReadString(binContent, readPos, out tmpStr);
            readPos += GameAssist.ReadInt32Variant(binContent, readPos, out tmpInt);
            vecLine.Add(tmpStr);
            vecHeadType.Add(tmpInt);
		}
		if(vecLine.Count != 17)
		{
			Ex.Logger.Log("ModelBase.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ModelID"){Ex.Logger.Log("ModelBase.csv中字段[ModelID]位置不对应"); return false; }
		if(vecLine[1]!="Res"){Ex.Logger.Log("ModelBase.csv中字段[Res]位置不对应"); return false; }
		if(vecLine[2]!="Height"){Ex.Logger.Log("ModelBase.csv中字段[Height]位置不对应"); return false; }
		if(vecLine[3]!="ModelR"){Ex.Logger.Log("ModelBase.csv中字段[ModelR]位置不对应"); return false; }
		if(vecLine[4]!="BanShen"){Ex.Logger.Log("ModelBase.csv中字段[BanShen]位置不对应"); return false; }
		if(vecLine[5]!="QuanShen"){Ex.Logger.Log("ModelBase.csv中字段[QuanShen]位置不对应"); return false; }
		if(vecLine[6]!="Blood"){Ex.Logger.Log("ModelBase.csv中字段[Blood]位置不对应"); return false; }
		if(vecLine[7]!="Progress"){Ex.Logger.Log("ModelBase.csv中字段[Progress]位置不对应"); return false; }
		if(vecLine[8]!="Damage"){Ex.Logger.Log("ModelBase.csv中字段[Damage]位置不对应"); return false; }
		if(vecLine[9]!="Exp"){Ex.Logger.Log("ModelBase.csv中字段[Exp]位置不对应"); return false; }
		if(vecLine[10]!="Tips"){Ex.Logger.Log("ModelBase.csv中字段[Tips]位置不对应"); return false; }
		if(vecLine[11]!="Nickname"){Ex.Logger.Log("ModelBase.csv中字段[Nickname]位置不对应"); return false; }
		if(vecLine[12]!="NicknameSize"){Ex.Logger.Log("ModelBase.csv中字段[NicknameSize]位置不对应"); return false; }
		if(vecLine[13]!="Title"){Ex.Logger.Log("ModelBase.csv中字段[Title]位置不对应"); return false; }
		if(vecLine[14]!="TitleSize"){Ex.Logger.Log("ModelBase.csv中字段[TitleSize]位置不对应"); return false; }
		if(vecLine[15]!="CityNickname"){Ex.Logger.Log("ModelBase.csv中字段[CityNickname]位置不对应"); return false; }
		if(vecLine[16]!="CityNicknameSize"){Ex.Logger.Log("ModelBase.csv中字段[CityNicknameSize]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			ModelBaseElement member = new ModelBaseElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ModelID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Res);
			readPos += GameAssist.ReadFloat( binContent, readPos, out member.Height);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ModelR );
			readPos += GameAssist.ReadString( binContent, readPos, out member.BanShen);
			readPos += GameAssist.ReadString( binContent, readPos, out member.QuanShen);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Blood);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Progress);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Damage);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Exp);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Tips);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Nickname);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.NicknameSize );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Title);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.TitleSize );
			readPos += GameAssist.ReadString( binContent, readPos, out member.CityNickname);
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.CityNicknameSize );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ModelID] = member;
		}
		return true;
	}
	public bool LoadCsv(string strContent)
	{
		if( strContent.Length == 0 )
			return false;
		m_mapElements.Clear();
		m_vecAllElements.Clear();
		int contentOffset = 0;
		List<string> vecLine;
		vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
		if(vecLine.Count != 17)
		{
			Ex.Logger.Log("ModelBase.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ModelID"){Ex.Logger.Log("ModelBase.csv中字段[ModelID]位置不对应"); return false; }
		if(vecLine[1]!="Res"){Ex.Logger.Log("ModelBase.csv中字段[Res]位置不对应"); return false; }
		if(vecLine[2]!="Height"){Ex.Logger.Log("ModelBase.csv中字段[Height]位置不对应"); return false; }
		if(vecLine[3]!="ModelR"){Ex.Logger.Log("ModelBase.csv中字段[ModelR]位置不对应"); return false; }
		if(vecLine[4]!="BanShen"){Ex.Logger.Log("ModelBase.csv中字段[BanShen]位置不对应"); return false; }
		if(vecLine[5]!="QuanShen"){Ex.Logger.Log("ModelBase.csv中字段[QuanShen]位置不对应"); return false; }
		if(vecLine[6]!="Blood"){Ex.Logger.Log("ModelBase.csv中字段[Blood]位置不对应"); return false; }
		if(vecLine[7]!="Progress"){Ex.Logger.Log("ModelBase.csv中字段[Progress]位置不对应"); return false; }
		if(vecLine[8]!="Damage"){Ex.Logger.Log("ModelBase.csv中字段[Damage]位置不对应"); return false; }
		if(vecLine[9]!="Exp"){Ex.Logger.Log("ModelBase.csv中字段[Exp]位置不对应"); return false; }
		if(vecLine[10]!="Tips"){Ex.Logger.Log("ModelBase.csv中字段[Tips]位置不对应"); return false; }
		if(vecLine[11]!="Nickname"){Ex.Logger.Log("ModelBase.csv中字段[Nickname]位置不对应"); return false; }
		if(vecLine[12]!="NicknameSize"){Ex.Logger.Log("ModelBase.csv中字段[NicknameSize]位置不对应"); return false; }
		if(vecLine[13]!="Title"){Ex.Logger.Log("ModelBase.csv中字段[Title]位置不对应"); return false; }
		if(vecLine[14]!="TitleSize"){Ex.Logger.Log("ModelBase.csv中字段[TitleSize]位置不对应"); return false; }
		if(vecLine[15]!="CityNickname"){Ex.Logger.Log("ModelBase.csv中字段[CityNickname]位置不对应"); return false; }
		if(vecLine[16]!="CityNicknameSize"){Ex.Logger.Log("ModelBase.csv中字段[CityNicknameSize]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)17)
			{
				return false;
			}
			ModelBaseElement member = new ModelBaseElement();
			member.ModelID=Convert.ToInt32(vecLine[0]);
			member.Res=vecLine[1];
			member.Height=Convert.ToSingle(vecLine[2]);
			member.ModelR=Convert.ToInt32(vecLine[3]);
			member.BanShen=vecLine[4];
			member.QuanShen=vecLine[5];
			member.Blood=vecLine[6];
			member.Progress=vecLine[7];
			member.Damage=vecLine[8];
			member.Exp=vecLine[9];
			member.Tips=vecLine[10];
			member.Nickname=vecLine[11];
			member.NicknameSize=Convert.ToInt32(vecLine[12]);
			member.Title=vecLine[13];
			member.TitleSize=Convert.ToInt32(vecLine[14]);
			member.CityNickname=vecLine[15];
			member.CityNicknameSize=Convert.ToInt32(vecLine[16]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ModelID] = member;
		}
		return true;
	}
};
