using System;
using System.Text;
using System.Threading.Tasks;

namespace _21f_Lancolt_lista
{
	internal class Program
	{

		class Elem
		{
			public Elem elozo;
			public int tartalom;
			public Elem kovetkezo;

			public Elem(Elem elozo, int tartalom, Elem kovetkezo)
			{
				this.elozo = elozo;
				this.tartalom = tartalom;
				this.kovetkezo = kovetkezo;
			}

			/// <summary>
			/// ez a konstruktor az, amely a fejelemet hozza létre!
			/// </summary>
			public Elem()
			{
				this.elozo = this;
				this.kovetkezo = this;
			}
			/// <summary>
			/// Ez a konstruktor fűz hozzá egy elemhez egy másikat.
			/// </summary>
			public Elem(Elem kijelolt, int tartalom)
			{
				this.tartalom = tartalom;
				Elem új = this;
				új.elozo = kijelolt;
				új.kovetkezo = kijelolt.kovetkezo;
				kijelolt.kovetkezo.elozo = új;
				kijelolt.kovetkezo = új;
			}


		}

		static void Main(string[] args)
		{

			Elem fejelem = new Elem();
			Elem egyik = new Elem(fejelem, 5);
			Elem masik = new Elem(fejelem, 7);
		}
	}
}
