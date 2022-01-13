using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Fantacalcio
{
    class Campionato
    {
        List<int> puntiCamp = new List<int>();              //dichiaro una lista per i punti del campionato
        List<int> indVinCamp = new List<int>();             //dichiaro una lista per individuare i punti di una squadra 
        List<string> nomiSquadre = new List<string>();      //dichiaro una lista con i n0mi delle squadre 
        private int nPartecipanti;                          //dichiaro il numero dei partecipanti
        public Campionato(List<int> puntiCamp, int nPartecipanti, List<string> nomiSquadre)     //costruttore a cui passo partecipanti, punti e nomi delle squadre
        {
            this.puntiCamp = puntiCamp;                     //istanza punti
            this.nPartecipanti = nPartecipanti;             //istanza partecipanti
            this.nomiSquadre = nomiSquadre;                 //istanza nomi squadre
        }

        public string controlloVincitoreCampionato()        //metodo per trovare il vincitore
        {
            string k;                                       //dichiaro stringa che ritornerà la funzione
            double vincitore = puntiCamp[0];                //dichiaro una variabile vincitore che avrà il numero di punti più aòto
            for (int i = 0; i < nPartecipanti; i++)          //ciclo per trovare il punteggio più alto
            {
                if (vincitore < puntiCamp[i])                //if per trovare il valore del vincitore
                {
                    vincitore = puntiCamp[i];               //se un elemento di puntiCamp è maggiore del vincitore, lo sostituisce
                }
            }
            for (int i = 0; i < nPartecipanti; i++)          //ciclo per la posizione del vincitore
            {
                if (vincitore == puntiCamp[i])               //se il vincitore è uguale all'elemento di puntiCamp in quella posizione,
                {
                    indVinCamp.Add(i);                      //allora lo aggiungo nella lista delle posizioni 
                }
            }
            if (indVinCamp.Count > 1)                        //se i vincitori sono più di uno
            {
                k = "I vincitori del campionato sono: ";    //inizializzo k con questa frase
                foreach (int a in indVinCamp)               //e cercando gli elementi nella lista IndVinCamp
                {
                    k += $"{nomiSquadre[a]}, ";             //stampo i nomi delle squadre vincitrici
                }
            }
            else                                            //oppure
            {
                k = "Il vincitore del campionato è: ";      //inizializzo k con questa frase
                foreach (int a in indVinCamp)               //per ogni indirizzo in indVinCamp
                {
                    k += $"{nomiSquadre[a]}";               //stampo il nome della squadra vincitrice
                }

            }
            return k;                                       //ritorno k che contiene il vincitore o i vincitori
        }
    }
    class Partite
    {
        private int nPartecipanti;                                          //dichiaro variabile con il numero dei partecipanti
        List<double> punteggioSquadreGiornata = new List<double>();         //lista con i punteggi delle squadre in quella giornata
        List<double> golSquadreGiornata = new List<double>();               //lista con i gol delle squadre nella giornata
        List<string> nomiSquadre = new List<string>();                      //lista nomi squadre
        List<string> vincitori = new List<string>();                        //lista vincitori della giornata
        List<int> indVin = new List<int>();                                 //lista indirizzi vincitori
        List<int> puntiCamp = new List<int>();                              //lista dei punteggi del campionato
        public Partite(int nPartecipanti)                                   //costruttore a cui passo il numero dei partecipanti
        {
            this.nPartecipanti = nPartecipanti;                             //istanza partecipanti
        }
        public void inserimentoPunteggiSquadraGiornata(List<double> punteggioSquadreGiornata)                   //metodo inserimento dei punti della giornata
        {
            this.punteggioSquadreGiornata = punteggioSquadreGiornata;                                           //istanza punti giotnata
        }
        public string calcoloGolGiornata(List<double> punteggioSquadreGiornata, List<string> nomiSquadre)       //metodo per calcolare i gol effettuati
        {
            this.nomiSquadre = nomiSquadre;                                 //istanza nomi squadre
            string g = "";                                                  //creo stringa che ritornerà la funzione
            int j = 0;                                                      //creo indice per i nomi delle squadre
            for (int i = 0; i < nPartecipanti; i++)                          //ciclo per calcolare i punti
            {
                double x = 0;                                               //dichiaro variabile che assumerà il valore dei gol fatti
                if (punteggioSquadreGiornata[i] < 66)                       //guardo che il punteggio non sia minore di 66
                {
                    x = 0;                                                  //in quel caso il punteggio sarà 0 
                }
                else                                                        //se è maggiore di 66
                {
                    punteggioSquadreGiornata[i] -= 66;                      //tolgo 66 dal totale dei punti 
                    while (punteggioSquadreGiornata[i] >= 0)                //così controllando che non vada sotto lo 0
                    {
                        punteggioSquadreGiornata[i] -= 6;                   //tolgo 6 ad ogni ripetizione del ciclo
                        x++;                                                //implementando così la variabile che definisce i gol 
                    }
                }
                golSquadreGiornata.Add(x);                                  //aggiungo il valore dei gol alla lista dei gol totalizzati dalle squadre
            }
            foreach (double gol in golSquadreGiornata)                      //per ogni gol contenuto nella lista dei gol
            {
                g += $"la squadra {nomiSquadre[j]} questa giornata ha fatto {gol} gol\n";       //implemento la stringa che stamperà i gol fatti dalla rispettiva squadra
                j++;                                                        //implemento l'indice della lista dei nomi delel squadre
            }
            return g;                                                       //ritorno la stringa g
        }
        public string controlloVincitoreGiornata()              //metodo che controlla il vincitore della giornata
        {
            string k;                                           //stringa che ritornerà la funzione
            double vincitore = golSquadreGiornata[0];           //dichiaro il vincitore
            for (int i = 0; i < nPartecipanti; i++)              //ciclo che analizza tutti gli elementi contenuti nella lista dei gol fatti dalle squadre
            {
                if (vincitore < golSquadreGiornata[i])           //se un elemento è maggiore del vincitore
                {
                    vincitore = golSquadreGiornata[i];          //esso diventa il vincitore
                }
            }
            for (int i = 0; i < nPartecipanti; i++)              //ciclo per la posizione del vincitore
            {
                if (vincitore == golSquadreGiornata[i])          //se il vincitore si trova in quel posto
                {
                    indVin.Add(i);                              //memorizzo la sua posizione nella lista delle posizioni
                }
            }
            if (indVin.Count > 1)                                //se trovo più di una posizione dei vincitore
            {
                k = "I vincitori della giornata sono: ";        //stampo questa frase
                foreach (int a in indVin)                       //e per ogni indce contenuto nella lista
                {
                    k += $"{nomiSquadre[a]}, ";                 //stampo il nome delle squadre vincitrici
                }
            }
            else                                                //se c'è un solo vincitore
            {
                k = "Il vincitore della giornata è: ";          //stamp questa frase
                foreach (int a in indVin)                       //e prendendo l'indice
                {
                    k += $"{nomiSquadre[a]}";                   //stampo il nome della squadra
                }

            }
            return k;                                           //ritorno la stringa k
        }
        public void puntiCampionato(List<int> puntiCamp)        //metodo per trovare i punti in campionato
        {
            for (int i = 0; i < nPartecipanti; i++)              //ciclo che analizza ogni squadra
            {
                puntiCamp.Add(0);                               //e inizializza i suoi punti a 0
            }
            foreach (int a in indVin)                           //per ogni indice delle squadre vincitrici
            {
                puntiCamp[a] += 3;                              //aggiungo 3 punti in campionato alla rispettiva squadra
            }
        }
    }
    class Squadre
    {
        private int nPartecipanti;                                          //numero dei partecipanti
        List<string> nomiSquadre = new List<string>();                      //lista con i nomi delle squadre
        List<string> nomiGiocatori = new List<string>();                    //lista con i nomi dei giocatori
        List<int> prezzi = new List<int>();                                 //lista con i prezzi dei giocatori

        public Squadre(int nPartecipanti)                                   //costruttore a cui passo il numero dei partecipanti
        {
            this.nPartecipanti = nPartecipanti;                             //istanza partecipanti
        }
        public void inserimentoSquadre(List<string> nomiSquadre)            //metodo per inserire i nomi delle squadre
        {
            this.nomiSquadre = nomiSquadre;                                 //istanza nomi squadre
        }
        public void inserimentoGiocatori(List<string> nomiGiocatori, List<int> prezzi)      //metodo per inserire i nomi dei giocatori e i loro prezzi
        {
            this.nomiGiocatori = nomiGiocatori;             //istanza nomi giocatori
            this.prezzi = prezzi;                           //istanza prezzi
        }
        public string toStringSquadre()                     //metodo per stampare i nomi delle squadre
        {
            string s = "";                                  //inizializzo stringa
            foreach (string nome in nomiSquadre)            //per ogni nome delle squadre
            {
                s += $"{nome}\n";                           //lo aggiungo alla stringa
            }
            return s;                                       //ritorno stringa s
        }
    }
    class MainClass
    {
        static void Main(string[] args)
        {
            //SQUADRE

            int nPartecipanti;                                          //dichiaro numero partecipanti                          scritta fantacalcio in ascii
            bool controllo;                                             //dichiaro variabile per controllo                                |
            List<string> nomiSquadre = new List<string>();              //lista nomi delle squadre                                        |
            List<string> nomiGiocatori = new List<string>();            //lista nomi giocatori                                            V
            List<int> prezzi = new List<int>();                         //lista prezzi
            Console.WriteLine("\n███████╗░█████╗░███╗░░██╗████████╗░█████╗░░█████╗░░█████╗░██╗░░░░░░█████╗░██╗░█████╗░\n██╔════╝██╔══██╗████╗░██║╚══██╔══╝██╔══██╗██╔══██╗██╔══██╗██║░░░░░██╔══██╗██║██╔══██╗\n█████╗░░███████║██╔██╗██║░░░██║░░░███████║██║░░╚═╝███████║██║░░░░░██║░░╚═╝██║██║░░██║\n██╔══╝░░██╔══██║██║╚████║░░░██║░░░██╔══██║██║░░██╗██╔══██║██║░░░░░██║░░██╗██║██║░░██║\n██║░░░░░██║░░██║██║░╚███║░░░██║░░░██║░░██║╚█████╔╝██║░░██║███████╗╚█████╔╝██║╚█████╔╝\n╚═╝░░░░░╚═╝░░╚═╝╚═╝░░╚══╝░░░╚═╝░░░╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝╚══════╝░╚════╝░╚═╝░╚════╝░");
            Thread.Sleep(3500);                                         //thread per far comparire le scritte dopo 3,5 secondi
            Console.WriteLine("Inserisci il numero delle squadre partecipanti");        //istruzione
            do                                                                           //do while per il controllo dell'inserimento
            {
                Console.WriteLine("Deve essere pari e maggiore di 1");                   //del numero dei partecipanti
                string np = Convert.ToString(Console.ReadLine());                        //scrivo il valore in una stringa
                controllo = int.TryParse(np, out nPartecipanti);                         //che verrà convertita in int
            } while (!controllo || nPartecipanti < 2 || nPartecipanti % 2 != 0);         //se sarà un numero intero, pari e maggiore di 2
            Squadre c = new Squadre(nPartecipanti);                                      //inizializzo costruttore
            for (int i = 0; i < nPartecipanti; i++)                                      //ciclo per inserire i nomi delle squadre
            {
                Console.WriteLine("Inserisci il nome della squadra {0}\n", i + 1);       //istruzione
                string nome;                                                             //inizializzo variabile nome
                nome = Convert.ToString(Console.ReadLine());                             //e la inserisco
                nomiSquadre.Add(nome);                                                   //aggiungendola alla lista dei nomi delle squadre
                Console.WriteLine("Inserisci i nomi dei giocatori e il loro relativo prezzo");  //istruzione
                for (int j = 0; j < 11; j++)                                              //ciclo per inserire nomi giocatori e prezzo
                {
                    Console.WriteLine($"inserisci il nome del {j + 1} giocatore\n");     //istruzione
                    string nomeGiocatore = Convert.ToString(Console.ReadLine());         //inserisco stringa per i nomi dei giocatori
                    Console.WriteLine($"\ninserisci il prezzo del {j + 1} giocatore\n");    //istruzione
                    int prezzo = Convert.ToInt32(Console.ReadLine());                    // inserisco prezzo
                    nomiGiocatori.Add(nomeGiocatore);                                       //aggiungo il nome alla lista dei nomi
                    prezzi.Add(prezzo);                                                     //aggiungo il prezzo alla lista dei prezzi
                }
                c.inserimentoGiocatori(nomiGiocatori, prezzi);                              //passo al metodo di inserimento nomi e prezzi
                Console.Clear();                                                            //pulisco l'interfaccia
            }
            c.inserimentoSquadre(nomiSquadre);                                              //passo al metodo di inserimento nomi squadre
            Console.WriteLine($"Le squadre sono:\n{c.toStringSquadre()}\n");                //stampo i nomi delle squadre
            int k = 0;                                                                      //inizializzo variabile indice
            for (int i = 0; i < nPartecipanti; i++)                                         //ciclo per stampare giocatori e prezzi
            {
                Console.WriteLine($"\nI giocatori della squadra {nomiSquadre[i]} sono: \n");    //scritta a video
                int x = 0;                                                                      //indice che permettere di "assegnare" una squadra ai giocatori quando vengono stampati
                do
                {
                    x++;                                                                    //implemento l'indice di 1
                    Console.WriteLine($"{nomiGiocatori[k]}, {prezzi[k]}");                  //stampo nome e prezzo
                    k++;                                                                    //implemento l'indice
                } while (x < 11);                                                            //ripeto fino a quando con cambia squadra
            }

            List<int> puntiCamp = new List<int>();                                       //lista dei punti in campionato
            int cnt = 0;                                                                    //contatore per il ciclo
            while (cnt == 0)                                                                 //per giocare altre giornate
            {

                //PARTITE

                bool controllo2;                                                            //dichiaro controllo di inserimento variabile
                int nGiornate;                                                              //dichiaro numero giornate
                double golBonus, assistBonus, gialloMalus, rossoMalus, autogolMalus;        //dichiaro i bonus e malus
                List<double> punteggioSquadreGiornata = new List<double>();                 //dichiaro lista punteggi della giornata
                List<double> golSquadreGiornata = new List<double>();                       //dichiaro lista gol fatti 

                nGiornate = (nPartecipanti * 2) - 2;                                        //calcolo il numero delle giornate
                Partite c2 = new Partite(nPartecipanti);                                    //passo al cotruttore il numero dei partecipanti

                for (int i = 0; i < nPartecipanti; i++)                                     //ciclo per inserimento bonus o malus
                {
                    Console.WriteLine($"\nQuanti gol hanno fatto i giocatori di {nomiSquadre[i]} questa giornata?");
                    golBonus = Convert.ToDouble(Console.ReadLine());            //inserisco gol
                    Console.WriteLine($"Quanti assist hanno fatto i giocatori di {nomiSquadre[i]} questa giornata?");
                    assistBonus = Convert.ToDouble(Console.ReadLine());         //inserisco assist
                    Console.WriteLine($"Quanti cartellini gialli hanno preso i giocatori di {nomiSquadre[i]} questa giornata?");
                    gialloMalus = Convert.ToDouble(Console.ReadLine());         //inserisco gialli
                    Console.WriteLine($"Quanti cartellini rossi hanno preso i giocatori di {nomiSquadre[i]} questa giornata?");
                    rossoMalus = Convert.ToDouble(Console.ReadLine());          //inserisco rossi
                    Console.WriteLine($"Quanti autogol hanno fatto i giocatori di {nomiSquadre[i]} questa giornata?");
                    autogolMalus = Convert.ToDouble(Console.ReadLine());        //inserisco autogol
                    double punteggioGiornata;                                   //inizializzo punteggi
                    punteggioGiornata = 66 + (golBonus * 3) + assistBonus - (gialloMalus / 2) - rossoMalus - (autogolMalus * 3);        //calcolo punteggio con i bonus
                    punteggioSquadreGiornata.Add(punteggioGiornata);                //aggiungo il punteggio alla lista
                    Console.Clear();            //pulisco l'interfaccia
                }
                c2.inserimentoPunteggiSquadraGiornata(punteggioSquadreGiornata);        //chiamo il metodo per inserire i punteggi

                for (int i = 0; i < nPartecipanti; i++)         //ciclo per stampare il punteggio
                {
                    Console.WriteLine($"Il punteggio della squadra {nomiSquadre[i]} in questa giornata è: {punteggioSquadreGiornata[i]}");      //stampo nome della squadra e punteggio
                }

                Console.WriteLine($"\n{c2.calcoloGolGiornata(punteggioSquadreGiornata, nomiSquadre)}\n");       //chiamo il calcolo dei gol e li stampo

                Console.WriteLine($"\n{c2.controlloVincitoreGiornata()}\n");        //chiamo il metodo per decretare il vincitore della giornata

                c2.puntiCampionato(puntiCamp);              //calcolo i punti in campionato
                for (int i = 0; i < nPartecipanti; i++)      //ciclo per aggiungere i punti del campionato alla lista
                {
                    puntiCamp.Add(puntiCamp[i]);        //aggiungo i punti alla lista
                }

                Console.WriteLine("Vuoi continuare a giocare o vedere il vincitore?");          //chiedo se si vuole continuare con un'altra giornata o no
                do
                {
                    Console.WriteLine("Digita 0 se vuoi continuare, digita 1 se vuoi fermarti e vedere il vincitore del campionato."); //se si vole continuare bisogna scrivere 0
                    string s = Convert.ToString(Console.ReadLine());        //controllo perchè
                    controllo2 = int.TryParse(s, out cnt);      //il valore inserito
                } while (!controllo2 && cnt != 1 && cnt != 0);      //sia 0 o 1
            }

            //VINCITORE CAMPIONATO

            Campionato c3 = new Campionato(puntiCamp, nPartecipanti, nomiSquadre);      //passo al costruttore punti, partecipanti e squadre

            Console.WriteLine($"\n{c3.controlloVincitoreCampionato()}\n");      //decreto e stampo il vincitore del campionato

            Console.ReadKey();
        }
    }
}