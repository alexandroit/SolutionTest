using FluentValidator.Validation;
using System.Collections.Generic;
using System.Linq;

namespace Soluction.Domain.Entites
{
    public class Commande : BaseEntitie
    {
        #region ctor
        public Commande()
        {
            Produits = new List<Produit>();
            ProduitRabais = new List<ProduitRabais>();
        }
        #endregion

        #region attributes
        public IList<Produit> Produits { get; private set; }
        public IList<ProduitRabais> ProduitRabais { get; private set; }
        #endregion

        #region methods

        public decimal getTotal() =>
                Produits.Sum(t => t.Prix);
        //Rabais
        public decimal getTotalAvecCouponRabais() =>
                Produits.Sum(t => t.Prix) - ProduitRabais.Sum(t=> t.PrixRabais());
        
        public void AjouterProduit(Produit produit)
        {
            if(produit.Valid)
                Produits.Add(produit);
        }

        public void AppliquerCouponRabais(string nom, decimal pourcentageRabais)
        {           
         
            var produits = Produits.Where(p => p.Nom.Contains(nom)).ToList();
            foreach (var produit in produits)
            {
                var produitRebais = new ProduitRabais(produit, pourcentageRabais);
                if (produitRebais.Valid)
                     ProduitRabais.Add(produitRebais);
            }
        }
    #endregion
    }
}
