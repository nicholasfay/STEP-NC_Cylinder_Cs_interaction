using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Cylinder
{

    class CylinTest
    {
	static void Main(string[] args)
	{
        // Create a trivial STEP-NC file
	STEPNCLib.Finder Find = new STEPNCLib.Finder();
        string file = "v14_IMTS_HARDMOLDY.stpnc";

        Find.Open238(file);

        long wp_id = Find.GetMainWorkplan();
        long tl_count = Find.GetWorkplanToolCount(wp_id);

        Console.WriteLine("There are {0} tools", tl_count);

        for (int I = 0; I < tl_count; I++)
        {
            long tl_id = Find.GetWorkplanToolNext(wp_id,I);
            Boolean has_diam;
            Boolean has_length;
            Boolean has_radius;
            double tl_diam = Find.GetToolDiameter(tl_id, out has_diam);
            double tl_length = Find.GetToolLength(tl_id, out has_length);
            double tl_rad = Find.GetToolCornerRadius(tl_id, out has_radius);
            Console.WriteLine("Tool with tool id: {0} has diameter {1} and length {2} and radius {3}", tl_id, tl_diam, tl_length, tl_rad);
        }
        Console.ReadLine();
	}
    }
}