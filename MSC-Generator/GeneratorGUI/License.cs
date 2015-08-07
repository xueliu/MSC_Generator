/*
 * Created by SharpDevelop.
 * User: T.Trunz
 * Date: 02.08.2006
 * Time: 13:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace LicenseKey
{
	public enum LicenseType{
		Free,
		NonCommercial,
		Commercial,
		Demo
	}
	
	public enum ValidResult{
		OK,
		OutOfDate,
		NoLicensed
	}
	
	/******************************************************************
	 * Zusammenstellung der Key-Datei
	 * 
	 * Byte 0,1,2,3			Randomwert
	 * Byte 4....7			Applicationtyp
	 * Byte 8				Lizenztyp
	 * Byte 9				Ablaufdatum (Tag)
	 * Byte 10				Ablaufdatum (Monat)
	 * Byte 11				Ablaufdatum (Jahr+2000) (0xFF - Ohne Zeitbegrenzung)
	 * Byte 12...16			Lizenznummer 
	 * Byte 17...49			Reserviert
	 * Byte 50				Länge Firma(1)
	 * Byte 51...159		Firma (1)
	 * Byte 160				Länge Firms(2)
	 * Byte 161...249		Firma (2)
	 * Byte 250..255        "ITESYS"
	 *
	 * *****************************************************************/
	 
	/// <summary>
	/// Description of License.
	/// </summary>
	/// 
	public class License
	{
		private byte[] validationKey = new byte[]{0x49,0x54,0x45,0x53,0x59,0x53};
		private const byte keyLen=6;
		private const byte startByte = 0xAA;
		
		private string mCompany1, mCompany2;
		private LicenseType mLicenseType = LicenseType.Free;
		private ValidResult mValid;
		private ulong mLicenseNumber;
		private DateTime mDate;
		
		public License()
		{
			mValid = ValidResult.NoLicensed;
			
		}
		public ulong licenseNumber{
			get{
				return mLicenseNumber;
			}
		}		
		public DateTime licenseDate{
			get{
				return mDate;
			}
		}		
		public string company1{
			get{
				return mCompany1;
			}
			set{
				mCompany1=value;
			}
		}		
		public string company2{
			get{
				return mCompany2;
			}
			set{
				mCompany2=value;
			}
		}		
		public LicenseType licenseType{
			get{
				return mLicenseType;
			}
			set{
				mLicenseType=value;
			}
		}		
		public ValidResult valid{
			get{
				return mValid;
			}
		}		

		public void CheckLicense(uint appType)
		{
			try{
				if(File.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\license.key")){
					FileStream fs=new FileStream(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\license.key",FileMode.Open);
	                if (fs.Length != 256){
						mValid = ValidResult.NoLicensed;
						fs.Close();
					}
					else{
						byte[] keyData = new byte[256];
						byte oldByte = 0x00;
						byte readByte = 0x00;
						BinaryReader br = new BinaryReader(fs);
						for (int i=0;i<256;i++){
							readByte = br.ReadByte();
							keyData[i] = (byte)((readByte ^ validationKey[i % keyLen]) ^ oldByte);
							oldByte = readByte;
						}
						br.Close();
						fs.Close();
						
						mValid = ValidResult.OK;
						//Itesys check
						if((keyData[250] != validationKey[0]) ||
							(keyData[251] != validationKey[1]) || 
							(keyData[252] != validationKey[2]) ||
							(keyData[253] != validationKey[3]) ||
							(keyData[254] != validationKey[4]) ||
							(keyData[255] != validationKey[5])) mValid = ValidResult.NoLicensed;
						
						//Date check
						DateTime dt= new DateTime(2000 + keyData[11], keyData[10], keyData[9]);
						mDate = dt;
						if (keyData[11] != 0xFF){
							if (dt < DateTime.Today) mValid = ValidResult.OutOfDate;
						}
						
						// Application check
						uint verAppType = 0;
						verAppType = ((uint)keyData[4]<<24)|((uint)keyData[5]<<16)|((uint)keyData[6]<<8)|((uint)keyData[7]);
						if (verAppType != appType) mValid = ValidResult.NoLicensed;
						
						// set license number
						mLicenseNumber = ((ulong)keyData[12]<<32)|((ulong)keyData[13]<<24)|((ulong)keyData[14]<<16)|((ulong)keyData[15]<<8)|((ulong)keyData[16]);
	
						// set company name
						Encoding ascii = Encoding.ASCII;
						mCompany1 = ascii.GetString(keyData,51,keyData[50]);	
						mCompany2 = ascii.GetString(keyData,161,keyData[160]);	
						
						// set license type
						switch (keyData[8]){
							case (byte)LicenseType.Free:
								mLicenseType = LicenseType.Free;
								break;
							case (byte)LicenseType.Commercial:
								mLicenseType = LicenseType.Commercial;
								break;
							case (byte)LicenseType.NonCommercial:
								mLicenseType = LicenseType.NonCommercial;
								break;
							case (byte)LicenseType.Demo:
								mLicenseType = LicenseType.Demo;
								break;							
							default:
								mValid = ValidResult.NoLicensed;
								break;
						}
					}
				}
				else{
					mValid = ValidResult.NoLicensed;
				}
			}
			catch(System.Exception ex){
				mValid = ValidResult.NoLicensed;
				MessageBox.Show(ex.Message);
			}
		}
		
		public string MakeLicense(uint appType, string company1, string company2, DateTime runout, LicenseType licenseType)
		{
			byte[] keyData = new byte[256];
			byte oldByte = 0x00;
			byte writeByte = 0x00;
			ulong licenseNumber;
			// fill with random values
			Random rnd = new Random();
			rnd.NextBytes(keyData);
			// set application type
			keyData[4] = (byte)((appType >> 24) & 0xFF);
			keyData[5] = (byte)((appType >> 16) & 0xFF);
			keyData[6] = (byte)((appType >> 8) & 0xFF);
			keyData[7] = (byte)((appType >> 0) & 0xFF);
			// set license type
			keyData[8] = (byte)licenseType;
			// set out running date
			keyData[9] = (byte)runout.Day;
			keyData[10] = (byte)runout.Month;
			keyData[11] = (byte)(runout.Year - 2000);
			// set license number
			if(!File.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\licenses.lst")){
				StreamWriter sw = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\licenses.lst");
				sw.Close();
			}
			bool newLicense = false;
			do{
				licenseNumber = (ulong)rnd.Next(1000,10000) * 100000000 + (ulong)rnd.Next(1000,10000) * 10000 + (ulong)rnd.Next(1000,10000);
				string s = String.Empty;
				StreamReader sr = new StreamReader(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\licenses.lst");
				newLicense = true;
				do{
					s = sr.ReadLine();
					if (s != null){
						string[] temp = s.Split(' ');
						if (temp[0] == licenseNumber.ToString()) newLicense = false;
					}
				}while(s != null);
				sr.Close();
			}while(newLicense == false);
			StreamWriter sw2 = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\licenses.lst",true);
			sw2.WriteLine(licenseNumber.ToString() + " " + company1 + " " + " " + company2 + appType.ToString());
			sw2.Close();
			keyData[12] = (byte)((licenseNumber >> 32) & 0xFF);
			keyData[13] = (byte)((licenseNumber >> 24) & 0xFF);
			keyData[14] = (byte)((licenseNumber >> 16) & 0xFF);
			keyData[15] = (byte)((licenseNumber >> 8) & 0xFF);
			keyData[16] = (byte)((licenseNumber >> 0) & 0xFF);
			
			//set company
			Encoding ascii = Encoding.ASCII;
			keyData[50] = (byte) company1.Length;
			ascii.GetBytes(company1,0,company1.Length,keyData,51);
			keyData[160] = (byte) company2.Length;
			ascii.GetBytes(company2,0,company2.Length,keyData,161);
			
			//set ITESYS checksum
			for(int i=0;i<keyLen;i++){
				keyData[250+i] = validationKey[i];
			}
			
			//encode key and write keyfile
			FileStream fs=new FileStream(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\license.key",FileMode.OpenOrCreate);
			string output = string.Empty;
			for(int i=0; i<256; i++){
				writeByte = (byte)(keyData[i] ^ oldByte);
				keyData[i] = (byte)(writeByte ^ validationKey[i%keyLen]);
				oldByte = keyData[i];
				fs.WriteByte(oldByte);
				output += keyData[i].ToString() + " ";
			}
			fs.Close();
			return output;
		}
	}
}
