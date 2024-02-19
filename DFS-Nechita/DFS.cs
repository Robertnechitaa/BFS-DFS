using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS_Nechita
{
    internal class DFS
    {
        private int vertici;
        private List<int>[] nodi;

        public DFS( int vertici )
        {
            this.vertici = vertici;
            nodi = new List <int> [vertici];

            for ( int i = 0; i < vertici; ++i )
            {
                nodi[i] = new List <int> ();
            }
        }

        public void AggiungiArco ( int nodoPadre, int nodoFiglio )
        {
            nodi[nodoPadre].Add( nodoFiglio );
        }

        public void DepthFirstSearch( int nodoPartenza, string sequenza )
        {
            bool[] nodiVisitati = new bool[vertici];

            if ( sequenza == "PreOrdine" )
                DFSPreOrdine( nodoPartenza, nodiVisitati );

            else if ( sequenza == "InOrdine" )
                DFSInOrdine( nodoPartenza, nodiVisitati );

            else if ( sequenza == "PostOrdine" )
                DFSPostOrdine( nodoPartenza, nodiVisitati );

            else
                throw new Exception( "Sequenza non supportata" );

        }

        private void DFSPreOrdine( int nodoCorrente, bool[] nodiVisitati )
        {
            nodiVisitati[nodoCorrente] = true;
            Console.WriteLine( nodoCorrente + " " );

            foreach ( int prossimoNodo in nodi[nodoCorrente] )
            {
                if ( !nodiVisitati[prossimoNodo] )
                {
                    DFSPreOrdine( prossimoNodo, nodiVisitati );
                }
            }
        }

        private void DFSInOrdine( int nodoCorrente, bool[] nodiVisitati )
        {
            nodiVisitati[nodoCorrente] = true;

            if ( nodi[nodoCorrente].Count > 0 )
            {
                DFSInOrdine( nodi[nodoCorrente][0], nodiVisitati );
                Console.WriteLine( nodoCorrente + " " );

                if ( nodi[nodoCorrente].Count > 1 )
                    DFSInOrdine( nodi[nodoCorrente][1], nodiVisitati );
            }

            else
                Console.WriteLine( nodoCorrente + " " );

        }

        private void DFSPostOrdine( int nodoCorrente, bool[] nodiVisitati )
        {
            nodiVisitati[nodoCorrente] = true;

            foreach ( int prossimoNodo in nodi[nodoCorrente] )
            {
                if ( !nodiVisitati[prossimoNodo] )
                    DFSPostOrdine( prossimoNodo, nodiVisitati );
            }

            Console.WriteLine( nodoCorrente + " " );
        }
    }
}
