using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificaLabInfo4F
{
    class Treni
    {
        public int codtreno;
        public string tipo;
        public string nome;
        public double costo;
        public Treni(int codtreno, string tipo, string nome, double costo)
        {
            this.codtreno = codtreno;
            this.tipo = tipo;
            this.nome = nome;
            this.costo = costo;
        }
        public virtual double CostoMezzo()      //metodo che ritorna il prezzo generico di un treno
        {
            return 100000;
        }
        public virtual double CostoUtilizzo(double km)      //metodo che ritorna i km percorsi
        {
            return km;
        }
        public virtual double CostoTot(double km)       //metodo che somma il costo del mezzo al costo dell'utilizzo per trovare il costo totale
        {
            return CostoMezzo() + CostoUtilizzo(km);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci il numero di km percorsi dal treno Passeggeri");       //inserisco il numero dei km percorsi dal Passeggeri
            double kmP = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Inserisci il numero di km percorsi dal treno Merci");        //inserisco il numero dei km percorsi dal Merci
            double kmM = Convert.ToDouble(Console.ReadLine());
            Passeggeri p = new Passeggeri(1, "Regionale", "Passeggeri", 150, 10, "benzina");        //Inserisco i parametri dei treni richiesti dal metodo costruttore
            Merci m = new Merci(2, "Nazionale", "Merci", 100, 20, "gasolio" );
            Console.WriteLine($"Il treno {p.nome} ha un prezzo di {p.CostoMezzo()} euro, ha percorso {kmP}km spendendo {p.CostoUtilizzo(kmP)} euro e in totale è costato {p.CostoTot(kmP)} euro.");
            Console.WriteLine($"Il treno {m.nome} ha un prezzo di {m.CostoMezzo()} euro, ha percorso {kmM}km spendendo {m.CostoUtilizzo(kmM)} euro e in totale è costato {m.CostoTot(kmM)} euro.");
            Console.ReadKey();
        }
    }
    class Passeggeri : Treni
    {
        public int numvagoni;
        public string alimentazione;
        public Passeggeri(int codtreno, string tipo, string nome, double costo, int numvagoni, string alimentazione) : base(codtreno, tipo, nome, costo)
        {
            this.codtreno = codtreno;
            this.tipo = tipo;
            this.nome = nome;
            this.costo = costo;
            this.numvagoni = numvagoni;
            this.alimentazione = alimentazione;
        }
        public override double CostoMezzo()     //prendendo il prezzo generico lo moltiplico per la percentuale di aumento del prezzo
        {
            return base.CostoMezzo() * 1.25;
        }
        public override double CostoUtilizzo(double km)     //prendendo il numero di km, lo moltiplico per il prezzo per ogni km percorso
        {
            return base.CostoUtilizzo(km) * 150;
        }
        public override double CostoTot(double km)      //riciamo il metodo per calcolare il costo totale
        {
            return base.CostoTot(km);
        }

    }
    class Merci : Treni
    {
        public int numvagoni;
        public string alimentazione;
        public Merci(int codtreno, string tipo, string nome, double costo, int numvagoni, string alimentazione) : base(codtreno, tipo, nome, costo)
        {
            this.codtreno = codtreno;
            this.tipo = tipo;
            this.nome = nome;
            this.costo = costo;
            this.numvagoni = numvagoni;
            this.alimentazione = alimentazione;
        }
        public override double CostoMezzo()     //prendendo il prezzo generico lo moltiplico per la percentuale di aumento del prezzo
        {
            return base.CostoMezzo() * 1.35;
        }
        public override double CostoUtilizzo(double km)     //prendendo il numero di km, lo moltiplico per il prezzo per ogni km percorso
        {
            return base.CostoUtilizzo(km) * 100;
        }
        public override double CostoTot(double km)      //riciamo il metodo per calcolare il costo totale
        {
            return base.CostoTot(km);
        }

    }
}
