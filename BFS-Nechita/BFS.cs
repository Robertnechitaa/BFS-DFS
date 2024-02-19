using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_Nechita
{
    internal class BFS
    {
        private int vertici;
        private List <int> [] nodi;

        public BFS ( int vertici )
        {
            this.vertici = vertici;
            nodi = new List <int> [vertici];

            for (int i = 0; i < vertici; ++i)
            {
                nodi [i] = new List <int> ();
            }
        }

        public void AggiungiArco ( int nodoPadre, int nodoFiglio )
        {
            nodi [nodoPadre].Add( nodoFiglio );
        }

        public void BreadthFirstSearch(int nodoPartenza)
        {
            bool [] nodiVisitati = new bool [vertici];

            List <int> coda = new List <int> ();

            nodiVisitati [nodoPartenza] = true;
            coda.Add( nodoPartenza );

            while ( coda.Count != 0 )
            {
                int nodoCorrente = coda[0];
                coda.RemoveAt( 0 );

                Console.Write( nodoCorrente + " " );

                foreach ( int prossimoNodo in nodi[nodoCorrente] )
                {
                    if ( !nodiVisitati[prossimoNodo] )
                    {
                        nodiVisitati[prossimoNodo] = true;
                        coda.Add( prossimoNodo );
                    }
                }
            }
        }
    }
}
