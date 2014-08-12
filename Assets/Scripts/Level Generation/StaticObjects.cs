using UnityEngine;
using System.Collections;

/// <summary>
/// Created when initial plans for the project included backtracking between levels without them being recreated as static objects are not destroyed between scene transitions.
/// <para>Levels are held as static 3D integer arrays of 0s and 1s.</para>
/// </summary>
public static class StaticObjects {
	/// <summary>
	/// Gets or sets the cellular automata terrain.
	/// </summary>
	/// <value>The CA terrain.</value>
	public static int[,,] terrain{get;set;}
	/// <summary>
	/// Gets or sets the perlin noise terrain.
	/// </summary>
	/// <value>The perlin noise terrain.</value>
	public static int[,] pnTerrain{get;set;}
	/// <summary>
	/// Gets or sets the celluar automata cave.
	/// </summary>
	/// <value>The CA cave.</value>
	public static int[,,] cave{get;set;}
	/// <summary>
	/// Gets or sets the ad-hoc cave.
	/// </summary>
	/// <value>The ad-hoc cave.</value>
	public static int[,,] ahCave{get;set;}
	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="StaticObjects"/> cellular automata terrain built.
	/// </summary>
	/// <value><c>true</c> if CA terrain built; otherwise, <c>false</c>.</value>
	public static bool terrainBuilt {get;set;}
	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="StaticObjects"/> perlin noise terrain built.
	/// </summary>
	/// <value><c>true</c> if PN terrain built; otherwise, <c>false</c>.</value>
	public static bool pnTBuilt {get;set;}
	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="StaticObjects"/> cellular automata cave built.
	/// </summary>
	/// <value><c>true</c> if CA cave built; otherwise, <c>false</c>.</value>
	public static bool caveBuilt {get;set;}
	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="StaticObjects"/> ad-hoc cave built.
	/// </summary>
	/// <value><c>true</c> if ad-hoc cave built; otherwise, <c>false</c>.</value>
	public static bool cahBuilt {get;set;}
	/// <summary>
	/// Gets or sets the length of the tele.
	/// </summary>
	/// <value>The length of the tele.</value>
	//public static float teleLength {get;set;}
}
