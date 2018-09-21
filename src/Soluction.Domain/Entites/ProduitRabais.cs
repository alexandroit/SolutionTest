using FluentValidator.Validation;
using System;

namespace Soluction.Domain.Entites
{
    public class ProduitRabais : BaseEntitie
    {
        #region ctor
        public ProduitRabais(Produit produit, decimal rabais)
        {
            Produit = produit;
            Rabais = rabais;
            DateRabais = DateTime.Now;
            //Validate
            var contracts = new ValidationContract()
               .Requires()
               .IsTrue(IsBetween(), "Rabais", Ressource.Domain.POURCENTAGE_RABAIS_INVALIDE);
            AddNotifications(contracts);
        }
        #endregion

        #region attributes
        public Produit Produit { get; private set; }
        public decimal Rabais { get; private set; }
        public DateTime DateRabais { get; private set; }
        #endregion

        #region methods
        public decimal PrixRabais() =>
                Produit.Prix * (Rabais / 100);
        #endregion

        #region validation
        private bool IsBetween() =>
            Rabais >= 1 && Rabais <= 100;
        #endregion
    }
}
