using Soluction.Domain.Entites;
using Xunit;

namespace Solution.Tests
{
    public class ProduitRabaisTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(99)]
        [InlineData(100)]
        public void ProduitRabaisValid(decimal rebais)
        {
            decimal prix = 999.99M;
            var produit = new Produit("Ordinateur IBM", prix);
            var produitRabais = new ProduitRabais(produit, rebais);

            Assert.True(produitRabais.Valid);
        }

        [Theory]
        [InlineData(0.9)]
        [InlineData(101)]
        public void ProduitRabaisInValid(decimal rebais)
        {
            decimal prix = 999.99M;
            var produit = new Produit("Ordinateur IBM", prix);
            var produitRabais = new ProduitRabais(produit, rebais);

            Assert.False(produitRabais.Valid);
        }

        [Fact]
        public void ProduitRabaisVerifie()
        {
            decimal prix = 999.99M;
            decimal rebais = 5.1M;            
            var produit = new Produit("Ordinateur IBM", prix);
            var produitRabais = new ProduitRabais(produit, rebais);
            //applique rebais
            var prixRabais = produitRabais.PrixRabais();
            //matematique inverse pour valider
            var calc = prixRabais / rebais * 100;
            var result = prix == calc;
            Assert.True(result);
        }
    }
}
