using UnityEngine;
using System.Collections;
using System.IO;


public class LevelReader {
	private int counter = 0;
	private string line;
	public int[,,] caveArr{get;set;}


	private StreamReader file;

	public LevelReader() { 
		file = new StreamReader(@"C:\Users\Dan\Documents\Uni\Year Three\Final Project\Unity\Final Project\Assets\Level Files\Corners\corner0.txt");
	}

	public void displayTxts() {
		while((line = file.ReadLine()) != null)
		{
			Debug.Log(line);
			counter++;
		}
		file.Close();
	}

}
