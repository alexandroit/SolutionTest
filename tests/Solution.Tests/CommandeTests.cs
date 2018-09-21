using Soluction.Domain.Entites;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Solution.Tests
{
    public class CommandeTests
    {
        public CommandeTests()
        {
            Produits = new List<Produit>(){
                new Produit("Ordinateur IBM", 900.1M),
                new Produit("Ordinateur HP",   1000.1M),
                new Produit("Ordinateur ASUS", 800.1M),
                new Produit("Ordinateur APPLE", 1500.1M),
            };
        }

        #region attributes
        public  IList<Produit> Produits { get; private set; }
        #endregion

        [Fact]
        public void CommandeValid()
        {
            var commande = new Commande();
            foreach (var p in Produits)
            {
                commande.AjouterProduit(p);
            }

            commande.AppliquerCouponRabais("HP", 1);
            Assert.True(commande.Valid);
        }

        [Fact]
        public void CommandeQuantiteRabais()
        {
            var commande = new Commande();
            foreach (var p in Produits)
            {
                commande.AjouterProduit(p);
            }
            commande.AppliquerCouponRabais("HP", 1);
            Assert.True(commande.ProduitRabais.Count() == 1);
        }

        //Vérifier que les méthodes Totales
        [Fact] 
        public void CommandeVerifierTotales()
        {
            var commande = new Commande();
            foreach (var p in Produits)
            {
                commande.AjouterProduit(p);
            }
            commande.AppliquerCouponRabais("HP", 1);

            var totalAvecRebais = commande.getTotalAvecCouponRabais();
            var total = commande.getTotal();
            Assert.True(total > totalAvecRebais);
        }
    }
}
