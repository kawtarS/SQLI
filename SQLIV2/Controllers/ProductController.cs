using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLIV2.InventaireData;
using SQLIV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SQLIV2.Controllers
{
    [Route("inventory/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductData _Data;

        public ProductController(IProductData Data) //inject the IData that im adding to the services dependency injection
        {
            _Data = Data;

        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_Data.GetProducts()); //Creates an OkObjectResult object that produces an Status200OK response

        }

        [HttpGet("{barcode}")]
        public IActionResult GetProduct(int barcode)
        {
            var product = _Data.GetProduct(barcode);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound($"product with :{barcode} was not found");
        }
        [HttpGet("{discount}")]//recupérer tt les element supérieur 
        public IActionResult GetProductSup(int discount)
        {
            var product = _Data.GetProductSup(discount);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();//jai pas pu envoyer un tableeau vide
        }
        [HttpGet("{category}")]
        public IActionResult GetProductByCategory(String category)
        {
            var product = _Data.GetProductsByCategory(category);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound($"products with :{category} was not found");
        }
        [HttpGet("{name}")]
        public IActionResult GetByName(String name)
        {
            var product = _Data.GetByName(name);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound($"products with :{name} was not found");
        }

        [HttpGet("{price}")]//•	Trier tous les articles en fonction du prix par ordre décroissant 
        public IActionResult GetProductdecroissant()
        {
            return Ok(_Data.GetProductdecroissant());



        }
        [HttpPost]//•	Ajout d'un nouvel élément 
        public IActionResult GetProduct([FromBody] Product epr)
        {
            _Data.AddProduct(epr);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + epr.barcode, epr);
        }

        [HttpDelete("{barcode}")]//•	Suppression de tout élément par code-barres 
        public HttpStatusCode DeleteProduct(int barcode)
        {
            var produit = _Data.GetProduct(barcode);
            if (produit != null)
            {
                _Data.DeleteProduct(produit);
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.NoContent;
        }

       [HttpPut("{barcode}")]//•	Modification de l'article 
         public IActionResult UpdateProduct(int barcode, [FromBody] Product epr)
         {
             var existintproduit = _Data.GetProduct(barcode);
             if (existintproduit != null)
             {
                epr.barcode = existintproduit.barcode;
                 _Data.EditProduct(epr);
                return NoContent();//La réponse HTTP doit être 204

            }

            return NotFound();//La réponse HTTP doit être 404.

        }


    }
}
