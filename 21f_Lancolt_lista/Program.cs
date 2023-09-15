using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _21f_Lancolt_lista
{
	internal class Program
	{

		class Lancolt_lista
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

				public void Torol()
				{
					this.kovetkezo.
				}
			}

			private Elem fejelem;
			public int Count;

			public Lancolt_lista()
			{
				fejelem = new Elem();
				Count = 0;
			}

			private Elem Utolso_elem()
			{
				return fejelem.elozo;
			}

			public void Add(int tartalom)
			{
				Elem elem = new Elem(Utolso_elem(), tartalom);
				Count++;
			}

			public int First()
			{
				if (Count==0)
				{
					throw new IndexOutOfRangeException();
				}
				return fejelem.kovetkezo.tartalom;
			}
			public int Last()
			{
				if (Count == 0)
				{
					throw new IndexOutOfRangeException();
				}
				return fejelem.elozo.tartalom;
			}

			public int Element_at(int n)
			{

				if (Count <= n)
				{
					throw new IndexOutOfRangeException();
				}

				Elem aktelem = fejelem.kovetkezo;

				for (int i = 0; i < n; i++)
				{
					aktelem = aktelem.kovetkezo;
				}

				return aktelem.tartalom;
				
			}

			public void Kiir()
			{
				Elem aktelem = fejelem.kovetkezo;
				for (int i = 0; i < Count; i++)
				{
                    Console.WriteLine(aktelem.tartalom);
					aktelem = aktelem.kovetkezo;
                }
			}

			public void RemoveAt(int n)
			{
				if (Count <= n)
				{
					throw new IndexOutOfRangeException();
				}

				Elem aktelem = fejelem.kovetkezo;

				for (int i = 0; i < n; i++)
				{
					aktelem = aktelem.kovetkezo;
				}
				aktelem.Torol();
				Count--;
			}

			public void Remove_goofy(int t)
			{
				Elem aktelem = fejelem.kovetkezo;

				for (int i = 0; i < Count; i++)
				{
					aktelem = aktelem.kovetkezo;
					if (aktelem.tartalom == t)
					{
						aktelem.Torol();
						Count--;
						return;
					}
				}
			}

			public void Remove(int t)
			{
				Elem aktelem = fejelem.kovetkezo;

				while (aktelem != fejelem && aktelem.tartalom != t)
				{
					aktelem = aktelem.kovetkezo;
				}
				aktelem.Torol();
				Count--;
			}

			public void RemoveAll(int t)
			{
				Elem aktelem = fejelem.kovetkezo;

				for (int i = 0; i < Count; i++)
				{
					if (aktelem.tartalom == t)
					{
						aktelem.Torol();
						Count--;
					}

					aktelem = aktelem.kovetkezo;
				}
			}
		}



		static void Main(string[] args)
		{
			Lancolt_lista lista	 = new Lancolt_lista();
			lista.Add(5);
			lista.Add(3);
			lista.Add(2);
			lista.Add(7);
			Console.WriteLine(lista.First());
			Console.WriteLine(lista.Last());
            Console.WriteLine(lista.Element_at(2)); // 2

			lista.RemoveAt(3);
			lista.Remove(7); // az első 7-es tartalmat, amit találsz, távolítsd el
			lista.RemoveAll(2); // az összes 7-es tartalmat távolítsd el!
			// A következőhöz vissza kell tenni a using System.Collections.Generic-et!
			List<int> regi_lista = new List<int> { 5, 7, 2, 3, 4, 5, 6, 7, 7,9};
			Lancolt_lista ujlista = new Lancolt_lista(regi_lista); // tehát kell írni egy olyan konstruktort, ami egy létező lista alapján feltölti a láncolt listát!
			Console.WriteLine(ujlista.Sum());
			Console.WriteLine(ujlista.Max());
			Console.WriteLine(ujlista.Min());

			Console.WriteLine("-----------------");
			lista.Kiir();
        }
	}
}
