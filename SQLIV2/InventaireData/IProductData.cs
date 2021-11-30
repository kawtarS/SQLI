using SQLIV2.Model;
using System;
using System.Collections.Generic;

using System.Linq;
namespace SQLIV2.InventaireData
{
    public interface IProductData //service to fetch data 
    {
        //•	Obtenir tous les éléments 
        List<Product> GetProducts();
        
       
        //•	Ajout d'un nouvel élément 
        Product AddProduct(Product product);

        //•	Suppression de tout élément par code-barres 
        void DeleteProduct(Product product);
        
        //•	Obtenir un article par code-barres 

        Product GetProduct(int barcode);
        
        // •	Obtenir tous les éléments de la catégorie
          List<Product> GetProductsByCategory(string category);
         

        //•	Obtenir tous les articles supérieurs à une valeur de remise particulière 
        List<Product> GetProductSup(int discount);
            
        //•	Trier tous les articles en fonction du prix par ordre décroissant -
        List<Product> GetProductdecroissant();
        //•	Obtenir un élément par nom
        Product GetByName(string name);

        //•	Modification de l'article 
       Product EditProduct(Product product);
    }
}
