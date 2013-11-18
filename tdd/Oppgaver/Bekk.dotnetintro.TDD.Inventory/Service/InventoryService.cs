using System;
using System.Collections.Generic;
using ExcelExport;
using Repository;

namespace Service
{
    public class InventoryService
    {
        private readonly InventoryRepository _inventoryRepository;
         
        public InventoryService()
        {
            _inventoryRepository = new InventoryRepository();
        }

        public List<int> GetProducts()
        {
            return _inventoryRepository.GetAllProductIds();
        }

        public List<int> GetProductsToOrder()
        {
            //Bruk _inventoryRepository.GetAllProductIds() til å hente ut alle produkter. 
            //Hent deretter ut antall av hvert produkt med _inventoryRepository.GetNumberOfProductItems. 
            //Returner produkt-idene som har mindre enn 100 varer tilgjengelig

            throw new NotImplementedException();
        }

        public string GetNameOfProduct(int productId, int maxNumberOfLetters)
        {
            // Varenavnet vises ulike steder i applikasjonen, og ikke alle stedene er det nok tilgjengelig plass til å vise hele navnet.
            // Dersom maxNumbersOfLetters er <= 0 skal hele navnet vises, ellers kun angitt antall tegn av navnet.
            // Navnet skal alltid vises med STORE BOKSTAVER

            throw new NotImplementedException();
        }

        public void UpdateProductInventory(int productId, int amountOfNewProductItems)
        {
            //Når nye varer leveres til butikken må antallet lagres. Man kan kun sette totalt antall varer for et produkt
            //Hent antall varer for ett produkt og oppdater dette med antall nye varer
            //Dersom et produkt ikke er registert i databasen skal det kastes en feil.
            throw new NotImplementedException();
        }

        public bool SellProductItem(int productId)
        {
            //Når en vare skal selges må beholdningen oppdater. 
            //Sjekk at det finnes minst en vare igjen.
            //Oppdater lagerbeholdningen
            //Dersom produktet var tilgjengelig og beholdning oppdatert, returner true.
            throw new NotImplementedException();
        }

        public void CreateInventoryReport()
        {
            //Butikken lagrer jevnlig rapporter over varebeholdningen. Til dette bruker de en tredjepartskomponent (ExcelExport.dll)
            //Hvordan kan denne testes når det ikke er et interface tilgjengelig?

            //Oppgave: Kall Save metopden med alle produkter med id, navn og antall
            //Test at filnavn har dagens dato og at Save blir kalt med riktig parametere

            var report = new ExcelInventoryReport(DateTime.Now.ToString("yyyy-MM-dd"));
            report.Save(new List<ReportLine>
                        {
                            new ReportLine
                            {
                                Id = 0,
                                Name = string.Empty,
                                Amount = 0
                            }
                        });
        }
    }
}
