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

		class Lancolt_lista<S>
		{
			class Elem<T>
			{
				public Elem<T> elozo;
				public T tartalom;
				public Elem<T> kovetkezo;

				public Elem(Elem<T> elozo, T tartalom, Elem<T> kovetkezo)
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
				public Elem(Elem<T> kijelolt, T tartalom)
				{
					this.tartalom = tartalom;
					Elem<T> új = this;
					új.elozo = kijelolt;
					új.kovetkezo = kijelolt.kovetkezo;
					kijelolt.kovetkezo.elozo = új;
					kijelolt.kovetkezo = új;
				}

				public void Torol()
				{
					this.kovetkezo.elozo = this.elozo;
					this.elozo.kovetkezo = this.kovetkezo;
				}
			}

			private Elem<S> fejelem;
			public int Count;

			public Lancolt_lista()
			{
				fejelem = new Elem<S>();
				Count = 0;
			}

			private Elem<S> Utolso_elem()
			{
				return fejelem.elozo;
			}

			public void Add(S tartalom)
			{
				Elem<S> elem = new Elem<S>(Utolso_elem(), tartalom);
				Count++;
			}

			public S First()
			{
				if (Count==0)
				{
					throw new IndexOutOfRangeException();
				}
				return fejelem.kovetkezo.tartalom;
			}
			public S Last()
			{
				if (Count == 0)
				{
					throw new IndexOutOfRangeException();
				}
				return fejelem.elozo.tartalom;
			}

			public S Element_at(int n)
			{

				if (Count <= n)
				{
					throw new IndexOutOfRangeException();
				}

				Elem<S> aktelem = fejelem.kovetkezo;

				for (int i = 0; i < n; i++)
				{
					aktelem = aktelem.kovetkezo;
				}

				return aktelem.tartalom;
			}

			/// <summary>
			/// kicsit erőltett vizualizációja a lista belső szerkezetének.
			/// </summary>
			public void Diagnosztika()
			{
				Console.WriteLine("-----------------");
				Console.WriteLine($"Count: {Count}");
				Console.WriteLine($"Elemek:");
				Elem<S> aktelem = fejelem.kovetkezo;
				for (int i = 0; i < Count; i++)
				{
                    Console.WriteLine($"{(aktelem.elozo==fejelem?"FEJELEM": aktelem.elozo.tartalom.ToString())} -> {aktelem.tartalom.ToString()} -> {(aktelem.kovetkezo == fejelem ? "FEJELEM" : aktelem.kovetkezo.tartalom.ToString())}");
					aktelem = aktelem.kovetkezo;
                }
				Console.WriteLine("-----------------");
			}

			public void RemoveAt(int n)
			{
				if (Count <= n)
				{
					throw new IndexOutOfRangeException();
				}

				Elem<S> aktelem = fejelem.kovetkezo;

				for (int i = 0; i < n; i++)
				{
					aktelem = aktelem.kovetkezo;
				}
				aktelem.Torol();
				Count--;
			}

			public void Remove(S t)
			{
				Elem<S> aktelem = fejelem.kovetkezo;

				while (aktelem != fejelem && !aktelem.tartalom.Equals(t))
				{
					aktelem = aktelem.kovetkezo;
				}
				aktelem.Torol();
				Count--;
			}

			public void RemoveAll(S t)
			{
				Elem<S> aktelem = fejelem.kovetkezo;

				while (aktelem!= fejelem)
				{
					if (aktelem.tartalom.Equals(t))
					{
						aktelem.Torol();
						Count--;
					}
					aktelem = aktelem.kovetkezo;
				}
			}

			public override string ToString()
			{
				string s = "[";

				Elem<S> aktelem = fejelem.kovetkezo;
				for (int i = 0; i < Count - 1; i++)
				{
					s += $" {aktelem.tartalom},";
					aktelem = aktelem.kovetkezo;
				}
				if (0 < Count)
				{
					s += $" {aktelem.tartalom}";
				}
				s += " ]";
				return s;  // [2, 5, 8, 9, 10, ... ]
			}

			public S Max(Func<S, S, int> rendezesi_szempont)  // comparator: rendezesi_szempont(A,B) == -1, ha "A<B"
			{
				// itt tartottunk

				// Na hogy kellett ezt?
				// Emlékszünk?
				// tegnapi dolgok? táblán? Excalidraw?
				// :(
			}
		}



		static void Main(string[] args)
		{
			Lancolt_lista<int> lista = new Lancolt_lista<int>();
			lista.Add(2);
			lista.Add(5);
			lista.Add(3);
			lista.Add(2);
			lista.Add(7);
			lista.Add(2);
			lista.Add(2);
			lista.Add(2);
			lista.Add(2);
			//Console.WriteLine(lista.First());
			//Console.WriteLine(lista.Last());
            //Console.WriteLine(lista.Element_at(2)); // 2

			//lista.RemoveAt(3);
			//lista.Remove(7); // az első 7-es tartalmat, amit találsz, távolítsd el
			
			lista.RemoveAll(2); // az összes 7-es tartalmat távolítsd el!
			// A következőhöz vissza kell tenni a using System.Collections.Generic-et!

			List<int> regi_lista = new List<int> { 5, 7, 2, 3, 4, 5, 6, 7, 7,9};
            //Lancolt_lista ujlista = new Lancolt_lista(regi_lista); // tehát kell írni egy olyan konstruktort, ami egy létező lista alapján feltölti a láncolt listát!
            //Console.WriteLine(ujlista.Sum());
            //Console.WriteLine(ujlista.Max());
            //Console.WriteLine(ujlista.Min());

            Console.WriteLine(lista); // [ 5, 3, 7 ]

            Console.WriteLine("-----------------");

			lista.Diagnosztika();
        }
	}
}
