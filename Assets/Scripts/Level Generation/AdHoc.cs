using UnityEngine;
using System.Collections;
using System.IO;
using System;

/// <summary>
/// Ad hoc. This class uses TextFile templates placed in Unity's Resources folder to create pseudo-random interior environments.
/// </summary>
public class AdHoc {
	/// <summary>
	/// Gets or sets the level array.
	/// </summary>
	/// <value>The level array</value>
	public int[,,] levelArr {get;set;}
	/// <summary>
	/// The section array.
	/// </summary>
	private int[,,] my3DArr;
	/// <summary>
	/// The length and depth of a section.
	/// </summary>
	private int length;
	/// <summary>
	/// The height of the arrays.
	/// </summary>
	private int height;
	/// <summary>
	/// The number of sections.
	/// </summary>
	private int sectNum;
	/// <summary>
	/// Current line of text read from file.
	/// </summary>
	private string line;
	/// <summary>
	/// Copy of the whole textfile.
	/// </summary>
	private string longLine;
	/// <summary>
	/// Array holding each line of text.
	/// </summary>
	private string[] lines;
	/// <summary>
	/// Textfiles are loaded as TextAssets for conversion to string.
	/// </summary>
	private TextAsset[] sects = new TextAsset[16];

	/// <summary>
	/// Initializes a new instance of the <see cref="AdHoc"/> class.
	/// </summary>
	/// <param name="l">The section length and depth.</param>
	/// <param name="h">The height of the arrays.</param>
	/// <param name="sn">The number of sections</param>
	public AdHoc(int l, int h, int sn) {
		length = l;
		height = h;
		sectNum = sn;
		lines = new string[length];
		my3DArr = new int[length,length,height];
		levelArr = new int[sectNum,sectNum,height];
	}

	/// <summary>
	/// Places a section within the level array.
	/// </summary>
	/// <param name="i">The first start index.</param>
	/// <param name="j">The second start index.</param>
	private void placeSection(int i, int j) {		
		for(int x = 0; x < 8; x++) {				
			for( int z = 0; z < 8; z++) {
				for(int y = 0; y < 16; y++) {
					levelArr[x+(i*8),z+(j*8),y] = my3DArr[x,z,y]; 
				}
			}
			
		}
	}

	/// <summary>
	/// Gets a section from the Resources folder. Converts it from 16 TextFiles of 8 rows of 8 characters to a 16x8x8 integer array.
	/// </summary>
	/// <param name="s">String of datapath to a section folder.</param>
	private void getSection(string s) {
		for(int i = 0; i < 16; i++) {
			sects[i] = (TextAsset)Resources.Load(s + i, typeof(TextAsset)); //load current TextFile in to TextAsset array
			longLine = sects[i].text; //convert i'th TextFile to string
			string[] myLines = longLine.Split('\n'); //split by carriage return in to 8 row string array 
			for(int j = 0; j < 8; j++) {
				line = myLines[j]; //current row in string array
				for(int k = 0; k < 8; k++) {
					for (int num = 0; num < 8; num++) {
						lines [num] = Convert.ToString (line [k]); //convert current row from a string to a string array for integer conversion later
					}
					my3DArr [j, k, i] = Convert.ToInt32 (lines [k]); //convert string at index k to integer and copy it to section array
				}

			}
		}
	}

	/// <summary>
	/// Adds randomisation to a section's floor and ceiling by placing extra cells above or below live cells using random number generation and probability. 
	/// </summary>
	/// <param name="s">Type of section.</param>
	private void randomiseSection(string s) {
		float prob;
		string section = s;
		//set probability dependent on type of section
		if(section == "wall") {
			prob = 0.05f;
		} else if (section == "interior") {
			prob = 0.2f;
		} else {
			prob = 0f;
		}			
		for(int x = 0; x < 8; x++) {				
			for( int z = 0; z < 8; z++) {
				for(int y = 0; y < 16; y++) {
				if(y-1 >= 0 && y < 4)  {
					//if random value less than probabilty place a live cell above a "floor" cell
					if (UnityEngine.Random.value < prob){								
							if (my3DArr[x,z,y-1] == 1) my3DArr[x,z,y] = 1;								
					}
				} else if(y+1 <= 15 && y >= 8) {
					//if random value less than probabilty place a live cell below a "ceiling" cell
					if (UnityEngine.Random.value < prob){								
						if (my3DArr[x,z,y+1] == 1) my3DArr[x,z,y] = 1;								
					}
				}

				} 
			}			
		}
	}

	/// <summary>
	/// Places the corner sections.
	/// </summary>
	public void placeCorners() {
		//Top left
		getSection(@"Level Files/Corners/CornersTL/corner0/cornerTL");
		placeSection(0,0);
		//Top right
		getSection ( @"Level Files/Corners/CornersTR/corner0/cornerTR");
		placeSection(0,7);
		//Bottom left
		getSection (@"Level Files/Corners/CornersBL/corner0/cornerBL");
		placeSection(7,0);
		//Bottom right
		getSection (@"Level Files/Corners/CornersBR/corner0/cornerBR");
		placeSection(7,7);
	}

	/// <summary>
	/// Places the wall sections.
	/// </summary>
	public void placeWalls() {
		string section = "wall";
		//top
		getSection (@"Level Files/Walls/WallsT/wall0/wallT");
		for (int i = 1; i < 7; i++) {
			randomiseSection(section);
			placeSection(0,i);
		}
		//right
		getSection (@"Level Files/Walls/WallsR/wall0/wallR");
		for (int i = 1; i < 7; i++) {
			randomiseSection(section);
			placeSection(i,7);
		}
		//bottom
		getSection (@"Level Files/Walls/WallsB/wall0/wallB");
		for (int i = 1; i < 7; i++) {
			randomiseSection(section);
			placeSection(7,i);
		}
		//left
		getSection (@"Level Files/Walls/WallsL/wall0/wallL");
		for (int i = 1; i < 7; i++) {
			randomiseSection(section);
			placeSection(i,0);
		}
	}

	/// <summary>
	/// Places the interior sections.
	/// </summary>
	public void placeInteriors() {
		string section = "interior";
		for (int i = 1; i < 7; i++) {
			for (int j = 1; j < 7; j++) {
				int rand = UnityEngine.Random.Range(0,5); //randomly choose an interior section from the available templates
				getSection (@"Level Files/Interiors/interior" + rand + @"/interior");
				randomiseSection(section);
				placeSection(i,j);
			}
		}
	}

}
