using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolletta
{
    public class Elettrico
    {
        //stufa elettrica
        //pompa di calore di buon livello
        //pompa di calore economica
        public int costoInstallazione;
        public double rendimento;
        public Elettrico(double rendimento, int costoInstallazione)
        {

        }
    }
    public class StufaElettrica : Elettrico
    {
        public StufaElettrica(double rendimento, int costoInstallazione) : base(rendimento, costoInstallazione)
        {
            this.rendimento = rendimento;
            this.costoInstallazione = costoInstallazione;
        }
        public double CalcoloStufa(double consumoEnergia)
        {
            return ((consumoEnergia / rendimento) * 0.3 + costoInstallazione + 213);
        }
    }
    public class PompaDiCaloreBuonLivello : Elettrico
    {
        public PompaDiCaloreBuonLivello(double rendimento, int costoInstallazione) : base(rendimento, costoInstallazione)
        {
            this.rendimento = rendimento;
            this.costoInstallazione = costoInstallazione;
        }
        public double CalcoloPompaB(double consumoEnergia)
        {
            return ((consumoEnergia / rendimento) * 0.3 + costoInstallazione + 213);
        }
    }
    public class PompaDiCaloreEconomica : Elettrico
    {
        public PompaDiCaloreEconomica(double rendimento, int costoInstallazione) : base(rendimento, costoInstallazione)
        {
            this.rendimento = rendimento;
            this.costoInstallazione = costoInstallazione;
        }
        public double CalcoloPompaE(double consumoEnergia)
        {
            return ((consumoEnergia / rendimento) * 0.3 + costoInstallazione + 213);
        }
    }
    public class Gas
    {
        //caldaia a condensazione
        //caldaia tradizionale
        public int costoInstallazione;
        public double rendimento;
        public Gas(double rendimento, int costoInstallazione)
        {

        }
    }
    public class CaldaiaACondensazione : Gas
    {
        public CaldaiaACondensazione(double rendimento, int costoInstallazione) : base(rendimento, costoInstallazione)
        {
            this.rendimento = rendimento;
            this.costoInstallazione = costoInstallazione;
        }
        public double CalcoloCaldaiaAC(double consumoGas)
        {
            return ((consumoGas / rendimento) * 0.5 + costoInstallazione + 213);
        }
    }
    public class CaldaiaTradizionale : Gas
    {
        public CaldaiaTradizionale(double rendimento, int costoInstallazione) : base(rendimento, costoInstallazione)
        {
            this.rendimento = rendimento;
            this.costoInstallazione = costoInstallazione;
        }
        public double CalcoloCaldaiaT(double consumoGas)
        {
            return ((consumoGas / rendimento) * 0.5 + costoInstallazione + 213);
        }
    }
    class Program
    {
        static double ConsumoGas(double consumo)
        {
            return (consumo / 10.7);
        }
        static double ConsumoElettricita(double consumo)
        {
            return (consumo * 10.7);
        }
        static void Main(string[] args)
        {
            bool controllo;
            int scelta = 0;
            double consumoE;
            double consumoG;
            double bollettaStufa;
            double bollettaPompaB;
            double bollettaPompaE;
            double bollettaCaldaiaC;
            double bollettaCaldaiaT;
            
            StufaElettrica stufa = new StufaElettrica(1, 0);     //(rendimento del metodo di riscaldamento, costo installazione)
            PompaDiCaloreBuonLivello pompaB = new PompaDiCaloreBuonLivello(3.6, 3000);
            PompaDiCaloreEconomica pompaE = new PompaDiCaloreEconomica(2.8, 1000);
            CaldaiaACondensazione caldaiaC = new CaldaiaACondensazione(1, 0);
            CaldaiaTradizionale caldaiaT = new CaldaiaTradizionale(0.9, 0);
   
            do
            {
                Console.WriteLine("Qual'è il tuo metodo di riscaldamento?\n Premi i seguenti tasti per selezionarlo\n" +
                              " 1 --> stufa elettrica\n" +
                              " 2 --> pompa di calore di buon livello\n" +
                              " 3 --> pompa di calore economica\n" +
                              " 4 --> caldaia a condesazione\n" +
                              " 5 --> caldaia tradizionale\n");
                string s = Convert.ToString(Console.ReadLine());
                controllo = int.TryParse(s, out scelta);
                Console.Clear();
            } while (!controllo || scelta < 1 || scelta > 5);

            if (scelta < 4 && scelta > 0)
            {
                do
                {
                    string e;
                    Console.WriteLine("Quanti kWh di energia elettrica consumi?\n");
                    e = Convert.ToString(Console.ReadLine());
                    controllo = double.TryParse(e, out consumoE);
                } while (!controllo || consumoE <= 0);

                consumoG = ConsumoGas(consumoE);

                switch (scelta)
                {
                    case 1:

                        bollettaStufa = stufa.CalcoloStufa(consumoE);
                        Console.WriteLine("Il costo della bolletta attuale è di: {0}\n", bollettaStufa);

                        bollettaPompaB = pompaB.CalcoloPompaB(consumoE);
                        bollettaPompaE = pompaE.CalcoloPompaE(consumoE);
                        bollettaCaldaiaC = caldaiaC.CalcoloCaldaiaAC(consumoG);
                        bollettaCaldaiaT = caldaiaT.CalcoloCaldaiaT(consumoG);

                        Console.WriteLine("Il costo della bolletta con una pompa di calore di buon livello (compresa installazione) è di: {0}", bollettaPompaB);
                        Console.WriteLine("Il costo della bolletta con una pompa di calore economica (compresa installazione) è di: {0}", bollettaPompaE);
                        Console.WriteLine("Il costo della bolletta con una caldaia a condensazione è di: {0}", bollettaCaldaiaC);
                        Console.WriteLine("Il costo della bolletta con una caldaia tradizionale è di: {0}", bollettaCaldaiaT);

                        break;
                    case 2:

                        bollettaPompaB = pompaB.CalcoloPompaB(consumoE);
                        Console.WriteLine("Il costo della bolletta attuale è di: {0}\n", (bollettaPompaB - 3000));

                        bollettaStufa = stufa.CalcoloStufa(consumoE);
                        bollettaPompaE = pompaE.CalcoloPompaE(consumoE);
                        bollettaCaldaiaC = caldaiaC.CalcoloCaldaiaAC(consumoG);
                        bollettaCaldaiaT = caldaiaT.CalcoloCaldaiaT(consumoG);

                        Console.WriteLine("Il costo della bolletta con una stufa elettrica è di: {0}", bollettaStufa);
                        Console.WriteLine("Il costo della bolletta con una pompa di calore economica (compresa installazione di 1000) è di: {0}", bollettaPompaE);
                        Console.WriteLine("Il costo della bolletta con una caldaia a condensazione è di: {0}", bollettaCaldaiaC);
                        Console.WriteLine("Il costo della bolletta con una caldaia tradizionale è di: {0}", bollettaCaldaiaT);

                        break;
                    case 3:

                        bollettaPompaE = pompaE.CalcoloPompaE(consumoE);
                        Console.WriteLine("Il costo della bolletta attuale è di: {0}\n", (bollettaPompaE - 1000));

                        bollettaStufa = stufa.CalcoloStufa(consumoE);
                        bollettaPompaB = pompaB.CalcoloPompaB(consumoE);
                        bollettaCaldaiaC = caldaiaC.CalcoloCaldaiaAC(consumoG);
                        bollettaCaldaiaT = caldaiaT.CalcoloCaldaiaT(consumoG);

                        Console.WriteLine("Il costo della bolletta con una stufa elettrica è di: {0}", bollettaStufa);
                        Console.WriteLine("Il costo della bolletta con una pompa di calore di buon livello (compresa installazione di 3000 euro) è di: {0}", bollettaPompaB);
                        Console.WriteLine("Il costo della bolletta con una caldaia a condensazione è di: {0}", bollettaCaldaiaC);
                        Console.WriteLine("Il costo della bolletta con una caldaia tradizionale è di: {0}", bollettaCaldaiaT);

                        break;
                }
            }
            else
            {
                do
                {
                    string g;
                    Console.WriteLine("Quanti smc di gas consumi?\n");
                    g = Convert.ToString(Console.ReadLine());
                    controllo = double.TryParse(g, out consumoG);
                } while (!controllo || consumoG <= 0);

                consumoE = ConsumoElettricita(consumoG);

                switch (scelta)
                {
                    case 4:

                        bollettaCaldaiaC = caldaiaC.CalcoloCaldaiaAC(consumoG);
                        Console.WriteLine("Il costo della bolletta attuale è di: {0}\n", bollettaCaldaiaC);

                        bollettaStufa = stufa.CalcoloStufa(consumoE);
                        bollettaPompaB = pompaB.CalcoloPompaB(consumoE);
                        bollettaPompaE = pompaE.CalcoloPompaE(consumoE);
                        bollettaCaldaiaT = caldaiaT.CalcoloCaldaiaT(consumoG);

                        Console.WriteLine("Il costo della bolletta con una stufa elettrica è di: {0}", bollettaStufa);
                        Console.WriteLine("Il costo della bolletta con una pompa di calore di buon livello (compresa installazione) è di: {0}", bollettaPompaB);
                        Console.WriteLine("Il costo della bolletta con una pompa di calore economica (compresa installazione) è di: {0}", bollettaPompaE);
                        Console.WriteLine("Il costo della bolletta con una caldaia tradizionale è di: {0}", bollettaCaldaiaT);

                        break;
                    case 5:

                        bollettaCaldaiaT = caldaiaT.CalcoloCaldaiaT(consumoG);
                        Console.WriteLine("Il costo della bolletta attuale è di: {0}\n", bollettaCaldaiaT);

                        bollettaStufa = stufa.CalcoloStufa(consumoE);
                        bollettaPompaB = pompaB.CalcoloPompaB(consumoE);
                        bollettaPompaE = pompaE.CalcoloPompaE(consumoE);
                        bollettaCaldaiaC = caldaiaC.CalcoloCaldaiaAC(consumoG);

                        Console.WriteLine("Il costo della bolletta con una stufa elettrica è di: {0}", bollettaStufa);
                        Console.WriteLine("Il costo della bolletta con una pompa di calore di buon livello (compresa installazione) è di: {0}", bollettaPompaB);
                        Console.WriteLine("Il costo della bolletta con una pompa di calore economica (compresa installazione) è di: {0}", bollettaPompaE);
                        Console.WriteLine("Il costo della bolletta con una caldaia a condensazione è di: {0}", bollettaCaldaiaC);

                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
