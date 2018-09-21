using FluentValidator.Validation;

namespace Soluction.Domain.Entites
{
    public class Produit : BaseEntitie
    {
        public Produit(string nom, decimal prix)
        {
            Nom = nom;
            Prix = prix;
            //Validations
            var contracts = new ValidationContract()
               .Requires()
               .HasMinLen(Nom, 3, "Nom", Ressource.Domain.NOM_MIN )
               .HasMaxLen(Nom, 100, "Nom", Ressource.Domain.NOM_MAX);

            AddNotifications(contracts);
            if (Prix <= 0)
                AddNotification("Prix", Ressource.Domain.LE_PRIX_NE_PEUT_ETRE_INFERIEUR_A_ZERO);
        }

        public string Nom { get; private set; }
        public decimal Prix { get; private set; }
        public decimal Rabais { get; private set; }
    }
}
