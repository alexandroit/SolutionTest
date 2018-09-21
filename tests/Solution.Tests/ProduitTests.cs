using Soluction.Domain.Entites;
using Xunit;

namespace Solution.Tests
{
    public class ProduitTests
    {
        [Fact]
        public void ProduitValid()
        {
            var produit = new Produit("Ordinateur IBM", 999.99M);
            Assert.True(produit.Valid);
        }

        [Fact]
        public void ProduitSansNom()
        {
            var produit = new Produit("", 999.99M);
            Assert.False(produit.Valid);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ProduitPrixInvalid(decimal prix)
        {
            var produit = new Produit("Ordinateur IBM", prix);
            Assert.False(produit.Valid);
        }
    }
}
